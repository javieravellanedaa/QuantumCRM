using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TiposCategoriaBLL
    {
        public List<TipoCategoria> listarCategorias()
        {

            TiposCategoriaDAL tiposCategoriaDAL =

                new TiposCategoriaDAL();
            return tiposCategoriaDAL.ListarTiposDeCategorias();
        }
    }
}
