using BE;
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DAL
{
    public class ClienteDAL
    {

        private readonly Acceso _acceso = new Acceso();
        public ClienteDAL()
        {

        }


        private bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }



        #region MapearCliente  
        // Mapeo completo de Cliente (incluye datos de Usuario y de Cliente)
        //private Cliente MapearCliente(SqlDataReader reader)
        //{
        //    return new Cliente
        //    {
        //        // Campos heredados de Usuario

        //        Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
        //        Email = reader.GetString(reader.GetOrdinal("email")),
        //        Password = reader.GetString(reader.GetOrdinal("password")),
        //        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
        //        Apellido = reader.GetString(reader.GetOrdinal("apellido")),
        //        NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario")),
        //        Legajo = reader.GetInt32(reader.GetOrdinal("legajo")),
        //        FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta")),
        //        UltimoInicioSesion = reader.IsDBNull(reader.GetOrdinal("ultimo_inicio_sesion"))
        //                                  ? (DateTime?)null
        //                                  : reader.GetDateTime(reader.GetOrdinal("ultimo_inicio_sesion")),

        //        // Campos propios de Cliente
        //        ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id")),
        //        Departamento = new Departamento
        //        {
        //            Id = reader.GetInt32(reader.GetOrdinal("departamento_id"))
        //        },
        //        FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecha_registro"))
        //                                  ? (DateTime?)null
        //                                  : reader.GetDateTime(reader.GetOrdinal("fecha_registro")),
        //        Telefono = reader.IsDBNull(reader.GetOrdinal("telefono"))
        //                                  ? null
        //                                  : reader.GetString(reader.GetOrdinal("telefono")),
        //        Direccion = reader.IsDBNull(reader.GetOrdinal("direccion"))
        //                                  ? null
        //                                  : reader.GetString(reader.GetOrdinal("direccion")),
        //        EmailContacto = reader.IsDBNull(reader.GetOrdinal("email_contacto"))
        //                                  ? null
        //                                  : reader.GetString(reader.GetOrdinal("email_contacto")),
        //        FechaUltimaInteraccion = reader.IsDBNull(reader.GetOrdinal("fecha_ultima_interaccion"))
        //                                  ? (DateTime?)null
        //                                  : reader.GetDateTime(reader.GetOrdinal("fecha_ultima_interaccion")),
        //        PreferenciaContacto = reader.IsDBNull(reader.GetOrdinal("preferencia_contacto"))
        //                                  ? null
        //                                  : reader.GetString(reader.GetOrdinal("preferencia_contacto")),
        //        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
        //        Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones"))
        //                                  ? null
        //                                  : reader.GetString(reader.GetOrdinal("observaciones")),
        //        EsAprobador = reader.GetBoolean(reader.GetOrdinal("es_aprobador"))
        //    };
        //}

        private Cliente MapearCliente(SqlDataReader reader)
        {
            var cliente = new Cliente();

            // --- Campos de Usuario (opcionales) ---
            if (HasColumn(reader, "usuario_id"))
                cliente.Id = reader.GetGuid(reader.GetOrdinal("usuario_id"));

            if (HasColumn(reader, "email"))
                cliente.Email = reader.GetString(reader.GetOrdinal("email"));

            if (HasColumn(reader, "password"))
                cliente.Password = reader.GetString(reader.GetOrdinal("password"));

            if (HasColumn(reader, "nombre"))
                cliente.Nombre = reader.GetString(reader.GetOrdinal("nombre"));

            if (HasColumn(reader, "apellido"))
                cliente.Apellido = reader.GetString(reader.GetOrdinal("apellido"));

            if (HasColumn(reader, "nombre_usuario"))
                cliente.NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario"));

            if (HasColumn(reader, "legajo"))
                cliente.Legajo = reader.GetInt32(reader.GetOrdinal("legajo"));

            if (HasColumn(reader, "fecha_alta"))
                cliente.FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta"));

            if (HasColumn(reader, "ultimo_inicio_sesion"))
                cliente.UltimoInicioSesion = reader.IsDBNull(reader.GetOrdinal("ultimo_inicio_sesion"))
                    ? (DateTime?)null
                    : reader.GetDateTime(reader.GetOrdinal("ultimo_inicio_sesion"));

            // --- Campos propios de Cliente (estos sí siempre están en tu SP) ---
            cliente.ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id"));

            // departamento_id siempre existe
            cliente.Departamento = new Departamento
            {
                Id = reader.GetInt32(reader.GetOrdinal("departamento_id"))
            };

            if (HasColumn(reader, "fecha_registro"))
                cliente.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("fecha_registro"))
                    ? (DateTime?)null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_registro"));

            if (HasColumn(reader, "telefono"))
                cliente.Telefono = reader.IsDBNull(reader.GetOrdinal("telefono"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("telefono"));

            if (HasColumn(reader, "direccion"))
                cliente.Direccion = reader.IsDBNull(reader.GetOrdinal("direccion"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("direccion"));

            if (HasColumn(reader, "email_contacto"))
                cliente.EmailContacto = reader.IsDBNull(reader.GetOrdinal("email_contacto"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("email_contacto"));

            if (HasColumn(reader, "fecha_ultima_interaccion"))
                cliente.FechaUltimaInteraccion = reader.IsDBNull(reader.GetOrdinal("fecha_ultima_interaccion"))
                    ? (DateTime?)null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_ultima_interaccion"));

            if (HasColumn(reader, "preferencia_contacto"))
                cliente.PreferenciaContacto = reader.IsDBNull(reader.GetOrdinal("preferencia_contacto"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("preferencia_contacto"));

            if (HasColumn(reader, "estado"))
                cliente.Estado = reader.GetBoolean(reader.GetOrdinal("estado"));

            if (HasColumn(reader, "observaciones"))
                cliente.Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("observaciones"));

            if (HasColumn(reader, "es_aprobador"))
                cliente.EsAprobador = reader.GetBoolean(reader.GetOrdinal("es_aprobador"));

            return cliente;
        }




        public Cliente ObtenerClientePorId(Guid usuarioId)
        {
         
            var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@usuario_id", usuarioId)
                };

            try
            {
               
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerClientePorIdUsuario", parametros))
                {
                    if (reader.Read())
                    {
                        return MapearCliente(reader);
                    }
                }
            }
            finally
            {
            
                _acceso.Cerrar();
            }

  
            return null;
        }

        #endregion  

        public Cliente ObtenerClientePorId(int clienteId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ClienteID", clienteId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerClientePorID", parametros))
                {
                    if (reader.Read())
                    {
                            return MapearCliente(reader);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return null;
        }

        public List<Cliente> ListarClientesDisponiblesParaLider()
        {
            List<Cliente> clientes = new List<Cliente>();
            _acceso.Abrir();

            using (var reader = _acceso.EjecutarLectura("sp_ListarClientesParaLider"))
            {
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                        Email = reader.GetString(reader.GetOrdinal("email"))
                    });
                }
            }

            _acceso.Cerrar();
            return clientes;
        }


        public void AgregarCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@UsuarioID", cliente.Id.ToString()), // ID heredado de Usuario (GUID)
                    _acceso.CrearParametro("@DepartamentoID", cliente.Departamento.Id.ToString()),
                    _acceso.CrearParametro("@FechaRegistro", cliente.FechaRegistro?.ToString("yyyy-MM-dd HH:mm:ss")),
                    _acceso.CrearParametro("@Telefono", cliente.Telefono),
                    _acceso.CrearParametro("@Direccion", cliente.Direccion),
                    _acceso.CrearParametro("@EmailContacto", cliente.EmailContacto),
                    _acceso.CrearParametro("@FechaUltimaInteraccion", cliente.FechaUltimaInteraccion?.ToString("yyyy-MM-dd HH:mm:ss")),
                    _acceso.CrearParametro("@PreferenciaContacto", cliente.PreferenciaContacto),
                    _acceso.CrearParametro("@Estado", cliente.Estado ? "1" : "0"),
                    _acceso.CrearParametro("@Observaciones", cliente.Observaciones),
                    _acceso.CrearParametro("@EsAprobador", cliente.EsAprobador ? "1" : "0")
                };

            try
            {
                _acceso.Abrir();
                _acceso.ComenzarTransaccion();
                cliente.ClienteId = Convert.ToInt32(_acceso.EscribirEscalar("sp_CrearCliente", parametros));
                _acceso.ConfirmarTransaccion();
            }
            catch (Exception)
            {
                _acceso.CancelarTransaccion();
                throw;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ClienteID", cliente.Id.ToString()),
                _acceso.CrearParametro("@Telefono", cliente.Telefono),
                _acceso.CrearParametro("@Direccion", cliente.Direccion),
                _acceso.CrearParametro("@EmailContacto", cliente.EmailContacto),
                _acceso.CrearParametro("@PreferenciaContacto", cliente.PreferenciaContacto)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarCliente", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void EliminarCliente(int clienteId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ClienteID", clienteId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarCliente", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }


        public List<Cliente> ListarClientesPorDepartamento(int departamentoId)
        {
            List<Cliente> clientes = new List<Cliente>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DepartamentoID", departamentoId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerClientesPorDepartamento", parametros))
                {

                    while (reader.Read())
                    {
                        Cliente cliente = MapearCliente(reader);
                        clientes.Add(cliente);

                    }
    
                  
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return clientes;
        }


        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarClientes"))
                {
                    while (reader.Read())
                    {
                        Cliente cliente = MapearCliente(reader);


                        clientes.Add(cliente);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            return clientes;
        }


        public List<Cliente> ListarClientesAprobadores ()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarClientesAprobadores"))
                {
                    while (reader.Read())
                    {
                        Cliente cliente = MapearCliente(reader);
                        clientes.Add(cliente);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return clientes;
        }

        public void ActualizarEstadoAprobador(int clienteId, bool esAprobador)
        {
            var parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@ClienteId", clienteId),
        _acceso.CrearParametro("@EsAprobador", esAprobador)
    };

            _acceso.Abrir();
            _acceso.Escribir("sp_ActualizarEsAprobador", parametros);
            _acceso.Cerrar();
        }
        public Guid ObtenerIdUsuarioPorClienteId(int clienteId)
        {
            // Prepara el parámetro
            var parametros = new List<SqlParameter>
    {
        _acceso.CrearParametro("@ClienteID", clienteId)
    };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerUsuarioIdPorClienteId", parametros))
                {
                    if (reader.Read())
                    {
                        // Lee el GUID de la columna usuario_id
                        return reader.GetGuid(reader.GetOrdinal("usuario_id"));
                    }
                    else
                    {
                        throw new KeyNotFoundException($"No se encontró un usuario para el ClienteID {clienteId}.");
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
        public Cliente ObtenerClientePorIdUsuario(Guid usuarioId)
        {
            // Preparamos el parámetro para el SP
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@usuario_id", usuarioId)
            };

            try
            {
                // Abrimos la conexión con Acceso
                _acceso.Abrir();

                // Ejecutamos el SP y obtenemos el lector
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerClientePorIdUsuario", parametros))
                {
                    // Si encontramos un registro, lo mapeamos y devolvemos
                    if (reader.Read())
                    {
                        Cliente cliente = MapearCliente(reader);
                        return cliente;
                    }

                }
            }
            finally
            {
                // Nos aseguramos de cerrar la conexión en todo caso
                _acceso.Cerrar();
            }

            // Si no hay filas, devolvemos null
            return null;
        }


    }

}
