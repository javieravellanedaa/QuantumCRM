using BE;
using System;

namespace SERVICIOS
{
    public static class UsuarioFactory
    {
        public static Usuario CrearUsuario(int rolId)
        {
            switch (rolId)
            {
                case 1:
                    // Administrador
                    return new Administrador();
                case 2:
                    // Cliente
                    return new Cliente();
                case 3:
                    // Técnico
                    return new Tecnico();
                default:
                    return new Usuario();
            }
        }
    }
}
