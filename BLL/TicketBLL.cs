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
        public void CrearTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            ticketDAL.GuardarTicket(ticket);
        }

        // Método para obtener un ticket por su ID.
        public Ticket ObtenerTicketPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            return ticketDAL.ObtenerTicketPorId(id);
        }

        // Método para actualizar un ticket existente.
        public void ActualizarTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket), "El ticket no puede ser nulo.");
            ticketDAL.ActualizarTicket(ticket);
        }

        // Método para eliminar un ticket usando su ID.
        public void EliminarTicket(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.");
            ticketDAL.EliminarTicket(id);
        }

        /// <summary>
        /// Agrega un comentario al ticket: persiste el comentario en la base de datos y lo agrega al objeto Ticket en memoria.
        /// </summary>
        public void AgregarComentario(Ticket ticket, Usuario usuario, string comentario)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            if (string.IsNullOrWhiteSpace(comentario))
                throw new ArgumentException("El comentario no puede estar vacío.", nameof(comentario));

            // Usar el identificador del usuario pasado como parámetro.
            Guid usuarioId = usuario.Id;

            // Llamada a la DAL para persistir el comentario en la base de datos.
            ticketDAL.AgregarComentario(ticket.TicketId, usuarioId, comentario);

            // Crear un nuevo objeto Comentario y agregarlo a la lista del ticket.
            Comentario nuevoComentario = new Comentario
            {
                // Se asume que el campo Id se asigna automáticamente en la base de datos.
                TicketId = ticket.TicketId,
                Texto = comentario,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId,
                Ticket = ticket
            };

            ticket.Comentarios.Add(nuevoComentario);
        }

        /// <summary>
        /// Lista los tickets creados por el usuario identificado por usuarioId.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario (Guid).</param>
        /// <returns>Lista de tickets creados por ese usuario.</returns>
        public List<Ticket> ListarTicketsDelUsuario(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(usuarioId));
            return ticketDAL.ListarTicketsDelUsuario(usuarioId);
        }

        /// <summary>
        /// Lista los tickets creados por el departamento indicado.
        /// </summary>
        /// <param name="departamentoId">Identificador del departamento (int).</param>
        /// <returns>Lista de tickets creados por el departamento.</returns>
        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            if (departamentoId <= 0)
                throw new ArgumentException("El ID del departamento debe ser mayor que cero.", nameof(departamentoId));
            return ticketDAL.ListarTicketsDelDepartamento(departamentoId);
        }
    }
}
