using BE;
using BE.PN;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DefinicionCampoPersonalizadoBLL
    {
        private readonly DefinicionCampoPersonalizadoDAL _dal = new DefinicionCampoPersonalizadoDAL();

        /// <summary>
        /// Lista todas las definiciones de campo personalizado.
        /// </summary>
        public List<DefinicionCampoPersonalizado> ListarDefiniciones()
        {
            return _dal.ListarTodas();
        }

        /// <summary>
        /// Obtiene una definición por su ID.
        /// </summary>
        public DefinicionCampoPersonalizado ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(id));

            return _dal.ObtenerPorId(id);
        }

        /// <summary>
        /// Inserta una nueva definición de campo personalizado.
        /// </summary>
        public int AgregarDefinicion(DefinicionCampoPersonalizado def)
        {
            if (def == null)
                throw new ArgumentNullException(nameof(def));

            if (string.IsNullOrWhiteSpace(def.Etiqueta))
                throw new ArgumentException("La etiqueta no puede estar vacía.", nameof(def.Etiqueta));

            return _dal.Insertar(def);
        }

        /// <summary>
        /// Actualiza una definición existente.
        /// </summary>
        public void ActualizarDefinicion(DefinicionCampoPersonalizado def)
        {
            if (def == null)
                throw new ArgumentNullException(nameof(def));
            if (def.Id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(def.Id));
            if (string.IsNullOrWhiteSpace(def.Etiqueta))
                throw new ArgumentException("La etiqueta no puede estar vacía.", nameof(def.Etiqueta));

            _dal.Actualizar(def);
        }

        /// <summary>
        /// Elimina una definición por su ID.
        /// </summary>
        public void EliminarDefinicion(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(id));

            _dal.Eliminar(id);
        }
    }
}
