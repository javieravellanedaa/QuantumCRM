using BE;
using DAL;
using System.Collections.Generic;
using System;

public class DepartamentoBLL
{
    private DepartamentosDAL departamentosDAL = new DepartamentosDAL();

    public List<Departamento> ListarDepartamentos() =>
        departamentosDAL.ListarDepartamentos();

    public int AgregarDepartamento(Departamento departamento)
    {
        if (string.IsNullOrWhiteSpace(departamento.Nombre))
            throw new ArgumentException("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(departamento.CodigoDepartamento))
            throw new ArgumentException("El código es obligatorio.");

        return departamentosDAL.AgregarDepartamento(departamento);
    }

    public void ActualizarDepartamento(Departamento departamento)
    {
        if (departamento.Id <= 0)
            throw new ArgumentException("El ID no es válido.");

        departamentosDAL.ActualizarDepartamento(departamento);
    }

    public void EliminarDepartamento(int id) =>
        departamentosDAL.EliminarDepartamento(id);

    public Departamento ObtenerDepartamentoPorId(int id) =>
        departamentosDAL.ObtenerDepartamentoPorId(id);

    public List<Departamento> ListarDepartamentosPorEstado(bool estado) =>
        departamentosDAL.ListarDepartamentosPorEstado(estado);

    public List<Departamento> BuscarDepartamentoPorNombre(string nombre) =>
        departamentosDAL.BuscarDepartamentoPorNombre(nombre);

    public Departamento ObtenerPorCodigo(string codigo) =>
        departamentosDAL.ObtenerDepartamentoPorCodigo(codigo); 
}
