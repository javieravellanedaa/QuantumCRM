using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INTERFACES;

namespace BE
{
    public class Traduccion : Entity, ITraduccion
    {
        public IEtiqueta Etiqueta { get; set; }
        public string Texto { get; set; }
        public Guid IdiomaId { get; set; }
        public Guid EtiquetaId { get; set; }
        public string EtiquetaNombre { get; set; }
        public string Formulario { get; set; }
    }


}
