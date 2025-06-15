using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ControlDeCambiosDAL
    {
        private readonly Acceso _acceso;

        public ControlDeCambiosDAL()
        {
            _acceso = new Acceso();
        }

        #region ► INSERT

        public void Guardar(ControlDeCambios cambio)
        {
            const string sql = @"
INSERT INTO ControlDeCambios
    (Tabla, EntityId, Propiedad, ValorViejo, ValorNuevo, CambiadoPor, FechaCambio, TipoOperacion)
VALUES
    (@Tabla, @EntityId, @Propiedad, @ValorViejo, @ValorNuevo, @CambiadoPor, @FechaCambio, @TipoOperacion)";

            _acceso.Abrir();
            try
            {
                using (var cmd = new SqlCommand(sql, _acceso.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@Tabla", cambio.Tabla);
                    cmd.Parameters.AddWithValue("@EntityId", cambio.EntityId);
                    cmd.Parameters.AddWithValue("@Propiedad", (object)cambio.Propiedad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ValorViejo", (object)cambio.ValorViejo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ValorNuevo", (object)cambio.ValorNuevo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CambiadoPor", cambio.CambiadoPor);
                    cmd.Parameters.AddWithValue("@FechaCambio", cambio.FechaCambio);
                    cmd.Parameters.AddWithValue("@TipoOperacion", (char)cambio.TipoOperacion);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        #endregion

        #region ► SELECTs

        public IEnumerable<ControlDeCambios> ObtenerTodos()
        {
            const string sql = @"
SELECT LogId, Tabla, EntityId, Propiedad, ValorViejo, ValorNuevo,
       CambiadoPor, FechaCambio, TipoOperacion
FROM   ControlDeCambios";

            return EjecutarConsulta(sql);
        }

        public IEnumerable<ControlDeCambios> ObtenerHasta(DateTime fechaHasta)
        {
            const string sql = @"
SELECT LogId, Tabla, EntityId, Propiedad, ValorViejo, ValorNuevo,
       CambiadoPor, FechaCambio, TipoOperacion
FROM   ControlDeCambios
WHERE  FechaCambio <= @FechaHasta";

            return EjecutarConsulta(sql, p =>
            {
                p.AddWithValue("@FechaHasta", fechaHasta);
            });
        }

        public IEnumerable<string> ObtenerTablas()
        {
            var tablas = new List<string>();

            _acceso.Abrir();
            try
            {
                using (var cmd = new SqlCommand(
                    "SELECT DISTINCT Tabla FROM ControlDeCambios ORDER BY Tabla",
                    _acceso.ObtenerConexion()))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        tablas.Add(rd.GetString(0));
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return tablas;
        }

        #endregion

        #region ► UPDATE (Revertir)

        /// <summary>
        /// Restaura el valor anterior de una propiedad en la tabla indicada.
        /// </summary>
        public void RevertirCambio(string tabla, Guid entityId, string propiedad, string valorAnterior)
        {
            // Escapamos nombres para evitar inyección en identificadores
            var tablaEsc = tabla.Replace("]", "]]");
            var propEsc = propiedad.Replace("]", "]]");

            var sql = $@"
UPDATE [{tablaEsc}]
SET    [{propEsc}] = @ValorAnterior
WHERE  EntityId    = @EntityId";

            _acceso.Abrir();
            try
            {
                using (var cmd = new SqlCommand(sql, _acceso.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@ValorAnterior", valorAnterior);
                    cmd.Parameters.AddWithValue("@EntityId", entityId);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        #endregion

        #region ► Utilidad interna

        private IEnumerable<ControlDeCambios> EjecutarConsulta(
            string sql,
            Action<SqlParameterCollection> bind = null)
        {
            var lista = new List<ControlDeCambios>();

            _acceso.Abrir();
            try
            {
                using (var cmd = new SqlCommand(sql, _acceso.ObtenerConexion()))
                {
                    bind?.Invoke(cmd.Parameters);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ControlDeCambios
                            {
                                LogId = reader.GetInt64(0),
                                Tabla = reader.GetString(1),
                                EntityId = reader.GetGuid(2),
                                Propiedad = reader.IsDBNull(3) ? null : reader.GetString(3),
                                ValorViejo = reader.IsDBNull(4) ? null : reader.GetString(4),
                                ValorNuevo = reader.IsDBNull(5) ? null : reader.GetString(5),
                                CambiadoPor = reader.GetGuid(6),
                                FechaCambio = reader.GetDateTime(7),
                                TipoOperacion = (TipoDeOperacion)reader.GetString(8)[0]
                            });
                        }
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return lista;
        }

        #endregion
    }
}
