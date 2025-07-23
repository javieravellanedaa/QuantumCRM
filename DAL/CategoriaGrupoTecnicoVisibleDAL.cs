using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaGrupoTecnicoVisibleDAL
    {
        private readonly Acceso _acceso = new Acceso();

        /// <summary>
        /// Obtiene los IDs de los grupos técnicos que tienen visibilidad sobre una categoría.
        /// </summary>
        public List<int> ObtenerGruposTecnicosVisiblesIds(int categoriaId)
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
                    "sp_ObtenerGruposTecnicosVisiblesIds",
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
        /// Reemplaza la visibilidad de grupos técnicos para una categoría:
        /// elimina todas las entradas existentes y vuelve a insertar las nuevas.
        /// </summary>
        public void ActualizarVisibilidad(int categoriaId, IEnumerable<int> gruposTecnicoIds)
        {
            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();

                // 1) Eliminar todas las visibilidades anteriores
                _acceso.Escribir(
                    "sp_EliminarVisibilidadPorCategoriaGrupoTecnico",
                    new List<SqlParameter>
                    {
                        _acceso.CrearParametro("@CategoriaId", categoriaId)
                    }
                );

                // 2) Insertar las nuevas asociaciones
                foreach (var grupoId in gruposTecnicoIds)
                {
                    _acceso.Escribir(
                        "sp_AgregarVisibilidadCategoriaGrupoTecnico",
                        new List<SqlParameter>
                        {
                            _acceso.CrearParametro("@CategoriaId", categoriaId),
                            _acceso.CrearParametro("@GrupoTecnicoId", grupoId)
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
        /// Obtiene los IDs de las categorías visibles para un grupo técnico dado.
        /// </summary>
        public List<int> ObtenerCategoriasVisiblesIds(int grupoTecnicoId)
        {
            var resultado = new List<int>();
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@GrupoTecnicoId", grupoTecnicoId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura(
                    "sp_ListarCategoriasVisiblesPorGrupoTecnico",
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
