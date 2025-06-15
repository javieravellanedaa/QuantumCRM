using System;
using BE;
using DAL;

namespace BLL
{
    public class AdministradorBLL
    {
        private readonly AdministradorDAL _administradorDAL;

        public AdministradorBLL()
        {
            _administradorDAL = new AdministradorDAL();
        }

        public void CrearAdministrador(Administrador administrador)
        {
            if (administrador == null)
                throw new ArgumentNullException(nameof(administrador), "El objeto Administrador no puede ser nulo.");

            if (administrador.Id == Guid.Empty)
                throw new ArgumentException("El ID de usuario no puede ser vacío.", nameof(administrador.Id));

            administrador.IdAdministrador = Guid.NewGuid();
            administrador.FechaCreacion = DateTime.Now;
            administrador.Estado = true;

            _administradorDAL.InsertarAdministrador(administrador);
        }
    }
}
