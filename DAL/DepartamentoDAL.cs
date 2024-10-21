using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartamentosDAL
    {
        private Acceso acceso;

        public DepartamentosDAL()
        {
            acceso = new Acceso();
        }

        public List<Departamento> ListarDepartamentos()
        {
            try
            {
                acceso.Abrir(); // Abre la conexión
                acceso.CancelarTransaccion(); // Cancela cualquier transacción pendiente
                SqlDataReader reader = acceso.EjecutarLectura("sp_ListarDepartamentos");

                List<Departamento> departamentos = new List<Departamento>();

                while (reader.Read())
                {
                    Departamento departamento = new Departamento
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("departamento_id")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        ClienteLiderId = reader.IsDBNull(reader.GetOrdinal("cliente_lider_id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("cliente_lider_id")),
                        FechaCreacion = reader.GetDateTime(reader.GetOrdinal("fecha_creacion")),
                        CodigoDepartamento = reader.GetString(reader.GetOrdinal("codigo_departamento")),
                        Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                        UbicacionId = reader.IsDBNull(reader.GetOrdinal("ubicacion_id")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ubicacion_id")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                        EsPrioritario = reader.GetBoolean(reader.GetOrdinal("es_prioritario")),
                        HorarioAtencion = reader.IsDBNull(reader.GetOrdinal("horario_atencion")) ? null : reader.GetString(reader.GetOrdinal("horario_atencion")),
                        EmailContacto = reader.IsDBNull(reader.GetOrdinal("email_contacto")) ? null : reader.GetString(reader.GetOrdinal("email_contacto"))
                    };

                    departamentos.Add(departamento);
                }

                reader.Close(); // Cierra el SqlDataReader
                acceso.Cerrar(); // Cierra la conexión

                return departamentos;
            }
            catch (Exception ex)
            {
                acceso.Cerrar(); // Cierra la conexión en caso de error
                throw new Exception("Error al listar los departamentos: " + ex.Message);
            }
        }

    }

}
