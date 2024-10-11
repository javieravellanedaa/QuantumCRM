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
            return idiomas.First(); // Devuelve el primer idioma como el idioma por defecto
        }

        public IIdioma ObtenerIdiomaPorNombre(string nombre)
        {
            return _idiomaDAL.ObtenerIdiomas().FirstOrDefault(i => i.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public bool AgregarIdioma(string nombre)
        {
            var resultado = _idiomaDAL.AgregarIdioma(nombre);
            if (resultado)
            {
                IdiomaAgregado?.Invoke(); // Disparar el evento
            }
            return resultado;
        }
    }
}
