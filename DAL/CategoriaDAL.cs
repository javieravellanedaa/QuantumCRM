using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class CategoriaDAL
    {
        private Acceso _acceso = new Acceso();

        // Agregar una nueva categoría con campos asociados
        public void AgregarCategoria(Categoria categoria)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Nombre", categoria.Nombre),
                _acceso.CrearParametro("@GroupId", categoria.GroupId),
                _acceso.CrearParametro("@TipoId", categoria.tipoCategoria.Id),
                _acceso.CrearParametro("@EstadoCategoriaId", categoria.Estado.EstadoCategoriaId),
                _acceso.CrearParametro("@FechaCreacion", categoria.FechaCreacion),
                _acceso.CrearParametro("@CreadorId", categoria.CreadorId.ToString()),
                _acceso.CrearParametro("@Descripcion", categoria.Descripcion),
                _acceso.CrearParametro("@AprobadorRequerido", categoria.AprobadorRequerido),
                _acceso.CrearParametro("@UsuarioAprobador", categoria.UsuarioAprobador.Id.ToString()),
                _acceso.CrearParametro("@DepartamentoId", categoria.Departamento.Id)
            };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                categoria.CategoriaId = Convert.ToInt32(_acceso.EscribirEscalar("sp_AgregarCategoria", parametros));
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Actualizar una categoría existente
        public void ActualizarCategoria(Categoria categoria)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", categoria.CategoriaId),
                _acceso.CrearParametro("@Nombre", categoria.Nombre),
                _acceso.CrearParametro("@GroupId", categoria.GroupId),
                _acceso.CrearParametro("@TipoId", categoria.tipoCategoria.Id),
                _acceso.CrearParametro("@EstadoCategoriaId", categoria.Estado.EstadoCategoriaId),
                _acceso.CrearParametro("@FechaCreacion", categoria.FechaCreacion),
                _acceso.CrearParametro("@CreadorId", categoria.CreadorId.ToString()),
                _acceso.CrearParametro("@Descripcion", categoria.Descripcion),
                _acceso.CrearParametro("@AprobadorRequerido", categoria.AprobadorRequerido),
                _acceso.CrearParametro("@UsuarioAprobador", categoria.UsuarioAprobador.Id.ToString()),
                _acceso.CrearParametro("@DepartamentoId", categoria.Departamento.Id)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarCategoria", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Eliminar una categoría
        public void EliminarCategoria(int categoriaId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", categoriaId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarCategoria", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public Prioridad ObtenerPrioridad(Categoria categoria)
        {
            Prioridad prioridad = null;

            // Crear el parámetro con el Id de la categoría
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@CategoriaId", categoria.CategoriaId)
    };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_obtenerPrioridad", parametros))
                {
                    if (reader.Read())
                    {
                        // Crear y asignar los valores de la prioridad
                        prioridad = new Prioridad
                        {
                            Prioridad_id = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion"))
                        };
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return prioridad;
        }




        // Obtener una categoría por su Id
        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            Categoria categoria = null;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", categoriaId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerCategoriaPorId", parametros))
                {
                    if (reader.Read())
                    {
                        categoria = new Categoria
                        {
                            CategoriaId = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Estado = new EstadosCategoria
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                            }
                        };
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return categoria;
        }

        // Listar todas las categorías con sus estados
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarCategorias"))
                {
                    while (reader.Read())
                    {
                        var categoria = new Categoria
                        {
                            CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("categoria_nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                            Estado = new EstadosCategoria
                            {
                                EstadoCategoriaId = reader.GetInt32(reader.GetOrdinal("estado_categoria_id"))
                            },
                            tipoCategoria = new TipoCategoria
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("tipo_id"))
                            },
                            Departamento = new Departamento
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("departamento_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("departamento_id"))
                            },
                            GroupId = reader.IsDBNull(reader.GetOrdinal("group_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("group_id")),
                            FechaCreacion = reader.IsDBNull(reader.GetOrdinal("fecha_creacion")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                            CreadorId = reader.IsDBNull(reader.GetOrdinal("creador_id")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("creador_id")),
                            AprobadorRequerido = reader.IsDBNull(reader.GetOrdinal("aprobador_requerido")) ? false : reader.GetBoolean(reader.GetOrdinal("aprobador_requerido")),
                            UsuarioAprobador = new Usuario
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("usuario_aprobador")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("usuario_aprobador")),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                                Password = reader.IsDBNull(reader.GetOrdinal("password")) ? null : reader.GetString(reader.GetOrdinal("password")),
                                Nombre = reader.IsDBNull(reader.GetOrdinal("usuario_nombre")) ? null : reader.GetString(reader.GetOrdinal("usuario_nombre")),
                                Apellido = reader.IsDBNull(reader.GetOrdinal("apellido")) ? null : reader.GetString(reader.GetOrdinal("apellido")),
                                NombreUsuario = reader.IsDBNull(reader.GetOrdinal("nombre_usuario")) ? null : reader.GetString(reader.GetOrdinal("nombre_usuario")),
                                Legajo = reader.IsDBNull(reader.GetOrdinal("legajo")) ? 0 : reader.GetInt32(reader.GetOrdinal("legajo")),
                                FechaAlta = reader.IsDBNull(reader.GetOrdinal("fecha_alta")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_alta")),
                                UltimoInicioSesion = reader.IsDBNull(reader.GetOrdinal("ultimo_inicio_sesion")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("ultimo_inicio_sesion"))
                            }
                        };

                        categorias.Add(categoria);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return categorias;
        }
    }
}
