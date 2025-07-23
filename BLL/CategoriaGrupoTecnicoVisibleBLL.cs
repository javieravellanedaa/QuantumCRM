using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class CategoriaGrupoTecnicoVisibleBLL
    {
        private readonly CategoriaGrupoTecnicoVisibleDAL _dal = new CategoriaGrupoTecnicoVisibleDAL();

        /// <summary>
        /// Obtiene los IDs de los grupos técnicos que pueden ver una categoría.
        /// </summary>
        public List<int> ListarGruposTecnicosVisibles(int categoriaId)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de categoría debe ser mayor que cero.", nameof(categoriaId));

            return _dal.ObtenerGruposTecnicosVisiblesIds(categoriaId);
        }

        /// <summary>
        /// Reemplaza qué grupos técnicos pueden ver una categoría:
        /// elimina las asociaciones actuales y agrega las nuevas.
        /// </summary>
        public void ActualizarVisibilidad(int categoriaId, IEnumerable<int> gruposTecnicoIds)
        {
            if (categoriaId <= 0)
                throw new ArgumentException("El ID de categoría debe ser mayor que cero.", nameof(categoriaId));
            if (gruposTecnicoIds == null)
                throw new ArgumentNullException(nameof(gruposTecnicoIds));

            // Validar que todos los IDs de grupo sean válidos
            foreach (var gid in gruposTecnicoIds)
            {
                if (gid <= 0)
                    throw new ArgumentException("Todos los IDs de grupo técnico deben ser mayores que cero.", nameof(gruposTecnicoIds));
            }

            _dal.ActualizarVisibilidad(categoriaId, gruposTecnicoIds);
        }

        /// <summary>
        /// Obtiene los IDs de las categorías que un grupo técnico en particular puede ver.
        /// </summary>
        public List<int> ListarCategoriasVisibles(int grupoTecnicoId)
        {
            if (grupoTecnicoId <= 0)
                throw new ArgumentException("El ID de grupo técnico debe ser mayor que cero.", nameof(grupoTecnicoId));

            return _dal.ObtenerCategoriasVisiblesIds(grupoTecnicoId);
        }
    }
}
