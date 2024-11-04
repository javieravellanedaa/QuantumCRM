using BE;
using INTERFACES;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SesionDAL 
    {
        private readonly Acceso _acceso = new Acceso();

        public SesionDAL()
        {
        }

        // Método para registrar una nueva sesión
        public void RegistrarSesion(Sesion sesion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@SessionID",sesion.Id.ToString()),
                _acceso.CrearParametro("@UsuarioID", sesion.Usuario.Id.ToString()),
                _acceso.CrearParametro("@FechaInicio", sesion.Usuario.UltimoInicioSesion),
                _acceso.CrearParametro("@UltimoIdioma", sesion.Usuario.Idioma.Id.ToString()),
                _acceso.CrearParametro("@UltimoRolID", sesion.Usuario.UltimoRolId.ToString()),
                _acceso.CrearParametro("@Estado", true) // Estado de inicio
               
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_RegistrarSesion", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Método para finalizar una sesión
        public void FinalizarSesion(Sesion sesion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@SessionID",sesion.Id.ToString() ),
                _acceso.CrearParametro("@FechaFin", DateTime.Now),
                _acceso.CrearParametro("@Estado", false), // Estado de finalización,
                _acceso.CrearParametro("@UltimmoRolID", sesion.Usuario.UltimoRolId.ToString())  
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_FinalizarSesion", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Método para actualizar el último inicio de sesión en la tabla de usuarios
        public void ActualizarUsuario(IUsuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@UsuarioID", usuario.Id.ToString()),
                _acceso.CrearParametro("@UltimoInicioSesion", DateTime.Now),
                _acceso.CrearParametro("@IdiomaID", usuario.Idioma.Id.ToString())
            

            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarTablaUsuario", parametros);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }





        // Método auxiliar para mapear una sesión (si necesitas retornar la sesión en alguna consulta)
        //private Sesion MapearSesion(SqlDataReader reader)
        //{
        //    return new Sesion
        //    {
        //        SessionId = reader.GetGuid(reader.GetOrdinal("session_id")),
        //        UsuarioId = reader.GetGuid(reader.GetOrdinal("usuario_id")),
        //        FechaInicio = reader.GetDateTime(reader.GetOrdinal("fecha_inicio")),
        //        FechaFin = reader.IsDBNull(reader.GetOrdinal("fecha_fin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha_fin")),
        //        UltimoIdioma = reader.GetGuid(reader.GetOrdinal("ultimo_idioma")),
        //        UltimoRolId = reader.GetInt32(reader.GetOrdinal("ultimo_rol_id")),
        //        Estado = reader.GetBoolean(reader.GetOrdinal("estado"))
        //    };
        //}
    }
}
    
