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
                        categoria.Id = Convert.ToInt32(cmd.ExecuteScalar());

                        // Insertar los campos asociados en la tabla puente
                        foreach (var campoId in idsCampos)
                        {
                            cmd = new SqlCommand("INSERT INTO CategoriaCampo (CategoriaId, CampoId) VALUES (@CategoriaId, @CampoId)", conn, transaction);
                            cmd.Parameters.AddWithValue("@CategoriaId", categoria.Id);
                            cmd.Parameters.AddWithValue("@CampoId", campoId);
                            cmd.ExecuteNonQuery();
                        }

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
                    cmd.Parameters.AddWithValue("@Id", categoria.Id);
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
                string sql = "SELECT Id, Nombre, Estado FROM Categoria WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", categoriaId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado")),
                                Campos = ObtenerCamposPorCategoriaId(categoriaId)  // Obtener los campos asociados
                            };
                        }
                    }
                }
            }
            return categoria;
        }

        // Listar todas las categorías
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Estado FROM Categoria";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoriaId = reader.GetInt32(reader.GetOrdinal("Id"));
                            var categoria = new Categoria
                            {
                                Id = categoriaId,
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado")),
                                Campos = ObtenerCamposPorCategoriaId(categoriaId)  // Obtener los campos asociados
                            };
                            categorias.Add(categoria);
                        }
                    }
                }
            }
            return categorias;
        }

        

        // Obtener campos asociados a una categoría por su Id
        private List<Campo> ObtenerCamposPorCategoriaId(int categoriaId)
        {
            List<Campo> campos = new List<Campo>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT c.Id, c.Nombre, c.Descripcion, c.Estado " +
                             "FROM Campo c " +
                             "INNER JOIN CategoriaCampo cc ON c.Id = cc.CampoId " +
                             "WHERE cc.CategoriaId = @CategoriaId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
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
    }
}
