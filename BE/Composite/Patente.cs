using BE.Composite;
using INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class Patente: Componente
    {


        public override List<Componente> Hijos
        {
            get
            {
                return new List<Componente>();
            }

        }

        public override void AgregarHijo(Componente c)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(Componente c)
        {
            throw new NotImplementedException();
        }

        public override void VaciarHijos()
        {
            throw new NotImplementedException();
        }
    }
}
