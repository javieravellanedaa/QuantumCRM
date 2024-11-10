using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace SERVICIOS
{
    public class SingletonSesion
    {
        private static SingletonSesion _instancia;
        private static readonly object _lock = new object();
        private Sesion _sesion;

        private SingletonSesion()
        {
            _sesion = new Sesion();
        }

        public static SingletonSesion Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new SingletonSesion();
                }
                return _instancia;
            }
        }

        public Sesion Sesion => _sesion;
    }
}
