using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{

    internal class Acceso
    {

        SqlConnection conexion;
        SqlTransaction tx;
        public Acceso()
        {


        }

        public SqlConnection ObtenerConexion()
        {

            return conexion;
        }   

        public void Abrir()
        {
            string cns = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";
            conexion = new SqlConnection();
            conexion.ConnectionString = cns;
            conexion.Open();
        }

        public void Cerrar()
        {
       
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        public void ComenzarTransaccion()
        {

            if (tx == null)
            {

                tx = conexion.BeginTransaction();
            }
            else tx.Dispose();

        }

        public void CancelarTransaccion()
        {

            if (tx != null)
            {

                tx.Rollback();
                tx.Dispose();
                tx = null;
            }

        }

        public void ConfirmarTransaccion()
        {

            if (tx != null)
            {

                tx.Commit();
                tx.Dispose();
                tx = null;
            }

        }



        private SqlCommand CrearComando(string nombre, List<SqlParameter> pars=null)
        {

            SqlCommand cmd = new SqlCommand(nombre, conexion);
            if (tx != null)
            {

                cmd.Transaction = tx;
            }

            if (pars != null && pars.Count > 0)
            {

                cmd.Parameters.AddRange(pars.ToArray());
            }

            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        // revisar esta función que no devuelve nada
        public DataTable Leer(string nombre, List<SqlParameter> pars = null)
        {

            DataTable tabla = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter())
            {

                da.SelectCommand = CrearComando(nombre, pars);
                da.Fill(tabla);
                da.Dispose();
            }

            return tabla; // aca viene vacía la tabla revisar
        }

        public SqlDataReader EjecutarLectura(string nombre, List<SqlParameter> pars = null)
        {
            SqlCommand cmd = CrearComando(nombre, pars);
            return cmd.ExecuteReader(); // Retorna el SqlDataReader
        }


        public int Escribir(string nombre, List<SqlParameter> pars = null)
        {

            int FilasAfectadas = 0;
            using (SqlCommand cmd = CrearComando(nombre, pars))
            {

                try
                {

                    FilasAfectadas = cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {

                    FilasAfectadas = -1;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

            return FilasAfectadas;
        }

        public object EscribirEscalar(string nombre, List<SqlParameter> pars = null)
        {

            object retorno = null;
            using (SqlCommand cmd = CrearComando(nombre, pars))
            {

                try
                {

                    retorno = cmd.ExecuteScalar();
                }

                catch (Exception ex)
                {

                    retorno = "-1";
                }

                cmd.Dispose();
            }

            return retorno;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {

            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {

            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, float valor)
        {

            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Single;
            return parametro;
        }
        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.DateTime;
            return parametro;
        }
        public SqlParameter CrearParametro(string nombre, bool valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Boolean;
            return parametro;
        }


        public SqlParameter CrearParametro(string nombre, DateTime? valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor.HasValue ? (object)valor.Value : DBNull.Value);
            parametro.DbType = DbType.DateTime;
            return parametro;
        }





        public SqlParameter CrearParametro(string nombre, long valor)
        {

            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Int64;
            return parametro;
        }

    }

}

