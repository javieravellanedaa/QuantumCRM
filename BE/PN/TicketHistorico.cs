﻿// BE/TicketHistorico.cs
using System;

namespace BE
{
    public class TicketHistorico
    {
        public int TicketHistoricoId { get; set; }

        // FK al ticket original
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        // Cuándo y quién realizó el cambio
        public DateTime FechaCambio { get; set; }
        public Guid UsuarioCambioId { get; set; }
        public Usuario UsuarioCambio { get; set; }  // Navegación opcional si se desea

        // Tipo de evento: "Estado", "Grupo", "Prioridad", "Categoría", etc.
        public string TipoEvento { get; set; }

        // Valores antes y después (pueden ser null si no aplica)
        public int? ValorAnteriorId { get; set; }
        public int? ValorNuevoId { get; set; }

        // Comentario opcional para agregar contexto al cambio
        public string Comentario { get; set; }
    }
}
