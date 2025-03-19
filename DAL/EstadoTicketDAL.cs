using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class EstadoTicketDAL
    {
        private Acceso _acceso = new Acceso();

        /// <summary>
        /// Retorna la lista completa de estados de ticket utilizando el SP sp_ListarEstadosTicket.
        /// </summary>
        /// <returns>Lista de objetos EstadoTicket</returns>
        public List<EstadoTicket> ListarEstadosTicket()
        {
            List<EstadoTicket> lista = new List<EstadoTicket>();
            try
            {
                _acceso.Abrir();
                // Se asume que existe un SP llamado sp_ListarEstadosTicket que retorna ticket_estado_id y nombre
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ListarEstadosTicket", null))
                {
                    while (reader.Read())
                    {
                        EstadoTicket estado = new EstadoTicket
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ticket_estado_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                        lista.Add(estado);
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return lista;
        }

        /// <summary>
        /// Obtiene un estado de ticket en base a su id utilizando el SP sp_ObtenerEstadoTicket.
        /// </summary>
        /// <param name="id">Identificador del estado de ticket</param>
        /// <returns>Objeto EstadoTicket o null si no se encuentra</returns>
        public EstadoTicket ObtenerEstadoTicket(int id)
        {
            EstadoTicket estado = null;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ticket_estado_id", id)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerEstadoTicket", parametros))
                {
                    if (reader.Read())
                    {
                        estado = new EstadoTicket
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ticket_estado_id")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                    }
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return estado;
        }
    }
}
