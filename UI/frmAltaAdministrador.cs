using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmAltaAdministrador : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        private readonly AdministradorBLL _adminBLL = new AdministradorBLL();

        private List<Usuario> _usuariosDisponibles;

        public frmAltaAdministrador()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            Load += FrmAltaAdministrador_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void FrmAltaAdministrador_Load(object sender, EventArgs e)
        {
            CargarUsuariosDisponibles();
        }

        private void CargarUsuariosDisponibles()
        {
            try
            {
                _usuariosDisponibles = _usuarioBLL.ObtenerCandidatosParaAdministrador();

                lstUsuarios.DataSource = null;
                lstUsuarios.DataSource = _usuariosDisponibles;
                lstUsuarios.DisplayMember = "Email";
                lstUsuarios.ValueMember = "Id";

                if (_usuariosDisponibles.Count == 0)
                {
                    MessageBox.Show("No quedan usuarios disponibles para asignar como administradores.");
                    btnGuardar.Enabled = false;
                }
                else
                {
                    btnGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false; // prevenir doble clic

                if (lstUsuarios.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                var usuario = (Usuario)lstUsuarios.SelectedItem;

                var administrador = new Administrador
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email
                    // IdAdministrador, Estado y FechaCreacion se generan en la BLL
                };

                _adminBLL.CrearAdministrador(administrador);

                MessageBox.Show("Administrador creado correctamente.");

                LimpiarFormulario();
                lstUsuarios.SelectedIndex = -1; // asegurarse de deseleccionar
                CargarUsuariosDisponibles();   // recarga lista sin el asignado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el administrador: " + ex.Message);
            }
            finally
            {
                if (_usuariosDisponibles.Count > 0)
                    btnGuardar.Enabled = true;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            lstUsuarios.ClearSelected();
            lstUsuarios.SelectedIndex = -1;
        }
    }
}
