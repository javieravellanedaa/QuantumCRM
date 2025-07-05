using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.PN
{
    public class ValorCampoTicket
    {
        public int Id { get; set; }

        // FK al ticket
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        // FK a la definición de campo
        public int DefinicionCampoPersonalizadoId { get; set; }
        public DefinicionCampoPersonalizado Definicion { get; set; }

        // Columnas para cada tipo de dato (solo se usa la apropiada)
        public string ValorTexto { get; set; }
        public decimal? ValorNumero { get; set; }
        public DateTime? ValorFecha { get; set; }
    }

}
