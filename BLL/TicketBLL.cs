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

        public void CrearTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            ticketDAL.GuardarTicket(ticket);
        }
        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            return ticketDAL.ObtenerTicketPorId(id);
        }

        public void ActualizarTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            ticketDAL.ActualizarTicket(ticket);
        }

        public void EliminarTicket(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            ticketDAL.EliminarTicket(id);
        }

        public void AgregarComentario(Ticket ticket, Usuario usuario, string comentario)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            if (string.IsNullOrWhiteSpace(comentario))
                throw new ArgumentException("El comentario no puede estar vacío.", nameof(comentario));


            Guid usuarioId = usuario.Id;

    
            ticketDAL.AgregarComentario(ticket.TicketId, usuarioId, comentario);

            Comentario nuevoComentario = new Comentario
            {
               
                TicketId = ticket.TicketId,
                Texto = comentario,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId,
                Ticket = ticket
            };

            ticket.Comentarios.Add(nuevoComentario);
        }


        public List<Ticket> ListarTicketsDelUsuario(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(usuarioId));
            return ticketDAL.ListarTicketsDelUsuario(usuarioId);
        }

        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            if (departamentoId <= 0)
                throw new ArgumentException("El ID del departamento debe ser mayor que cero.", nameof(departamentoId));
            return ticketDAL.ListarTicketsDelDepartamento(departamentoId);
        }
    }
}
