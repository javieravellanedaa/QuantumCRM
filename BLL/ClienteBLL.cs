using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL _clienteDAL;

        public ClienteBLL()
        {
            _clienteDAL = new ClienteDAL();
        }

        public Cliente ObtenerClientePorId(int clienteId)
        {
            try
            {
                return _clienteDAL.ObtenerClientePorId(clienteId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción (registrar el error, rethrow, etc.)
                throw new Exception("Error al obtener el cliente por ID.", ex);
            }
        }


        public Guid ObtenerIdUsuarioPorClienteId(int clienteId)
        {
            try
            {
                return _clienteDAL.ObtenerIdUsuarioPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al obtener el ID de usuario por cliente ID.", ex);
            }
        }
        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                _clienteDAL.AgregarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al agregar el cliente.", ex);
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            try
            {
                _clienteDAL.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al actualizar el cliente.", ex);
            }
        }

        public void EliminarCliente(int clienteId)
        {
            try
            {
                _clienteDAL.EliminarCliente(clienteId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al eliminar el cliente.", ex);
            }
        }

        public List<Cliente> ListarClientesPorDepartamento(int departamentoId)
        {
            try
            {
                return _clienteDAL.ListarClientesPorDepartamento(departamentoId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al listar clientes por departamento.", ex);
            }
        }


        public List<Cliente> ListarClientes()
        {
            try
            {
                return _clienteDAL.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes.", ex);
            }
        }

        public List<Cliente> ListarClientesAprobadores()
        {
            try
            {
                return _clienteDAL.ListarClientesAprobadores();
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al listar los clientes aprobadores.", ex);
            }
        }


        public void MarcarComoAprobador(int clienteId)
        {
            _clienteDAL.ActualizarEstadoAprobador(clienteId, true);
        }


        public Cliente ObtenerClientePorIdUsuario(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("El ID de usuario no puede ser vacío.", nameof(usuarioId));

            try
            {
                // Devolvemos directamente lo que nos devuelve la DAL (puede ser null)
                return _clienteDAL.ObtenerClientePorIdUsuario(usuarioId);
            }
            catch (SqlException sqlex)
            {
                // Si quieres capturar errores de BD
                throw new Exception("Error de base de datos al obtener el cliente por ID de usuario.", sqlex);
            }
            catch (Exception ex)
            {
                // Otros errores
                throw new Exception("Error inesperado al obtener el cliente por ID de usuario.", ex);
            }
        }

    }
}

