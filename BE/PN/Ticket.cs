    using System;
    using System.Collections.Generic;

    namespace BE
    {
        public class Ticket
        {
        public Guid Id { get; set; } // Se mantiene el GUID como ID
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Usuario UsuarioCreador { get; set; } // Usuario que crea el ticket
        public int UsuarioCreadorId { get; set; }
        public Usuario UsuarioAprobador { get; set; } // Solo si es necesario el aprobador
        public int? UsuarioAprobadorId { get; set; }
        public string Asunto { get; set; } // Campo por defecto
        public string Detalle { get; set; } // Campo por defecto

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>(); // Comentarios de usuarios y técnicos

        public int TecnicoAsignadoId { get; set; }
        public Usuario TecnicoAsignado { get; set; } // Técnico asignado actual

        public Ticket()
        {
            Id = Guid.NewGuid();
           
            Comentarios = new List<Comentario>();
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
    }
