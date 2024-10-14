using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EstadosCategoriaDAL
    {
        private Acceso acceso;
        public EstadosCategoriaDAL()
        {
            acceso = new Acceso();
        }


        public List<EstadosCategoria> ListarEstadosCategoria()
        {
            try
            {
                acceso.Abrir(); // Abre la conexión
                acceso.CancelarTransaccion(); // Cancela cualquier transacción pendiente
                SqlDataReader reader = acceso.EjecutarLectura("sp_ListarEstadosCategorias"); // Usa el nuevo método de acceso

                List<EstadosCategoria> estadosCategorias = new List<EstadosCategoria>();

                while (reader.Read())
                {
                    EstadosCategoria estadosCategoria = new EstadosCategoria();
                    estadosCategoria.EstadoCategoriaId = reader.GetInt32(0); // Lee el estado_categoria_id
                    estadosCategoria.Nombre = reader.GetString(1); // Lee el nombre
                    estadosCategoria.Descripcion = reader.GetString(2); // Lee la descripción
                    estadosCategorias.Add(estadosCategoria); // Agrega a la lista
                }

                reader.Close(); // Cierra el SqlDataReader
                acceso.Cerrar(); // Cierra la conexión

                return estadosCategorias;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                acceso.Cerrar(); // Cierra la conexión en caso de error
                throw new Exception("Error al listar los estados de categoría: " + ex.Message);
            }
        }

    }


}
