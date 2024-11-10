using System;
using System.Collections.Generic;

namespace BE
{
    public class Ticket
    {

        public Guid TicketId { get; set; } // ticket_id en la base de datos
        public string Asunto { get; set; } // asunto
        public string Descripcion { get; set; } // descripcion
        public int CategoriaId { get; set; } // categoria_id
        public Categoria Categoria { get; set; } // Relación con la clase Categoria
        public int EstadoId { get; set; } // estado_id
        public DateTime FechaCreacion { get; set; } // fecha_creacion
        public DateTime FechaUltimaModif { get; set; } // fecha_ultima_modif

        public string PrioridadNombre { get; set; } // Nombre de la prioridad de la categoría

        public int TecnicoId { get; set; } // tecnico_id
        public Tecnico TecnicoAsignado { get; set; } // Técnico asignado actual
        public Guid UsuarioCreadorId { get; set; } // usuario_creador_id
        public Cliente UsuarioCreador { get; set; } // Relación con el usuario creador

        public int PrioridadId { get; set; } // prioridad_id
        
        public Prioridad Prioridad { get; set; } // Relación con la clase Prioridad

        // Campos adicionales para relacionar aprobadores y comentarios
        public Cliente UsuarioAprobador { get; set; } // Usuario aprobador si es necesario
        public int? UsuarioAprobadorId { get; set; } // Id del aprobador, nullable

        // Relación de comentarios
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();

        public DateTime fecha_cierre { get;set; } // fecha_cierre
        public Ticket()
        {
            TicketId = Guid.NewGuid(); // Genera un GUID único para el ticket
        }

        // Propiedad adicional `Tipo`
        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
