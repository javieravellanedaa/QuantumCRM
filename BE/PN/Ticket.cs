// BE/Ticket.cs
using System;
using System.Collections.Generic;
using BE.PN;
using INTERFACES;

namespace BE
{
    public class Ticket : IDigitVerificable
    {
        public Ticket()
        {
            TicketId = Guid.NewGuid();
            Comentarios = new List<Comentario>();
            Historicos = new List<TicketHistorico>();
        }
        public string DigitoVerificadorH { get; set; }

        public Guid TicketId { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModif { get; set; }
        public DateTime? FechaCierre { get; set; }
        public bool Eliminado { get; set; }

        public string Asunto { get; set; }
        public string Descripcion { get; set; }

        // Origen y clasificación
        public int ClienteCreadorId { get; set; }
        public Cliente ClienteCreador { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        // Prioridad actual (mutable por UI)
        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }

        // Estado actual
        public int EstadoId { get; set; }
        public EstadoTicket Estado { get; set; }

        // Aprobación si corresponde
        public int? UsuarioAprobadorId { get; set; }
        public Cliente UsuarioAprobador { get; set; }

        // Grupo técnico actual
        public int? GrupoTecnicoId { get; set; }
        public GrupoTecnico GrupoTecnico { get; set; }

        // Técnico asignado
        public int? TecnicoId { get; set; }
        public Tecnico TecnicoAsignado { get; set; }

        // Bitácora de comentarios
        public List<Comentario> Comentarios { get; set; }

        // Historial genérico de eventos
        public List<TicketHistorico> Historicos { get; set; }

        public List<ValorCampoTicket> ValoresCamposPersonalizados { get; set; }
        = new List<ValorCampoTicket>();
    }
}
