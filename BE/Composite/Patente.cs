using BE.Composite;
using INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patente: Componente
    {
        

        public override IList<Componente> Hijos
        {
            get
            {
                return new List<Componente>();
            }

        }

        public override void AgregarHijo(Componente c)
        {
            throw new InvalidOperationException("No se puede agregar hijos a un permiso simple.");
        }

        

        public override void VaciarHijos()
        {

        }
    }
}
