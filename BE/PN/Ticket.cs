using System;
using System.Collections.Generic;
using BE.PN;

namespace BE
{
    public class Ticket
    {
        public Ticket()
        {
            TicketId = Guid.NewGuid();
        }

        public Guid TicketId { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModif { get; set; }
        public DateTime? FechaCierre { get; set; }
        public bool Eliminado { get; set; }
        public string Asunto { get; set; }

        public string Descripcion { get; set; }

        public int ClienteCreadorId { get; set; }
        public Cliente ClienteCreador { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }

        public int EstadoId { get; set; }
        public EstadoTicket Estado { get; set; }

        public int? UsuarioAprobadorId { get; set; }
        public Cliente UsuarioAprobador { get; set; }

        public int? TecnicoId { get; set; }
        public Tecnico TecnicoAsignado { get; set; }

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
