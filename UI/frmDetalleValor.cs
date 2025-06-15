using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmDetalleValor : Form
    {
        public frmDetalleValor(string texto)
        {
            InitializeComponent();

            // Carga el texto y suscribe el botón
            txtDetalle.Text = texto;
            btnCerrar.Click += (s, e) => this.Close();
        }
    }
}
