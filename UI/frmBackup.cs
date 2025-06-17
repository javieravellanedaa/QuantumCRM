using System;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICIOS; // para acceder a SingletonSesion

namespace UI
{
    public partial class frmBackup : Form
    {
        private readonly BackupBLL _backupBLL;

        public frmBackup()
        {
            InitializeComponent();
            _backupBLL = new BackupBLL();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            CargarBackups();
        }

        private void CargarBackups()
        {
            try
            {
                var lista = _backupBLL.Listar();
                dgvBackups.DataSource = lista;
                dgvBackups.Columns["Id"].Visible = false;
                dgvBackups.Columns["FilePath"].Visible = false;
                dgvBackups.Columns["Description"].HeaderText = "Descripción";
                dgvBackups.Columns["CreatedAt"].HeaderText = "Fecha de creación";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar backups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Por favor ingrese una descripción para el backup.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_backupBLL.Crear(desc))
            {
                MessageBox.Show("Backup creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Clear();
                CargarBackups();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al crear el backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (dgvBackups.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un backup para restaurar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seleccionado = (Backup)dgvBackups.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"¿Está seguro que desea restaurar el backup creado el {seleccionado.CreatedAt}?\n\nEsta acción es irreversible.",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (_backupBLL.Restaurar(seleccionado.Id))
                {
                    // Verificamos si el usuario actual sigue existiendo
                    var usuarioActual = SingletonSesion.Instancia.Sesion.Usuario;
                    var usuarioBLL = new UsuarioBLL();

                    if (!usuarioBLL.UsuarioExiste(usuarioActual.Id))
                    {
                        MessageBox.Show("Atención: el usuario actual ya no existe en la base de datos restaurada.\n\nEl sistema se cerrará por seguridad.",
                            "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                        return;
                    }

                    MessageBox.Show("Restauración completada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la restauración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            var formHistorial = new frmHistorialBackup();
            formHistorial.ShowDialog();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                _backupBLL.SincronizarMetadataDesdeDisco();
                MessageBox.Show("Sincronización finalizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarBackups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincronizar backups desde disco:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
