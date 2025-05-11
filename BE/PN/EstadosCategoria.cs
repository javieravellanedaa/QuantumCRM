using System;

namespace BE
{
    public class EstadosCategoria
    {
       
        public int EstadoCategoriaId { get; set; }

        public string Nombre { get; set; }
      
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public int CreadorId { get; set; }

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
