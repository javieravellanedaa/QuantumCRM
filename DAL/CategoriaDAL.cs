using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaDAL
    {
        private readonly Acceso _acceso = new Acceso();

        #region MapearCategoriaDesdeReader <<Mapeo: SqlDataReader → Categoria>>
        public Categoria MapearCategoriaDesdeReader(SqlDataReader reader)
        {
            var categoria = new Categoria
            {
                CategoriaId = reader.GetInt32(reader.GetOrdinal("categoria_id")),
                Nombre = reader.GetString(reader.GetOrdinal("categoria_nombre")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),

                // Reemplazamos Estado por Eliminado
                Eliminado = reader.IsDBNull(reader.GetOrdinal("eliminado")) ? false : reader.GetBoolean(reader.GetOrdinal("eliminado")),

                FechaCreacion = reader.IsDBNull(reader.GetOrdinal("fecha_creacion")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                CreadorId = reader.IsDBNull(reader.GetOrdinal("creador_id")) ? Guid.Empty : reader.GetGuid(reader.GetOrdinal("creador_id")),
                AprobadorRequerido = reader.IsDBNull(reader.GetOrdinal("aprobador_requerido")) ? false : reader.GetBoolean(reader.GetOrdinal("aprobador_requerido")),

                Departamento = new Departamento
                {
                    Id = reader.GetInt32(reader.GetOrdinal("departamento_id")),
                    Nombre = reader.GetString(reader.GetOrdinal("departamento_nombre"))
                },

                GrupoTecnico = new BE.PN.GrupoTecnico
                {
                    GrupoId = reader.GetInt32(reader.GetOrdinal("group_id")), // corregido si corresponde
                    Nombre = reader.IsDBNull(reader.GetOrdinal("grupo_nombre")) ? null : reader.GetString(reader.GetOrdinal("grupo_nombre"))
                },

                ClienteAprobador = reader.IsDBNull(reader.GetOrdinal("cliente_aprobador_id"))
                    ? null
                    : new Cliente
                    {
                        ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_aprobador_id")),
                        Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                        Nombre = reader.GetString(reader.GetOrdinal("usuario_nombre")),
                        Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"))
                    }
            };

            return categoria;
        }


        #endregion 
        public void AgregarCategoria(Categoria categoria)
        {
            var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Nombre", categoria.Nombre),
                    _acceso.CrearParametro("@GroupId", categoria.GrupoTecnico.GrupoId.ToString()),
                    _acceso.CrearParametro("@TipoId", ((int)categoria.tipoCategoria).ToString()),
                    _acceso.CrearParametro("@Eliminado", categoria.Eliminado ? "0" : "1"),
                    _acceso.CrearParametro("@FechaCreacion", categoria.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss")),
                    _acceso.CrearParametro("@CreadorId", categoria.CreadorId.ToString()),
                    _acceso.CrearParametro("@Descripcion", categoria.Descripcion ?? string.Empty),
                    _acceso.CrearParametro("@AprobadorRequerido", categoria.AprobadorRequerido ? "1" : "0"),
                                            _acceso.CrearParametro("@ClienteAprobador",
                                                categoria.AprobadorRequerido && categoria.ClienteAprobador != null
                                                    ? categoria.ClienteAprobador.ClienteId.ToString()
                                                    : null),

                    _acceso.CrearParametro("@DepartamentoId", categoria.Departamento.Id.ToString()),
                    _acceso.CrearParametro("@PrioridadId", categoria.Prioridad.Id.ToString())
                };
        



            try
            {
                _acceso.Abrir();
              
                categoria.CategoriaId = Convert.ToInt32(_acceso.EscribirEscalar("sp_AgregarCategoria", parametros));
                _acceso.ConfirmarTransaccion();
            }
            catch
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", categoria.CategoriaId),
                _acceso.CrearParametro("@Nombre", categoria.Nombre),
                _acceso.CrearParametro("@GroupId", categoria.GrupoTecnico.GrupoId),
                _acceso.CrearParametro("@TipoId", categoria.tipoCategoria.ToString()),
                _acceso.CrearParametro("@FechaCreacion", categoria.FechaCreacion),
                _acceso.CrearParametro("@CreadorId", categoria.CreadorId.ToString()),
                _acceso.CrearParametro("@Descripcion", categoria.Descripcion),
                _acceso.CrearParametro("@AprobadorRequerido", categoria.AprobadorRequerido),
                _acceso.CrearParametro("@ClienteAprobadorId", categoria.ClienteAprobador?.ClienteId.ToString()),
                _acceso.CrearParametro("@DepartamentoId", categoria.Departamento.Id),
                _acceso.CrearParametro("@prioridadId", categoria.Prioridad.Id)
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

        public List<Categoria> ListarCategorias()
        {
            var categorias = new List<Categoria>();

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarCategorias"))
                {
                    while (reader.Read())
                    {
                        Categoria categoria = MapearCategoriaDesdeReader(reader);

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

        public void EliminarCategoria(int categoriaId)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", categoriaId.ToString())
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

        public BE.PN.Prioridad ObtenerPrioridad(Categoria categoria)
        {
            BE.PN.Prioridad prioridad = null;

            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", categoria.CategoriaId.ToString())
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_obtenerPrioridad", parametros))
                {
                    if (reader.Read())
                    {
                        prioridad = new BE.PN.Prioridad
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
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

        
    }
}
