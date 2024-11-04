using DAL;
using INTERFACES;
using SERVICIOS;
using System;

namespace BLL
{
    public class SesionBLL : IEventListener
    {
        private SesionDAL SesionDAL = new SesionDAL();
        public Sesion Sesion;

        public void Update(string eventType, object data)
        {
            if (data is SERVICIOS.Sesion sesionData)
            {
                if (eventType == "Cerrarsesion")
                {
                    // Lógica para guardar los datos del usuario cuando se cierra la sesión
                    sesionData.Usuario.UltimoInicioSesion = DateTime.Now;
                   
                    SesionDAL.FinalizarSesion(sesionData);
                    SesionDAL.ActualizarUsuario(sesionData.Usuario);
                }
                else if (eventType == "Iniciarsesion")
                {
                    // Lógica para guardar los datos del usuario cuando se inicia la sesión
                    //SesionDAL.ObtenerUsuario(sesionData.Usuario);
                    SesionDAL.RegistrarSesion(sesionData);
                }
            
            }
        }
    }
}
