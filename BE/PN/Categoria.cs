using System;
using System.Collections.Generic;
using System.Runtime;

namespace BE
{
    public class Categoria
    {
        public int CategoriaId { get; set; } 
        public string Nombre { get; set; } 
        public int GroupId { get; set; } 
        public int TipoId { get; set; } 
        public DateTime FechaCreacion { get; set; }
        public Guid CreadorId { get; set; }

        public string Descripcion { get; set; }

        private bool aprobadorRequerido;
        public bool AprobadorRequerido
        {
            get { return aprobadorRequerido; }
            set
            {
                aprobadorRequerido = value;

                
                if (!aprobadorRequerido)
                {
                    UsuarioAprobador = null;
                }
            }
        }

        public string NombreUsuarioAprobador
        {
            get
            {
                return UsuarioAprobador != null ? UsuarioAprobador.NombreUsuario : string.Empty;
            }
        }

        
        public string NombreEstadoCategoria
            {
            get
            {
                return Estado.Nombre;
            }
        }
        private Usuario usuarioAprobador;
        public Usuario UsuarioAprobador
        {
            get { return usuarioAprobador; }
            set
            {
               
                if (AprobadorRequerido)
                {
                    usuarioAprobador = value;
                }
                else
                {
                    usuarioAprobador = null; 
                }
            }
        }



       
        public Categoria()
        {
        }

        private EstadosCategoria estado;
        public EstadosCategoria Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
