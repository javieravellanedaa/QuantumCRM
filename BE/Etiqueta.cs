using INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Etiqueta : Entity, IEtiqueta
    {
        public string Nombre { get; set; }
    }
}
