using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ComentarioDAL
    {
        private readonly Acceso _acceso = new Acceso();

        // Mapea un SqlDataReader a un objeto Comentario
        private Comentario MapearComentario(SqlDataReader reader)
        {
            var comentario = new Comentario
            {
                ComentarioId = reader.GetInt32(reader.GetOrdinal("comentario_id")),
                TicketId = reader.GetGuid(reader.GetOrdinal("ticket_id")),
                UsuarioId = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                Texto = reader.GetString(reader.GetOrdinal("texto")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                Eliminado = reader.GetBoolean(reader.GetOrdinal("eliminado")),
                ComentarioPadreId = reader.IsDBNull(reader.GetOrdinal("comentario_padre_id"))
                                        ? (int?)null
                                        : reader.GetInt32(reader.GetOrdinal("comentario_padre_id"))
            };

            // Navegación mínima:
            comentario.Ticket = new Ticket { TicketId = comentario.TicketId };
            comentario.Usuario = new Usuario
            {
                Id = comentario.UsuarioId,
                Nombre = reader.GetString(reader.GetOrdinal("usuario_nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("usuario_apellido"))
            };

            return comentario;
        }

        // Obtiene todos los comentarios de un ticket (no incluye eliminados)
        public List<Comentario> ListarComentariosPorTicket(Guid ticketId)
        {
            var lista = new List<Comentario>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", ticketId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarComentariosPorTicket", parametros))
                {
                    while (reader.Read())
                    {
                        var c = MapearComentario(reader);
                        if (!c.Eliminado)
                            lista.Add(c);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
        }

        // Obtiene un comentario por su ID
        public Comentario ObtenerComentario(int comentarioId)
        {
            Comentario comentario = null;
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@comentario_id", comentarioId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerComentario", parametros))
                {
                    if (reader.Read())
                        comentario = MapearComentario(reader);
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return comentario;
        }

        // Inserta un nuevo comentario y devuelve el ID generado
        public int InsertarComentario(Comentario comentario)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", comentario.TicketId),
                _acceso.CrearParametro("@usuario_id", comentario.UsuarioId),
                _acceso.CrearParametro("@texto", comentario.Texto),
                _acceso.CrearParametro("@comentario_padre_id", comentario.ComentarioPadreId)
            };

            try
            {
                _acceso.Abrir();
                var result = _acceso.EscribirEscalar("sp_InsertarComentario", parametros);
                var nuevoId = Convert.ToInt32(result);
                comentario.ComentarioId = nuevoId;
                return nuevoId;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Elimina recursivamente (lógico) un comentario y todos sus hijos en BD
        public void EliminarComentarioRecursivo(int comentarioId)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@comentario_id", comentarioId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarComentarioRecursivo", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
