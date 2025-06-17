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

        public override void Save(Usuario entity)
        {
            var parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@UsuarioId",      (Guid?)entity.Id),          // Guid? -> UniqueIdentifier
                    acceso.CrearParametro("@Email",          entity.Email),              // string
                    acceso.CrearParametro("@Password",       Encriptador.Hash(entity.Password)), // string
                    acceso.CrearParametro("@Nombre",         entity.Nombre),             // string
                    acceso.CrearParametro("@Apellido",       entity.Apellido),           // string
                    acceso.CrearParametro("@Nombre_Usuario", $"{entity.Nombre[0]}{entity.Apellido[0]}_{entity.Legajo}"), // string
                    acceso.CrearParametro("@Legajo",         entity.Legajo),             // int
                    acceso.CrearParametro("@Fecha_Alta",     entity.FechaAlta),          // DateTime
                    acceso.CrearParametro("@Idioma_Id",      entity.Idioma?.Id)          // Guid? (si es null, el parámetro será DBNull)
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


        public List<Usuario> ObtenerlistaDeUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ListarUsuarios"))
                {
                    while (reader.Read())
                    {
                        Guid usuarioId = Guid.Parse(reader["usuario_id"].ToString());
                        
                        int rolId = ObtenerUltimoRol(usuarioId);
                        Usuario usuario = UsuarioFactory.CrearUsuario(rolId);
                        usuario.Id = usuarioId;
                        usuario.Email = reader["email"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Apellido = reader["apellido"].ToString();
                        usuario.NombreUsuario = reader["nombre_usuario"].ToString();
                        usuario.Legajo = int.Parse(reader["legajo"].ToString());
                        usuario.FechaAlta = DateTime.Parse(reader["fecha_alta"].ToString());
                        usuario.UltimoInicioSesion = DateTime.Now;
                        usuario.Roles = GetRolesInternal(usuario);
                        listaUsuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios", ex);
            }
            finally
            {
                acceso.Cerrar();
            }

            return listaUsuarios;
        }

        public Usuario Login(string email, string password)
        {
            var parametros = new List<SqlParameter>{ acceso.CrearParametro("@Email", email), acceso.CrearParametro("@Password", Encriptador.Hash(password))};

            Usuario usuario = null;
            Guid usuarioId = Guid.Empty;
            string emailDb = string.Empty;
            string passwordDb = string.Empty;
            string nombre = string.Empty;
            string apellido = string.Empty;
            string nombreUsuario = string.Empty;
            int legajo = 0;
            DateTime fechaAlta = DateTime.MinValue;

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_LoginUsuario", parametros))
                {
                    if (reader.Read())
                    {
                        usuarioId = Guid.Parse(reader["usuario_id"].ToString());
                        emailDb = reader["email"].ToString();
                        passwordDb = reader["password"].ToString();
                        nombre = reader["nombre"].ToString();
                        apellido = reader["apellido"].ToString();
                        nombreUsuario = reader["nombre_usuario"].ToString();
                        legajo = int.Parse(reader["legajo"].ToString());
                        fechaAlta = DateTime.Parse(reader["fecha_alta"].ToString());
                    }
                    else
                    {
   
                        return null;
                    }
                } 

                int rolId = ObtenerUltimoRol(usuarioId);
                if (rolId ==-1)
                    {
                    
                    return usuario;
                    

                }
                usuario = UsuarioFactory.CrearUsuario(rolId);
                usuario.Id = usuarioId;
                usuario.Email = emailDb;
                usuario.Password = passwordDb;
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.NombreUsuario = nombreUsuario;
                usuario.Legajo = legajo;
                usuario.FechaAlta = fechaAlta;
                usuario.UltimoInicioSesion = DateTime.Now;
                usuario.Roles = GetRolesInternal(usuario);
                usuario.Permisos = GetPermisosInternal(usuario);
                usuario.UltimoRolId = rolId;
                usuario.Idioma = ObtenerIdiomaInternal(usuario);

                // Carga de atributos específicos según el rol
                switch (rolId)
                {
                    case 1: // Administrador
                        usuario = CargarAtributosAdministradorInternal((Administrador)usuario, usuarioId);
                        break;
                    case 2: // Técnico
                            // usuario = CargarAtributosTecnicoInternal((Tecnico)usuario, usuarioId);
                        break;
                    case 3: // Cliente
                        usuario = CargarAtributosClienteInternal((Cliente)usuario, usuarioId);
                        break;
                    default:
                        throw new Exception("Rol no reconocido");
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar iniciar sesión", ex);
            }
            finally
            {
                if (acceso.ObtenerConexion()!=null){
                    acceso.Cerrar();
                }
             
            }
        }



        private int ObtenerUltimoRolInternal(Guid usuarioId)
        {
            var rolId = -1;
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UsuarioID", usuarioId.ToString())
            };

            DataTable resultado = acceso.Leer("sp_ObtenerUsuarioDeSesion", parametros);
            if (resultado.Rows.Count > 0)
            {
                
                rolId = Convert.ToInt32(resultado.Rows[0]["ultimo_rol_id"]);
            }
   
            return rolId;
        }

        private List<Rol> GetRolesInternal(Usuario usuario)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UsuarioId", usuario.Id.ToString())
            };

            using (var reader = acceso.EjecutarLectura("sp_ObtenerRolesUsuario", parametros))
            {
                return MapearRoles(reader);
            }
        }

        private IIdioma ObtenerIdiomaInternal(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UsuarioID", usuario.Id.ToString())
            };

            DataTable resultado = acceso.Leer("sp_ObtenerIdiomaDeSesion", parametros);
            if (resultado.Rows.Count > 0)
            {
                Idioma idioma = new Idioma
                {
                    Id = Guid.Parse(resultado.Rows[0]["idioma_id"].ToString()),
                    Nombre = resultado.Rows[0]["idioma_nombre"].ToString()
                };
                usuario.Idioma = idioma;
            }
            return usuario.Idioma;
        }

        private Administrador CargarAtributosAdministradorInternal(Administrador administrador, Guid usuarioId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@usuario_id", usuarioId.ToString())
            };

            using (var reader = acceso.EjecutarLectura("sp_ObtenerAtributosAdministrador", parametros))
            {
                if (reader.Read())
                {
                    administrador.Estado = reader["estado"] != DBNull.Value && (bool)reader["estado"];
                    administrador.FechaCreacion = reader["fecha_creacion"] != DBNull.Value ? DateTime.Parse(reader["fecha_creacion"].ToString()) : (DateTime?)null;
                }
            }
            return administrador;
        }

        private Cliente CargarAtributosClienteInternal(Cliente usuario, Guid usuarioId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@usuario_id", usuarioId.ToString())
    };

            using (var reader = acceso.EjecutarLectura("sp_ObtenerAtributosCliente", parametros))
            {
                if (reader.Read())
                {
                    usuario.ClienteId = reader["cliente_id"] != DBNull.Value ? (int)reader["cliente_id"] : 0;

                    int departamentoId = reader["departamento_id"] != DBNull.Value ? (int)reader["departamento_id"] : 0;
                    if (departamentoId > 0)
                    {
                        DepartamentosDAL deptDal = new DepartamentosDAL();
                        usuario.Departamento = deptDal.ObtenerDepartamentoPorId(departamentoId);
                    }

                    usuario.Direccion = reader["direccion"] != DBNull.Value ? reader["direccion"].ToString() : null;
                    usuario.EmailContacto = reader["email_contacto"] != DBNull.Value ? reader["email_contacto"].ToString() : null;

                    usuario.FechaRegistro = reader["fecha_registro"] != DBNull.Value
                        ? DateTime.Parse(reader["fecha_registro"].ToString())
                        : (DateTime?)null;

                    usuario.FechaUltimaInteraccion = reader["fecha_ultima_interaccion"] != DBNull.Value
                        ? DateTime.Parse(reader["fecha_ultima_interaccion"].ToString())
                        : (DateTime?)null;

                    usuario.PreferenciaContacto = reader["preferencia_contacto"] != DBNull.Value ? reader["preferencia_contacto"].ToString() : null;
                    usuario.Telefono = reader["telefono"] != DBNull.Value ? reader["telefono"].ToString() : null;

                    usuario.Estado = reader["estado"] != DBNull.Value && (bool)reader["estado"];
                    usuario.Observaciones = reader["observaciones"] != DBNull.Value ? reader["observaciones"].ToString() : null;
                    usuario.EsAprobador = reader["es_aprobador"] != DBNull.Value && (bool)reader["es_aprobador"];
                }
            }
            return usuario;
        }


    
        private List<Componente> GetPermisosInternal(Usuario user)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", user.Id.ToString())
            };

            using (var reader = acceso.EjecutarLectura("sp_ObtenerPermisosUsuario", parametros))
            {
                List<Componente> permisos = new List<Componente>();
                while (reader.Read())
                {
                    Patente permiso = new Patente
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("permiso_id")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        //Permiso = reader.GetString(reader.GetOrdinal("descripcion"))
                    };
                    permisos.Add(permiso);
                }
                return permisos;
            }
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
                //// Se elimina la configuración actual de permisos del usuario
                //acceso.Escribir("sp_EliminarPermisosUsuario", parametrosEliminar);

                foreach (var permiso in usuario.Permisos)
                {
                    var parametrosInsertar = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", usuario.Id.ToString()),
                acceso.CrearParametro("@id_permiso", permiso.Id)
            };

                    // Se ejecuta siempre el SP para agregar el permiso al usuario
                    acceso.Escribir("sp_agregar_permisos_usuario", parametrosInsertar);

                    // Si el permiso es 1, 2 o 3, también se agrega en la tabla de roles del usuario
                    if (permiso.Id == 1 || permiso.Id == 2 || permiso.Id == 3)
                    {
                        acceso.Escribir("sp_agregar_rol_usuario", parametrosInsertar);
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        public List<Patente> GetPermisos(Usuario user)
        {
            var parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", user.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerPermisosUsuario", parametros))
                {
                    List<Patente> permisos = new List<Patente>();
                    while (reader.Read())
                    {
                        Patente permiso = new Patente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Permiso = reader.GetString(reader.GetOrdinal("permiso"))
                        };
                        permisos.Add(permiso);
                    }
                    return permisos;
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public List<Rol> GetRoles(Usuario usuario)
        {
            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerRolesUsuario",
                    new List<SqlParameter> { acceso.CrearParametro("@UsuarioId", usuario.Id.ToString()) }))
                {
                    List<Rol> roles = MapearRoles(reader);
                    return roles;
                }
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public Usuario CambiarDeRol(Guid usuarioId, int rolId)
        {
            Usuario usuario;

            try
            {
                acceso.Abrir();

                // 1) Traer datos base de la tabla 'usuarios'
                var pUsuario = new List<SqlParameter>
            {
                acceso.CrearParametro("@usuario_id", usuarioId.ToString())
            };
                using (var reader = acceso.EjecutarLectura(
                    "sp_ObtenerUsuarioPorId", pUsuario))
                {
                    if (!reader.Read())
                        throw new Exception($"Usuario {usuarioId} no encontrado.");

                    // 2) Crear la instancia concreta según rol
                    usuario = UsuarioFactory.CrearUsuario(rolId);
                    usuario.Id = usuarioId;
                    usuario.Email = reader["email"].ToString();
                    usuario.Password = reader["password"].ToString();
                    usuario.Nombre = reader["nombre"].ToString();
                    usuario.Apellido = reader["apellido"].ToString();
                    usuario.NombreUsuario = reader["nombre_usuario"].ToString();
                    usuario.Legajo = Convert.ToInt32(reader["legajo"]);
                    //usuario.FechaAlta = reader["fecha_alta"] != DBNull.Value ? DateTime.Parse(reader["fecha_alta"].ToString())
                    usuario.UltimoInicioSesion = reader["ultimo_inicio_sesion"] != DBNull.Value
                                              ? DateTime.Parse(reader["ultimo_inicio_sesion"].ToString())
                                              : DateTime.Now;
                }

                // 3) Cargar idioma y roles generales
                usuario.Idioma = ObtenerIdiomaInternal(usuario);
                usuario.Roles = GetRolesInternal(usuario);
                usuario.UltimoRolId = rolId;

                // 4) Despachar a la carga de atributos por subclase
                switch (rolId)
                {
                    case 1: // Administrador
                        usuario = CargarAtributosAdministradorInternal((Administrador)usuario, usuarioId);
                        break;
                    //case 2: // Técnico
                        //usuario = CargarAtributosTecnicoInternal((Tecnico)usuario, usuarioId);
                        break;
                    case 3: // Cliente
                        usuario = CargarAtributosClienteInternal((Cliente)usuario, usuarioId);
                        break;
                    default:
                        throw new Exception("Rol no reconocido.");
                }

                return usuario;
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public int ObtenerUltimoRol(Guid usuarioId)
        {
            try
            {
                acceso.Abrir();
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@UsuarioID", usuarioId.ToString())
                };

                DataTable resultado = acceso.Leer("sp_ObtenerUsuarioDeSesion", parametros);
                acceso.Cerrar();
               var rolId = -1;
                if (resultado.Rows.Count > 0)
                {
                    rolId = Convert.ToInt32(resultado.Rows[0]["ultimo_rol_id"]);
                }
                else 
                {
                    var lista_de_roles = ObtenerRolesPorUsuario(usuarioId);
                    if (lista_de_roles.Count > 0)
                    {
                        rolId = lista_de_roles[0].Id;
                    }
                


                }
                return rolId;
            }
            finally
            {
                if (acceso.ObtenerConexion() != null)
                    {
                    acceso.Cerrar();
                }
            
            }
            
        }

        public IIdioma ObtenerIdioma(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@UsuarioID", usuario.Id.ToString())
            };

            try
            {
                acceso.Abrir();
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
            acceso.Abrir();
            var lista = new List<Usuario>();
           
            while (reader.Read())
            {
                
                var usuario = MapearUsuario(reader);
                if (incluirPermisos)
                {
                    acceso.Cerrar();
                    // Se utiliza la versión interna para evitar reabrir la conexión
                    usuario.Permisos.AddRange(GetPermisosInternal(usuario));
                }
                lista.Add(usuario);
            }
            return lista;
        }



        public List<Usuario> ObtenerUsuariosConRolClienteNoRegistrados()
        {
            var usuarios = new List<Usuario>();

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@rol_cliente", 2) // Cliente
    };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerUsuariosDisponiblesParaCliente", parametros))
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            Email = reader.GetString(reader.GetOrdinal("email"))
                        });
                    }
                }

                return usuarios;
            }
            finally
            {
                acceso.Cerrar();
            }
        }




        public List<Usuario> ObtenerUsuariosDisponiblesParaAdministrador()
        {
            var usuarios = new List<Usuario>();
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@rol_Admin", 1)
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerUsuariosDisponiblesParaAdministrador", parametros))
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            // Agregá más campos si los necesitás
                        });
                    }
                }
                return usuarios;
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        public List<Usuario> ObtenerUsuariosDisponiblesParaTecnico()
        {
            var usuarios = new List<Usuario>();
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@rol_tecnico", 3)
            };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerUsuariosDisponiblesParaTecnico", parametros))
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            // Agregá más campos si los necesitás
                        });
                    }
                }
                return usuarios;
            }
            finally
            {
                acceso.Cerrar();
            }
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
                UltimoInicioSesion = DateTime.Now,
                Idioma = idioma

            };
        }
        public List<Rol> ObtenerRolesPorUsuario(Guid usuarioId)
        {
            try
            {
                acceso.Abrir();
                List<SqlParameter> parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@UsuarioId", usuarioId.ToString())
        };

                using (var reader = acceso.EjecutarLectura("sp_ObtenerRolesUsuario", parametros))
                {
                    return MapearRoles(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener roles por usuario: " + ex.Message, ex);
            }
            //finally
            //{
            //    acceso.Cerrar();
            //}
        }

        public bool ExisteUsuario(Guid usuarioId)
        {
            try
            {
                acceso.Abrir();
                var parametros = new List<SqlParameter>
        {
            acceso.CrearParametro("@usuario_id", usuarioId.ToString())
        };

                DataTable resultado = acceso.Leer("sp_ExisteUsuario", parametros);
                if (resultado.Rows.Count > 0)
                {
                    int cantidad = Convert.ToInt32(resultado.Rows[0][0]);
                    return cantidad > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar existencia del usuario", ex);
            }
            finally
            {
                acceso.Cerrar();
            }
        }

        public Usuario ObtenerPorId(int legajo)
        {
            Usuario usuario = null;

            var parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@Legajo", legajo)
    };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerUsuarioPorLegajo", parametros))
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = Guid.Parse(reader["usuario_id"].ToString()),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            NombreUsuario = reader["nombre_usuario"].ToString(),
                            Legajo = int.Parse(reader["legajo"].ToString()),
                            FechaAlta = DateTime.Parse(reader["fecha_alta"].ToString()),
                            DigitoVerificadorH = reader["digito_verificador_h"]?.ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario por legajo", ex);
            }
            finally
            {
                acceso.Cerrar();
            }

            return usuario;
        }

        public void ActualizarDVH(Usuario usuario)
        {
            var parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@UsuarioId", usuario.Id),
        acceso.CrearParametro("@DigitoVerificadorH", usuario.DigitoVerificadorH)
    };

            try
            {
                acceso.Abrir();
                acceso.Escribir("sp_ActualizarDVH_Usuario", parametros); // creá este SP
            }
            finally
            {
                acceso.Cerrar();
            }
        }


        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ListarUsuariosConDVH")) // asegurate de que este SP incluya la columna DigitoVerificadorH
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = Guid.Parse(reader["usuario_id"].ToString()),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Apellido = reader["apellido"].ToString(),
                            NombreUsuario = reader["nombre_usuario"].ToString(),
                            Legajo = int.Parse(reader["legajo"].ToString()),
                            FechaAlta = DateTime.Parse(reader["fecha_alta"].ToString()),
                            DigitoVerificadorH = reader["digito_verificador_h"]?.ToString()
                        };

                        listaUsuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios", ex);
            }
            finally
            {
                acceso.Cerrar();
            }

            return listaUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(Guid usuarioId)
        {
            Usuario usuario = null;
            var parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@UsuarioId", usuarioId)
    };

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("sp_ObtenerUsuarioPorId", parametros))
                {
                    if (reader.Read())
                    {
                        // Mapea igual que en MapearUsuario, incluyendo DVH
                        usuario = new Usuario
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                            NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario")),
                            Legajo = reader.GetInt32(reader.GetOrdinal("legajo")),
                            FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta")),
                            UltimoInicioSesion = reader.IsDBNull(reader.GetOrdinal("ultimo_inicio_sesion"))
                                                 ? (DateTime?)null
                                                 : reader.GetDateTime(reader.GetOrdinal("ultimo_inicio_sesion")),
                            DigitoVerificadorH = reader["digito_verificador_h"]?.ToString()
                        };
                    }
                }
            }
            finally
            {
                acceso.Cerrar();
            }

            return usuario;
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


    }
}
