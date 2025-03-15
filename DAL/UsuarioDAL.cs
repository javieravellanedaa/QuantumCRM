using BE;
using BE.Composite;
using INTERFACES;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class UsuarioDAL : AbstractDAL<Usuario>
    {
        private readonly Acceso acceso;

        public UsuarioDAL()
        {
            acceso = new Acceso();
        }

        internal UsuarioDAL(Acceso ac)
        {
            acceso = ac;
        }

        public override void Save(Usuario entity)
        {
            var parametros = new List<SqlParameter>
            {
               
                acceso.CrearParametro("@Email", entity.Email),
                acceso.CrearParametro("@Password", Encriptador.Hash(entity.Password)),
                acceso.CrearParametro("@Nombre", entity.Nombre),
                acceso.CrearParametro("@Apellido", entity.Apellido),
                acceso.CrearParametro("@nombre_usuario", entity.Nombre[0]+entity.Apellido[0]+"_"+entity.Legajo),
                acceso.CrearParametro("@fecha_alta", entity.FechaAlta),
                acceso.CrearParametro("@idioma_id", entity.Idioma.Id.ToString()), // aca debe ir el idioma por defecto


                
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_InsertarUsuario", parametros);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<Usuario> GetAll()
        {
            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("usuarios_listar"))
                {
                    return MapearUsuarios(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public Usuario Login(string email, string password)
        {
            var parametros = new List<SqlParameter>
            {
                    acceso.CrearParametro("@Email", email),
                    acceso.CrearParametro("@Password", Encriptador.Hash(password))
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_LoginUsuario", parametros))
                {
                    
                    if (reader.Read())
                        {
         
                        Guid usuarioId = Guid.Parse(reader["usuario_id"].ToString());
                        int rolId =  ObtenerUltimoRol(usuarioId);
                        Usuario usuario = UsuarioFactory.CrearUsuario(rolId); // aca pasarle el GUID para que se cree con ese ID
                        usuario.Id = usuarioId; // por que si aca le paso el ID 
                        usuario.Email = reader["email"].ToString();
                        usuario.Password = reader["password"].ToString(); 
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Apellido = reader["apellido"].ToString();
                        usuario.NombreUsuario = reader["nombre_usuario"].ToString();
                        usuario.Legajo = int.Parse(reader["legajo"].ToString());
                        usuario.FechaAlta = DateTime.Parse(reader["fecha_alta"].ToString());
                        usuario.UltimoInicioSesion = DateTime.Now;
                        usuario.Permisos.AddRange(GetPermisos(usuario));
                        usuario.Roles = GetRoles(usuario);
                        usuario.UltimoRolId = rolId;
                        usuario.Idioma = ObtenerIdioma(usuario);





                        // Instanciación y carga de atributos específicos según el rol

                        switch (rolId)
                        {
                            case 1: // Administrador
                                usuario = CargarAtributosAdministrador((Administrador)usuario, usuarioId);
                                break;
                            case 2: // Técnico
                                //usuario = CargarAtributosTecnico((Tecnico)usuario, usuarioId);
                                break;
                            case 3: // Cliente
                                usuario = CargarAtributosCliente((Cliente)usuario, usuarioId);
                                break;
                            default:
                                throw new Exception("Rol no reconocido");
                        }




                        return usuario;
                    }
                }
                acceso.Cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar iniciar sesión", ex);
            }
 


            return null;
        }

        private Administrador CargarAtributosAdministrador(Administrador administrador, Guid usuarioId)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@usuario_id", usuarioId.ToString())
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerAtributosAdministrador", parametros))
                {
                    if (reader.Read())
                    {
                        administrador.Estado = reader["estado"] != DBNull.Value && (bool)reader["estado"];
                        administrador.FechaCreacion = reader["fecha_creacion"] != DBNull.Value ? DateTime.Parse(reader["fecha_creacion"].ToString()) : (DateTime?)null;
                    }
                }
            }
            finally
            { 
                acceso.Cerrar();
            }

            return administrador;
        }
        private Cliente CargarAtributosCliente(Cliente usuario, Guid usuarioId)
        {
            var parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@usuario_id", usuarioId.ToString())
    };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerAtributosCliente", parametros))
                {
                    if (reader.Read())
                    {
                        usuario.ClienteId = reader["cliente_id"] != DBNull.Value ? (int)reader["cliente_id"] : 0;
                        usuario.DepartamentoId = reader["departamento_id"] != DBNull.Value ? (int)reader["departamento_id"] : 0;
                        usuario.Direccion = reader["direccion"] != DBNull.Value ? reader["direccion"].ToString() : null;
                        usuario.EmailContacto = reader["email_contacto"] != DBNull.Value ? reader["email_contacto"].ToString() : null;
                        usuario.Empresa = reader["empresa"] != DBNull.Value ? reader["empresa"].ToString() : null;
                        usuario.EsInterno = reader["es_interno"] != DBNull.Value && (bool)reader["es_interno"];
                        usuario.EstadoClienteId = reader["estado_cliente_id"] != DBNull.Value ? (int)reader["estado_cliente_id"] : 0;
                        usuario.FechaRegistro = reader["fecha_registro"] != DBNull.Value ? DateTime.Parse(reader["fecha_registro"].ToString()) : (DateTime?)null;
                        usuario.FechaUltimaInteraccion = reader["fecha_ultima_interaccion"] != DBNull.Value ? DateTime.Parse(reader["fecha_ultima_interaccion"].ToString()) : (DateTime?)null;
                        usuario.PreferenciaContacto = reader["preferencia_contacto"] != DBNull.Value ? reader["preferencia_contacto"].ToString() : null;
                        usuario.Telefono = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : null;
                        usuario.TipoClienteId = reader["tipo_cliente_id"] != DBNull.Value ? (int)reader["tipo_cliente_id"] : 0;

                        // Aquí cargamos el departamento completo
                        if (usuario.DepartamentoId > 0)
                        {
                            DepartamentosDAL deptDal = new DepartamentosDAL();
                            usuario.Departamento = deptDal.ObtenerDepartamentoPorId(usuario.DepartamentoId);
                        }
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return usuario;
        }



        public void GuardarPermisos(Usuario usuario)
        {
            var parametrosEliminar = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", usuario.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_EliminarPermisosUsuario", parametrosEliminar);

                foreach (var permiso in usuario.Permisos)
                {
                    var parametrosInsertar = new List<SqlParameter>
                    {
                        acceso.CrearParametro("@id_usuario", usuario.Id.ToString()),
                        acceso.CrearParametro("@id_permiso", permiso.Id)
                    };
                    acceso.Escribir("sp_InsertarPermisoUsuario", parametrosInsertar);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<Patente> GetPermisos(Usuario usuario)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", usuario.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerPermisosUsuario", parametros))
                {
                    return MapearPermisos(reader);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        public List<Rol> GetRoles(Usuario usuario)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UsuarioId", usuario.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerRolesUsuario", parametros))
                {
                    List<Rol> roles  = MapearRoles(reader);
                    //usuario.Roles = roles;
                    return roles;
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }
        public int ObtenerUltimoRol(Guid usuarioId)
        {
            int rolId = 3; // Valor predeterminado en caso de que no se encuentre el rol
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@UsuarioID", usuarioId.ToString()),
                };

            try
            {
                acceso.Abrir();

                //la tabla sesion esta vacia
                DataTable resultado = acceso.Leer("sp_ObtenerUsuarioDeSesion", parametros);

                if (resultado.Rows.Count > 0)
                {
                    // Capturar el valor de ultimo_rol_id desde la primera fila
                    rolId = Convert.ToInt32(resultado.Rows[0]["ultimo_rol_id"]);
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return rolId;
        }

        public IIdioma ObtenerIdioma(Usuario usuario)
        {

            // Valor predeterminado en caso de que no se encuentre el rol
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@UsuarioID", usuario.Id.ToString()),
                };

            try
            {
                acceso.Abrir();

                // Ejecutar el procedimiento almacenado y obtener el resultado como DataTable
                DataTable resultado = acceso.Leer("sp_ObtenerIdiomaDeSesion", parametros);

                if (resultado.Rows.Count > 0)
                {
                    Idioma idioma = new Idioma();
                    usuario.Idioma = idioma;
                    usuario.Idioma.Id = Guid.Parse(resultado.Rows[0]["idioma_id"].ToString());
                    usuario.Idioma.Nombre = resultado.Rows[0]["idioma_nombre"].ToString();
                }

            }
            finally
            {
                acceso.Cerrar();
            }

            
            return usuario.Idioma;
        

        }

        public List<Usuario> ListarUsuariosConTodosLosAtributos()
        {
            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ListarUsuariosConAtributos"))
                {
                    return MapearUsuarios(reader, incluirPermisos: true);
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        private List<Usuario> MapearUsuarios(SqlDataReader reader, bool incluirPermisos = false) 
        {
            var lista = new List<Usuario>();
            while (reader.Read())
            {
                var usuario = MapearUsuario(reader);
                if (incluirPermisos)
                {
                    usuario.Permisos.AddRange(GetPermisos(usuario));
                }
                lista.Add(usuario);
            }
            return lista;
        }

        private Usuario MapearUsuario(SqlDataReader reader)
        {
 
                IIdioma idioma = new Idioma
                {
                    Id = Guid.Parse(reader["idioma_id"].ToString()),
                    Nombre = reader["nombre_idioma"].ToString()
                };

            return new Usuario
            {
                Id = Guid.Parse(reader["usuario_id"].ToString()),
                Email = reader["email"].ToString(),
                Password = reader["password"].ToString(),
                Nombre = reader["nombre"].ToString(),
                Apellido = reader["apellido"].ToString(),
                NombreUsuario = reader["nombre_usuario"].ToString(),
                Legajo = int.Parse(reader["legajo"].ToString()),
                FechaAlta = DateTime.Parse(reader["fecha_alta"].ToString()),
                UltimoInicioSesion = DateTime.Now,//reader["ultimo_inicio_sesion"] != DBNull.Value? DateTime.Parse(reader["ultimo_inicio_sesion"].ToString()): (DateTime?)null,



                Idioma = idioma,
            };

            
           
            


          

        }
        private List<Rol> MapearRoles(SqlDataReader reader)
        {
            var roles = new List<Rol>();
            while (reader.Read())
            {
                roles.Add(new Rol
                {
                    Id = reader.GetInt32(reader.GetOrdinal("rol_id")),
                    Nombre = reader.GetString(reader.GetOrdinal("rol_nombre")),
                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion"))
                });
            }
            return roles;
        }

        private List<Patente> MapearPermisos(SqlDataReader reader)
        {
            var permisos = new List<Patente>();
            while (reader.Read())
            {
                permisos.Add(new Patente
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                    Permiso = reader.GetString(reader.GetOrdinal("descripcion"))
                });
            }
            return permisos;
        }
    }
}
