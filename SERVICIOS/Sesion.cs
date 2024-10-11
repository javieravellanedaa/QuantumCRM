using BE;
using INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVICIOS
{
    public class Sesion
    {

        //private IUsuario _user { get; set; }
        private BE.Usuario _user { get; set; }
        private IIdioma _idioma;
        private static readonly IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();
        public IIdioma Idioma => _idioma;
        public IUsuario Usuario
        {
            get
            {
                return _user;
            }
        }


        //public void Login(IUsuario usuario)
        public void Login(BE.Usuario usuario)
        {
           
            _user = usuario;
            Notificar(usuario.Idioma);
        }

        public void Logout()
        {
            _user = null;
        }

        public bool IsLogged()
        {
            return _user != null;
        }
        public void SuscribirObservador(IIdiomaObserver observer)
        {
            _observers.Add(observer);
        }


        public void DesuscribirObservador(IIdiomaObserver observer)
        {
            _observers.Remove(observer);
        }
        private void Notificar(IIdioma idioma)
        {
            foreach (var observer in _observers)
            {
                observer.UpdateLanguage(idioma);
            }
        }

        public void CambiarIdioma(IIdioma idioma)
        {

            _idioma = idioma;
            if (_user != null)
            {
                _user.Idioma = idioma;
            }
            Notificar(idioma);
        }



        private bool IsInRoleRecursivo(BE.Composite.Componente p, int id_permiso, bool valid)
        {

            foreach (var item in p.Hijos)
            {
                // Recorro la familia Nivel por Nivel
                if(item.Id == id_permiso)
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
                if(p.Id == id_permiso)
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
