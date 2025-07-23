using BE.PN;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class ValorCampoTicketBLL
    {
        private readonly ValorCampoTicketDAL _dal = new ValorCampoTicketDAL();

        /// <summary>
        /// Obtiene todos los valores de campos personalizados de un ticket.
        /// </summary>
        public List<ValorCampoTicket> ListarPorTicket(Guid ticketId)
        {
            if (ticketId == Guid.Empty) throw new ArgumentException("El ID del ticket no puede ser vacío.");
            return _dal.ListarPorTicket(ticketId);
        }

        /// <summary>
        /// Guarda (inserta o actualiza) los valores de campos personalizados de un ticket.
        /// </summary>
        public void GuardarValores(Guid ticketId, IEnumerable<ValorCampoTicket> valores)
        {
            if (ticketId == Guid.Empty) throw new ArgumentException("El ID del ticket no puede ser vacío.");
            // Borramos los existentes y volvemos a insertar
            _dal.EliminarPorTicket(ticketId);
            foreach (var v in valores)
            {
                v.TicketId = ticketId;
                _dal.Insertar(v);
            }
        }
        public void ActualizarValoresPorTicket(Guid ticketId, List<ValorCampoTicket> nuevosValores)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.");

            if (nuevosValores == null || nuevosValores.Count == 0)
                return;

            try
            {
                // 1. Obtener definiciones de campos que vamos a actualizar
                var definicionesAAcualizar = nuevosValores
                    .Select(v => v.DefinicionCampoPersonalizadoId)
                    .ToList();

                // 2. Eliminar solo los valores de los campos que estamos actualizando
                foreach (var definicionId in definicionesAAcualizar)
                {
                    _dal.EliminarPorTicketYDefinicion(ticketId, definicionId);
                }

                // 3. Insertar los nuevos valores
                foreach (var nuevoValor in nuevosValores)
                {
                    nuevoValor.TicketId = ticketId;
                    _dal.Insertar(nuevoValor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los valores de campos personalizados.", ex);
            }
        }
    }
}
