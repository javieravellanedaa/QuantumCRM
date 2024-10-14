using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CategoriaDAL
    {
        private string _connectionString = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";

        // Agregar una nueva categoría con campos asociados
        public void AgregarCategoria(Categoria categoria, List<int> idsCampos)
        {
            // Instanciar EstadosCategoriaDAL para listar los estados
            EstadosCategoriaDAL estadosCategoriaDAL = new EstadosCategoriaDAL();
            List<EstadosCategoria> estadosCategorias = estadosCategoriaDAL.ListarEstadosCategoria();

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

                        // Aquí seleccionas el estado por algún criterio, por ejemplo el primer estado en la lista o uno específico
                        EstadosCategoria estadoSeleccionado = estadosCategorias.Find(e => e.EstadoCategoriaId == categoria.Estado.EstadoCategoriaId);

                        // Asignar el ID del estado seleccionado a la categoría
                        cmd.Parameters.AddWithValue("@Estado", estadoSeleccionado.EstadoCategoriaId);
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
            // Instanciar EstadosCategoriaDAL para listar los estados
            EstadosCategoriaDAL estadosCategoriaDAL = new EstadosCategoriaDAL();
            List<EstadosCategoria> estadosCategorias = estadosCategoriaDAL.ListarEstadosCategoria();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Categoria SET Nombre = @Nombre, Estado = @Estado WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", categoria.CategoriaId);
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);

                    // Aquí seleccionas el estado por algún criterio, por ejemplo el ID del estado
                    EstadosCategoria estadoSeleccionado = estadosCategorias.Find(e => e.EstadoCategoriaId == categoria.Estado.EstadoCategoriaId);

                    // Asignar el ID del estado seleccionado a la categoría
                    cmd.Parameters.AddWithValue("@Estado", estadoSeleccionado.EstadoCategoriaId);
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

        // Listar todas las categorías con sus estados
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            // Paso 1: Obtener todas las categorías sin hacer join con estados ni tipos
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"SELECT categoria_id, nombre, descripcion, estado_categoria_id, tipo_id, group_id, fecha_creacion, creador_id, aprobador_requerido 
                       FROM categorias";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = new Categoria
                            {
                                CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                                Estado = new EstadosCategoria
                                {
                                    EstadoCategoriaId = reader.GetInt32(reader.GetOrdinal("estado_categoria_id"))
                                }, // Solo asignamos el ID del estado
                                TipoId = reader.IsDBNull(reader.GetOrdinal("tipo_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("tipo_id")),
                                GroupId = reader.IsDBNull(reader.GetOrdinal("group_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("group_id")),
                                FechaCreacion = reader.IsDBNull(reader.GetOrdinal("fecha_creacion")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                                CreadorId = reader.IsDBNull(reader.GetOrdinal("creador_id")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("creador_id")),
                                AprobadorRequerido = reader.IsDBNull(reader.GetOrdinal("aprobador_requerido")) ? false : reader.GetBoolean(reader.GetOrdinal("aprobador_requerido"))
                                //UsuarioAprobador = reader.IsDBNull(reader.GetOrdinal("usuario_aprobador")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("usuario_aprobador")),
                            };


                            categorias.Add(categoria);
                        }
                    }
                }
            } 

            // Paso 2: Obtener todos los estados de categorías a través del método en DAL
            EstadosCategoriaDAL estadosCategoriaDAL = new EstadosCategoriaDAL();
            List<EstadosCategoria> estadosCategorias = estadosCategoriaDAL.ListarEstadosCategoria();

            // Paso 3: Hacer un "JOIN" en memoria para asignar el objeto EstadosCategoria a cada Categoría
            foreach (var categoria in categorias)
            {
                // Buscar el estado correspondiente en la lista de estados
                categoria.Estado = estadosCategorias.FirstOrDefault(e => e.EstadoCategoriaId == categoria.Estado.EstadoCategoriaId);
            }

            return categorias;
        }

    }
}
