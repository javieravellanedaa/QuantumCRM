﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACES
{
    public interface ITraduccion
    {
        IEtiqueta Etiqueta { get; set; }
        string Texto { get; set; }
        string Formulario { get; set; }
    }
}
