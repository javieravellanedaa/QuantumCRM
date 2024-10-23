using BE;
using BE.PN; // Asegúrate de que este espacio de nombres sea correcto
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class GruposTecnicosDAL
    {
        private Acceso acceso;

        public GruposTecnicosDAL()
        {
            acceso = new Acceso();
        }

        public List<GrupoTecnico> ListarGruposTecnicos()
        {
            try
            {
                acceso.Abrir(); // Abre la conexión
                acceso.CancelarTransaccion(); // Cancela cualquier transacción pendiente
                SqlDataReader reader = acceso.EjecutarLectura("sp_ListarGruposTecnicos"); // Usa el nuevo método de acceso

                List<GrupoTecnico> gruposTecnicos = new List<GrupoTecnico>();

                while (reader.Read())
                {
                    GrupoTecnico grupoTecnico = new GrupoTecnico
                    {
                        GrupoId = reader.GetInt32(reader.GetOrdinal("grupo_id")), // Lee el ID del grupo
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")), // Lee el nombre
                        Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")), // Lee la descripción
                        TecnicoLider = new Tecnico
                        {
                            TecnicoId = reader.IsDBNull(reader.GetOrdinal("id_tecnico_lider")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_tecnico_lider")), // Mapea el ID del técnico líder
                            // Puedes agregar otras propiedades aquí si las necesitas
                        }
                    };

                    gruposTecnicos.Add(grupoTecnico); // Agrega a la lista
                }

                reader.Close(); // Cierra el SqlDataReader
                acceso.Cerrar(); // Cierra la conexión

                return gruposTecnicos;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                acceso.Cerrar(); // Cierra la conexión en caso de error
                throw new Exception("Error al listar los grupos técnicos: " + ex.Message);
            }
        }
    }
}
