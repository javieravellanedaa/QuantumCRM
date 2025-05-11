 using System.Collections.Generic;
using System;

namespace BE
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Cliente ClienteLider { get; set; } // Cliente líder del departamento
        public DateTime FechaCreacion { get; set; } 
        public string CodigoDepartamento { get; set; } 
        public string Descripcion { get; set; }

        private string ubicacion;

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public bool Estado { get; set; } // Estado (activo/inactivo)


      

    }
}
