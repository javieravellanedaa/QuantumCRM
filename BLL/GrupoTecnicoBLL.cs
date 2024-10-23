using BE;
using BE.PN;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GrupoTecnicoBLL
    {

        public List<GrupoTecnico> ListarGruposTecnicos()
        {
            // Instancia de la capa DAL
            GruposTecnicosDAL GrupoTecnicoDal = new GruposTecnicosDAL();

            // Llamamos al método DAL y devolvemos la lista
            return GrupoTecnicoDal.ListarGruposTecnicos();
        }
    }
}
