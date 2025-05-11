using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DepartamentosDAL
    {
        private Acceso acceso;

        public DepartamentosDAL()
        {
            acceso = new Acceso();
        }

        public List<Departamento> ListarDepartamentos()
        {
            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ListarDepartamentos"))
                {
                    return MapearDepartamentos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public int AgregarDepartamento(Departamento departamento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre", departamento.Nombre ?? string.Empty),
                acceso.CrearParametro("@ClienteLiderId",
                    departamento.ClienteLider != null ? departamento.ClienteLider.ClienteId.ToString() : null),
                acceso.CrearParametro("@FechaCreacion", departamento.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss")),
                acceso.CrearParametro("@CodigoDepartamento", departamento.CodigoDepartamento ?? string.Empty),
                acceso.CrearParametro("@Descripcion", departamento.Descripcion ?? string.Empty),
                acceso.CrearParametro("@Ubicacion", departamento.Ubicacion ?? string.Empty),
                acceso.CrearParametro("@Estado", departamento.Estado ? "1" : "0")
            };

            try
            {
                acceso.Abrir();
                return Convert.ToInt32(acceso.EscribirEscalar("sp_AgregarDepartamento", parametros));
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void ActualizarDepartamento(Departamento departamento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamento.Id.ToString()),
                acceso.CrearParametro("@Nombre", departamento.Nombre ?? string.Empty),
                acceso.CrearParametro("@ClienteLiderId",
                    departamento.ClienteLider != null ? departamento.ClienteLider.ClienteId.ToString() : null),
                acceso.CrearParametro("@FechaCreacion", departamento.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss")),
                acceso.CrearParametro("@CodigoDepartamento", departamento.CodigoDepartamento ?? string.Empty),
                acceso.CrearParametro("@Descripcion", departamento.Descripcion ?? string.Empty),
                acceso.CrearParametro("@Ubicacion", departamento.Ubicacion ?? string.Empty),
                acceso.CrearParametro("@Estado", departamento.Estado ? "1" : "0")
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_ActualizarDepartamento", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void EliminarDepartamento(int departamentoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamentoId.ToString())
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_EliminarDepartamento", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public Departamento ObtenerDepartamentoPorId(int departamentoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamentoId.ToString())
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ObtenerDepartamentoPorId", parametros))
                {
                    if (reader.Read())
                        return MapearDepartamento(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return null;
        }

        public List<Departamento> ListarDepartamentosPorEstado(bool estado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Estado", estado ? "1" : "0")
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ListarDepartamentosPorEstado", parametros))
                {
                    return MapearDepartamentos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<Departamento> BuscarDepartamentoPorNombre(string nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre", nombre ?? string.Empty)
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_BuscarDepartamentoPorNombre", parametros))
                {
                    return MapearDepartamentos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public Departamento ObtenerDepartamentoPorCodigo(string codigo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@CodigoDepartamento", codigo ?? string.Empty)
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ObtenerDepartamentoPorCodigo", parametros))
                {
                    if (reader.Read())
                        return MapearDepartamento(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return null;
        }

        private List<Departamento> MapearDepartamentos(SqlDataReader reader)
        {
            var departamentos = new List<Departamento>();

            while (reader.Read())
            {
                departamentos.Add(MapearDepartamento(reader));
            }

            return departamentos;
        }

        private Departamento MapearDepartamento(SqlDataReader reader)
        {
            return new Departamento
            {
                Id = reader.GetInt32(reader.GetOrdinal("departamento_id")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                ClienteLider = reader.IsDBNull(reader.GetOrdinal("cliente_lider_id"))
                    ? null
                    : new Cliente { ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_lider_id")) },
                FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                CodigoDepartamento = reader.GetString(reader.GetOrdinal("codigo_departamento")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                Ubicacion = reader.IsDBNull(reader.GetOrdinal("ubicacion")) ? null : reader.GetString(reader.GetOrdinal("ubicacion")),
                Estado = reader.GetBoolean(reader.GetOrdinal("estado"))
            };
        }
    }
}
