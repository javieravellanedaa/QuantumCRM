using System;
using System.Collections.Generic;

namespace BE
{
    public class Comentario
    {
        public int ComentarioId { get; set; }   

        public Guid TicketId { get; set; }     
        public Ticket Ticket { get; set; }

        public Guid UsuarioId { get; set; }      
        public Usuario Usuario { get; set; }

        public string Texto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public bool Eliminado { get; set; }      

        // Para comentarios anidados
        public int? ComentarioPadreId { get; set; }   
        public Comentario ComentarioPadre { get; set; }
        public List<Comentario> Respuestas { get; set; } = new List<Comentario>();
    }
}