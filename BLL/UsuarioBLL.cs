using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using INTERFACES;
using System.Xml;

namespace BLL
{
    public class UsuarioBLL : AbstractBLL<BE.Usuario>
    {
        UsuarioDAL _crud;
        public UsuarioBLL()
        {
            _crud = new UsuarioDAL();
        }

        public LoginResult Login(string email, string password)
        {
            if (SingletonSesion.Instancia.Sesion.IsLogged())
            {
                throw new Exception("Ya hay una sesión iniciada");
            }

            // Autenticar al usuario y obtener su ID
            Usuario usuario = ((DAL.UsuarioDAL)_crud).Login(email, password);

            if (usuario == null) throw new LoginException(LoginResult.InvalidUsername);

            if (usuario.Roles.Count == 0)
            {
                throw new LoginException(LoginResult.NoRolesAssigned);
            }

            SingletonSesion.Instancia.Sesion.Login(usuario);

            return LoginResult.ValidUser;
        }

        public void Logout()
        {
            if (!SingletonSesion.Instancia.Sesion.IsLogged())
            {
                throw new Exception("No hay sesión iniciada");
            }

            SingletonSesion.Instancia.Sesion.Logout();
        }
        public void CambiarRol(Guid usuarioId, int rolId)
        {
            Usuario usuario = ((DAL.UsuarioDAL)_crud).CambiarDeRol(usuarioId, rolId);

            if (usuario.Id == Guid.Empty) throw new LoginException(LoginResult.InvalidUsername);

            if (usuario.Roles.Count == 0)
            {
                throw new LoginException(LoginResult.NoRolesAssigned);
            }

            SingletonSesion.Instancia.Sesion.Login(usuario);


        }


        public void GuardarPermisos(Usuario u)
        {
            _crud.GuardarPermisos(u);
        }

        public List<Usuario> ListarTodosLosUsuarios()
        {
            return _crud.ListarUsuariosConTodosLosAtributos();
        }

        public List<Usuario> ObtenerlistaDeUsuarios()
        {
            return _crud.ObtenerlistaDeUsuarios();
        }

        public List<Rol> ObtenerRolesPorUsuario(Guid usuarioId)
        {
            List<Rol> Roles = _crud.ObtenerRolesPorUsuario(usuarioId);
            return Roles;
        }

        // Método para asignar un permiso (rol) a un usuario.
        public bool AsignarPermiso(Guid usuarioId, int permisoId)
        {
            try
            {
                // Obtener el usuario con todos sus atributos (incluyendo roles)
                var usuario = ListarTodosLosUsuarios().FirstOrDefault(u => u.Id == usuarioId);
                if (usuario == null)
                    throw new Exception("Usuario no encontrado.");

                // Verificar si el usuario ya posee el permiso
                if (usuario.Roles.Any(r => r.Id == permisoId))
                    throw new Exception("El usuario ya posee el permiso asignado.");

                // Obtener el permiso (rol) a través de PermisoBLL
                PermisoBLL permisoBLL = new PermisoBLL();
                var permiso = permisoBLL.GetAllFamilias().FirstOrDefault(p => p.Id == permisoId);
                if (permiso == null)
                    throw new Exception("Permiso no encontrado.");

                
                usuario.Permisos.Add(permiso);
                
                //// Guardar los permisos actualizados
                GuardarPermisos(usuario);

                return true;
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o lanzar la excepción según sea necesario.
                return false;
            }
        }
    }
}
