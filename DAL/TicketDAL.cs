 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using BE;

namespace DAL
{
    public class TicketDAL
    {
        private Acceso _acceso = new Acceso();

        
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
                _acceso.CrearParametro("@PrioridadId", ticket.PrioridadId),
                _acceso.CrearParametro("@TecnicoId", ticket.TecnicoId),
                _acceso.CrearParametro("@UsuarioCreadorId", ticket.UsuarioCreadorId.ToString())
            };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                _acceso.Escribir("sp_GuardarTicket", parametros); 
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

                        // Mapear Departamento y Cliente
                        int ordinalDepartamentoId = reader.GetOrdinal("departamento_id");
                        int ordinalDepartamentoNombre = reader.GetOrdinal("departamento_nombre");
                        int ordinalClienteId = reader.GetOrdinal("cliente_id");

                        if (!reader.IsDBNull(ordinalDepartamentoId) && !reader.IsDBNull(ordinalDepartamentoNombre))
                        {
                            // Se asume que la propiedad UsuarioCreador es de tipo Cliente y éste posee un objeto Departamento.
                            if (ticket.UsuarioCreador == null)
                                ticket.UsuarioCreador = new Cliente();
                            ticket.UsuarioCreador.Departamento = new Departamento
                            {
                                Id = reader.GetInt32(ordinalDepartamentoId),
                                Nombre = reader.GetString(ordinalDepartamentoNombre)
                            };
                        }
                        if (!reader.IsDBNull(ordinalClienteId))
                        {
                            if (ticket.UsuarioCreador == null)
                                ticket.UsuarioCreador = new Cliente();
                            ticket.UsuarioCreador.ClienteId = reader.GetInt32(ordinalClienteId);
                        }

                        // Mapear los comentarios del ticket (si existen)
                        int ordinalComentarios = reader.GetOrdinal("ComentariosXml");
                        if (!reader.IsDBNull(ordinalComentarios))
                        {
                            var sqlXml = reader.GetSqlXml(ordinalComentarios);
                            string comentariosXml = sqlXml.Value;
                            if (!string.IsNullOrEmpty(comentariosXml))
                            {
                                XDocument doc = XDocument.Parse(comentariosXml);
                                foreach (var elem in doc.Descendants("Comentario"))
                                {
                                    Comentario comentario = new Comentario
                                    {
                                        Id = int.Parse(elem.Element("Id").Value),
                                        UsuarioId = Guid.Parse(elem.Element("UsuarioId").Value),
                                        Texto = elem.Element("Texto").Value,
                                        Fecha = DateTime.Parse(elem.Element("Fecha").Value),
                                        TicketId = ticket.TicketId
                                    };
                                    ticket.Comentarios.Add(comentario);
                                }
                            }
                        }

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

                        // Mapear los comentarios del ticket, si existen
                        int ordinalComentarios = reader.GetOrdinal("ComentariosXml");
                        if (!reader.IsDBNull(ordinalComentarios))
                        {
                            // Se obtiene el XML de los comentarios
                            var sqlXml = reader.GetSqlXml(ordinalComentarios);
                            string comentariosXml = sqlXml.Value;
                            if (!string.IsNullOrEmpty(comentariosXml))
                            {
                                // Parsear el XML y crear objetos Comentario
                                XDocument doc = XDocument.Parse(comentariosXml);
                                foreach (var elem in doc.Descendants("Comentario"))
                                {
                                    Comentario comentario = new Comentario
                                    {
                                        Id = int.Parse(elem.Element("Id").Value),
                                        UsuarioId = Guid.Parse(elem.Element("UsuarioId").Value),
                                        Texto = elem.Element("Texto").Value,
                                        Fecha = DateTime.Parse(elem.Element("Fecha").Value),
                                        TicketId = ticket.TicketId
                                    };
                                    ticket.Comentarios.Add(comentario);
                                }
                            }
                        }

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
