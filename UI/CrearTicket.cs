using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class CrearTicket : Form
    {
        CategoriaBLL categoriaBLL = new CategoriaBLL(); 
        public CrearTicket()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            var categorias = categoriaBLL.ListarCategorias(); // Obtener la lista de categorías

            if (categorias != null && categorias.Count > 0)
            {
                // Asignar la lista completa de categorías al ComboBox
                cmbCategorias.DataSource = categorias;

                // Especificar qué propiedad de la clase Categoria se mostrará en el ComboBox
                cmbCategorias.DisplayMember = "Nombre";

                // Opcional: Especificar qué propiedad se utilizará como valor de la categoría
                cmbCategorias.ValueMember = "CategoriaId";
            }
            else
            {
                // Manejar el caso en que no haya categorías disponibles
                cmbCategorias.Items.Clear();
                cmbCategorias.Text = "No hay categorías disponibles";
            }


        }


        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
