using BE.Composite;
using INTERFACES;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BE
{
    public class Usuario : Entity, IUsuario
    {
        public Usuario()
        {
            _permisos = new List<Componente>();
            Roles = new List<Rol>();
            NombreDeLosRoles = new List<string>();
        }

        List<Componente> _permisos;
        public List<Componente> Permisos
        {
            get
            {
                return _permisos;
            }
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
        public DateTime UltimoInicioSesion { get; set; }

        
        public List<Rol> Roles { get; set; }
        public List<string> NombreDeLosRoles { get ; set; }
        public int UltimoRolId { get; set; }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
