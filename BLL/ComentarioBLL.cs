using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class ComentarioBLL
    {
        private readonly ComentarioDAL _comentarioDAL;

        public ComentarioBLL()
        {
            _comentarioDAL = new ComentarioDAL();
        }

        public List<Comentario> ListarComentariosPorTicket(Guid ticketId)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticketId));
            return _comentarioDAL.ListarComentariosPorTicket(ticketId);
        }

        public Comentario ObtenerComentario(int comentarioId)
        {
            if (comentarioId <= 0)
                throw new ArgumentException("El ID del comentario no es válido.", nameof(comentarioId));
            return _comentarioDAL.ObtenerComentario(comentarioId);
        }

        public void AgregarComentario(Guid ticketId, Guid usuarioId, string texto, int? comentarioPadreId = null)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticketId));
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(usuarioId));
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("El texto del comentario no puede estar vacío.", nameof(texto));

            var comentario = new Comentario
            {
                TicketId = ticketId,
                UsuarioId = usuarioId,
                Texto = texto,
                Fecha = DateTime.Now,
                ComentarioPadreId = comentarioPadreId,
                Eliminado = false
            };

            _comentarioDAL.InsertarComentario(comentario);
        }

        public void EliminarComentario(int comentarioId)
        {
            if (comentarioId <= 0)
                throw new ArgumentException("El ID del comentario no es válido.", nameof(comentarioId));

            _comentarioDAL.EliminarComentarioRecursivo(comentarioId);
        }
    }
}
