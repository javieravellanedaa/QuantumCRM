using BE.PN;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class GrupoTecnicoBLL
    {
        private readonly GruposTecnicosDAL _grupoTecnicoDAL = new GruposTecnicosDAL();

        public List<GrupoTecnico> ListarGruposTecnicos()
        {
            return _grupoTecnicoDAL.ListarGruposTecnicos();
        }

        public GrupoTecnico ObtenerGrupoPorId(int id)
        {
            return _grupoTecnicoDAL.ObtenerPorId(id);
        }

        public void AgregarGrupoTecnico(GrupoTecnico grupo)
        {
            if (string.IsNullOrWhiteSpace(grupo.Nombre))
                throw new ArgumentException("El nombre del grupo técnico no puede estar vacío.");

            _grupoTecnicoDAL.AgregarGrupoTecnico(grupo);
        }

        public void EliminarGrupoTecnico(int id)
        {
            _grupoTecnicoDAL.EliminarGrupoTecnico(id);
        }
    }
}
