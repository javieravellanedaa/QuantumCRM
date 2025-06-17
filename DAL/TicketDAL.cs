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
                // —— NUEVO —— carga del DVH
                DigitoVerificadorH = reader.IsDBNull(reader.GetOrdinal("digito_verificador_h"))
                                         ? null
                                         : reader.GetString(reader.GetOrdinal("digito_verificador_h")),

                Comentarios = new List<Comentario>(),
                Historicos = new List<TicketHistorico>()
            };
        }

        public void ActualizarTicket(Ticket ticket)
        {
            // Creamos la lista de parámetros usando las sobrecargas adecuadas de CrearParametro
            var parametros = new List<SqlParameter>
    {
        // @ticket_id         UNIQUEIDENTIFIER
        // En la clase Acceso existe la sobrecarga CrearParametro(string, Guid?)
        // Pasamos ticket.TicketId como Guid (se convierte implícitamente a Guid?)
        _acceso.CrearParametro("@ticket_id", ticket.TicketId),

        // @asunto            NVARCHAR(50)
        // Sobre carga CrearParametro(string, string) → DbType.String → NVARCHAR
        _acceso.CrearParametro("@asunto", ticket.Asunto),

        // @descripcion       NVARCHAR(150)
        _acceso.CrearParametro("@descripcion", ticket.Descripcion),

        // @categoria_id      INT
        _acceso.CrearParametro("@categoria_id", ticket.CategoriaId),

        // @prioridad_id      INT
        _acceso.CrearParametro("@prioridad_id", ticket.PrioridadId),

        // @estado_id         INT
        _acceso.CrearParametro("@estado_id", ticket.EstadoId),

        // @usuario_aprobador_id  INT = NULL
        // ticket.UsuarioAprobadorId es int?; si es null, la sobrecarga lo pone como DBNull
        _acceso.CrearParametro("@usuario_aprobador_id", ticket.UsuarioAprobadorId),

        // @grupo_tecnico_id   INT = NULL
        _acceso.CrearParametro("@grupo_tecnico_id", ticket.GrupoTecnicoId),

        // @tecnico_id        INT = NULL
        _acceso.CrearParametro("@tecnico_id", ticket.TecnicoId),

        // @eliminado         BIT
        // Sobre carga CrearParametro(string, bool) → DbType.Boolean → BIT
        _acceso.CrearParametro("@eliminado", ticket.Eliminado),

        // @fecha_ultima_modif DATETIME
        _acceso.CrearParametro("@fecha_ultima_modif", ticket.FechaUltimaModif)
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
        public List<Ticket> ListarTodos()
        {
            var lista = new List<Ticket>();

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarTodosTickets"))
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearTicket(reader));
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
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


        /// <summary>
        /// Devuelve todos los tickets asignados a un aprobador en un estado concreto.
        /// </summary>
        public List<Ticket> ListarTicketsParaAprobacion(int usuarioAprobadorId, int estadoId)
        {
            var lista = new List<Ticket>();
            var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@usuario_aprobador_id", usuarioAprobadorId),
                    _acceso.CrearParametro("@estado_id",           estadoId)
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
            var pars = new List<SqlParameter> { _acceso.CrearParametro("@grupo_tecnico_id", grupoId) };
            _acceso.Abrir();
            using (var reader = _acceso.EjecutarLectura("sp_ListarTicketsPorGrupoTecnico", pars))
                while (reader.Read())
                    lista.Add(MapearTicket(reader));
            _acceso.Cerrar();
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


