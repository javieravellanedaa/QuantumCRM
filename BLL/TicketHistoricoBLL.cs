// BLL/TicketHistoricoBLL.cs
using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class TicketHistoricoBLL
    {
        private readonly TicketHistoricoDAL _dal = new TicketHistoricoDAL();

        /// <summary>
        /// Inserta un registro de histórico usando la DAL.
        /// </summary>
        public void AgregarHistorico(TicketHistorico historico)
        {
            if (historico == null)
                throw new ArgumentNullException(nameof(historico));

            // Validaciones básicas
            if (historico.TicketId == Guid.Empty)
                throw new ArgumentException("El TicketId no puede estar vacío.");

            if (historico.UsuarioCambioId == Guid.Empty)
                throw new ArgumentException("El UsuarioCambioId no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(historico.TipoEvento))
                throw new ArgumentException("TipoEvento es requerido.");

            // Si no se proporciona FechaCambio, la asignamos a la fecha actual
            if (historico.FechaCambio == default(DateTime))
                historico.FechaCambio = DateTime.Now;

            _dal.Insertar(historico);
        }

        /// <summary>
        /// Recupera la lista de histórico de un ticket específico.
        /// </summary>
        public List<TicketHistorico> ObtenerHistorialPorTicket(Guid ticketId)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ticketId no puede estar vacío.");

            return _dal.ListarPorTicket(ticketId);
        }
    }
}
