using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;

namespace BLL
{
    public class EstadoTicketBLL
    {
        private readonly EstadoTicketDAL _estadoTicketDAL;

        public EstadoTicketBLL()
        {
            _estadoTicketDAL = new EstadoTicketDAL();
        }

        public List<EstadoTicket> ListarEstadosTicket()
        {
            return _estadoTicketDAL.ListarEstadosTicket();
        }

        public EstadoTicket ObtenerEstadoTicket(int id)
        {
            return _estadoTicketDAL.ObtenerEstadoTicket(id);
        }
        public EstadoTicket ObtenerPorNombre(string nombre)
        {
            var todos = ListarEstadosTicket();
            var estado = todos
                .FirstOrDefault(e =>
                    e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            return estado
                ?? throw new InvalidOperationException(
                     $"EstadoTicket con nombre '{nombre}' no encontrado.");
        }


    }
}
