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

            if (usuario.Id == Guid.Empty) throw new LoginException(LoginResult.InvalidUsername);

 

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


        public List<Usuario> GetAll()
        {
            return _crud.GetAll(); 
        }

        public void GuardarPermisos(Usuario u)
        {
            _crud.GuardarPermisos(u);
        }

        public List<Usuario> ListarTodosLosUsuarios()
        {

            return _crud.ListarUsuariosConTodosLosAtributos();
        }

    }
}
