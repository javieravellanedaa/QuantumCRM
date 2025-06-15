using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using BE.PN;
using DAL;

namespace BLL
{
    public class TecnicoBLL
    {
        private readonly TecnicoDAL _tecnicoDAL;
        private readonly GrupoTecnicoDAL _grupoDAL;

        public TecnicoBLL()
        {
            _tecnicoDAL = new TecnicoDAL();
            _grupoDAL = new GrupoTecnicoDAL();
        }

        // Crear un nuevo técnico
        public Tecnico CrearTecnico(Tecnico tecnico)
        {
            if (string.IsNullOrWhiteSpace(tecnico.Nombre))
                throw new ArgumentException("El nombre del técnico es obligatorio.");

            tecnico.FechaIngreso = DateTime.Now;
            tecnico.EstaActivo = true;

            // 1. Insertamos técnico
            var tecnicoCreado = _tecnicoDAL.Insertar(tecnico);

            // 2. Asignamos sus grupos usando la lógica de BLL (validación incluida)
            if (tecnico.GruposTecnicos != null)
            {
                foreach (var grupo in tecnico.GruposTecnicos)
                {
                    _grupoDAL.AgregarTecnicoAGrupo(grupo.GrupoId, tecnicoCreado.TecnicoId);
                }
            }

            return tecnicoCreado;
        }

        public List<Tecnico> ListarTecnicosActivos()
        {
            var tecnicos = _tecnicoDAL.ListarTodos();
            return tecnicos.Where(t => t.EstaActivo).ToList();
        }



        // Obtener un técnico por su ID
        public Tecnico ObtenerTecnicoPorId(int id)
        {
            var t = _tecnicoDAL.ObtenerPorId(id)
                ?? throw new InvalidOperationException($"Técnico con ID {id} no encontrado.");

            if (!t.EstaActivo)
                throw new InvalidOperationException($"El técnico {id} está inactivo.");

            return t;
        }

        // Listar todos los técnicos (activos/inactivos)
        public IEnumerable<Tecnico> ObtenerTodos(bool soloActivos = true)
        {
            var lista = _tecnicoDAL.ObtenerTodos();
            return soloActivos
                ? lista.Where(x => x.EstaActivo)
                : lista;
        }

        // Actualizar datos básicos del técnico
        public void ActualizarTecnico(Tecnico tecnico)
        {
            var existente = ObtenerTecnicoPorId(tecnico.TecnicoId);

 

            existente.Especialidad = tecnico.Especialidad;
         
            existente.EstaActivo = tecnico.EstaActivo;
            existente.DepartamentoId = tecnico.DepartamentoId;

            _tecnicoDAL.Actualizar(existente);
        }

        // "Eliminar" lógicamente (marcar inactivo)
        public void EliminarTecnico(int id)
        {
            var t = ObtenerTecnicoPorId(id);
            t.EstaActivo = false;
            _tecnicoDAL.Actualizar(t);
        }

        // Asignar un grupo técnico (join table)
        public void AsignarGrupoTecnico(int tecnicoId, int grupoId)
        {
            var t = ObtenerTecnicoPorId(tecnicoId);
            var g = _grupoDAL.ObtenerPorId(grupoId)
                ?? throw new InvalidOperationException($"Grupo {grupoId} no existe.");

            if (t.GruposTecnicos.Any(x => x.GrupoId == grupoId))
                throw new InvalidOperationException("Ya está asignado a ese grupo.");

            // 1) Persisto la relación en BD
            _grupoDAL.AgregarTecnicoAGrupo(grupoId, tecnicoId);
            // 2) Actualizo el objeto en memoria
            t.GruposTecnicos.Add(g);
        }

        // Quitar un grupo técnico
        public void QuitarGrupoTecnico(int tecnicoId, int grupoId)
        {

            _grupoDAL.EliminarTecnicoDeGrupo(tecnicoId, grupoId);
        }

        // Obtener los grupos a los que pertenece un técnico
        public IEnumerable<GrupoTecnico> ObtenerGruposAsignados(int tecnicoId)
        {
            var t = ObtenerTecnicoPorId(tecnicoId);
            return t.GruposTecnicos;
        }
    }
}
