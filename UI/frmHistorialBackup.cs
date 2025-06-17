using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmHistorialBackup : Form
    {
        private readonly BackupBLL _backupBLL;

        public frmHistorialBackup()
        {
            InitializeComponent();
            _backupBLL = new BackupBLL();
        }

        private void frmHistorialBackup_Load(object sender, EventArgs e)
        {
            try
            {
                var historial = _backupBLL.ListarHistorial();
                dgvHistorial.DataSource = historial;

                dgvHistorial.Columns["Id"].Visible = false;
                dgvHistorial.Columns["Description"].HeaderText = "Descripción";
                dgvHistorial.Columns["CreatedAt"].HeaderText = "Fecha de creación";
                dgvHistorial.Columns["FileName"].HeaderText = "Archivo";
                dgvHistorial.Columns["User"].HeaderText = "Usuario";
                dgvHistorial.Columns["MachineName"].HeaderText = "Equipo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
