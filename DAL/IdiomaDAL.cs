using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using INTERFACES;

namespace DAL
{
    public class IdiomaDAL : AbstractDAL<BE.Idioma>
    {
        private string _connectionString;

        public IdiomaDAL()
        {
            // usar clase acceso!!!
            _connectionString = "Integrated Security=SSPI;Data Source=.\\SQLEXPRESS;Initial Catalog=CRM";
        }

        public IList<Idioma> ObtenerIdiomas()
        {
            List<Idioma> idiomas = new List<Idioma>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT idioma_id, nombre FROM Idiomas ORDER BY idioma_id ASC", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
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
            return idiomas;
        }

        public bool AgregarIdioma(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Idiomas (id, name) VALUES (@id, @name)", conn);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@name", nombre);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
    }
}

