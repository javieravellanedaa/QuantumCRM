using BE.PN;
using System;
using System.Collections.Generic;

namespace BE
{
    public class Categoria
    {
        public Categoria() { }

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public GrupoTecnico GrupoTecnico { get; set; }

        public DateTime FechaCreacion { get; set; }
        public Guid CreadorId { get; set; }

        public string Descripcion { get; set; }
        public TipoCategoria tipoCategoria { get; set; }

        public Prioridad Prioridad { get; set; }

        private bool aprobadorRequerido;
        public bool AprobadorRequerido
        {
            get => aprobadorRequerido;
            set
            {
                aprobadorRequerido = value;
                if (!value)
                    ClienteAprobador = null;
            }
        }
        public List<CategoriaCampoPersonalizado> CamposPersonalizados { get; set; }
    = new List<CategoriaCampoPersonalizado>();

        public string NombreClienteAprobador =>
            ClienteAprobador != null
                ? $"{ClienteAprobador.Apellido}, {ClienteAprobador.Nombre}"
                : string.Empty;

        private Cliente clienteAprobador;
        public Cliente ClienteAprobador
        {
            get => clienteAprobador;
            set
            {
                if (AprobadorRequerido)
                    clienteAprobador = value;   
                else
                    clienteAprobador = null;
            }
        }
        public bool Eliminado { get; set; }

            
        public Departamento Departamento { get; set; }

        public bool Estado { get; set; }
    }
}
