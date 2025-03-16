using INTERFACES;
using System;

namespace BE
{
    public class Idioma : Entity, IIdioma
    {
        public string Nombre { get; set; }
        public bool Activo { get; set; } = true; // <-- Iniciado en true por defecto
    }
}
