using System;
using System.Collections.Generic;
using BE;
using INTERFACES;

namespace SERVICIOS
{
    public class Sesion:Entity
    {
        // Usuario autenticado
        private BE.Usuario _user { get; set; }

        // Idioma actual del usuario
        private IIdioma _idioma;


        // Lista de observadores para cambios de idioma


        // Propiedad para obtener el idioma actual
        public IIdioma Idioma => _idioma;

        // Propiedad para obtener el usuario actual
        public Usuario Usuario => _user;

        public Cliente ObtenerCliente() 
        {
            BE.Cliente cliente = new Cliente();
            cliente.Nombre = _user.Nombre;
            cliente.NombreDeLosRoles = _user.NombreDeLosRoles;
            cliente.Roles = _user.Roles;
           
            return cliente;
        }

        public Tecnico ObtenerTecnico()
        {
            return _user as Tecnico;
        } 

        public Administrador ObtenerAdministrador()
        {
            return _user as Administrador;
        }


        // Lógica para iniciar sesión
        public void Login(BE.Usuario usuario)
        {
            _user = usuario;

            // Notificar a los observadores de idioma al iniciar sesión
          
        }
        public void CambiarIdioma(IIdioma idioma)
        {
            _idioma = idioma;
            if (_user != null)
            {
                _user.Idioma = idioma;
            }
            // Notificar a los observadores del cambio de idioma
        
        }


        // Lógica para cerrar sesión
        public void Logout()
        {
         
            _user = null;
        }

        // Verificar si hay un usuario autenticado
        public bool IsLogged()
        {
            return _user != null;
        }


        // Lógica para verificar roles y permisos
        private bool IsInRoleRecursivo(BE.Composite.Componente p, int id_permiso, bool valid)
        {
            foreach (var item in p.Hijos)
            {
                // Recorro la familia Nivel por Nivel
                if (item.Id == id_permiso)
                {
                    valid = true;
                    break;
                }
                else
                {
                    valid = IsInRoleRecursivo(item, id_permiso, valid);
                }
            }
            return valid;
        }

        public bool IsInRole(int id_permiso)
        {
            if (_user == null) return false;

            bool valid = false;
            foreach (var p in _user.Permisos)
            {
                // Valido si es Patente o Familia
                if (p.Id == id_permiso)
                {
                    valid = true;
                    break;
                }
                else
                {
                    valid = IsInRoleRecursivo(p, id_permiso, valid);
                }
            }

            return valid;
        }
    }
}
