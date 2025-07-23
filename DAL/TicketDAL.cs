using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                Numero = reader.GetInt32(reader.GetOrdinal("numero")),
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
                DigitoVerificadorH = reader.IsDBNull(reader.GetOrdinal("digito_verificador_h"))
                                     ? null
                                     : reader.GetString(reader.GetOrdinal("digito_verificador_h")),
                Comentarios = new List<Comentario>(),
                Historicos = new List<TicketHistorico>()
            };
        }

        public void GuardarTicket(Ticket ticket)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticket.TicketId),
                _acceso.CrearParametro("@FechaCreacion", ticket.FechaCreacion),
                _acceso.CrearParametro("@FechaUltimaModif", ticket.FechaUltimaModif),
                _acceso.CrearParametro("@Eliminado", ticket.Eliminado),
                _acceso.CrearParametro("@Asunto", ticket.Asunto),
                _acceso.CrearParametro("@Descripcion", ticket.Descripcion),
                _acceso.CrearParametro("@ClienteCreadorId", ticket.ClienteCreadorId),
                _acceso.CrearParametro("@CategoriaId", ticket.CategoriaId),
                _acceso.CrearParametro("@PrioridadId", ticket.PrioridadId),
                _acceso.CrearParametro("@EstadoId", ticket.EstadoId)
            };

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
                using (var reader = _acceso.EjecutarLectura("sp_GuardarTicket", parametros))
                {
                    if (reader.Read())
                        ticket.Numero = reader.GetInt32(reader.GetOrdinal("NuevoNumero"));
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void ActualizarTicket(Ticket ticket)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", ticket.TicketId),
                _acceso.CrearParametro("@asunto", ticket.Asunto),
                _acceso.CrearParametro("@descripcion", ticket.Descripcion),
                _acceso.CrearParametro("@categoria_id", ticket.CategoriaId),
                _acceso.CrearParametro("@prioridad_id", ticket.PrioridadId),
                _acceso.CrearParametro("@estado_id", ticket.EstadoId),
                _acceso.CrearParametro("@usuario_aprobador_id", ticket.UsuarioAprobadorId),
                _acceso.CrearParametro("@grupo_tecnico_id", ticket.GrupoTecnicoId),
                _acceso.CrearParametro("@tecnico_id", ticket.TecnicoId),
                _acceso.CrearParametro("@eliminado", ticket.Eliminado),
                _acceso.CrearParametro("@fecha_ultima_modif", ticket.FechaUltimaModif)
            };

            try
            {
                _acceso.Abrir();
                // Ahora usamos EjecutarLectura para consumir el OUTPUT inserted.numero
                using (var reader = _acceso.EjecutarLectura("sp_ActualizarTicket", parametros))
                {
                    if (reader.Read())
                        ticket.Numero = reader.GetInt32(reader.GetOrdinal("NuevoNumero"));
                }
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
                _acceso.CrearParametro("@departamento_id", departamentoId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarTicketsDelDepartamento", parametros))
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
                _acceso.CrearParametro("@cliente_id", clienteId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarTicketsDeCliente", parametros))
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

        public List<Ticket> ListarTodos()
        {
            var lista = new List<Ticket>();

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarTodosTickets"))
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

        public List<Ticket> ListarTicketsParaAprobacion(int usuarioAprobadorId, int estadoId)
        {
            var lista = new List<Ticket>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@usuario_aprobador_id", usuarioAprobadorId),
                _acceso.CrearParametro("@estado_id", estadoId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarTicketsParaAprobacion", parametros))
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

        public List<Ticket> ListarTicketsPorGrupoTecnico(int grupoId)
        {
            var lista = new List<Ticket>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@grupo_tecnico_id", grupoId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarTicketsPorGrupoTecnico", parametros))
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
                _acceso.CrearParametro("@ticket_id", ticketId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerTicketPorId", parametros))
                {
                    if (reader.Read())
                        ticket = MapearTicket(reader);
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return ticket;
        }

        public void ActualizarDVH(Guid ticketId, string dvh)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id", ticketId),
                _acceso.CrearParametro("@dvh", dvh)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarDVHTicket", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
