using System;
using System.Collections.Generic;
using BE.PN;

namespace BE
{
    public class TicketHistorico
    {
        public int TicketHistoricoId { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime FechaCambio { get; set; }
        public Guid UsuarioCambioId { get; set; }

        public string TipoEvento { get; set; }

        public int? ValorAnteriorId { get; set; }
        public int? ValorNuevoId { get; set; }

        // Comentario opcional para notas libres
        public string Comentario { get; set; }
    }
}
