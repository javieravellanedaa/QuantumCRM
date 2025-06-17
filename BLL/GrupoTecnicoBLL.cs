using System;
using System.Collections.Generic;
using BE;
using BE.PN;
using DAL;
using System.Linq;

namespace BLL
{
    public class GrupoTecnicoBLL
    {
        private readonly GrupoTecnicoDAL _grupoTecnicoDAL = new GrupoTecnicoDAL();

        public List<GrupoTecnico> ListarGruposTecnicos()
        {
            // Obtenemos todos y filtramos los eliminados en la capa BLL
            var grupos = _grupoTecnicoDAL.ListarGruposTecnicos();
            return grupos.Where(g => !g.Eliminado).ToList();
        }


        public GrupoTecnico ObtenerGrupoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del grupo técnico no es válido.", nameof(id));

            var grupo = _grupoTecnicoDAL.ObtenerPorId(id);
            if (grupo == null || grupo.Eliminado)
                throw new KeyNotFoundException($"No existe un grupo técnico activo con ID {id}.");

            return grupo;
        }

        public void AgregarGrupoTecnico(GrupoTecnico grupo)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));

            if (string.IsNullOrWhiteSpace(grupo.Nombre))
                throw new ArgumentException("El nombre del grupo técnico no puede estar vacío.", nameof(grupo.Nombre));

            if (grupo.TecnicoLiderId <= 0)
                throw new ArgumentException("Debe especificar un técnico líder válido.", nameof(grupo.TecnicoLiderId));

            if (grupo.Tecnicos == null || !grupo.Tecnicos.Any())
                throw new InvalidOperationException("El grupo debe tener al menos un técnico.");

            // 🔍 Validar que el líder esté en la lista de técnicos
            if (!grupo.Tecnicos.Any(t => t.TecnicoId == grupo.TecnicoLiderId))
                throw new InvalidOperationException("El técnico líder debe formar parte de la lista de técnicos del grupo.");

            if (_grupoTecnicoDAL.ExisteNombre(grupo.Nombre))
                throw new InvalidOperationException($"Ya existe otro grupo técnico con el nombre '{grupo.Nombre}'.");

            int nuevoGrupoId= _grupoTecnicoDAL.AgregarGrupoTecnico(grupo);

            foreach (var tecnico in grupo.Tecnicos)
            {
                _grupoTecnicoDAL.AgregarTecnicoAGrupo(nuevoGrupoId, tecnico.TecnicoId);
            }
        }



        public void ActualizarGrupoTecnico(GrupoTecnico grupo)
        {
            if (grupo == null)
                throw new ArgumentNullException(nameof(grupo));

            if (grupo.GrupoId <= 0)
                throw new ArgumentException("El ID del grupo técnico no es válido.", nameof(grupo.GrupoId));

            if (string.IsNullOrWhiteSpace(grupo.Nombre))
                throw new ArgumentException("El nombre del grupo técnico no puede estar vacío.", nameof(grupo.Nombre));

            if (grupo.TecnicoLiderId <= 0)
                throw new ArgumentException("Debe especificar un técnico líder válido.", nameof(grupo.TecnicoLiderId));

            if (grupo.Tecnicos == null || !grupo.Tecnicos.Any())
                throw new InvalidOperationException("El grupo debe tener al menos un técnico.");

            // 🔍 Validar que el líder esté en la lista de técnicos
            if (!grupo.Tecnicos.Any(t => t.TecnicoId == grupo.TecnicoLiderId))
                throw new InvalidOperationException("El técnico líder debe formar parte de la lista de técnicos del grupo.");

            var existente = _grupoTecnicoDAL.ObtenerPorId(grupo.GrupoId);
            if (existente == null || existente.Eliminado)
                throw new KeyNotFoundException($"No existe un grupo técnico activo con ID {grupo.GrupoId}.");

            if (!string.Equals(existente.Nombre, grupo.Nombre, StringComparison.OrdinalIgnoreCase)
                && _grupoTecnicoDAL.ExisteNombre(grupo.Nombre))
            {
                throw new InvalidOperationException($"Ya existe otro grupo técnico con el nombre '{grupo.Nombre}'.");
            }

            _grupoTecnicoDAL.ActualizarGrupoTecnico(grupo);
        }

        public void EliminarGrupoTecnico(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del grupo técnico no es válido.", nameof(id));

            var grupo = _grupoTecnicoDAL.ObtenerPorId(id);
            if (grupo == null || grupo.Eliminado)
                throw new KeyNotFoundException($"No existe un grupo técnico activo con ID {id}.");

            // Soft-delete
            _grupoTecnicoDAL.MarcarComoEliminado(id);
        }

        public List<GrupoTecnico> ObtenerGruposAsignados(int tecnicoId)
        {
            if (tecnicoId <= 0)
                throw new ArgumentException("El ID de técnico no es válido.", nameof(tecnicoId));

            var grupos = _grupoTecnicoDAL.ListarGruposPorTecnico(tecnicoId);
            // Filtrar activos y no eliminados
            return grupos
                .Where(g => g.Activo && !g.Eliminado)
                .ToList();
        }

        // ----- Métodos para relación m:n con técnicos -----

        public void AsignarTecnicoAlGrupo(int grupoId, int tecnicoId)
        {
            if (grupoId <= 0) throw new ArgumentException("ID de grupo no válido.", nameof(grupoId));
            if (tecnicoId <= 0) throw new ArgumentException("ID de técnico no válido.", nameof(tecnicoId));

            // Validar existencia
            var grupo = ObtenerGrupoPorId(grupoId);
            if (_grupoTecnicoDAL.ExisteTecnicoEnGrupo(grupoId, tecnicoId))
                throw new InvalidOperationException("El técnico ya forma parte de ese grupo.");

            _grupoTecnicoDAL.AgregarTecnicoAGrupo(grupoId, tecnicoId);
        }

        public void QuitarTecnicoDelGrupo(int grupoId, int tecnicoId)
        {
            if (grupoId <= 0) throw new ArgumentException("ID de grupo no válido.", nameof(grupoId));
            if (tecnicoId <= 0) throw new ArgumentException("ID de técnico no válido.", nameof(tecnicoId));

            if (!_grupoTecnicoDAL.ExisteTecnicoEnGrupo(grupoId, tecnicoId))
                throw new KeyNotFoundException("El técnico no pertenece a ese grupo.");

            _grupoTecnicoDAL.EliminarTecnicoDeGrupo(grupoId, tecnicoId);
        }

 
        public List<GrupoTecnico> ListarGruposTecnicosActivos()
        {
            return _grupoTecnicoDAL.ListarGruposTecnicos()
                                   .Where(g => !g.Eliminado && g.Activo)
                                   .ToList();
        }

    }
}
