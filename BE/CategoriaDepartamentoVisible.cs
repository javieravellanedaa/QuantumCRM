using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CategoriaDepartamentoVisible
    {
        public int CategoriaDepartamentoId { get; set; }
        public int CategoriaId { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? CreadorId { get; set; }
    }
}
