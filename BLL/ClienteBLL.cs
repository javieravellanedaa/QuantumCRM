using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL _clienteDAL;

        public ClienteBLL()
        {
            _clienteDAL = new ClienteDAL();
        }

        public Cliente ObtenerClientePorID(int clienteId)
        {
            try
            {
                return _clienteDAL.ObtenerClientePorID(clienteId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción (registrar el error, rethrow, etc.)
                throw new Exception("Error al obtener el cliente por ID.", ex);
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

        public void AsignarTecnicoACliente(int clienteId, int tecnicoId)
        {
            try
            {
                _clienteDAL.AsignarTecnicoACliente(clienteId, tecnicoId);
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                throw new Exception("Error al asignar técnico al cliente.", ex);
            }
        }
    }
}
