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

        // Método para listar todos los departamentos
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

        // Método para agregar un nuevo departamento
        public int AgregarDepartamento(Departamento departamento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre", departamento.Nombre),
                acceso.CrearParametro("@ClienteLiderId", departamento.ClienteLiderId ?? 0),
                acceso.CrearParametro("@FechaCreacion", departamento.FechaCreacion),
                acceso.CrearParametro("@CodigoDepartamento", departamento.CodigoDepartamento),
                acceso.CrearParametro("@Descripcion", departamento.Descripcion),
                acceso.CrearParametro("@UbicacionId", departamento.UbicacionId ?? 0),
                acceso.CrearParametro("@Estado", departamento.Estado),
                acceso.CrearParametro("@EsPrioritario", departamento.EsPrioritario),
                acceso.CrearParametro("@HorarioAtencion", departamento.HorarioAtencion),
                acceso.CrearParametro("@EmailContacto", departamento.EmailContacto)
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

        // Método para actualizar un departamento existente
        public void ActualizarDepartamento(Departamento departamento)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamento.Id),
                acceso.CrearParametro("@Nombre", departamento.Nombre),
                acceso.CrearParametro("@ClienteLiderId", departamento.ClienteLiderId ?? 0),
                acceso.CrearParametro("@FechaCreacion", departamento.FechaCreacion),
                acceso.CrearParametro("@CodigoDepartamento", departamento.CodigoDepartamento),
                acceso.CrearParametro("@Descripcion", departamento.Descripcion),
                acceso.CrearParametro("@UbicacionId", departamento.UbicacionId ?? 0),
                acceso.CrearParametro("@Estado", departamento.Estado),
                acceso.CrearParametro("@EsPrioritario", departamento.EsPrioritario),
                acceso.CrearParametro("@HorarioAtencion", departamento.HorarioAtencion),
                acceso.CrearParametro("@EmailContacto", departamento.EmailContacto)
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

        // Método para eliminar un departamento
        public void EliminarDepartamento(int departamentoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamentoId)
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

        // Método para obtener un departamento por su Id
        public Departamento ObtenerDepartamentoPorId(int departamentoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", departamentoId)
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ObtenerDepartamentoPorId", parametros))
                {
                    if (reader.Read())
                    {
                        return MapearDepartamento(reader);
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return null;
        }

        // Método para listar departamentos por estado
        public List<Departamento> ListarDepartamentosPorEstado(bool estado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Estado", estado)
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

        // Método para buscar departamentos por nombre
        public List<Departamento> BuscarDepartamentoPorNombre(string nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre", nombre)
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

        // Método para listar departamentos prioritarios
        public List<Departamento> ListarDepartamentosPrioritarios()
        {
            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ListarDepartamentosPrioritarios"))
                {
                    return MapearDepartamentos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        // Método para listar departamentos por ubicación
        public List<Departamento> ListarDepartamentosPorUbicacion(int ubicacionId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UbicacionId", ubicacionId)
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ListarDepartamentosPorUbicacion", parametros))
                {
                    return MapearDepartamentos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        // Método auxiliar para mapear una lista de departamentos
        private List<Departamento> MapearDepartamentos(SqlDataReader reader)
        {
            List<Departamento> departamentos = new List<Departamento>();

            while (reader.Read())
            {
                departamentos.Add(MapearDepartamento(reader));
            }

            return departamentos;
        }

        // Método auxiliar para mapear un solo departamento
        private Departamento MapearDepartamento(SqlDataReader reader)
        {
            return new Departamento
            {
                Id = reader.GetInt32(reader.GetOrdinal("departamento_id")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                ClienteLiderId = reader.IsDBNull(reader.GetOrdinal("cliente_lider_id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("cliente_lider_id")),
                FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                CodigoDepartamento = reader.GetString(reader.GetOrdinal("codigo_departamento")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                UbicacionId = reader.IsDBNull(reader.GetOrdinal("ubicacion_id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ubicacion_id")),
                Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                EsPrioritario = reader.GetBoolean(reader.GetOrdinal("es_prioritario")),
                HorarioAtencion = reader.IsDBNull(reader.GetOrdinal("horario_atencion")) ? null : reader.GetString(reader.GetOrdinal("horario_atencion")),
                EmailContacto = reader.IsDBNull(reader.GetOrdinal("email_contacto")) ? null : reader.GetString(reader.GetOrdinal("email_contacto"))
            };
        }
    }
}
