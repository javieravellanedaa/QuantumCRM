using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using INTERFACES;


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
                // revisar este if
            if (SingletonSesion.Instancia.IsLogged())
            {
                throw new Exception("Ya hay una sesión iniciada");
            }

            var user = ((DAL.UsuarioDAL)_crud).Login(email, password);

            if (user == null) throw new LoginException(LoginResult.InvalidUsername);

            // buscar los permisos del usuario en la dal 

            List<Patente> permisos = _crud.GetPermisos(user);
            foreach (var item in permisos)
            {
                user.Permisos.Add(item);
            }

            SingletonSesion.Instancia.Login(user);


            new MP_PERMISO ().FillUserComponents(user); // dudoso
            return LoginResult.ValidUser;
        } //revisar metodo dudoso

        public void Logout()
        {
            if (!SingletonSesion.Instancia.IsLogged())
            {
                throw new Exception("No hay sesión iniciada");
            }

            SingletonSesion.Instancia.Logout();
        }


        public List<Usuario> GetAll()
        {
            return _crud.GetAll(); // aca cambie a _crud en vez de usuarios
        }

        public void GuardarPermisos(Usuario u)
        {
            _crud.GuardarPermisos(u);
        }

    }
}
