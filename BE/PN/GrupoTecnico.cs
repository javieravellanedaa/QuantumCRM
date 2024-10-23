using System;
using System.Collections.Generic;

namespace BE.PN
{
    public class GrupoTecnico
    {
        public int GrupoId { get; set; }  // Clave primaria del grupo
        public string Nombre { get; set; }  // Nombre del grupo
        public string Descripcion { get; set; }  // Descripción del grupo

        private Tecnico tecnicoLider; // Objeto del técnico líder

        public Tecnico TecnicoLider
        {
            get { return tecnicoLider; }
            set { tecnicoLider = value; }
        }

        public int? TecnicoLiderId
        {
            get
            {
                // Devuelve el ID del técnico líder si existe, de lo contrario devuelve null
                return TecnicoLider != null ? TecnicoLider.TecnicoId : (int?)null;
            }
        }

        // Constructor vacío
        public GrupoTecnico() { }

        // Constructor con parámetros
        public GrupoTecnico(int grupoId, string nombre, string descripcion, Tecnico tecnicoLider)
        {
            GrupoId = grupoId;
            Nombre = nombre;
            Descripcion = descripcion;
            TecnicoLider = tecnicoLider; // Asignar el objeto del técnico líder
        }
    }
}
