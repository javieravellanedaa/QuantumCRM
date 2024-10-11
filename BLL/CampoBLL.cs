using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class CampoBLL
    {
        private CampoDAL campoDAL;

        public CampoBLL()
        {
            campoDAL = new CampoDAL();
        }

        // Método para agregar un nuevo campo
        public void AgregarCampo(Campo campo)
        {
            if (campo == null)
                throw new ArgumentNullException("El campo no puede ser null.");
            

            if (string.IsNullOrEmpty(campo.Nombre))
                throw new ArgumentException("El nombre del campo no puede estar vacío.");

            // Asumiendo que el estado debe ser verdadero al crear un nuevo campo
            campo.Estado = true;
            campoDAL.AgregarCampo(campo);
        }

        // Método para actualizar un campo existente
        public void ActualizarCampo(Campo campo)
        {
            if (campo == null)
                throw new ArgumentNullException("El campo no puede ser null.");

            if (string.IsNullOrEmpty(campo.Nombre))
                throw new ArgumentException("El nombre del campo no puede estar vacío.");

            campoDAL.AgregarCampo(campo); // Asume que el mismo método de guardar maneja la actualización
        }

        // Método para eliminar un campo
        public void EliminarCampo(int campoId)
        {
            Campo campo = campoDAL.ObtenerCampoPorId(campoId);
            if (campo == null)
                throw new ArgumentException("El campo con el ID especificado no existe.");

            campoDAL.EliminarCampo(campoId);
        }

        // Método para obtener un campo por ID
        public Campo ObtenerCampoPorId(int campoId)
        {
            return campoDAL.ObtenerCampoPorId(campoId);
        }

        // Método para listar todos los campos
        public List<Campo> ListarTodosLosCampos()
        {
            return campoDAL.ListarTodosLosCampos();
        }
        public List<Campo> ListarCamposPorCategoria(int categoriaId)
        {
            return campoDAL.ListarCamposPorCategoria(categoriaId);
        }
    }
}
