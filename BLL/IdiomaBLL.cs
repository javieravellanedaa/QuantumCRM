 using System;
using System.Collections.Generic;
using System.Linq;
using INTERFACES;
using DAL;
using BE;

namespace BLL
{
    public class IdiomaBLL
    {
        private readonly IdiomaDAL _idiomaDAL;

        public event Action IdiomaAgregado;

        public IdiomaBLL()
        {
            _idiomaDAL = new IdiomaDAL();
        }

        public IList<Idioma> ObtenerIdiomas()
        {
            return _idiomaDAL.ObtenerIdiomas();
        }


        public IIdioma ObtenerIdiomaDefault()
        {
            var idiomas = ObtenerIdiomas();
            if (idiomas == null || idiomas.Count == 0)
            {
                throw new Exception("No hay idiomas disponibles.");
            }
            return idiomas.First(); // Devuelve el primer idioma activo
        }

        public IIdioma ObtenerIdiomaPorNombre(string nombre)
        {
            return _idiomaDAL.ObtenerIdiomas()
                             .FirstOrDefault(i => i.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }


        public bool AgregarIdioma(string nombre)
        {
            var resultado = _idiomaDAL.AgregarIdioma(nombre);
            if (resultado)
            {
                // Disparar el evento si se ha suscripto un oyente
                IdiomaAgregado?.Invoke();
            }
            return resultado;
        }

        public void DesactivarIdioma(Guid idiomaId)
        {
            _idiomaDAL.DesactivarIdioma(idiomaId);
        }


        public IList<Idioma> ObtenerIdiomasInactivos()
        {
            // Llama a un método en IdiomaDAL que retorne solamente inactivos
            return _idiomaDAL.ObtenerIdiomasInactivos();
        }

        public IList<Idioma> ObtenerTodosLosIdiomas()
        {
            // Llama a un método en IdiomaDAL que retorne todos (activos e inactivos)
            return _idiomaDAL.ObtenerTodosLosIdiomas();
        }
        // En IdiomaBLL
        public IIdioma ObtenerIdiomaPorNombreEnTodos(string nombre)
        {
            var todos = _idiomaDAL.ObtenerTodosLosIdiomas();
            // "ObtenerTodosLosIdiomas" no filtra por activo/inactivo
            return todos.FirstOrDefault(i =>
                i.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
            );
        }

        public bool EliminarIdioma(Guid idiomaId)
        {
            // Llama a un método de IdiomaDAL que haga DELETE físico 
            // o lo que definas como "eliminar" definitivamente
            return _idiomaDAL.EliminarIdioma(idiomaId);
        }
        public void ActivarIdioma(Guid idiomaId)
        {
            _idiomaDAL.ActivarIdioma(idiomaId);
        }


    }
}
