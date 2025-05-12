using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ComentarioDAL
    {
        private readonly Acceso _acceso = new Acceso();

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

            // Mapear usuario completo
            comentario.Usuario = new Usuario
            {
                Id = comentario.UsuarioId,
                Nombre = reader.GetString(reader.GetOrdinal("usuario_nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("usuario_apellido"))
            };

            return comentario;
        }

        public List<Comentario> ListarComentariosPorTicket(Guid ticketId)
        {
            var lista = new List<Comentario>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", ticketId.ToString())
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarComentariosPorTicket", parametros))
                {
                    while (reader.Read())
                    {
                        var comentario = MapearComentario(reader);
                        lista.Add(comentario);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
        }

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
                    {
                        comentario = MapearComentario(reader);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return comentario;
        }

        public void InsertarComentario(Comentario comentario)
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
                _acceso.Escribir("sp_InsertarComentario", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void EliminarComentarioRecursivo(int comentarioId)
        {
            // Obtener comentarios hijos
            var todos = ListarComentariosPorTicket(Guid.Empty); // Considerar método ListarPorPadre en el futuro
            foreach (var hijo in todos)
            {
                if (hijo.ComentarioPadreId == comentarioId)
                {
                    EliminarComentarioRecursivo(hijo.ComentarioId);
                }
            }

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
