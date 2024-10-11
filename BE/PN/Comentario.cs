using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Comentario
    {
        public int Id { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }


    }
}
