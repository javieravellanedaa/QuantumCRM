using System.Collections.Generic;
using System;

namespace BE
{
    public class Departamento
    {
        public int Id { get; set; } // ID del departamento
        public string Nombre { get; set; } // Nombre del departamento
        public int? ClienteLiderId { get; set; } // ID del cliente líder (opcional)
        public DateTime FechaCreacion { get; set; } // Fecha de creación
        public string CodigoDepartamento { get; set; } // Código del departamento
        public string Descripcion { get; set; } // Descripción
        public int? UbicacionId { get; set; } // ID de la ubicación (opcional)
        public bool Estado { get; set; } // Estado (activo/inactivo)
        public bool EsPrioritario { get; set; } // Indica si es prioritario
        public string HorarioAtencion { get; set; } // Horario de atención
        public string EmailContacto { get; set; } // Email de contacto

        // Listas para asociaciones (por ejemplo, con usuarios o tickets)
        public List<Usuario> Usuarios { get; set; } // Lista de usuarios asociados
        public List<Ticket> BandejaDeTickets { get; set; } // Bandeja de tickets
    }
}
