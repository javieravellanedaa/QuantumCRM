using BE.PN;
using BE;
using System.Collections.Generic;
using System;

public class Tecnico : Usuario
{
    public int TecnicoId { get; set; }

    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }

    // Declarado como List en lugar de ICollection
    public List<GrupoTecnico> GruposTecnicos { get; set; } = new List<GrupoTecnico>();

    public bool EstaActivo { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string Especialidad { get; set; }
    public int CapacidadMaximaTickets { get; set; }

    public List<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();
}
