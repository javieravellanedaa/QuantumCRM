using BE;
using BE.PN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ValorCampoTicketDAL
    {
        private readonly Acceso _acceso = new Acceso();

        private ValorCampoTicket MapearDesdeReader(SqlDataReader reader)
        {
            return new ValorCampoTicket
            {
                Id = reader.GetInt32(reader.GetOrdinal("ValorId")),
                TicketId = reader.GetGuid(reader.GetOrdinal("TicketId")),
                DefinicionCampoPersonalizadoId = reader.GetInt32(reader.GetOrdinal("DefinicionCampoPersonalizadoId")),
                ValorTexto = reader.IsDBNull(reader.GetOrdinal("ValorTexto"))
                             ? null
                             : reader.GetString(reader.GetOrdinal("ValorTexto")),
                ValorNumero = reader.IsDBNull(reader.GetOrdinal("ValorNumero"))
                              ? (decimal?)null
                              : reader.GetDecimal(reader.GetOrdinal("ValorNumero")),
                ValorFecha = reader.IsDBNull(reader.GetOrdinal("ValorFecha"))
                             ? (DateTime?)null
                             : reader.GetDateTime(reader.GetOrdinal("ValorFecha"))
            };
        }

        public List<ValorCampoTicket> ListarPorTicket(Guid ticketId)
        {
            var lista = new List<ValorCampoTicket>();
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticketId)
            };
            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarValoresCampoTicket", pars))
                {
                    while (reader.Read())
                        lista.Add(MapearDesdeReader(reader));
                }
                return lista;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void EliminarPorTicket(Guid ticketId)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticketId)
            };
            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarValoresCampoTicket", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        /// <summary>
        /// Elimina un valor específico de campo personalizado por TicketId y DefinicionId
        /// </summary>
        public void EliminarPorTicketYDefinicion(Guid ticketId, int definicionId)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", ticketId),
                _acceso.CrearParametro("@DefinicionId", definicionId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarValorCampoTicketPorDefinicion", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Insertar(ValorCampoTicket valor)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@TicketId", valor.TicketId),
                _acceso.CrearParametro("@DefinicionId", valor.DefinicionCampoPersonalizadoId)
            };

            // ValorTexto
            pars.Add(_acceso.CrearParametro("@ValorTexto", valor.ValorTexto ?? string.Empty));

            // ValorNumero (decimal?)
            var paramNumero = new SqlParameter("@ValorNumero", SqlDbType.Decimal)
            {
                Value = valor.ValorNumero.HasValue
                            ? (object)valor.ValorNumero.Value
                            : DBNull.Value
            };
            pars.Add(paramNumero);

            // ValorFecha (DateTime?)
            var paramFecha = new SqlParameter("@ValorFecha", SqlDbType.DateTime)
            {
                Value = valor.ValorFecha.HasValue
                            ? (object)valor.ValorFecha.Value
                            : DBNull.Value
            };
            pars.Add(paramFecha);

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_InsertarValorCampoTicket", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}