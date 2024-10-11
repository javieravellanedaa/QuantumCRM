namespace BE
{
    public class Campo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } // Ejemplo: Texto, Número, Fecha

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool estado;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }


    }
}   
