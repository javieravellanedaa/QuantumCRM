using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EstadosCategoriaBLL
    {
        // Método para listar estados de categoría desde la capa DAL
        public List<EstadosCategoria> ListarEstadosCategoria()
        {
            // Instancia de la capa DAL
            EstadosCategoriaDAL estadosCategoriaDAL = new EstadosCategoriaDAL();

            // Llamamos al método DAL y devolvemos la lista
            return estadosCategoriaDAL.ListarEstadosCategoria();
        }
    }
}
