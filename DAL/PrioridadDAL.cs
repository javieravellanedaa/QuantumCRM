using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE.PN; // Espacio de nombres donde se encuentra la clase Prioridad

namespace DAL
{
    public class PrioridadDAL
    {
        private Acceso _acceso = new Acceso();


        public Prioridad ObtenerPrioridad(int categoriaId)
        {
            Prioridad prioridad = null;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@CategoriaId", categoriaId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_obtenerPrioridad", parametros))
                {
                    if (reader.Read())
                    {
                        prioridad = new Prioridad
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


        public List<Prioridad> GetAll()
        {
            List<Prioridad> lista = new List<Prioridad>();
            try
            {
                _acceso.Abrir();
                // Se asume que tienes un SP llamado sp_GetAllPrioridades que retorna todos los registros de la tabla prioridades
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarPrioridades", null))
                {
                    while (reader.Read())
                    {
                        Prioridad prioridad = new Prioridad
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("prioridad_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion"))
                        };
                        lista.Add(prioridad);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return lista;
        }
    }
}
