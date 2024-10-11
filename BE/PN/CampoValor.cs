using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CampoValor
    {
        public int Id { get; set; }
        public int CampoId { get; set; }
        public Campo Campo { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string Valor { get; set; } // El valor ingresado por el usuario
    }
}
