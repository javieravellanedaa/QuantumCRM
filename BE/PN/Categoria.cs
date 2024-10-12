using System.Collections.Generic;
using System.Runtime;

namespace BE
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public bool RequiereAprobacion { get; set; }
       
        public Usuario UsuarioAprobador { get; set; }
        private Departamento departamento;

        public Departamento Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        public Categoria()
        {
           
        }
        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}
