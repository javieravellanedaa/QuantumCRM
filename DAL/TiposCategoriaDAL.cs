using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TiposCategoriaDAL
    {
        private Acceso acceso;
        public TiposCategoriaDAL()
        {
            acceso = new Acceso();
        }


        public List<TipoCategoria> ListarTiposDeCategorias()
        {
            try
            {
                acceso.Abrir(); // Abre la conexión
                acceso.CancelarTransaccion(); // Cancela cualquier transacción pendiente
                SqlDataReader reader = acceso.EjecutarLectura("sp_ListarTiposCategorias"); // Usa el nuevo método de acceso

                List<TipoCategoria> TiposCategorias = new List<TipoCategoria>();

                while (reader.Read())
                {
                    TipoCategoria TiposCategoria = new TipoCategoria();
                    TiposCategoria.Id = reader.GetInt32(0); // Lee el estado_categoria_id
                    TiposCategoria.Nombre = reader.GetString(1); // Lee el nombre
                    TiposCategoria.Descripcion = reader.GetString(2); // Lee la descripción
                    TiposCategorias.Add(TiposCategoria); // Agrega a la lista
                }

                reader.Close(); // Cierra el SqlDataReader
                acceso.Cerrar(); // Cierra la conexión

                return TiposCategorias;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                acceso.Cerrar(); // Cierra la conexión en caso de error
                throw new Exception("Error al listar los tipos de categoría: " + ex.Message);
            }
        }

    }
}
