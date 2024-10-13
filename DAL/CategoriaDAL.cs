using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaDAL
    {
        private string _connectionString = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";

        // Agregar una nueva categoría con campos asociados
        public void AgregarCategoria(Categoria categoria, List<int> idsCampos)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insertar la nueva categoría y obtener el Id generado
                        SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (Nombre, Estado) VALUES (@Nombre, @Estado); SELECT SCOPE_IDENTITY();", conn, transaction);
                        cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                        cmd.Parameters.AddWithValue("@Estado", categoria.Estado);
                        categoria.CategoriaId = Convert.ToInt32(cmd.ExecuteScalar());



                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Actualizar una categoría existente
        public void ActualizarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Categoria SET Nombre = @Nombre, Estado = @Estado WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", categoria.CategoriaId);
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.Estado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una categoría y sus asociaciones con campos
        public void EliminarCategoria(int categoriaId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Eliminar asociaciones en la tabla puente
                        SqlCommand cmd = new SqlCommand("DELETE FROM CategoriaCampo WHERE CategoriaId = @CategoriaId", conn, transaction);
                        cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                        cmd.ExecuteNonQuery();

                        // Eliminar la categoría
                        cmd = new SqlCommand("DELETE FROM Categoria WHERE Id = @Id", conn, transaction);
                        cmd.Parameters.AddWithValue("@Id", categoriaId);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Obtener una categoría por su Id
        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            Categoria categoria = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Consulta SQL para hacer JOIN con la tabla de estados y obtener el nombre del estado
                string sql = @"SELECT c.categoria_id AS Id, c.nombre AS Nombre, e.nombre AS EstadoNombre
                       FROM categorias c
                       JOIN estados_categoria e ON c.estado_categoria_id = e.estado_categoria_id
                       WHERE c.categoria_id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", categoriaId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria
                            {
                                CategoriaId = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                // Se asigna el nombre del estado en el objeto EstadosCategoria
                                Estado = new EstadosCategoria
                                {
                                    Nombre = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                }
                            };
                        }
                    }
                }
            }

            return categoria;
        }

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Consulta SQL que hace un JOIN para obtener el nombre del estado
                string sql = @"SELECT c.categoria_id AS Id, c.nombre AS Nombre, e.nombre AS EstadoNombre
                       FROM categorias c
                       JOIN estados_categorias e ON c.estado_categoria_id = e.estado_categoria_id;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoriaId = reader.GetInt32(reader.GetOrdinal("Id"));

                            var categoria = new Categoria
                            {
                                CategoriaId = categoriaId,
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                // Aquí se crea el objeto EstadosCategoria y se asigna el nombre del estado
                                Estado = new EstadosCategoria
                                {
                                    Nombre = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                }
                            };

                            categorias.Add(categoria);
                        }
                    }
                }
            }
            return categorias;
        }




        // Obtener campos asociados a una categoría por su Id

    }
}
