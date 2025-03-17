using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BE;
using BE.Composite;

namespace DAL
{
    public class PermisoDAL
    {
        private readonly Acceso acceso;

        public PermisoDAL()
        {
            acceso = new Acceso();
        }


        public List<string> GetAllPermission()
        {
            List<string> permisos = new List<string>();
            try
            {
                acceso.Abrir();
                // Se asume que "sp_permiso_listar" es un SP que devuelve los permisos.
                DataTable tabla = acceso.Leer("sp_permiso_listar");
                foreach (DataRow registro in tabla.Rows)
                {
                    permisos.Add(registro["nombre"].ToString());
                    permisos.Add(registro["descripcion"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los permisos", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
            return permisos;
        }

        public Componente GuardarComponente(Componente componente, bool esfamilia)
        {
            try
            {
                acceso.Abrir();
                // Selecciona el procedimiento almacenado según el tipo de componente.
                string storedProcedure = esfamilia ? "sp_insertar_familia" : "sp_insertar_patente";

                // Crea la lista de parámetros e incluye el nombre.
                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@Nombre", componente.Nombre)
        };

                if (!esfamilia && componente is Patente patente)
                {
                    // Para una patente, se agregan los parámetros de permiso y descripción.
                    parametros.Add(acceso.CrearParametro("@Permiso", patente.Permiso));
                    parametros.Add(acceso.CrearParametro("@Descripcion", patente.Descripcion.ToString()));
                }
                else
                {
                    // Para una familia se envía nulo en el parámetro de permiso.
                    parametros.Add(acceso.CrearParametro("@Permiso", DBNull.Value.ToString()));
                }

                // Ejecuta el procedimiento almacenado con los parámetros.
                acceso.Escribir(storedProcedure, parametros);
                return componente;
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        private bool ValidateFamilyRecursion(Familia familia, HashSet<int> visited)
        {
            if (visited.Contains(familia.Id))
            {
                return false;
            }

            visited.Add(familia.Id);

            foreach (Componente hijo in familia.Hijos)
            {
                if (hijo is Familia hijoFamilia)
                {
                    if (!ValidateFamilyRecursion(hijoFamilia, visited))
                    {
                        return false;
                    }
                }
            }

            visited.Remove(familia.Id);

            return true;
        }

        private bool IsValidFamily(Familia familia)
        {
            HashSet<int> visited = new HashSet<int>();
            return ValidateFamilyRecursion(familia, visited);
        }
        public void GuardarFamilia(Familia familia)
        {
            // Validar que la familia no sea recursiva
            if (!IsValidFamily(familia))
            {
                throw new Exception("La familia es recursiva y no se puede guardar.");
            }

            try
            {
                acceso.Abrir();

                // Primero se borra la relación de permisos existentes para la familia
                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@id", familia.Id)
        };
                acceso.Escribir("sp_borrar_permiso_permiso", parametros);

                // Luego se insertan las nuevas relaciones de familia
                foreach (var hijo in familia.Hijos)
                {
                    var parameters = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_permiso_padre", familia.Id),
                acceso.CrearParametro("@id_permiso_hijo", hijo.Id)
            };
                    acceso.Escribir("sp_familia_guardar", parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la familia en la base de datos.", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        public IList<Patente> GetAllPatentes()
        {
            List<Patente> patentes = new List<Patente>();

            try
            {
                acceso.Abrir();
                DataTable tabla = acceso.Leer("sp_listar_patentes");

                foreach (DataRow registro in tabla.Rows)
                {
                    Patente patente = new Patente
                    {
                        Id = Convert.ToInt32(registro["permiso_id"]),
                        Nombre = registro["nombre"].ToString(),
                        Permiso = registro["descripcion"] != DBNull.Value ? registro["descripcion"].ToString() : "SIN_PERMISO",
                       // Descripcion = registro["descripcion"] != DBNull.Value ? registro["descripcion"].ToString() : ""
                    };

                    patentes.Add(patente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las patentes desde la base de datos.", ex);
            }
            finally
            {
                acceso.Cerrar();
            }

            return patentes;
        }

        public IList<Componente> GetChildren(int familiaId)
        {
            List<Componente> hijos = new List<Componente>();
            try
            {
                acceso.Abrir();
                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@FamiliaId", familiaId)
        };

                DataTable tabla = acceso.Leer("sp_listar_componentes_directos", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    int id = Convert.ToInt32(registro["permiso_id"]);
                    string nombre = registro["nombre"].ToString();
                    string permiso = registro["descripcion"] != DBNull.Value ? registro["descripcion"].ToString() : string.Empty;

                    Componente componente;
                    if (!string.IsNullOrEmpty(permiso))
                    {
                        // Es Patente
                        componente = new Patente
                        {
                            Id = id,
                            Nombre = nombre,
                            Permiso = permiso
                        };
                    }
                    else
                    {
                        // Es Familia
                        componente = new Familia
                        {
                            Id = id,
                            Nombre = nombre
                        };
                    }

                    hijos.Add(componente);
                }
                return hijos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los componentes directos.", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
        }



        public List<Familia> GetAllFamilias()
        {
            List<Familia> lista = new List<Familia>();
            try
            {
                acceso.Abrir();
                DataTable tabla = acceso.Leer("sp_familias_listar");
                foreach (DataRow registro in tabla.Rows)
                {
                    var familia = new Familia
                    {
                        Id = int.Parse(registro["permiso_id"].ToString()),
                        Nombre = registro["nombre"].ToString()
                    };
                    lista.Add(familia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las familias", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
            return lista;
        }

        private Componente GetComponent(int id, IList<Componente> lista)
        {
            // Búsqueda recursiva en la lista de componentes
            Componente componente = lista?.FirstOrDefault(i => i.Id.Equals(id));
            if (componente == null && lista != null)
            {
                foreach (var comp in lista)
                {
                    var hijo = GetComponent(id, comp.Hijos);
                    if (hijo != null)
                        return hijo;
                }
            }
            return componente;
        }

        public IList<Componente> GetAll(string familia)
        {
            List<Componente> componentes = new List<Componente>();

            try
            {
                acceso.Abrir();
                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@Familia", familia)
        };

                DataTable tabla = acceso.Leer("sp_listar_componentes", parametros);
                foreach (DataRow registro in tabla.Rows)
                {
                    // Se determina si el componente es una familia o una patente
                    bool esFamilia = registro["esFamilia"] != DBNull.Value && Convert.ToBoolean(registro["esFamilia"]);
                    Componente componente;

                    if (esFamilia)
                    {
                        componente = new Familia    
                        {
                            Id = Convert.ToInt32(registro["permiso_id"]),
                            Nombre = registro["nombre"].ToString()
                        };
                    }
                    else
                    {
                        componente = new Patente
                        {
                            Id = Convert.ToInt32(registro["permiso_id"]),
                            Nombre = registro["nombre"].ToString(),
                            Permiso = registro["descripcion"].ToString()
                        };
                    }

                    componentes.Add(componente);
                }

                return componentes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los componentes", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void FillUserComponents(Usuario usuario)
        {
            try
            {
                acceso.Abrir();

                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@UsuarioId", usuario.Id.ToString())
        };

                DataTable tabla = acceso.Leer("sp_obtener_componentes_usuario", parametros);
                usuario.Permisos.Clear();

                foreach (DataRow registro in tabla.Rows)
                {
                    int id = Convert.ToInt32(registro["id"]);
                    string nombre = registro["nombre"].ToString();
                    string permiso = registro["permiso"] != DBNull.Value ? registro["permiso"].ToString() : string.Empty;

                    Componente componente;

                    if (!string.IsNullOrEmpty(permiso))
                    {
                        componente = new Patente
                        {
                            Id = id,
                            Nombre = nombre,
                            Permiso = permiso
                        };
                    }
                    else
                    {
                        componente = new Familia
                        {
                            Id = id,
                            Nombre = nombre
                        };

                        // Cargar los hijos recursivamente
                        FillFamilyComponents((Familia)componente);
                    }

                    usuario.AgregarComponente(componente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar los componentes del usuario.", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public void FillFamilyComponents(Familia familia)
        {
            familia.VaciarHijos();

            // Obtener hijos directos en la BD
            var hijos = GetChildren(familia.Id);

            foreach (var hijo in hijos)
            {
                if (hijo is Familia subFamilia)
                {
                    // Llamada recursiva
                    FillFamilyComponents(subFamilia);
                }
                familia.AgregarHijo(hijo);
            }
        }
    }
}
