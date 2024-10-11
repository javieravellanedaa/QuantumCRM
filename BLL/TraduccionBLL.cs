using System;
using System.Collections.Generic;
using INTERFACES;
using DAL;
using BE;

namespace BLL
{
    public class TraduccionBLL
    {
        private readonly TraduccionDAL _traduccionDAL;
        private readonly IdiomaBLL _idiomaBLL;

        public TraduccionBLL()
        {
            _traduccionDAL = new TraduccionDAL();
            _idiomaBLL = new IdiomaBLL();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma = null)
        {
            if (idioma == null)
            {
                idioma = _idiomaBLL.ObtenerIdiomaDefault();
            }
            return _traduccionDAL.ObtenerTraducciones(idioma);
        }

        public List<Traduccion> ObtenerTraduccionesPorIdioma(Guid idiomaId)
        {
            return _traduccionDAL.ObtenerTraduccionesPorIdioma(idiomaId);
        }

        public void GuardarTraducciones(List<Traduccion> traducciones)
        {
            foreach (var traduccion in traducciones)
            {
                _traduccionDAL.GuardarTraduccion(traduccion);
            }
        }

        public void GuardarTraduccion(Traduccion traduccion)
        {
            _traduccionDAL.GuardarTraduccion(traduccion);
        }

    }
}
