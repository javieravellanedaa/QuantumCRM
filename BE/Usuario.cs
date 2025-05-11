using BE.Composite;
using INTERFACES;
using System;
using System.Collections.Generic;

namespace BE
{
    public class Usuario : Entity
    {
        public Usuario()
        {
            _permisos = new List<Componente>();
            Roles = new List<Rol>();
            NombreDeLosRoles = new List<string>();
        }

        // Propiedad pública para los permisos
        private List<Componente> _permisos;
        public List<Componente> Permisos
        {
            get { return _permisos; } set { _permisos = value; }
        }

        // Atributos originales
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public IIdioma Idioma { get; set; }

        // Nuevos atributos
        public string NombreUsuario { get; set; }
        public int Legajo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? UltimoInicioSesion { get; set; }

        public List<Rol> Roles { get; set; }
        public List<string> NombreDeLosRoles { get; set; }
        public int UltimoRolId { get; set; }
        public void AgregarComponente(Componente componente)
        {
            if (componente == null)
                throw new ArgumentNullException(nameof(componente));

            _permisos.Add(componente);
        }
        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
