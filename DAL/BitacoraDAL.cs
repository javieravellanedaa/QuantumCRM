using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class BitacoraDAL
    {
        private Bitacora MapBitacora(SqlDataReader reader)
        {
            return new Bitacora
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                FechaHora = reader.GetDateTime(reader.GetOrdinal("FechaHora")),
                UsuarioId = reader.GetGuid(reader.GetOrdinal("UsuarioId")),
                UsuarioNombre = reader.GetString(reader.GetOrdinal("UsuarioNombre")),
                Clase = reader.GetString(reader.GetOrdinal("Clase")),
                Accion = reader.GetString(reader.GetOrdinal("Accion")),
                InfoAdicional = reader.IsDBNull(reader.GetOrdinal("InfoAdicional"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("InfoAdicional"))
            };
        }

        public IList<Bitacora> ObtenerEntradas(DateTime? desde = null, DateTime? hasta = null,
                                                Guid? usuarioId = null, string clase = null, string accion = null)
        {
            var lista = new List<Bitacora>();
            var acceso = new Acceso();

            try
            {
                acceso.Abrir();

                var sql = @"
                    SELECT Id, FechaHora, UsuarioId, UsuarioNombre, Clase, Accion, InfoAdicional
                    FROM dbo.Bitacora
                    WHERE 1=1";

                var parametros = new List<SqlParameter>();

                if (desde.HasValue)
                {
                    sql += " AND FechaHora >= @desde";
                    parametros.Add(acceso.CrearParametro("@desde", desde.Value));
                }

                if (hasta.HasValue)
                {
                    sql += " AND FechaHora <= @hasta";
                    parametros.Add(acceso.CrearParametro("@hasta", hasta.Value));
                }

                if (usuarioId.HasValue)
                {
                    parametros.Add(acceso.CrearParametro("@usuarioId", usuarioId));
                    sql += " AND UsuarioId = @usuarioId";
                }

                if (!string.IsNullOrWhiteSpace(clase))
                {
                    sql += " AND Clase LIKE @clase";
                    parametros.Add(new SqlParameter("@clase", $"%{clase}%"));
                }

                if (!string.IsNullOrWhiteSpace(accion))
                {
                    sql += " AND Accion LIKE @accion";
                    parametros.Add(new SqlParameter("@accion", $"%{accion}%"));
                }

                var cmd = CrearCommandManual(sql, acceso, parametros);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(MapBitacora(reader));
                }

                reader.Close();
            }
            finally
            {
                acceso.Cerrar();
            }

            return lista;
        }

        public bool AgregarEntrada(Bitacora entrada)
        {
            var acceso = new Acceso();
            try
            {
                acceso.Abrir();

                const string sql = @"
                    INSERT INTO dbo.Bitacora 
                    (Id, FechaHora, UsuarioId, UsuarioNombre, Clase, Accion, InfoAdicional)
                    VALUES 
                    (@Id, @FechaHora, @UsuarioId, @UsuarioNombre, @Clase, @Accion, @InfoAdicional)";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Id", entrada.Id),
                    new SqlParameter("@FechaHora", entrada.FechaHora),
                    new SqlParameter("@UsuarioId", entrada.UsuarioId),
                    new SqlParameter("@UsuarioNombre", entrada.UsuarioNombre),
                    new SqlParameter("@Clase", entrada.Clase),
                    new SqlParameter("@Accion", entrada.Accion),
                    new SqlParameter("@InfoAdicional", (object)entrada.InfoAdicional ?? DBNull.Value)
                };

                var cmd = CrearCommandManual(sql, acceso, parametros);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        // Método auxiliar para crear comandos SQL "manuales" (no SP)
        private SqlCommand CrearCommandManual(string sql, Acceso acceso, List<SqlParameter> parametros = null)
        {
            // Crea el SqlCommand accediendo al campo interno a través de reflejo
            var conexion = acceso.GetType().GetField("conexion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(acceso) as SqlConnection;

            var cmd = new SqlCommand(sql, conexion);

            if (parametros != null && parametros.Count > 0)
                cmd.Parameters.AddRange(parametros.ToArray());

            return cmd;
        }
    }
}           
