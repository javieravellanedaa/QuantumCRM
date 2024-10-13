using System;

namespace BE
{
    public class EstadosCategoria
    {
        // Identificador único del estado de la categoría
        public int EstadoCategoriaId { get; set; }

        // Nombre del estado
        public string Nombre { get; set; }

        // Descripción del estado
        public string Descripcion { get; set; }

        // Fecha de creación del estado
        public DateTime FechaCreacion { get; set; }

        // Identificador del creador del estado
        public int CreadorId { get; set; }

        // Constructor por defecto
        public EstadosCategoria()
        {
        }

        //// Constructor para inicializar todos los campos
        //public EstadosCategoria(int estadoCategoriaId, string nombre, string descripcion, DateTime fechaCreacion, int creadorId)
        //{
        //    this.EstadoCategoriaId = estadoCategoriaId;
        //    this.Nombre = nombre;
        //    this.Descripcion = descripcion;
        //    this.FechaCreacion = fechaCreacion;
        //    this.CreadorId = creadorId;
        //}
    }
}
