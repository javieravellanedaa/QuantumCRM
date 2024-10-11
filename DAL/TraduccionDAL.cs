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
    public class TraduccionDAL : AbstractDAL<BE.Traduccion>
    {
        private string _connectionString;

        public TraduccionDAL()
        {
            // USAR LA CLASE ACCESO
            _connectionString = "Integrated Security=SSPI;Data Source=.\\SQLEXPRESS;Initial Catalog=CRM";
        }


        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            if (idioma == null)
            {
                throw new ArgumentNullException(nameof(idioma), "El parámetro idioma no puede ser nulo.");
            }

            IDictionary<string, ITraduccion> traducciones = new Dictionary<string, ITraduccion>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT t.traduccion_id, t.idioma_id, t.etiqueta_id, t.texto, e.nombre AS etiqueta FROM traducciones t INNER JOIN Etiquetas e ON t.etiqueta_id = e.etiqueta_id WHERE t.idioma_id = @IdiomaId", conn);
                cmd.Parameters.AddWithValue("@IdiomaId", idioma.Id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var etiquetaNombre = reader.GetString(reader.GetOrdinal("etiqueta"));
                        traducciones.Add(etiquetaNombre, new Traduccion
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("idioma_id")),
                            Texto = reader.GetString(reader.GetOrdinal("texto")),
                            Etiqueta = new Etiqueta
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("etiqueta_id")),
                                Nombre = etiquetaNombre
                            }
                        });
                    }
                }
            }
            return traducciones;
        }


        public List<Traduccion> ObtenerTraduccionesPorIdioma(Guid idiomaId)
        {
            List<Traduccion> traducciones = new List<Traduccion>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        e.id as EtiquetaId,
                        e.name as EtiquetaNombre,
                        ISNULL(t.id, NEWID()) as TraduccionId,
                        t.idioma_id as IdiomaId,
                        t.texto as Texto
                    FROM Etiqueta e
                    LEFT JOIN Traduccion t ON e.id = t.etiqueta_id AND t.idioma_id = @idioma_id
                    ORDER BY e.name ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idioma_id", idiomaId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Traduccion traduccion = new Traduccion
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("TraduccionId")),
                            IdiomaId = idiomaId,
                            EtiquetaId = reader.GetGuid(reader.GetOrdinal("EtiquetaId")),
                            Texto = reader.IsDBNull(reader.GetOrdinal("Texto")) ? string.Empty : reader.GetString(reader.GetOrdinal("Texto")),
                            EtiquetaNombre = reader.GetString(reader.GetOrdinal("EtiquetaNombre"))
                        };
                        traducciones.Add(traduccion);
                    }
                }
            }
            return traducciones;
        }


        public void GuardarTraduccion(Traduccion traduccion)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query;

                // Verificar si la traducción ya existe
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Traduccion WHERE id = @id", conn);
                checkCmd.Parameters.AddWithValue("@id", traduccion.Id);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Actualizar la traducción existente
                    query = @"
                    UPDATE Traduccion
                    SET texto = @texto
                    WHERE id = @id";
                }
                else
                {
                    // Insertar una nueva traducción
                    query = @"
                    INSERT INTO Traduccion (id, idioma_id, etiqueta_id, texto)
                    VALUES (@id, @idioma_id, @etiqueta_id, @texto)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", traduccion.Id);
                cmd.Parameters.AddWithValue("@idioma_id", traduccion.IdiomaId);
                cmd.Parameters.AddWithValue("@etiqueta_id", traduccion.EtiquetaId);
                cmd.Parameters.AddWithValue("@texto", (object)traduccion.Texto ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }


    }
}
