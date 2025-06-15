using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ControlDeCambios
    {
        public long LogId { get; set; }
        public string Tabla { get; set; }
        public Guid EntityId { get; set; }
        public string Propiedad { get; set; }
        public string ValorViejo { get; set; }
        public string ValorNuevo { get; set; }
        public Guid CambiadoPor { get; set; }
        public DateTime FechaCambio { get; set; }
        public TipoDeOperacion TipoOperacion { get; set; }
    }
}
