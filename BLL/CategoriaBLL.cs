using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class CategoriaBLL
    {
        private CategoriaDAL categoriaDAL;

        public CategoriaBLL()
        {
            categoriaDAL = new CategoriaDAL();
        }

        public void AgregarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentException("La categoría no puede ser nula.");

            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            if (categoria.AprobadorRequerido && categoria.ClienteAprobador == null)
                throw new ArgumentException("Debe seleccionarse un cliente aprobador si se requiere aprobación.");

                        
            categoria.Eliminado = false;

            categoriaDAL.AgregarCategoria(categoria);
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException("La categoría no puede ser nula.");

            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            if (categoria.AprobadorRequerido && categoria.ClienteAprobador == null)
                throw new ArgumentException("Debe seleccionarse un cliente aprobador si se requiere aprobación.");

            categoriaDAL.ActualizarCategoria(categoria);
        }

        public List<Categoria> ListarCategorias()
        {
            return categoriaDAL.ListarCategorias();
        }

        public void EliminarCategoria(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría no es válido.");

            categoriaDAL.EliminarCategoria(categoriaId);
        }

        // cambiar por la DAL de prioridad
        public BE.PN.Prioridad Obtener_prioridad(Categoria categoria)
        {
            return categoriaDAL.ObtenerPrioridad(categoria);
        }

        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría debe ser mayor que cero.", nameof(categoriaId));

            var categoria = categoriaDAL.ObtenerCategoriaPorId(categoriaId);
            if (categoria == null)
                throw new KeyNotFoundException($"No existe ninguna categoría con ID {categoriaId} o está eliminada.");

            return categoria;
        }


    }
}
