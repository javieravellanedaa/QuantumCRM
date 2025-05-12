using System;
using System.Collections.Generic;

namespace BE.PN
{
    public class GrupoTecnico
    {
        public int GrupoId { get; set; }              // PK
        public string Nombre { get; set; }            // Nombre del grupo
        public string Descripcion { get; set; }       // Descripción

        // Líder del grupo
        public int TecnicoLiderId { get; set; }
        public Tecnico TecnicoLider { get; set; }

        // Miembros del grupo (m:n)
        public List<Tecnico> Tecnicos { get; set; } = new List<Tecnico>();

        // Categorías asociadas (1 grupo ↔ n categorías)
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        // Soft delete y auditoría
        public bool Eliminado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Constructor vacío
        public GrupoTecnico()
        {
            FechaCreacion = DateTime.UtcNow;
        }

        // Constructor extendido
        public GrupoTecnico(int grupoId, string nombre, string descripcion, int tecnicoLiderId)
        {
            GrupoId = grupoId;
            Nombre = nombre;
            Descripcion = descripcion;
            TecnicoLiderId = tecnicoLiderId;
            FechaCreacion = DateTime.UtcNow;
        }
    }
}
