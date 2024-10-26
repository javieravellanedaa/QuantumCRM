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

        // Método para obtener un cliente por su Id
        public Cliente ObtenerClientePorID(int clienteId)
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

        // Método para crear un nuevo cliente
        // Método para crear un nuevo cliente
        public void AgregarCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@UsuarioID", cliente.Id.ToString()), // Id heredado de Usuario
                _acceso.CrearParametro("@DepartamentoID", cliente.DepartamentoId),
                _acceso.CrearParametro("@FechaRegistro", cliente.FechaRegistro),
                _acceso.CrearParametro("@EstadoClienteID", cliente.EstadoClienteId),
                _acceso.CrearParametro("@TipoClienteID", cliente.TipoClienteId),
                _acceso.CrearParametro("@Telefono", cliente.Telefono),
                _acceso.CrearParametro("@Direccion", cliente.Direccion) ,
                _acceso.CrearParametro("@EmailContacto", cliente.EmailContacto),
                _acceso.CrearParametro("@EsInterno", cliente.EsInterno),
                _acceso.CrearParametro("@Empresa", cliente.Empresa),
                _acceso.CrearParametro("@PreferenciaContacto", cliente.PreferenciaContacto)
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


        // Método para actualizar un cliente existente
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

        // Método para eliminar un cliente
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

        // Método para listar clientes por departamento
        public List<Cliente> ListarClientesPorDepartamento(int departamentoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DepartamentoID", departamentoId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerClientesPorDepartamento", parametros))
                {
                    return MapearClientes(reader);
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Método para asignar un técnico a un cliente
        public void AsignarTecnicoACliente(int clienteId, int tecnicoId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ClienteID", clienteId),
                _acceso.CrearParametro("@TecnicoID", tecnicoId)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_AsignarTecnicoACliente", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Método auxiliar para mapear una lista de clientes
        private List<Cliente> MapearClientes(SqlDataReader reader)
        {
            List<Cliente> clientes = new List<Cliente>();

            while (reader.Read())
            {
                clientes.Add(MapearCliente(reader));
            }

            return clientes;
        }

        // Método auxiliar para mapear un solo cliente
        private Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id")),
                Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                DepartamentoId = reader.GetInt32(reader.GetOrdinal("departamento_id")),
                FechaRegistro = reader.GetDateTime(reader.GetOrdinal("fecha_registro")),
                EstadoClienteId = reader.GetInt32(reader.GetOrdinal("estado_cliente_id")),
                TipoClienteId = reader.GetInt32(reader.GetOrdinal("tipo_cliente_id")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString(reader.GetOrdinal("telefono")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("direccion")) ? null : reader.GetString(reader.GetOrdinal("direccion")),
                EmailContacto = reader.IsDBNull(reader.GetOrdinal("email_contacto")) ? null : reader.GetString(reader.GetOrdinal("email_contacto")),
                EsInterno = reader.GetBoolean(reader.GetOrdinal("es_interno")),
                Empresa = reader.IsDBNull(reader.GetOrdinal("empresa")) ? null : reader.GetString(reader.GetOrdinal("empresa")),
                PreferenciaContacto = reader.IsDBNull(reader.GetOrdinal("preferencia_contacto")) ? null : reader.GetString(reader.GetOrdinal("preferencia_contacto"))
            };
        }
    }

}
