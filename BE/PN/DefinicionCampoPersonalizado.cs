using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DefinicionCampoPersonalizado
    {
        public int Id { get; set; }
        public string Etiqueta { get; set; }           // “Fecha de entrega”, “Departamento”, etc.
        public TipoDatoCampo TipoDato { get; set; }
        public string TextoAyuda { get; set; }         // Mensaje de ayuda / placeholder
        public bool EsObligatorio { get; set; }
        public int OrdenVisualizacion { get; set; }
        public string OpcionesJson { get; set; }       // Sólo si TipoDato == Lista
        public bool VisibleParaCliente { get; set; }
        public bool VisibleParaTecnico { get; set; }
        // Puedes agregar más metadatos de UI (ancho, alto, estilo…) si los necesitas
    }

}
