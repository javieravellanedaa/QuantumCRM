using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DepartamentoBLL
    {
        // Instancia de la capa DAL
        private DepartamentosDAL departamentosDAL = new DepartamentosDAL();

        // Método para listar todos los departamentos
        public List<Departamento> ListarDepartamentos()
        {
            return departamentosDAL.ListarDepartamentos();
        }

        // Método para agregar un nuevo departamento
        public int AgregarDepartamento(Departamento departamento)
        {
            return departamentosDAL.AgregarDepartamento(departamento);
        }

        // Método para actualizar un departamento existente
        public void ActualizarDepartamento(Departamento departamento)
        {
            departamentosDAL.ActualizarDepartamento(departamento);
        }

        // Método para eliminar un departamento
        public void EliminarDepartamento(int departamentoId)
        {
            departamentosDAL.EliminarDepartamento(departamentoId);
        }

        // Método para obtener un departamento por su Id
        public Departamento ObtenerDepartamentoPorId(int departamentoId)
        {
            return departamentosDAL.ObtenerDepartamentoPorId(departamentoId);
        }

        // Método para listar departamentos por estado
        public List<Departamento> ListarDepartamentosPorEstado(bool estado)
        {
            return departamentosDAL.ListarDepartamentosPorEstado(estado);
        }

        // Método para buscar departamentos por nombre
        public List<Departamento> BuscarDepartamentoPorNombre(string nombre)
        {
            return departamentosDAL.BuscarDepartamentoPorNombre(nombre);
        }

        // Método para listar departamentos prioritarios
        public List<Departamento> ListarDepartamentosPrioritarios()
        {
            return departamentosDAL.ListarDepartamentosPrioritarios();
        }

        // Método para listar departamentos por ubicación
        public List<Departamento> ListarDepartamentosPorUbicacion(int ubicacionId)
        {
            return departamentosDAL.ListarDepartamentosPorUbicacion(ubicacionId);
        }
    }
}
