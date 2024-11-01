using System;
using System.Collections.Generic;
using BE;
using INTERFACES;

namespace SERVICIOS
{
    public class Sesion
    {
        // Usuario autenticado
        private BE.Usuario _user { get; set; }

        // Idioma actual del usuario
        private IIdioma _idioma;


        // Lista de observadores para cambios de idioma
        private static readonly IList<IIdiomaObserver> _idiomaObservers = new List<IIdiomaObserver>();

        // Instancia de EventManager para gestionar eventos genéricos
        private static readonly EventManagerService _eventManager = new EventManagerService();

        // Propiedad para obtener el idioma actual
        public IIdioma Idioma => _idioma;

        // Propiedad para obtener el usuario actual
        public IUsuario Usuario => _user;

        // Métodos para gestionar observadores de idioma
        public void SuscribirObservador(IIdiomaObserver observer)
        {
            _idiomaObservers.Add(observer);
        }

        public void DesuscribirObservador(IIdiomaObserver observer)
        {
            _idiomaObservers.Remove(observer);
        }

        private void NotificarCambioIdioma(IIdioma idioma)
        {
            foreach (var observer in _idiomaObservers)
            {
                observer.UpdateLanguage(idioma);
            }
        }

        // Métodos para gestionar eventos genéricos
        public void SuscribirEvento(string eventType, IEventListener listener)
        {
            _eventManager.Subscribe(eventType, listener);
        }

        public void DesuscribirEvento(string eventType, IEventListener listener)
        {
            _eventManager.Unsubscribe(eventType, listener);
        }

        public void NotifyEvent(string eventType, object data)
        {
            _eventManager.Notify(eventType, data);
        }

        // Lógica para iniciar sesión
        public void Login(BE.Usuario usuario)
        {
            _user = usuario;
            // Notificar a los observadores de idioma al iniciar sesión
            NotificarCambioIdioma(usuario.Idioma);
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

        // Lógica para cambiar el idioma
        public void CambiarIdioma(IIdioma idioma)
        {
            _idioma = idioma;
            if (_user != null)
            {
                _user.Idioma = idioma;
            }
            // Notificar a los observadores del cambio de idioma
            NotificarCambioIdioma(idioma);
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
