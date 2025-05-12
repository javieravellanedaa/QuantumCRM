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

        public void Insertar(TicketHistorico historico)
        {
            var parametros = new List<SqlParameter>
            {
       
                _acceso.CrearParametro("@TicketId", historico.TicketId.ToString()),
                _acceso.CrearParametro("@FechaCambio", historico.FechaCambio.ToString("o")),
                _acceso.CrearParametro("@UsuarioCambioId", historico.UsuarioCambioId.ToString()),
                _acceso.CrearParametro("@TipoEvento", historico.TipoEvento),
                _acceso.CrearParametro(
                    "@ValorAnteriorId",
                    historico.ValorAnteriorId.HasValue
                        ? historico.ValorAnteriorId.Value.ToString()
                        : DBNull.Value.ToString()
                ),
                _acceso.CrearParametro(
                    "@ValorNuevoId",
                    historico.ValorNuevoId.HasValue
                        ? historico.ValorNuevoId.Value.ToString()
                        : DBNull.Value.ToString()
                ),
                _acceso.CrearParametro(
                    "@Comentario",
                    string.IsNullOrEmpty(historico.Comentario)
                        ? DBNull.Value.ToString()
                        : historico.Comentario
                )
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
    }
}
