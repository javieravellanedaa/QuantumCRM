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

        public void AgregarEtiquetasBulk(List<Etiqueta> etiquetas)
        {
            var table = new DataTable();
            table.Columns.Add("etiqueta_id", typeof(Guid));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("form", typeof(string));
            table.Columns.Add("texto", typeof(string));

            foreach (var etiqueta in etiquetas)
            {
                // Crear parámetros para la validación
                List<SqlParameter> parameters = new List<SqlParameter>
        {
            acceso.CrearParametro("@Nombre", etiqueta.Nombre),
            acceso.CrearParametro("@Form", etiqueta.Form),
            acceso.CrearParametro("@Texto", etiqueta.Texto)
        };

                bool existe = false;

                try
                {
                    acceso.Abrir();
                    using (SqlDataReader reader = acceso.EjecutarLectura("SP_ValidarEtiquetaExistente", parameters))
                    {
                        if (reader.Read())
                        {
                            existe = reader.GetInt32(0) == 1; // Comprobar si el SP devolvió 1
                        }
                    }
                }
                finally
                {
                    acceso.Cerrar();
                }

                if (!existe)
                {
                    // Si no existe, agregar al DataTable
                    table.Rows.Add(etiqueta.Id, etiqueta.Nombre, etiqueta.Form, etiqueta.Texto);
                }
            }

            if (table.Rows.Count > 0)
            {
                try
                {
                    acceso.Abrir();
                    using (var bulkCopy = new SqlBulkCopy(acceso.ObtenerConexion(), SqlBulkCopyOptions.Default, null))
                    {
                        bulkCopy.DestinationTableName = "etiquetas";
                        bulkCopy.WriteToServer(table);
                    }
                }
                finally
                {
                    acceso.Cerrar();
                }
            }
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
                        var etiquetaForm = reader.GetString(reader.GetOrdinal("formulario"));
                        var etiqueta = etiquetaForm + "." + etiquetaNombre;
                        traducciones.Add(etiqueta, new Traduccion
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("traduccion_id")),
                            Texto = reader.GetString(reader.GetOrdinal("texto")),
                            Etiqueta = new Etiqueta
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("etiqueta_id")),
                                Nombre = etiquetaNombre,
                                Form = reader.GetString(reader.GetOrdinal("formulario"))
                               
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
            List<Traduccion> lista = new List<Traduccion>();

            try
            {
                acceso.Abrir();

                // Se asume que 'EscribirLectura' ejecuta un SP y retorna SqlDataReader
                List<SqlParameter> parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@idioma_id", idiomaId.ToString())
        };

                using (var reader = acceso.EjecutarLectura("SP_ObtenerTraduccionesPorIdioma", parametros))
                {
                    while (reader.Read())
                    {
                        // Manejar DBnull => string.Empty o Guid.Empty
                        var traduccionId = reader["traduccion_id"] == DBNull.Value
                                           ? Guid.Empty
                                           : (Guid)reader["traduccion_id"];

                        var textoTraduccion = reader["TextoTraduccion"] == DBNull.Value
                                              ? ""
                                              : (string)reader["TextoTraduccion"];

                        var etiquetaId = (Guid)reader["etiqueta_id"];

                        // Construir
                        var obj = new Traduccion
                        {
                            Id = traduccionId,
                            IdiomaId = idiomaId,
                            EtiquetaId = etiquetaId,
                            Texto = textoTraduccion,
                            EtiquetaNombre = reader["EtiquetaNombre"].ToString(),
                            Formulario = reader["Formulario"].ToString(),
                            TextoOriginal = reader["TextoOriginal"].ToString()
                        };

                        lista.Add(obj);
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return lista;
        }


        // Método para guardar una traducción usando la clase Acceso
        public void GuardarTraduccion(Traduccion traduccion)
        {
            // Parámetros para SP_InsertarTraduccion o SP_ActualizarTraduccion
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@TraduccionId", traduccion.Id.ToString()),
                acceso.CrearParametro("@IdiomaId",     traduccion.IdiomaId.ToString()),
                acceso.CrearParametro("@EtiquetaId",   traduccion.EtiquetaId.ToString()),
                acceso.CrearParametro("@Texto",        traduccion.Texto ?? string.Empty)
            };

            // Parámetro para SP_ExisteTraduccion
            List<SqlParameter> checkParameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@TraduccionId", traduccion.Id.ToString())
            };

            try
            {
                acceso.Abrir();

                // 1) Verificar si existe la traducción
                int count = Convert.ToInt32(
                    acceso.EscribirEscalar("SP_ExisteTraduccion", checkParameters)
                );

                // 2) Insertar o Actualizar
                if (count > 0)
                {
                    // Update
                    acceso.Escribir("SP_ActualizarTraduccion", parameters);
                }
                else
                {
                    // Insert
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
