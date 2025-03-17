    using System;
    using System.Collections.Generic;
    using BE;
    using INTERFACES;
    using System.Data.SqlClient;
    using System.Data;

    namespace DAL
    {
        public class IdiomaDAL : AbstractDAL<BE.Idioma>
        {
            private readonly Acceso acceso;

            public IdiomaDAL()
            {
                acceso = new Acceso();
            }


            public IList<Idioma> ObtenerIdiomas()
            {
                IList<Idioma> lista = new List<Idioma>();
                try
                {
                    acceso.Abrir();
                    // Suponiendo que tienes un SP o Query similar a:
                    // SELECT idioma_id, nombre, activo FROM Idiomas WHERE activo = 1
                    // O bien, un SP_ObtenerIdiomasActivos con esa lógica
                    using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerIdiomasActivos"))
                    {
                        while (reader.Read())
                        {
                            var idioma = new Idioma
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("idioma_id")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("activo"))
                            };
                            lista.Add(idioma);
                        }
                    }
                }
                finally
                {
                    acceso.Cerrar();
                }
                return lista;
            }



            public bool AgregarIdioma(string nombre)
            {
                bool resultado = false;
                try
                {
                    acceso.Abrir();

                    List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@idioma_id", Guid.NewGuid().ToString()),    
                acceso.CrearParametro("@nombre", nombre),
                // Aquí pasas 1 (true) como valor inicial
                acceso.CrearParametro("@activo", true)
            };

                    // SP o Query para insertar con "activo = 1"
                    acceso.Escribir("SP_AgregarIdioma", parameters);
                    resultado = true;
                }
                catch
                {
                    resultado = false;
                }
                finally
                {
                    acceso.Cerrar();
                }
                return resultado;
            }

            public void DesactivarIdioma(Guid idiomaId)
            {
                try
                {
                    acceso.Abrir();
                    List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@idioma_id", idiomaId.ToString())
            };
                
                    acceso.Escribir("SP_DesactivarIdioma", parameters);
                }
                finally
                {
                    acceso.Cerrar();
                }
            }

            public IList<Idioma> ObtenerIdiomasInactivos()
            {
                IList<Idioma> lista = new List<Idioma>();
                try
                {
                    acceso.Abrir();
                    // Supongamos que existe un SP llamado "SP_ObtenerIdiomasInactivos"
                    using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerIdiomasInactivos"))
                    {
                        while (reader.Read())
                        {
                            var idioma = new Idioma
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("idioma_id")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("activo"))
                            };
                            lista.Add(idioma);
                        }
                    }
                }
                finally
                {
                    acceso.Cerrar();
                }
                return lista;
            }

            public IList<Idioma> ObtenerTodosLosIdiomas()
            {
                IList<Idioma> lista = new List<Idioma>();
                try
                {
                    acceso.Abrir();
                    // Supongamos que existe un SP llamado "SP_ObtenerTodosLosIdiomas"
                    // que hace SELECT * FROM Idiomas (sin filtrar por activo)
                    using (SqlDataReader reader = acceso.EjecutarLectura("SP_ObtenerTodosLosIdiomas"))
                    {
                        while (reader.Read())
                        {
                            var idioma = new Idioma
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("idioma_id")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                Activo = reader.GetBoolean(reader.GetOrdinal("activo"))
                            };
                            lista.Add(idioma);
                        }
                    }
                }
                finally
                {
                    acceso.Cerrar();
                }
                return lista;
            }

            public bool EliminarIdioma(Guid idiomaId)
            {
                bool resultado = false;
                try
                {
                    acceso.Abrir();
                    List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@idioma_id", idiomaId.ToString())
            };

                    // Asumimos que tienes un SP_EliminarIdioma que hace DELETE FROM Idiomas WHERE idioma_id = @idioma_id
                    acceso.Escribir("SP_EliminarIdioma", parameters);

                    resultado = true;
                }
                finally
                {
                    acceso.Cerrar();
                }
                return resultado;
            }
            public void ActivarIdioma(Guid idiomaId)
            {
                try
                {
                    acceso.Abrir();
                    List<SqlParameter> parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@idioma_id", idiomaId.ToString())
            };
                    acceso.Escribir("SP_ActivarIdioma", parameters);
                    // SP_ActivarIdioma -> UPDATE Idiomas SET activo = 1 WHERE idioma_id = @idioma_id
                }
                finally
                {
                    acceso.Cerrar();
                }
            }


        }
    }
