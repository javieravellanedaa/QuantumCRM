// DAL/TicketDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class TicketDAL
    {
        private readonly Acceso _acceso = new Acceso();
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
                var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_id",             ticket.TicketId.ToString()),
                _acceso.CrearParametro("@fecha_creacion",        ticket.FechaCreacion.ToString("o")),
                _acceso.CrearParametro("@fecha_ultima_modif",    ticket.FechaUltimaModif.ToString("o")),
                _acceso.CrearParametro(
                    "@fecha_cierre",
                    ticket.FechaCierre.HasValue
                        ? ticket.FechaCierre.Value.ToString("o")
                        : DBNull.Value.ToString()
                ),
                _acceso.CrearParametro("@eliminado",             ticket.Eliminado ? "1" : "0"),
                _acceso.CrearParametro("@asunto",                ticket.Asunto),
                _acceso.CrearParametro("@descripcion",           ticket.Descripcion),
                _acceso.CrearParametro("@cliente_creador_id",    ticket.ClienteCreadorId.ToString()),
                _acceso.CrearParametro("@categoria_id",          ticket.CategoriaId.ToString()),
                _acceso.CrearParametro("@prioridad_id",          ticket.PrioridadId.ToString()),
                _acceso.CrearParametro("@estado_id",             ticket.EstadoId.ToString()),
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
                )
            };

                try
                {
                    _acceso.Abrir();
                    _acceso.Escribir("sp_GuardarTicket", parametros);
                }
                finally
                {
                    _acceso.Cerrar();
                }
            }
        }
    }


