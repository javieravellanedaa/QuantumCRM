using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACES
{
   
        public interface IUsuario
        {

            string Email { get; set; }
            string Password { get; set; }
            string Nombre { get; set; }
            string Apellido { get; set; }
            IIdioma Idioma { get; set; }


             string NombreUsuario { get; set; }
             int Legajo { get; set; }
             DateTime FechaAlta { get; set; }
             DateTime UltimoInicioSesion { get; set; }

             List<string> NombreDeLosRoles { get; set; }




    }
    

}
