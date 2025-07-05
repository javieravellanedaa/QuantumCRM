using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.PN
{
    public class CategoriaCampoPersonalizado
    {
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int DefinicionCampoPersonalizadoId { get; set; }
        public DefinicionCampoPersonalizado Definicion { get; set; }

        public bool EsObligatorio { get; set; }        // Refuerza / anula EsObligatorio de la definición
        public int OrdenVisualizacion { get; set; }    // Posición dentro del formulario
    }

}
