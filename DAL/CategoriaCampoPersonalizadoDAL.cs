using BE.PN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CategoriaCampoPersonalizadoDAL
    {
        private readonly Acceso _acceso = new Acceso();

        // Comprueba si el reader contiene esta columna
        private bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        // Obtiene un int o devuelve 0 si no existe o es NULL
        private int GetIntOrDefault(SqlDataReader reader, string columnName)
        {
            if (!HasColumn(reader, columnName)) return 0;
            int ord = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ord) ? 0 : reader.GetInt32(ord);
        }

        // Obtiene un bool o devuelve false si no existe o es NULL
        private bool GetBoolOrDefault(SqlDataReader reader, string columnName)
        {
            if (!HasColumn(reader, columnName)) return false;
            int ord = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ord) ? false : reader.GetBoolean(ord);
        }

        private CategoriaCampoPersonalizado MapearDesdeReader(SqlDataReader reader)
        {
            return new CategoriaCampoPersonalizado
            {
                CategoriaId = GetIntOrDefault(reader, "CategoriaId"),
                DefinicionCampoPersonalizadoId = GetIntOrDefault(reader, "DefinicionCampoPersonalizadoId"),
                EsObligatorio = GetBoolOrDefault(reader, "EsObligatorio"),
                OrdenVisualizacion = GetIntOrDefault(reader, "OrdenVisualizacion")
            };
        }

        public List<CategoriaCampoPersonalizado> ListarPorCategoria(int categoriaId)
        {
            var lista = new List<CategoriaCampoPersonalizado>();
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", categoriaId)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarCamposPorCategoria", pars))
                {
                    while (reader.Read())
                        lista.Add(MapearDesdeReader(reader));
                }
                return lista;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Insertar(CategoriaCampoPersonalizado asoc)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", asoc.CategoriaId),
                _acceso.CrearParametro("@DefinicionId", asoc.DefinicionCampoPersonalizadoId),
                _acceso.CrearParametro("@EsObligatorio", asoc.EsObligatorio),
                _acceso.CrearParametro("@OrdenVisualizacion", asoc.OrdenVisualizacion)
            };
            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_InsertarCampoEnCategoria", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Actualizar(CategoriaCampoPersonalizado asoc)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", asoc.CategoriaId),
                _acceso.CrearParametro("@DefinicionId", asoc.DefinicionCampoPersonalizadoId),
                _acceso.CrearParametro("@EsObligatorio", asoc.EsObligatorio),
                _acceso.CrearParametro("@OrdenVisualizacion", asoc.OrdenVisualizacion)
            };
            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarAsociacionCampoCategoria", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Eliminar(int categoriaId, int definicionId)
        {
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", categoriaId),
                _acceso.CrearParametro("@DefinicionId", definicionId)
            };
            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarCampoDeCategoria", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
