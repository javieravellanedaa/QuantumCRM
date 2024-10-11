using System.Collections.Generic;
using System.Runtime;

namespace BE
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Campo> Campos { get; set; } = new List<Campo>(); // Lista de campos asociados a la categoría
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
            Campos = new List<Campo>();
        }
        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}
