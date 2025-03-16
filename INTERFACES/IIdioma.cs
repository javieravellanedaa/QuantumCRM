using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACES
{
    public interface IIdioma : IEntity
    {
        string Nombre { get; set; }
        bool Activo { get; set; }  // <-- Agregar esta propiedad
    }
}
