// DAL/TecnicoDAL.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BE;
using BE.PN;

namespace DAL
{
    public class TecnicoDAL
    {
        private readonly Acceso _acceso;
        private readonly GrupoTecnicoDAL _grupoDAL;

        public TecnicoDAL()
        {
            _acceso = new Acceso();
            _grupoDAL = new GrupoTecnicoDAL();
        }

        // Mapea un SqlDataReader a un objeto Tecnico
        private static Tecnico Map(SqlDataReader reader)
        {
            return new Tecnico
            {
                TecnicoId = reader.GetInt32(reader.GetOrdinal("tecnico_id")),
                Id = reader.GetGuid(reader.GetOrdinal("usuario_id")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                EstaActivo = reader.GetBoolean(reader.GetOrdinal("activo")),
                FechaIngreso = reader.GetDateTime(reader.GetOrdinal("fecha_alta"))
            };
        }

        // Recupera los grupos a los que pertenece un técnico
        private List<GrupoTecnico> ObtenerGruposPorTecnico(int tecnicoId)
        {
            var grupos = new List<GrupoTecnico>();
            var todos = _grupoDAL.ListarGruposTecnicos();
            foreach (var grupo in todos)
            {
                if (_grupoDAL.ExisteTecnicoEnGrupo(grupo.GrupoId, tecnicoId))
                    grupos.Add(grupo);
            }
            return grupos;
        }

        // Inserta un técnico y sus grupos
        public Tecnico Insertar(Tecnico tecnico)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@usuario_id", tecnico.Id),
                _acceso.CrearParametro("@activo", tecnico.EstaActivo),
                _acceso.CrearParametro("@fecha_alta", tecnico.FechaIngreso)
            };

            try
            {
                _acceso.Abrir();
                var result = _acceso.EscribirEscalar("sp_InsertarTecnico", parametros);
                tecnico.TecnicoId = Convert.ToInt32(result);

                if (tecnico.GruposTecnicos != null)
                {
                    foreach (var g in tecnico.GruposTecnicos)
                        _grupoDAL.AgregarTecnicoAGrupo(g.GrupoId, tecnico.TecnicoId);
                }
                return tecnico;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Obtiene un técnico por su ID, incluyendo los grupos
        public Tecnico ObtenerPorId(int tecnicoId)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@tecnico_id", tecnicoId)
            };

            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerTecnicoPorId", parametros))
                {
                    if (reader.Read())
                    {
                        var tecnico = Map(reader);
                        tecnico.GruposTecnicos = ObtenerGruposPorTecnico(tecnicoId);
                        return tecnico;
                    }
                }
                return null;
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Lista todos los técnicos con sus grupos
        public IEnumerable<Tecnico> ObtenerTodos()
        {
            try
            {
                _acceso.Abrir();
                using (SqlDataReader reader = _acceso.EjecutarLectura("sp_ObtenerTodosTecnicos"))
                {
                    var lista = new List<Tecnico>();
                    while (reader.Read())
                    {
                        var tecnico = Map(reader);
                        tecnico.GruposTecnicos = ObtenerGruposPorTecnico(tecnico.TecnicoId);
                        lista.Add(tecnico);
                    }
                    return lista;
                }
            }
            finally
            {
                _acceso.Cerrar();
            }
        }

        // Actualiza el estado activo y sincroniza grupos
        public void Actualizar(Tecnico tecnico)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@tecnico_id", tecnico.TecnicoId),
                _acceso.CrearParametro("@activo", tecnico.EstaActivo)
            };

            try
            {
                _acceso.Abrir();
                _acceso.Escribir("sp_ActualizarTecnico", parametros);

                var actuales = ObtenerGruposPorTecnico(tecnico.TecnicoId).Select(g => g.GrupoId);
                var deseados = tecnico.GruposTecnicos.Select(g => g.GrupoId);

                foreach (var toAdd in deseados.Except(actuales))
                    _grupoDAL.AgregarTecnicoAGrupo(toAdd, tecnico.TecnicoId);

                foreach (var toRemove in actuales.Except(deseados))
                    _grupoDAL.EliminarTecnicoDeGrupo(toRemove, tecnico.TecnicoId);
            }
            finally
            {
                _acceso.Cerrar();
            }
        }
    }
}
