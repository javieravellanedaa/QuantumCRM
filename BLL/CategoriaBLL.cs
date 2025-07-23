using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL _categoriaDAL;
        private readonly CategoriaDepartamentoVisibleDAL _visibilidadDAL;

        public CategoriaBLL()
        {
            _categoriaDAL = new CategoriaDAL();
            _visibilidadDAL = new CategoriaDepartamentoVisibleDAL();
        }

        public void AgregarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentException("La categoría no puede ser nula.");

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            if (categoria.AprobadorRequerido && categoria.ClienteAprobador == null)
                throw new ArgumentException("Debe seleccionarse un cliente aprobador si se requiere aprobación.");

            categoria.Eliminado = false;

            // Persistir categoría principal
            _categoriaDAL.AgregarCategoria(categoria);

            // Persistir visibilidad de departamentos, si hay alguno
            if (categoria.DepartamentosVisiblesIds != null && categoria.DepartamentosVisiblesIds.Count > 0)
            {
                _visibilidadDAL.ActualizarVisibilidad(
                    categoria.CategoriaId,
                    categoria.DepartamentosVisiblesIds
                );
            }
        }

        public void ActualizarCategoriaConVisibilidad(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria), "La categoría no puede ser nula.");

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            if (categoria.AprobadorRequerido && categoria.ClienteAprobador == null)
                throw new ArgumentException("Debe seleccionarse un cliente aprobador si se requiere aprobación.");

            // Actualizar datos de categoría
            _categoriaDAL.ActualizarCategoria(categoria);

            // Actualizar la visibilidad de departamentos
            _visibilidadDAL.ActualizarVisibilidad(
                categoria.CategoriaId,
                categoria.DepartamentosVisiblesIds ?? new List<int>()
            );
        }

        public List<Categoria> ListarCategorias()
        {
            var lista = _categoriaDAL.ListarCategorias();

            // Para cada categoría, poblar también los IDs de departamentos visibles
            foreach (var cat in lista)
            {
                cat.DepartamentosVisiblesIds =
                    _visibilidadDAL.ObtenerDepartamentosVisiblesIds(cat.CategoriaId);
            }

            return lista;
        }

        public void EliminarCategoria(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría no es válido.", nameof(categoriaId));

            // Primero limpiar visibilidades
            _visibilidadDAL.ActualizarVisibilidad(categoriaId, new List<int>());

            // Luego eliminar la categoría
            _categoriaDAL.EliminarCategoria(categoriaId);
        }

        public BE.PN.Prioridad Obtener_prioridad(Categoria categoria)
        {
            return _categoriaDAL.ObtenerPrioridad(categoria);
        }
        public List<Categoria> ListarCategoriasVisiblesPorDepartamento(int departamentoId)
        {
            // Usando SP + DAL:
            var ids = _visibilidadDAL.ObtenerCategoriasVisiblesIds(departamentoId);
            return _categoriaDAL.ListarCategorias()
                                .Where(c => ids.Contains(c.CategoriaId))
                                .ToList();
        }

        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría debe ser mayor que cero.", nameof(categoriaId));

            var categoria = _categoriaDAL.ObtenerCategoriaPorId(categoriaId);
            if (categoria == null)
                throw new KeyNotFoundException($"No existe ninguna categoría con ID {categoriaId} o está eliminada.");

            // Poblar visibilidad de departamentos
            categoria.DepartamentosVisiblesIds =
                _visibilidadDAL.ObtenerDepartamentosVisiblesIds(categoriaId);

            return categoria;
        }
    }
}
