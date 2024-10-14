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

        // Agregar una nueva categoría con campos asociados
        public void AgregarCategoria(Categoria categoria, List<int> idsCampos)
        {
            if (categoria == null )
                throw new ArgumentException("La categoría o departamento no pueden ser nulos.");
            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            categoriaDAL.AgregarCategoria(categoria, idsCampos);
        }

        // Actualizar una categoría existente
        public void ActualizarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException("La categoría no puede ser nula.");
            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            categoriaDAL.ActualizarCategoria(categoria);
        }

      

        // Eliminar una categoría y sus asociaciones con campos
        public void EliminarCategoria(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría no es válido.");

            categoriaDAL.EliminarCategoria(categoriaId);
        }

        // Obtener una categoría por su ID
        public Categoria ObtenerCategoriaPorId(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de la categoría no es válido.");

            return categoriaDAL.ObtenerCategoriaPorId(categoriaId);
        }

        // Listar todas las categorías
        public List<Categoria> ListarCategorias()
        {
            return categoriaDAL.ListarCategorias();
        }
    }
}
