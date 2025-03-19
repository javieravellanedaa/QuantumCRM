using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class EstadoTicketBLL
    {
        private EstadoTicketDAL _estadoTicketDAL;

        public EstadoTicketBLL()
        {
            _estadoTicketDAL = new EstadoTicketDAL();
        }

        /// <summary>
        /// Retorna la lista completa de estados de ticket.
        /// </summary>
        /// <returns>Lista de objetos EstadoTicket</returns>
        public List<EstadoTicket> ListarEstadosTicket()
        {
            return _estadoTicketDAL.ListarEstadosTicket();
        }

        /// <summary>
        /// Obtiene un estado de ticket a partir de su Id.
        /// </summary>
        /// <param name="id">Identificador del estado</param>
        /// <returns>Objeto EstadoTicket o null si no se encuentra</returns>
        public EstadoTicket ObtenerEstadoTicket(int id)
        {
            return _estadoTicketDAL.ObtenerEstadoTicket(id);
        }
    }
}
