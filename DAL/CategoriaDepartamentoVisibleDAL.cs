using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaDepartamentoVisibleDAL
    {
        private readonly Acceso _acceso = new Acceso();

        /// <summary>
        /// Obtiene los IDs de los departamentos que tienen visibilidad sobre una categoría.
        /// </summary>
        public List<int> ObtenerDepartamentosVisiblesIds(int categoriaId)
        {
            var resultado = new List<int>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", categoriaId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura(
                    "sp_ObtenerDepartamentosVisiblesIds",
                    parametros))
                {
                    while (reader.Read())
                        resultado.Add(reader.GetInt32(0));
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return resultado;
        }

        /// <summary>
        /// Reemplaza la visibilidad de departamentos para una categoría:
        /// elimina todas las entradas existentes y vuelve a insertar las nuevas.
        /// </summary>
        public void ActualizarVisibilidad(int categoriaId, IEnumerable<int> departamentosIds)
        {
            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();

                // 1) Eliminar todas las visibilidades anteriores
                _acceso.Escribir(
                    "sp_EliminarVisibilidadPorCategoria",
                    new List<SqlParameter>
                    {
                        _acceso.CrearParametro("@CategoriaId", categoriaId)
                    }
                );

                // 2) Insertar las nuevas asociaciones
                foreach (var depId in departamentosIds)
                {
                    _acceso.Escribir(
                        "sp_AgregarVisibilidadCategoria",
                        new List<SqlParameter>
                        {
                            _acceso.CrearParametro("@CategoriaId", categoriaId),
                            _acceso.CrearParametro("@DepId", depId)
                        }
                    );
                }

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

        /// <summary>
        /// Obtiene los IDs de las categorías visibles para un departamento dado.
        /// </summary>
        public List<int> ObtenerCategoriasVisiblesIds(int departamentoId)
        {
            var resultado = new List<int>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DepartamentoId", departamentoId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura(
                    "sp_ListarCategoriasVisiblesPorDepartamento",
                    parametros))
                {
                    while (reader.Read())
                        resultado.Add(reader.GetInt32(0));
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return resultado;
        }
    }
}
