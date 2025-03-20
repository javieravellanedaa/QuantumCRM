using BE.Composite;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Http;

namespace BLL
{
    public class PermisoBLL
    {
        PermisoDAL _permisos;
        public PermisoBLL()
        {
            _permisos = new PermisoDAL();
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

        public bool ExisteEnNivelActual(Componente c, int id)
        {
            if (c.Id == id) return true;

            foreach (var hijo in c.Hijos)
            {
                if (hijo.Id == id)
                    return true;
            }

            return false;
        }



        public List<string> GetAllPermission()
        {
            return _permisos.GetAllPermission();
        } // validada OK


        public Componente GuardarComponente(Componente p, bool esfamilia) // validada OK
        {
            return _permisos.GuardarComponente(p, esfamilia);
        }


        public void GuardarFamilia(Familia familia)
        {
            try
            {
                _permisos.GuardarFamilia(familia);
            }
            catch (Exception ex)
            {
                throw; /*new Exception("Error en la capa de repositorio al guardar la familia.", ex);*/
            }
        }

        public IList<Patente> GetAllPatentes()
        {
            return _permisos.GetAllPatentes();
        }

        public IList<Componente> GetAll(string familia)
        {
            return _permisos.GetAll(familia);

        }

        public List<Familia> GetAllFamilias()
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
