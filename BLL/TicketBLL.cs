using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class TicketBLL
    {
        private TicketDAL ticketDAL;

        public TicketBLL()
        {
            ticketDAL = new TicketDAL(); 
        }

        // Método para guardar un ticket en la base de datos.
        public void GuardarTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            }

            if (ticket.Campos == null || ticket.Campos.Count == 0)
            {
                throw new ArgumentException("El ticket debe contener al menos un campo.");
            }

            // Guarda el ticket usando TicketDAL.
            ticketDAL.GuardarTicket(ticket);
        }

        // Método para obtener un ticket por su ID.
        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            }

            // Devuelve el ticket obtenido de la base de datos.
            return ticketDAL.ObtenerTicketPorId(id);
        }

        // Método para listar todos los tickets existentes.
        public List<Ticket> ListarTodosLosTickets()
        {
            return ticketDAL.ListarTodosLosTickets();
        }

        // Método para actualizar un ticket existente.
        public void ActualizarTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            }

            if (ticket.Campos == null || ticket.Campos.Count == 0)
            {
                throw new ArgumentException("El ticket debe contener al menos un campo para ser actualizado.");
            }

            // Actualiza el ticket usando TicketDAL.
            ticketDAL.ActualizarTicket(ticket);
        }

        // Método para eliminar un ticket usando su ID.
        public void EliminarTicket(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            }

            // Elimina el ticket usando TicketDAL.
            ticketDAL.EliminarTicket(id);
        }
    }
}
