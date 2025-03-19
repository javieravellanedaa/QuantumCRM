using System;
using System.Collections.Generic;
using BE;              // Para otros tipos, como Categoria
using PN_Prioridad = BE.PN.Prioridad; // Alias para la Prioridad que se encuentra en BE.PN
using DAL;

namespace BLL
{
    public class PrioridadBLL
    {
        private PrioridadDAL _prioridadDAL;

        public PrioridadBLL()
        {
            _prioridadDAL = new PrioridadDAL();
        }

        /// <summary>
        /// Obtiene la prioridad asociada a la categoría pasada como parámetro.
        /// Se utiliza el SP "sp_obtenerPrioridad" para obtener la información.
        /// </summary>
        /// <param name="categoria">Categoría para la cual se desea obtener la prioridad</param>
        /// <returns>Objeto PN_Prioridad con la información de la prioridad</returns>
        public PN_Prioridad ObtenerPrioridad(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            return _prioridadDAL.ObtenerPrioridad(categoria.CategoriaId);
        }

        /// <summary>
        /// Retorna la lista completa de prioridades.
        /// </summary>
        /// <returns>Lista de objetos PN_Prioridad</returns>
        public List<PN_Prioridad> GetAllPrioridades()
        {
            return _prioridadDAL.GetAll();
        }
    }
}
