﻿using SERVICIOS;
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
        BitacoraBLL _bitacoraBLL;
        ControlDeCambiosBLL _controlDeCambiosBLL;
        public UsuarioBLL()
        {
            _crud = new UsuarioDAL();
            _bitacoraBLL = new BitacoraBLL();
            _controlDeCambiosBLL = new ControlDeCambiosBLL ();
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
            _bitacoraBLL.RegistrarEntrada(usuario.Id, usuario.NombreUsuario, "UsuarioBLL", "Login");
      
            
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

        /// <summary>
        /// Verifica si un usuario con el ID especificado existe en la base de datos.
        /// </summary>
        public bool UsuarioExiste(Guid usuarioId)
        {
            try
            {
                return _crud.ExisteUsuario(usuarioId);
            }
            catch
            {
                return false;
            }
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

        public List<Usuario> ListarUsuariosConRolClienteNoRegistrados()
        {
            // Retorna los usuarios con rol_id = 2 que NO están en la tabla Cliente
            return _crud.ObtenerUsuariosConRolClienteNoRegistrados();
        }


        public List<Usuario> ObtenerCandidatosParaTecnico()
        {
            
            return _crud.ObtenerUsuariosDisponiblesParaTecnico();
        }

        public List<Usuario> ObtenerCandidatosParaAdministrador()
        {

            return _crud.ObtenerUsuariosDisponiblesParaAdministrador();
        }

        public void CrearUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            usuario.Id = Guid.NewGuid();
            usuario.FechaAlta = DateTime.Now;

            //// Si no se especifica idioma, podrías asignar un valor por defecto:
            //if (usuario.Idioma == null)
            //    usuario.Idioma = new Idioma { Id = '37C99BDE-5A59-48E2-96D3-971D578F4815' };



            _crud.Save(usuario);
            _controlDeCambiosBLL.RegistrarCambios<BE.Usuario>(null, usuario);
            var mgr = new BLL.DigitVerifier.DigitVerifierManager();
            mgr.RecalcularDVDeTabla("Usuario");
        }
    }
}
