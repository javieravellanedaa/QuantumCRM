using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Lista los comentarios de un ticket y los arma en estructura jerárquica (hilos).
        /// </summary>
        public List<Comentario> ListarComentariosPorTicket(Guid ticketId)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticketId));

            // Traer todos los comentarios planos
            var comentarios = _comentarioDAL.ListarComentariosPorTicket(ticketId)
                .OrderBy(c => c.Fecha)
                .ToList();

            // Construir jerarquía
            var lookup = comentarios.ToDictionary(c => c.ComentarioId);
            var raiz = new List<Comentario>();

            foreach (var c in comentarios)
            {
                if (c.ComentarioPadreId.HasValue && lookup.TryGetValue(c.ComentarioPadreId.Value, out var padre))
                {
                    padre.Respuestas.Add(c);
                }
                else
                {
                    raiz.Add(c);
                }
            }

            return raiz;
        }

        /// <summary>
        /// Obtiene un comentario por su ID.
        /// </summary>
        public Comentario ObtenerComentario(int comentarioId)
        {
            if (comentarioId <= 0)
                throw new ArgumentException("El ID del comentario no es válido.", nameof(comentarioId));

            var comentario = _comentarioDAL.ObtenerComentario(comentarioId);
            if (comentario == null)
                throw new InvalidOperationException($"Comentario con ID {comentarioId} no encontrado.");

            return comentario;
        }

        /// <summary>
        /// Agrega un nuevo comentario (o respuesta) a un ticket.
        /// </summary>
        public void AgregarComentario(Guid ticketId, Guid usuarioId, string texto, int? comentarioPadreId = null)
        {
            if (ticketId == Guid.Empty)
                throw new ArgumentException("El ID del ticket no puede ser vacío.", nameof(ticketId));
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID del usuario no puede ser vacío.", nameof(usuarioId));
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("El texto del comentario no puede estar vacío.", nameof(texto));

            // Validar comentario padre (si aplica)
            if (comentarioPadreId.HasValue)
            {
                var padre = _comentarioDAL.ObtenerComentario(comentarioPadreId.Value);
                if (padre == null || padre.TicketId != ticketId)
                    throw new InvalidOperationException("El comentario padre no existe o no pertenece a este ticket.");
            }

            var nuevo = new Comentario
            {
                TicketId = ticketId,
                UsuarioId = usuarioId,
                Texto = texto.Trim(),
                Fecha = DateTime.Now,
                ComentarioPadreId = comentarioPadreId,
                Eliminado = false
            };

            _comentarioDAL.InsertarComentario(nuevo);
        }

        /// <summary>
        /// Elimina lógicamente un comentario y sus respuestas (recursivo).
        /// </summary>
        public void EliminarComentario(int comentarioId)
        {
            if (comentarioId <= 0)
                throw new ArgumentException("El ID del comentario no es válido.", nameof(comentarioId));

            // Verificar existencia
            var existente = _comentarioDAL.ObtenerComentario(comentarioId);
            if (existente == null)
                throw new InvalidOperationException($"Comentario con ID {comentarioId} no encontrado.");

            _comentarioDAL.EliminarComentarioRecursivo(comentarioId);
        }
    }
}
