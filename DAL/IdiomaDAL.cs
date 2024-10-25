using System;
using System.Collections.Generic;
using BE;
using INTERFACES;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class IdiomaDAL : AbstractDAL<BE.Idioma>
    {
        private readonly Acceso acceso;

        public IdiomaDAL()
        {
            acceso = new Acceso();
        }

        // Método para obtener todos los idiomas usando un SP
        public IList<Idioma> ObtenerIdiomas()
        {
            List<Idioma> idiomas = new List<Idioma>();

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerIdiomas"))
                {
                    while (reader.Read())
                    {
                        Idioma idioma = new Idioma
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("idioma_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                        idiomas.Add(idioma);
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return idiomas;
        }

        // Método para agregar un nuevo idioma usando un SP
        public bool AgregarIdioma(string nombre)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdiomaId", Guid.NewGuid().ToString()),
                acceso.CrearParametro("@Nombre", nombre)
            };

            try
            {
                acceso.Abrir();
                int rowsAffected = acceso.Escribir("SP_InsertarIdioma", parameters);
                return rowsAffected > 0;
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
