using System;
using System.Collections.Generic;
using BE;
using INTERFACES;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TraduccionDAL : AbstractDAL<BE.Traduccion>
    {
        private readonly Acceso acceso;

        public TraduccionDAL()
        {
            acceso = new Acceso();
        }

        // Método para obtener traducciones de un idioma específico usando la clase Acceso y un SP
        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {
            if (idioma == null)
            {
                throw new ArgumentNullException(nameof(idioma), "El parámetro idioma no puede ser nulo.");
            }

            IDictionary<string, ITraduccion> traducciones = new Dictionary<string, ITraduccion>();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdiomaId", idioma.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerTraducciones", parameters))
                {
                    while (reader.Read())
                    {
                        var etiquetaNombre = reader.GetString(reader.GetOrdinal("etiqueta"));
                        traducciones.Add(etiquetaNombre, new Traduccion
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("traduccion_id")),
                            Texto = reader.GetString(reader.GetOrdinal("texto")),
                            Etiqueta = new Etiqueta
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("etiqueta_id")),
                                Nombre = etiquetaNombre
                            }
                        });
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return traducciones;
        }

        // Método para obtener todas las traducciones de un idioma usando un SP
        public List<Traduccion> ObtenerTraduccionesPorIdioma(Guid idiomaId)
        {
            List<Traduccion> traducciones = new List<Traduccion>();

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@IdiomaId", idiomaId.ToString())
            };

            try
            {
                acceso.Abrir();
                using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerTraduccionesPorIdioma", parameters))
                {
                    while (reader.Read())
                    {
                        Traduccion traduccion = new Traduccion
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("TraduccionId")),
                            IdiomaId = idiomaId,
                            EtiquetaId = reader.GetGuid(reader.GetOrdinal("EtiquetaId")),
                            Texto = reader.IsDBNull(reader.GetOrdinal("Texto")) ? string.Empty : reader.GetString(reader.GetOrdinal("Texto")),
                            EtiquetaNombre = reader.GetString(reader.GetOrdinal("EtiquetaNombre"))
                        };
                        traducciones.Add(traduccion);
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return traducciones;
        }

        // Método para guardar una traducción usando la clase Acceso
        public void GuardarTraduccion(Traduccion traduccion)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@TraduccionId", traduccion.Id.ToString()),
                acceso.CrearParametro("@IdiomaId", traduccion.IdiomaId.ToString()),
                acceso.CrearParametro("@EtiquetaId", traduccion.EtiquetaId.ToString()),
                acceso.CrearParametro("@Texto", traduccion.Texto ?? string.Empty)
            };

            // Verificar si la traducción ya existe
            List<SqlParameter> checkParameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@TraduccionId", traduccion.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                int count = Convert.ToInt32(acceso.EscribirEscalar("SELECT COUNT(*) FROM traducciones WHERE traduccion_id = @TraduccionId", checkParameters));

                if (count > 0)
                {
                    // Actualizar traducción existente
                    acceso.Escribir("SP_ActualizarTraduccion", parameters);
                }
                else
                {
                    // Insertar nueva traducción
                    acceso.Escribir("SP_InsertarTraduccion", parameters);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }
    }
}
