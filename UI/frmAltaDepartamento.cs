using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class frmAltaDepartamento : Form
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly DepartamentoBLL _departamentoBLL = new DepartamentoBLL();
        private List<Cliente> _clientesLideres;

        public frmAltaDepartamento()
        {
            InitializeComponent();
            TopLevel = false; // por si lo abrís desde contenedor
            CargarClientesLideres();
            dtpFechaCreacion.Value = DateTime.Now;
        }

        private void CargarClientesLideres()
        {
            try
            {
                _clientesLideres = _clienteBLL.ObtenerClientesParaLider();
                cmbClienteLider.DataSource = _clientesLideres;
                cmbClienteLider.DisplayMember = "NombreCompleto";
                cmbClienteLider.ValueMember = "ClienteId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes líderes: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios: Nombre y Código.");
                return;
            }

            try
            {
                var nuevoDepartamento = new Departamento
                {
                    Nombre = txtNombre.Text.Trim(),
                    CodigoDepartamento = txtCodigo.Text.Trim(),
                    Ubicacion = txtUbicacion.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    ClienteLider = cmbClienteLider.SelectedItem as Cliente,
                    FechaCreacion = dtpFechaCreacion.Value,
                    Estado = chkEstado.Checked
                };

                _departamentoBLL.AgregarDepartamento(nuevoDepartamento);

                MessageBox.Show("Departamento creado exitosamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el departamento: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            txtUbicacion.Clear();
            txtDescripcion.Clear();
            chkEstado.Checked = true;
            if (cmbClienteLider.Items.Count > 0)
                cmbClienteLider.SelectedIndex = 0;
            dtpFechaCreacion.Value = DateTime.Now;
        }
    }

    // Extensión para mostrar nombre completo en el ComboBox
    public static class ClienteExtensions
    {
        public static string NombreCompleto(this Cliente c) =>
            $"{c.Nombre} {c.Apellido}";
    }
}
