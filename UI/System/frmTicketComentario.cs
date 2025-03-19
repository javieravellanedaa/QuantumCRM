using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UI
{
    public partial class frmTicketComentario : Form
    {
        /// <summary>
        /// Propiedad para obtener el comentario ingresado.
        /// </summary>
        public string Comentario { get; private set; }

        public frmTicketComentario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //// Se obtiene el comentario ingresado
            //Comentario = txtComentario.Text.Trim();

            //if (string.IsNullOrEmpty(Comentario))
            //{
            //    MessageBox.Show("Debe ingresar un comentario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// Se cierra el formulario con DialogResult.OK para indicar que se aceptaron los cambios.
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se cierra el formulario sin aceptar cambios.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            // Se obtiene el comentario ingresado
            Comentario = txtComentario.Text.Trim();

            if (string.IsNullOrEmpty(Comentario))
            {
                MessageBox.Show("Debe ingresar un comentario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se cierra el formulario con DialogResult.OK para indicar que se aceptaron los cambios.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
    
}
