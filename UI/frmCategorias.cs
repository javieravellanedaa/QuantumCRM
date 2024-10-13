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


            ConfigurarDataGridViewCampos();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = categoriaBLL.ListarCategorias();
            dgvCategorias.Columns["Id"].Visible = false; // Ocultar la columna de ID si está presente
            dgvCategorias.AutoResizeColumns();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridViewCampos();
            CargarCategorias();
        }

        private void ConfigurarDataGridViewCampos()
        {
            dgvCampos.Columns.Clear();
            dgvCampos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCampos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCampos.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Seleccionar";
            checkColumn.HeaderText = "";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            dgvCampos.Columns.Add(checkColumn);

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "Id";
            idColumn.ReadOnly = true;
            dgvCampos.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Nombre";
            nameColumn.HeaderText = "Nombre";
            nameColumn.DataPropertyName = "Nombre";
            nameColumn.ReadOnly = true;
            dgvCampos.Columns.Add(nameColumn);

            
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedFieldIds = new List<int>();
                foreach (DataGridViewRow row in dgvCampos.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        selectedFieldIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                    }
                }

                var categoria = new Categoria
                {
                    Nombre = txtNombre.Text,
                    Estado = chkEstado.Checked
                };

                categoriaBLL.AgregarCategoria(categoria, selectedFieldIds);
                MessageBox.Show("Categoría agregada correctamente.");
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la categoría: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                try
                {
                    var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    categoria.Nombre = txtNombre.Text;
                    categoria.Estado = chkEstado.Checked;

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
                var categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                txtNombre.Text = categoria.Nombre;
                chkEstado.Checked = categoria.Estado;


             
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> selectedFieldIds = new List<int>();
            foreach (DataGridViewRow row in dgvCampos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    selectedFieldIds.Add(Convert.ToInt32(row.Cells["Id"].Value));
                }
            }

            Categoria categoria = new Categoria
            {
                Nombre = txtNombre.Text,
                Estado = chkEstado.Checked
            };

            try
            {
                categoriaBLL.AgregarCategoria(categoria, selectedFieldIds);
                MessageBox.Show("Categoría guardada correctamente con campos seleccionados.");
                CargarCategorias();  // Recargar la lista de categorías
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message);
            }
        }

        private void dgvCampos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}