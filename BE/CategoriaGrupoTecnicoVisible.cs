using System;

namespace BE
{
    public class CategoriaGrupoTecnicoVisible
    {
        public int CategoriaGrupoTecnicoVisibleId { get; set; }
        public int CategoriaId { get; set; }
        public int GrupoTecnicoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? CreadorId { get; set; }
    }
}
