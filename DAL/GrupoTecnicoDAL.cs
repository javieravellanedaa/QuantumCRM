using BE;
using BE.PN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class GruposTecnicosDAL
    {
        private readonly Acceso acceso;

        public GruposTecnicosDAL()
        {
            acceso = new Acceso();
        }

        public List<GrupoTecnico> ListarGruposTecnicos()
        {
            var gruposTecnicos = new List<GrupoTecnico>();

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ListarGruposTecnicos"))
                {
                    while (reader.Read())
                    {
                        var grupo = new GrupoTecnico
                        {
                            GrupoId = reader.GetInt32(reader.GetOrdinal("grupo_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                            TecnicoLider = reader.IsDBNull(reader.GetOrdinal("tecnico_lider_id"))
                                ? null
                                : new Tecnico
                                {
                                    TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_lider_id"))
                                }
                        };

                        gruposTecnicos.Add(grupo);
                    }
                }
                return gruposTecnicos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los grupos técnicos: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public GrupoTecnico ObtenerPorId(int id)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", id.ToString())
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("sp_ObtenerGrupoTecnicoPorId", parametros))
                {
                    if (reader.Read())
                    {
                        return new GrupoTecnico
                        {
                            GrupoId = reader.GetInt32(reader.GetOrdinal("grupo_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                            TecnicoLider = reader.IsDBNull(reader.GetOrdinal("tecnico_lider_id"))
                                ? null
                                : new Tecnico
                                {
                                    TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_lider_id"))
                                }
                        };
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener grupo técnico por ID: " + ex.Message);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void AgregarGrupoTecnico(GrupoTecnico grupo)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Nombre", grupo.Nombre),
                acceso.CrearParametro("@Descripcion", grupo.Descripcion ?? DBNull.Value.ToString()),
               acceso.CrearParametro("@TecnicoLiderId", grupo.TecnicoLider != null ? grupo.TecnicoLider.Id.ToString() : DBNull.Value.ToString())

            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_AgregarGrupoTecnico", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void ActualizarGrupoTecnico(GrupoTecnico grupo)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", grupo.GrupoId.ToString()),
                acceso.CrearParametro("@Nombre", grupo.Nombre),
                acceso.CrearParametro("@Descripcion", grupo.Descripcion ?? DBNull.Value.ToString()),
               acceso.CrearParametro("@TecnicoLiderId", grupo.TecnicoLider != null ? grupo.TecnicoLider.Id.ToString() : DBNull.Value.ToString())

            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_ActualizarGrupoTecnico", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void EliminarGrupoTecnico(int grupoId)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@Id", grupoId.ToString())
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_EliminarGrupoTecnico", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
