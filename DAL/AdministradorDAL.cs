using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class AdministradorDAL
    {
        private readonly Acceso _acceso;

        public AdministradorDAL()
        {
            _acceso = new Acceso();
        }

        public void InsertarAdministrador(Administrador admin)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@administrador_id", admin.IdAdministrador),
                _acceso.CrearParametro("@usuario_id", admin.Id),
                _acceso.CrearParametro("@fecha_creacion", admin.FechaCreacion),
                _acceso.CrearParametro("@estado", admin.Estado)
            };

            try
            {
                _acceso.Abrir();
                int filas = int.Parse(_acceso.EscribirEscalar("sp_InsertarAdministrador", parametros).ToString());

                if (filas <= 0)
                {
                    throw new Exception("No se pudo insertar el administrador.");
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
