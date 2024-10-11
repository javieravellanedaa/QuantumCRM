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
using BE;

namespace UI
{
    public partial class frmCampo : Form
    {
        CampoBLL campoBLL;
        public frmCampo()
        {
            InitializeComponent();
            
            campoBLL = new CampoBLL();
            CargarCampos();
        }

        private void frmCampo_Load(object sender, EventArgs e)
        {

        }
        private void CargarCampos()
        {
            dgvCampos.DataSource=null;
            dgvCampos.DataSource = campoBLL.ListarTodosLosCampos();
            dgvCampos.AutoResizeColumns();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Campo campo = new Campo
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtValor.Text,
                    Estado = chkEstado.Checked
                };
                campoBLL.AgregarCampo(campo);
                MessageBox.Show("Campo agregado correctamente");
                CargarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el campo: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCampos.CurrentRow != null)
            {
                try
                {
                    Campo campo = (Campo)dgvCampos.CurrentRow.DataBoundItem;
                    campo.Nombre = txtNombre.Text;
                    campo.Descripcion = txtValor.Text;
                    campo.Estado = chkEstado.Checked;
                    campoBLL.ActualizarCampo(campo);
                    MessageBox.Show("Campo actualizado correctamente");
                    CargarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el campo: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCampos.CurrentRow != null)
            {
                try
                {
                    int campoId = ((Campo)dgvCampos.CurrentRow.DataBoundItem).Id;
                    campoBLL.EliminarCampo(campoId);
                    MessageBox.Show("Campo eliminado correctamente");
                    CargarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el campo: " + ex.Message);
                }
            }
        }

        private void dgvCampos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCampos.CurrentRow != null)
            {
                Campo campo = (Campo)dgvCampos.CurrentRow.DataBoundItem;
                txtNombre.Text = campo.Nombre;
                txtValor.Text = campo.Descripcion.ToString();
                chkEstado.Checked = campo.Estado;
            }
        }
    }
}
