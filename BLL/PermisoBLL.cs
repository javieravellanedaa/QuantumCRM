using BE.Composite;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PermisoBLL
    {
        MP_PERMISO _permisos;
        public PermisoBLL()
        {
            _permisos = new MP_PERMISO();
        }

        public bool Existe(Componente c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }


        public List<string> GetAllPermission()
        {
            return _permisos.GetAllPermission();
        } // validada OK


        public Componente GuardarComponente(Componente p, bool esfamilia) // validada OK
        {
            return _permisos.GuardarComponente(p, esfamilia);
        }


        public void GuardarFamilia(Familia c)
        {
            _permisos.GuardarFamilia(c);
        } // validada OK

        public IList<Patente> GetAllPatentes()
        {
            return _permisos.GetAllPatentes();
        }

        public IList<Componente> GetAll(string familia)
        {
            return _permisos.GetAll(familia);

        }

        public IList<Familia> GetAllFamilias()
        {
            return _permisos.GetAllFamilias();
        }



        public void FillUserComponents(Usuario u)
        {
            _permisos.FillUserComponents(u);

        }

        public void FillFamilyComponents(Familia familia)
        {
            _permisos.FillFamilyComponents(familia);
        }



    }
}
