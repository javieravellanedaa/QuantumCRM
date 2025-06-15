using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public Guid UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public string Clase { get; set; }
        public string Accion { get; set; }
        public string InfoAdicional { get; set; }
    }

}