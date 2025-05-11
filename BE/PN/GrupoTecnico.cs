using System;
using System.Collections.Generic;

namespace BE.PN
{
    public class GrupoTecnico
    {
        public int GrupoId { get; set; }  // Clave primaria del grupo
        public string Nombre { get; set; }  // Nombre del grupo
        public string Descripcion { get; set; }  // Descripción del grupo

        public Tecnico TecnicoLider { get; set; }  // Objeto del técnico líder

        public List<Tecnico> Tecnicos { get; set; } = new List<Tecnico>(); // Técnicos miembros del grupo

        public List<Ticket> Tickets { get; set; } = new List<Ticket>(); // Tickets asignados al grupo

        // Constructor vacío
        public GrupoTecnico() { }

        // Constructor extendido
        public GrupoTecnico(int grupoId, string nombre, string descripcion, Tecnico tecnicoLider)
        {
            GrupoId = grupoId;
            Nombre = nombre;
            Descripcion = descripcion;
            TecnicoLider = tecnicoLider;
        }
    }
}
