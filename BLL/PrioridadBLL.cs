using System;
using System.Collections.Generic;
using BE;
using PN_Prioridad = BE.PN.Prioridad; 
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

     
        public PN_Prioridad ObtenerPrioridadCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            return _prioridadDAL.ObtenerPrioridadCategoria(categoria.CategoriaId);
        }

        public List<PN_Prioridad> GetAllPrioridades()
        {
            return _prioridadDAL.GetAll();
        }
    }
}
