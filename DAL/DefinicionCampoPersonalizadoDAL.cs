using BE;
using BE.PN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DefinicionCampoPersonalizadoDAL
    {
        private readonly Acceso _acceso = new Acceso();

        private DefinicionCampoPersonalizado MapearDesdeReader(SqlDataReader reader)
        {
            return new DefinicionCampoPersonalizado
            {
                Id = reader.GetInt32(reader.GetOrdinal("DefinicionId")),
                Etiqueta = reader.GetString(reader.GetOrdinal("Etiqueta")),
                TipoDato = (TipoDatoCampo)reader.GetInt32(reader.GetOrdinal("TipoDato")),
                TextoAyuda = reader.IsDBNull(reader.GetOrdinal("TextoAyuda"))
                                      ? null
                                      : reader.GetString(reader.GetOrdinal("TextoAyuda")),
                EsObligatorio = reader.GetBoolean(reader.GetOrdinal("EsObligatorio")),
                OrdenVisualizacion = reader.GetInt32(reader.GetOrdinal("OrdenVisualizacion")),
                OpcionesJson = reader.IsDBNull(reader.GetOrdinal("OpcionesJson"))
                                      ? null
                                      : reader.GetString(reader.GetOrdinal("OpcionesJson")),
                VisibleParaCliente = reader.GetBoolean(reader.GetOrdinal("VisibleParaCliente")),
                VisibleParaTecnico = reader.GetBoolean(reader.GetOrdinal("VisibleParaTecnico"))
            };
        }

        public DefinicionCampoPersonalizado ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(id));

            DefinicionCampoPersonalizado def = null;
            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DefinicionId", id)
            };

            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ObtenerDefinicionCampoPorId", pars))
                {
                    if (reader.Read())
                        def = MapearDesdeReader(reader);
                }
            }
            finally
            {
                _acceso.Cerrar();
            }

            if (def == null)
                throw new KeyNotFoundException($"No existe definición con ID {id}.");

            return def;
        }

        public List<DefinicionCampoPersonalizado> ListarTodas()
        {
            var lista = new List<DefinicionCampoPersonalizado>();
            try
            {
                _acceso.Abrir();
                using (var reader = _acceso.EjecutarLectura("sp_ListarDefinicionesCampo"))
                {
                    while (reader.Read())
                        lista.Add(MapearDesdeReader(reader));
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
            return lista;
        }

        public int Insertar(DefinicionCampoPersonalizado def)
        {
            if (def == null)
                throw new ArgumentNullException(nameof(def));

            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Etiqueta",           def.Etiqueta),
                _acceso.CrearParametro("@TipoDato",           (int)def.TipoDato),
                _acceso.CrearParametro("@TextoAyuda",         def.TextoAyuda ?? string.Empty),
                _acceso.CrearParametro("@EsObligatorio",      def.EsObligatorio),
                _acceso.CrearParametro("@OrdenVisualizacion", def.OrdenVisualizacion),
                _acceso.CrearParametro("@OpcionesJson",       def.OpcionesJson ?? string.Empty),
                _acceso.CrearParametro("@VisibleParaCliente", def.VisibleParaCliente),
                _acceso.CrearParametro("@VisibleParaTecnico", def.VisibleParaTecnico)
            };

            try
            {
                _acceso.Abrir();
                // El SP debe devolver el nuevo DefinicionId
                return Convert.ToInt32(_acceso.EscribirEscalar("sp_InsertarDefinicionCampo", pars));
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Actualizar(DefinicionCampoPersonalizado def)
        {
            if (def == null)
                throw new ArgumentNullException(nameof(def));
            if (def.Id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(def.Id));

            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DefinicionId",       def.Id),
                _acceso.CrearParametro("@Etiqueta",           def.Etiqueta),
                _acceso.CrearParametro("@TipoDato",           (int)def.TipoDato),
                _acceso.CrearParametro("@TextoAyuda",         def.TextoAyuda ?? string.Empty),
                _acceso.CrearParametro("@EsObligatorio",      def.EsObligatorio),
                _acceso.CrearParametro("@OrdenVisualizacion", def.OrdenVisualizacion),
                _acceso.CrearParametro("@OpcionesJson",       def.OpcionesJson ?? string.Empty),
                _acceso.CrearParametro("@VisibleParaCliente", def.VisibleParaCliente),
                _acceso.CrearParametro("@VisibleParaTecnico", def.VisibleParaTecnico)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarDefinicionCampo", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la definición no puede ser menor o igual a cero.", nameof(id));

            var pars = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DefinicionId", id)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_EliminarDefinicionCampo", pars);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
