using System;

namespace BE
{
    public class Cliente : Usuario
    {
        public int ClienteId { get; set; }

        public Departamento Departamento { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string EmailContacto { get; set; }

        public DateTime? FechaUltimaInteraccion { get; set; }

        public string PreferenciaContacto { get; set; }

        public bool Estado { get; set; }

        public string Observaciones { get; set; }

        public bool EsAprobador { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string NombreListado => $"{Apellido}, {Nombre}";


    }
}
