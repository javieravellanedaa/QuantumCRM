using BE.PN;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaCampoPersonalizadoBLL
    {
        private readonly CategoriaCampoPersonalizadoDAL _dal = new CategoriaCampoPersonalizadoDAL();

        public List<CategoriaCampoPersonalizado> ListarPorCategoria(int categoriaId)
        {
            if (categoriaId <= 0) throw new ArgumentException("ID de categoría inválido.");
            return _dal.ListarPorCategoria(categoriaId);
        }

        public void AgregarCampoACategoria(CategoriaCampoPersonalizado asoc)
        {
            if (asoc == null) throw new ArgumentNullException(nameof(asoc));
            if (asoc.CategoriaId <= 0) throw new ArgumentException("ID de categoría inválido.");
            if (asoc.DefinicionCampoPersonalizadoId <= 0)
                throw new ArgumentException("ID de definición inválido.");
            _dal.Insertar(asoc);
        }

        public void ActualizarAsociacion(CategoriaCampoPersonalizado asoc)
        {
            if (asoc == null) throw new ArgumentNullException(nameof(asoc));
            if (asoc.CategoriaId <= 0 || asoc.DefinicionCampoPersonalizadoId <= 0)
                throw new ArgumentException("IDs inválidos.");
            _dal.Actualizar(asoc);
        }

        public void QuitarCampoDeCategoria(int categoriaId, int definicionId)
        {
            if (categoriaId <= 0 || definicionId <= 0)
                throw new ArgumentException("IDs inválidos.");
            _dal.Eliminar(categoriaId, definicionId);
        }
    }
}
