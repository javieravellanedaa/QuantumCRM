﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public abstract class Componente
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public abstract List<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente c);
        public abstract void VaciarHijos();
        public string Permiso { get; set; } 
        public string Descripcion { get; set; }
    
        public override string ToString()
        {
            return Nombre;
        }

        public abstract void EliminarHijo(Componente c);



    }
}
