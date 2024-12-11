using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public static class UsuarioFactory
    {
        public static Usuario CrearUsuario(int rolId)
        {
            switch (rolId)
            {
                case 3:
                    return new Cliente();
                default:
                    return new Administrador();
                
                        
            }
        }
    }
}
