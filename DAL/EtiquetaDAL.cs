using System;
using System.Collections.Generic;
using BE;
using INTERFACES;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class EtiquetaDAL : AbstractDAL<BE.Etiqueta>
    {
        private readonly Acceso acceso;

        public EtiquetaDAL()
        {
            acceso = new Acceso();
        }

        // Método para agregar una nueva etiqueta
        public override void Save(BE.Etiqueta etiqueta)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@EtiquetaId", etiqueta.Id.ToString()),
                acceso.CrearParametro("@Nombre", etiqueta.Nombre)
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("SP_InsertarEtiqueta", parameters);
            }
            finally
            {
                acceso.Cerrar();
            }

            // También agregar al contexto de datos local si es necesario
            base.Save(etiqueta);
        }

        // Método para actualizar una etiqueta existente
        public void ActualizarEtiqueta(BE.Etiqueta etiqueta)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@EtiquetaId", etiqueta.Id.ToString()),
                acceso.CrearParametro("@Nombre", etiqueta.Nombre)
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("SP_ActualizarEtiqueta", parameters);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        // Método para eliminar una etiqueta por su ID
        public void EliminarEtiqueta(Guid etiquetaId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@EtiquetaId", etiquetaId.ToString())
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("SP_EliminarEtiqueta", parameters);
            }
            finally
            {
                acceso.Cerrar();
            }

            // Remover del contexto de datos local si es necesario
            var etiqueta = GetById(etiquetaId);
            if (etiqueta != null)
            {
                Delete(etiqueta);
            }
        }

        // Método para obtener una etiqueta por su ID usando el SP
        public BE.Etiqueta ObtenerEtiquetaPorId(Guid etiquetaId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@EtiquetaId", etiquetaId.ToString())
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerEtiquetaPorId", parameters))
                {
                    if (reader.Read())
                    {
                        return new BE.Etiqueta
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("etiqueta_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }
            return null;
        }

        // Método para obtener todas las etiquetas usando un SP
        public IList<IEtiqueta> ObtenerEtiquetas()
        {
            IList<IEtiqueta> etiquetas = new List<IEtiqueta>();

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerTodasLasEtiquetas"))
                {
                    while (reader.Read())
                    {
                        etiquetas.Add(new BE.Etiqueta
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("etiqueta_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        });
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return etiquetas;
        }
    }
}
