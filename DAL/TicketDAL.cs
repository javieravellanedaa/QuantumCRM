// DAL/TicketDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using BE;

namespace DAL
{
    public class TicketDAL
    {
        private readonly Acceso _acceso = new Acceso();
        private Ticket MapearTicket(SqlDataReader reader)
        {
            return new Ticket
            {
                TicketId = reader.GetGuid(reader.GetOrdinal("ticket_id")),
                FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                FechaUltimaModif = reader.GetDateTime(reader.GetOrdinal("fecha_ultima_modif")),
                FechaCierre = reader.IsDBNull(reader.GetOrdinal("fecha_cierre"))
                                      ? (DateTime?)null
                                      : reader.GetDateTime(reader.GetOrdinal("fecha_cierre")),
                Eliminado = reader.GetBoolean(reader.GetOrdinal("eliminado")),
                Asunto = reader.GetString(reader.GetOrdinal("asunto")),
                Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                ClienteCreadorId = reader.GetInt32(reader.GetOrdinal("cliente_creador_id")),
                CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                PrioridadId = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                EstadoId = reader.GetInt32(reader.GetOrdinal("estado_id")),
                UsuarioAprobadorId = reader.IsDBNull(reader.GetOrdinal("usuario_aprobador_id"))
                                      ? (int?)null
                                      : reader.GetInt32(reader.GetOrdinal("usuario_aprobador_id")),
                GrupoTecnicoId = reader.IsDBNull(reader.GetOrdinal("grupo_tecnico_id"))
                                      ? (int?)null
                                      : reader.GetInt32(reader.GetOrdinal("grupo_tecnico_id")),
                TecnicoId = reader.IsDBNull(reader.GetOrdinal("tecnico_id"))
                                      ? (int?)null
                                      : reader.GetInt32(reader.GetOrdinal("tecnico_id")),
                Comentarios = new List<Comentario>(),
                Historicos = new List<TicketHistorico>()
            };
        }
        public void ActualizarTicket(Ticket ticket)
        {
            var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@ticket_id",            ticket.TicketId.ToString()),
                    _acceso.CrearParametro("@asunto",               ticket.Asunto),
                    _acceso.CrearParametro("@descripcion",          ticket.Descripcion),
                    _acceso.CrearParametro("@categoria_id",         ticket.CategoriaId.ToString()),
                    _acceso.CrearParametro("@prioridad_id",         ticket.PrioridadId.ToString()),
                    _acceso.CrearParametro("@estado_id",            ticket.EstadoId.ToString()),
                    _acceso.CrearParametro(
                        "@usuario_aprobador_id",
                        ticket.UsuarioAprobadorId.HasValue
                            ? ticket.UsuarioAprobadorId.Value.ToString()
                            : DBNull.Value.ToString()
                    ),
                    _acceso.CrearParametro(
                        "@grupo_tecnico_id",
                        ticket.GrupoTecnicoId.HasValue
                            ? ticket.GrupoTecnicoId.Value.ToString()
                            : DBNull.Value.ToString()
                    ),
                    _acceso.CrearParametro(
                        "@tecnico_id",
                        ticket.TecnicoId.HasValue
                            ? ticket.TecnicoId.Value.ToString()
                            : DBNull.Value.ToString()
                    ),
                    // <-- Nuevo parámetro eliminado
                    _acceso.CrearParametro(
                        "@eliminado",
                        ticket.Eliminado ? "1" : "0"
                    ),
                    _acceso.CrearParametro(
                        "@fecha_ultima_modif",
                        ticket.FechaUltimaModif.ToString("o")
                    )
                };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarTicket", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void GuardarTicket(Ticket ticket)
        {
            // parámetros “obligatorios” (todos con tipos correctos)
              var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@TicketId",          ticket.TicketId),
                    _acceso.CrearParametro("@ClienteCreadorId",  ticket.ClienteCreador.ClienteId),
                    _acceso.CrearParametro("@FechaCreacion",     ticket.FechaCreacion),
                    _acceso.CrearParametro("@FechaUltimaModif",  ticket.FechaUltimaModif),
                    _acceso.CrearParametro("@Eliminado",         ticket.Eliminado),
                    _acceso.CrearParametro("@Asunto",            ticket.Asunto),
                    _acceso.CrearParametro("@Descripcion",       ticket.Descripcion),
                    
                    _acceso.CrearParametro("@CategoriaId",       ticket.CategoriaId),
                    _acceso.CrearParametro("@PrioridadId",       ticket.PrioridadId),
                    _acceso.CrearParametro("@EstadoId",          ticket.EstadoId)
                };

            // parámetros “opcionales”, solo si tienen valor
            if (ticket.FechaCierre.HasValue)
                parametros.Add(_acceso.CrearParametro("@FechaCierre", ticket.FechaCierre.Value));
            if (ticket.UsuarioAprobadorId.HasValue)
                parametros.Add(_acceso.CrearParametro("@UsuarioAprobadorId", ticket.UsuarioAprobadorId.Value));
            if (ticket.GrupoTecnicoId.HasValue)
                parametros.Add(_acceso.CrearParametro("@GrupoTecnicoId", ticket.GrupoTecnicoId.Value));
            if (ticket.TecnicoId.HasValue)
                parametros.Add(_acceso.CrearParametro("@TecnicoId", ticket.TecnicoId.Value));


            try
            {
                _acceso.Abrir();
            
                _acceso.Escribir("sp_GuardarTicket", parametros);

            }
            catch
            {
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public List<Ticket> ListarTicketsDelDepartamento(int departamentoId)
        {
            var lista = new List<Ticket>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@departamento_id", departamentoId.ToString())
            };

            try
            {
                _acceso.Abrir();

                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarTicketsDelDepartamento", parametros))
                {
                    while (reader.Read())
                    lista.Add(MapearTicket(reader));
                }
            
            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
        }

        public List<Ticket> ListarTicketsDeCliente(int clienteId)
        {
            var lista = new List<Ticket>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@cliente_id", clienteId.ToString())
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarTicketsDeCliente", parametros))
                {
                    while (reader.Read())
                        lista.Add(MapearTicket(reader));
                }

            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
        }


        public Ticket ObtenerTicketPorId(Guid ticketId)
        {
            Ticket ticket = null;
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", ticketId.ToString())
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerTicketPorId", parametros))
                {
                    if (reader.Read())
                    {
                        ticket = MapearTicket(reader);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return ticket;
        }
    }
}


