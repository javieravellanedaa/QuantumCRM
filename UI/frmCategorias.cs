using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmCategorias : Form
    {
        
        private CategoriaBLL categoriaBLL;

        public frmCategorias()
        {
            InitializeComponent();
            categoriaBLL = new CategoriaBLL();


           
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = categoriaBLL.ListarCategorias();
            // Ocultar la columna de ID si está presente
            dgvCategorias.AutoResizeColumns();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            
            CargarCategorias();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    categoria.Nombre = txtNombre.Text;
                    categoria.Estado = new EstadosCategoria { Nombre = chkEstado.Checked ? "Activo" : "Inactivo" };

                    categoriaBLL.ActualizarCategoria(categoria);
                    MessageBox.Show("Categoría actualizada correctamente.");
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la categoría: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    int categoriaId = ((Categoria)dgvCategorias.CurrentRow.DataBoundItem).CategoriaId;
                    categoriaBLL.EliminarCategoria(categoriaId);
                    MessageBox.Show("Categoría eliminada correctamente.");
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
                }
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                // Obtener la categoría seleccionada
                var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                // Asignar el nombre de la categoría al TextBox
                txtNombre.Text = categoria.Nombre;

                // Verificar el estado de la categoría y reflejarlo en el checkbox
                if (categoria.Estado != null)
                {
                    chkEstado.Checked = categoria.Estado.Nombre == "Activo";
                }
                else
                {
                    chkEstado.Checked = false;
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        { 
        
        }

        private void dgvCampos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}