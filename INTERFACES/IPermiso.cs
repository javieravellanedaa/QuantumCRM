using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACES
{
    public interface IPermiso
    {
        string Nombre { get; set; }
        void AgregarPermiso(IPermiso p);
        void QuitarPermiso(IPermiso p);
        IList<IPermiso> ObtenerHijos();

        int Id { get; set; }

        string Permiso { get; set; }    
    }
}
