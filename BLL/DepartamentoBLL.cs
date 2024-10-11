using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartamentoBLL
    {
        public void CrearDepartamento(string nombre)
        
        {
            BE.Departamento departamento = new BE.Departamento();
            departamento.Nombre = nombre;
            DAL.DepartamentoDAL departamentoDAL = new DAL.DepartamentoDAL();
           // departamentoDAL.CrearDepartamento(departamento);

        }



	}
}
