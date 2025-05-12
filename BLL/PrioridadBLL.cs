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


        public PN_Prioridad ObtenerPrioridadPorId(int prioridadId)
        {
            if (prioridadId <= 0)
                throw new ArgumentException("El ID de prioridad debe ser mayor que cero.", nameof(prioridadId));

            var prioridad = _prioridadDAL.ObtenerPrioridadPorId(prioridadId);
            if (prioridad == null)
                throw new KeyNotFoundException($"No se encontró ninguna prioridad con ID {prioridadId}.");

            return prioridad;
        }
    }
}
