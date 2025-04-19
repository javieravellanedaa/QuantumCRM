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
                acceso.CrearParametro("@nombre_usuario", entity.Nombre[0] + entity.Apellido[0] + "_" + entity.Legajo),
                acceso.CrearParametro("@fecha_alta", entity.FechaAlta),
                acceso.CrearParametro("@idioma_id", entity.Idioma.Id.ToString())
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

        // Método público que administra la conexión y mapea cada registro a un Usuario.
        public List<Usuario> ObtenerlistaDeUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                acceso.Abrir();
                using (var reader = acceso.EjecutarLectura("usuarios_listar"))
                {
                    while (reader.Read())
                    {
                        Guid usuarioId = Guid.Parse(reader["usuario_id"].ToString());
                        // Se llama a la versión interna que asume conexión abierta.
                        
                        int rolId = ObtenerUltimoRolInternal(usuarioId);

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

                        // Se podrían mapear permisos, roles o idioma usando las versiones internas.
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
            var parametros = new List<SqlParameter>
    {
        acceso.CrearParametro("@Email", email),
        acceso.CrearParametro("@Password", Encriptador.Hash(password))
    };

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
                // Primero se ejecuta el sp_LoginUsuario y se leen los datos
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
                        // No se encontró el usuario
                        return null;
                    }
                } // Se cierra el DataReader aquí

                // Ahora que no hay ningún DataReader abierto, se pueden ejecutar nuevos comandos.
                int rolId = ObtenerUltimoRolInternal(usuarioId);
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
                acceso.Cerrar();
            }
        }


        #region Métodos Internos (asumen conexión abierta)

        // Versiones internas: no abren ni cierran la conexión

        private int ObtenerUltimoRolInternal(Guid usuarioId)
        {
            int rolId = 3; // Valor predeterminado
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

                    if (usuario.DepartamentoId > 0)
                    {
                        DepartamentosDAL deptDal = new DepartamentosDAL();
                        usuario.Departamento = deptDal.ObtenerDepartamentoPorId(usuario.DepartamentoId);
                    }
                }
            }
            return usuario;
        }

        // Para mapear permisos cuando ya se tiene la conexión abierta.
        private List<Patente> GetPermisosInternal(Usuario user)
        {
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", user.Id.ToString())
            };

            using (var reader = acceso.EjecutarLectura("sp_ObtenerPermisosUsuario", parametros))
            {
                List<Patente> permisos = new List<Patente>();
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

        #endregion

        public void GuardarPermisos(Usuario usuario)
        {
            var parametrosEliminar = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario", usuario.Id.ToString())
            };

            try
            {
                acceso.Abrir();
                // Se elimina la configuración actual de permisos del usuario
                acceso.Escribir("sp_EliminarPermisosUsuario", parametrosEliminar);

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
                    "sp_obtener_usuario_por_id", // Stored procedure que haga: SELECT * FROM usuarios WHERE usuario_id=@UsuarioID
                    pUsuario))
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
                int rolId = 3;
                if (resultado.Rows.Count > 0)
                {
                    rolId = Convert.ToInt32(resultado.Rows[0]["ultimo_rol_id"]);
                }
                return rolId;
            }
            finally
            {
                acceso.Cerrar();
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
            finally
            {
                acceso.Cerrar();
            }
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
