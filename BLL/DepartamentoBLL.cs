using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartamentoBLL
    {
       
            public List<Departamento> ListarDepartamentos()
            {
                // Instancia de la capa DAL
                DepartamentosDAL departamentosDAL = new DepartamentosDAL();

                // Llamamos al método DAL y devolvemos la lista
                return departamentosDAL.ListarDepartamentos();
           
            }



    }
}
