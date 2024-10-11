using BE.Composite;
using INTERFACES;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario : Entity, IUsuario
    {


        public Usuario()
        {
            _permisos = new List<Componente>();
        }


        List<Componente> _permisos;
        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
        }

        public string Email { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Password { get; set; }
        public IIdioma Idioma { get; set; }


        public override string ToString()
        {
            return Nombre;
        }

    }





}
