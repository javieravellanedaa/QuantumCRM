using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class EstadoTicketDAL
    {
        private readonly Acceso _acceso = new Acceso();

        public List<EstadoTicket> ListarEstadosTicket()
        {
            var lista = new List<EstadoTicket>();
            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarEstadosTicket", null))
                {
                    while (reader.Read())
                    {
                        var estado = new EstadoTicket
                        {
                            EstadoId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("Descripcion"))
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

        public EstadoTicket ObtenerEstadoTicket(int id)
        {
            EstadoTicket estado = null;
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@estado_id", id)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerEstadoTicket", parametros))
                {
                    if (reader.Read())
                    {
                        estado = new EstadoTicket
                        {
                            EstadoId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("Descripcion"))
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
