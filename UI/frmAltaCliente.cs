using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmAltaCliente : Form
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly DepartamentoBLL _departamentoBLL = new DepartamentoBLL();
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();

        private List<Usuario> _usuariosCandidatos;

        public frmAltaCliente()
        {
            InitializeComponent();

            // Estilo embebido
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Cargar datos y eventos
            btnGuardar.Click += btnGuardar_Click;
            CargarUsuariosCandidatos();
            CargarDepartamentos();
        }

        private void CargarUsuariosCandidatos()
        {
            try
            {
                _usuariosCandidatos = _usuarioBLL.ListarUsuariosConRolClienteNoRegistrados();

                cbUsuarios.DataSource = _usuariosCandidatos;
                cbUsuarios.DisplayMember = "NombreListado"; // Apellido, Nombre
                cbUsuarios.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios disponibles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbUsuarios.Enabled = false;
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                var departamentos = _departamentoBLL.ListarDepartamentos();
                cbDepartamentos.DataSource = departamentos;
                cbDepartamentos.DisplayMember = "Nombre";
                cbDepartamentos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDepartamentos.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                var nuevoCliente = new Cliente
                {
                    Id = (Guid)cbUsuarios.SelectedValue,
                    Departamento = (Departamento)cbDepartamentos.SelectedItem,
                    FechaRegistro = DateTime.Now,
                    Telefono = txtTelefono.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    EmailContacto = txtEmailContacto.Text.Trim(),
                    PreferenciaContacto = txtPreferenciaContacto.Text.Trim(),
                    Observaciones = txtObservaciones.Text.Trim(),
                    Estado = chkActivo.Checked,
                    EsAprobador = chkEsAprobador.Checked
                };

                _clienteBLL.AgregarCliente(nuevoCliente);

                MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // O podés limpiar el formulario si preferís
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (cbUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbDepartamentos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un departamento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmailContacto.Text))
            {
                MessageBox.Show("Debe ingresar un email de contacto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
