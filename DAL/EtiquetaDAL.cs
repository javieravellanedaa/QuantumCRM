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
    public class EtiquetaDAL : AbstractDAL<BE.Etiqueta>
    {
        private string _connectionString;

        public EtiquetaDAL()
        {
        // USAR LA CLASE ACCESO!!
            _connectionString = "Integrated Security=SSPI;Data Source=.\\SQLEXPRESS;Initial Catalog=CRM";
        }

        public IList<IEtiqueta> ObtenerEtiquetas()
        {
            IList<IEtiqueta> etiquetas = new List<IEtiqueta>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Etiqueta", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        etiquetas.Add(new BE.Etiqueta
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id")),
                            Nombre = reader.GetString(reader.GetOrdinal("name"))
                        });
                    }
                }
            }
            return etiquetas;
        }
    }
}
