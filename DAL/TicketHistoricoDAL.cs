// DAL/TicketHistoricoDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class TicketHistoricoDAL
    {
        private readonly Acceso _acceso = new Acceso();

        /// <summary>
        /// Inserta un nuevo registro de historial en la base de datos.
        /// </summary>
        public void Insertar(TicketHistorico historico)
        {
            var parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@ticket_id", historico.TicketId),
        _acceso.CrearParametro("@usuario_id", historico.UsuarioCambioId),
        _acceso.CrearParametro("@fecha_cambio", historico.FechaCambio),
        _acceso.CrearParametro("@TipoEvento", historico.TipoEvento ?? string.Empty),
        _acceso.CrearParametro("@ValorAnteriorId", historico.ValorAnteriorId),
        _acceso.CrearParametro("@ValorNuevoId", historico.ValorNuevoId),
        _acceso.CrearParametro("@comentario", string.IsNullOrEmpty(historico.Comentario) ? null : historico.Comentario)
    };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_InsertarTicketHistorico", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        /// <summary>
        /// Devuelve la lista de registros de historial asociados a un ticket específico.
        /// </summary>
        public List<TicketHistorico> ListarPorTicket(Guid ticketId)
        {
            var resultado = new List<TicketHistorico>();

            try
            {
                _acceso.Abrir();
                // Usamos EjecutarLectura para obtener SqlDataReader
                var dr = _acceso.EjecutarLectura(
                    "sp_ListarTicketHistoricoPorTicket",
                    new List<SqlParameter>
                    {
                        _acceso.CrearParametro("@ticket_id", ticketId)
                    }
                );

                while (dr.Read())
                {
                    var hist = new TicketHistorico
                    {
                        TicketHistoricoId = Convert.ToInt32(dr["ticket_historial_id"]),
                        TicketId = Guid.Parse(dr["ticket_id"].ToString()),
                        FechaCambio = Convert.ToDateTime(dr["fecha_cambio"]),
                        UsuarioCambioId = Guid.Parse(dr["usuario_id"].ToString()),
                        TipoEvento = dr["TipoEvento"].ToString(),
                        ValorAnteriorId = dr["ValorAnteriorId"] != DBNull.Value
                                                 ? (int?)Convert.ToInt32(dr["ValorAnteriorId"])
                                                 : null,
                        ValorNuevoId = dr["ValorNuevoId"] != DBNull.Value
                                                 ? (int?)Convert.ToInt32(dr["ValorNuevoId"])
                                                 : null,
                        Comentario = dr["comentario"] != DBNull.Value
                                                 ? dr["Comentario"].ToString()
                                                 : null
                    };

                    resultado.Add(hist);
                }

                dr.Close();
            }
            finally
            {
                _acceso.Cerrar();
            }

            return resultado;
        }
    }
}
