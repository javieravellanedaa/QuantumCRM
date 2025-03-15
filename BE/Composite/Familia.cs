using BE;
using BE.Composite;
using System.Collections.Generic;

namespace BE
{
    public class Familia : Componente
    {
        private IList<Componente> _hijos;

        public override IList<Componente> Hijos
        {
            get
            {
                return _hijos; // Devuelve la lista directamente, sin convertir a arreglo
            }
        }

        public Familia()
        {
            _hijos = new List<Componente>(); 
        }


        public override void VaciarHijos()
        {
            _hijos.Clear(); // Limpia la lista sin crear una nueva instancia
        }

        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }
    }
}
