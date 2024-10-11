using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CampoDAL
    {
        private string _connectionString = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";

        // Método para agregar un nuevo campo (sin necesidad de especificar el Id)
        public void AgregarCampo(Campo campo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Campo (Nombre, Descripcion, Estado) VALUES (@Nombre, @descripcion, @Estado)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", campo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", campo.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", campo.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar un campo existente
        public void ActualizarCampo(Campo campo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Campo SET Nombre = @Nombre, Descripcion = @descripcion, Estado = @Estado WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", campo.Id);
                    cmd.Parameters.AddWithValue("@Nombre", campo.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", campo.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", campo.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un campo por su Id
        public void EliminarCampo(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Campo WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener un campo por su Id
        public Campo ObtenerCampoPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Descripcion, Estado FROM Campo WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Campo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Método para listar todos los campos
        public List<Campo> ListarTodosLosCampos()
        {
            List<Campo> campos = new List<Campo>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Descripcion, Estado FROM Campo";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            campos.Add(new Campo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }
            return campos;
        }

        public List<Campo> ListarCamposPorCategoria(int categoriaId)
        {
            List<Campo> campos = new List<Campo>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT c.Id, c.Nombre, c.Descripcion, c.Estado, c.Valor " +
                    "FROM Campo c " +
                    "INNER JOIN CategoriaCampo cc ON c.Id = cc.CampoId " +
                    "WHERE cc.CategoriaId = @CategoriaId", conn);
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        campos.Add(new Campo
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Estado = (bool)reader["Estado"],
                            //Valor = reader["Valor"].ToString()  eso lo tengoque revisar
                        });
                    }
                }
            }
            return campos;
        }
    }
}
