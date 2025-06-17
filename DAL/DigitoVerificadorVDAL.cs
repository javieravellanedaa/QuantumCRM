using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DigitoVerificadorVDAL
    {
        private readonly Acceso acceso;

        public DigitoVerificadorVDAL()
        {
            acceso = new Acceso();
        }

        /// <summary>
        /// Obtiene el DVV almacenado para una tabla específica.
        /// </summary>
        public string ObtenerDVV(string nombreTabla)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Tabla", nombreTabla)
            };

            try
            {
                acceso.Abrir();
                var tabla = acceso.Leer("sp_ObtenerDVV", parametros);
                if (tabla.Rows.Count > 0)
                {
                    return tabla.Rows[0]["valor_dv"].ToString();
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return null;
        }

        /// <summary>
        /// Inserta o actualiza el DVV para una tabla específica.
        /// </summary>
        public void ActualizarDVV(string nombreTabla, string valorDV)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Tabla", nombreTabla),
                acceso.CrearParametro("@ValorDV", valorDV)
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_ActualizarDVV", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
