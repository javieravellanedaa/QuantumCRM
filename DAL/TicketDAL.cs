using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class TicketDAL
    {
        private Acceso _acceso = new Acceso();

        // Método para guardar un ticket
        public void GuardarTicket(Ticket ticket)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticket.TicketId.ToString()),
                _acceso.CrearParametro("@Asunto", ticket.Asunto),
                _acceso.CrearParametro("@Descripcion", ticket.Descripcion),
                _acceso.CrearParametro("@CategoriaId", ticket.CategoriaId),
                _acceso.CrearParametro("@EstadoId", ticket.EstadoId),
                _acceso.CrearParametro("@FechaCreacion", ticket.FechaCreacion),
                _acceso.CrearParametro("@FechaUltimaModif", ticket.FechaUltimaModif),
                _acceso.CrearParametro("@PrioridadId", ticket.PrioridadId),  // Se asume que PrioridadId es el identificador
                _acceso.CrearParametro("@TecnicoId", ticket.TecnicoId),
                _acceso.CrearParametro("@UsuarioCreadorId", ticket.UsuarioCreadorId.ToString())
            };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                _acceso.Escribir("sp_GuardarTicket", parametros);  // Se asume que el procedimiento almacenado es sp_GuardarTicket
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Método para obtener un ticket por su Id
        public Ticket ObtenerTicketPorId(Guid ticketId)
        {
            Ticket ticket = null;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticketId.ToString())
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerTicketPorId", parametros))
                {
                    if (reader.Read())
                    {
                        ticket = new Ticket
                        {
                            TicketId = reader.GetGuid(reader.GetOrdinal("ticket_id")),
                            Asunto = reader.GetString(reader.GetOrdinal("asunto")),
                            Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                            CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                            EstadoId = reader.GetInt32(reader.GetOrdinal("estado_id")),
                            FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                            FechaUltimaModif = reader.GetDateTime(reader.GetOrdinal("fecha_ultima_modif")),
                            PrioridadId = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                            TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_id")),
                            UsuarioCreadorId = reader.GetGuid(reader.GetOrdinal("usuario_creador_id"))
                        };
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return ticket;
        }

        //// Método para actualizar un ticket existente
        public void ActualizarTicket(Ticket ticket)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticket.TicketId.ToString()),
                _acceso.CrearParametro("@Asunto", ticket.Asunto),
                _acceso.CrearParametro("@Descripcion", ticket.Descripcion),
                _acceso.CrearParametro("@CategoriaId", ticket.CategoriaId),
                _acceso.CrearParametro("@EstadoId", ticket.EstadoId),
                _acceso.CrearParametro("@FechaUltimaModif", ticket.FechaUltimaModif),
                _acceso.CrearParametro("@PrioridadId", ticket.PrioridadId),
                _acceso.CrearParametro("@TecnicoId", ticket.TecnicoId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                _acceso.Escribir("sp_ActualizarTicket", parametros);  // Se asume que el procedimiento almacenado es sp_ActualizarTicket
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void AgregarComentario(Guid ticketId, Guid usuarioId, string comentario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@TicketId", ticketId.ToString()),
                    _acceso.CrearParametro("@UsuarioId", usuarioId.ToString()),
                    _acceso.CrearParametro("@Comentario", comentario)
                };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                _acceso.Escribir("sp_AgregarComentarioTicket", parametros);
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public List<Ticket> ListarTicketsDelUsuario(Guid usuarioId)
        {
            List<Ticket> lista = new List<Ticket>();
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@UsuarioId", usuarioId.ToString())
    };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarTicketsDelUsuario", parametros))
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            TicketId = reader.GetGuid(reader.GetOrdinal("ticket_id")),
                            Asunto = reader.GetString(reader.GetOrdinal("asunto")),
                            Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                            UsuarioCreadorId = reader.GetGuid(reader.GetOrdinal("usuario_creador_id")),
                            FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                            FechaUltimaModif = reader.GetDateTime(reader.GetOrdinal("fecha_ultima_modif")),
                            PrioridadId = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                            CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                            EstadoId = reader.GetInt32(reader.GetOrdinal("estado_id")),
                            TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_id"))
                        };
                        lista.Add(ticket);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return lista;
        }

        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            List<Ticket> lista = new List<Ticket>();
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@DepartamentoId", departamentoId)
    };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarTicketsDelDepartamento", parametros))
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            TicketId = reader.GetGuid(reader.GetOrdinal("ticket_id")),
                            Asunto = reader.GetString(reader.GetOrdinal("asunto")),
                            Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                            UsuarioCreadorId = reader.GetGuid(reader.GetOrdinal("usuario_creador_id")),
                            FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                            FechaUltimaModif = reader.GetDateTime(reader.GetOrdinal("fecha_ultima_modif")),
                            PrioridadId = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                            CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                            EstadoId = reader.GetInt32(reader.GetOrdinal("estado_id")),
                            TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_id"))
                        };
                        lista.Add(ticket);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return lista;
        }


        // Método para eliminar un ticket por su Id
        public void EliminarTicket(Guid ticketId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@TicketId", ticketId.ToString())
                };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                _acceso.Escribir("sp_EliminarTicket", parametros);  // Se asume que el procedimiento almacenado es sp_EliminarTicket
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
