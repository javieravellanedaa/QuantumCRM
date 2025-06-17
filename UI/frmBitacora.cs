using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class frmBitacora : Form
    {
        private readonly BitacoraBLL _bitacoraBLL;
        private List<Bitacora> todasLasEntradas;

        public frmBitacora()
        {
            InitializeComponent();
            _bitacoraBLL = new BitacoraBLL();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            CargarEntradas();
            CargarFiltros();
            EstilizarGrid();
        }

        private void CargarEntradas()
        {
            todasLasEntradas = _bitacoraBLL.ObtenerEntradas().ToList();
            dgvBitacora.DataSource = todasLasEntradas;
            AjustarColumnas();
        }

        private void CargarFiltros()
        {
            cmbClases.Items.Clear();
            cmbAcciones.Items.Clear();
            cmbUsuarios.Items.Clear();

            var clases = todasLasEntradas.Select(b => b.Clase).Distinct().OrderBy(x => x).ToList();
            var acciones = todasLasEntradas.Select(b => b.Accion).Distinct().OrderBy(x => x).ToList();
            var usuarios = todasLasEntradas.Select(b => b.UsuarioNombre).Distinct().OrderBy(x => x).ToList();

            cmbClases.Items.Add("");
            cmbAcciones.Items.Add("");
            cmbUsuarios.Items.Add("");

            cmbClases.Items.AddRange(clases.ToArray());
            cmbAcciones.Items.AddRange(acciones.ToArray());
            cmbUsuarios.Items.AddRange(usuarios.ToArray());

            cmbClases.SelectedIndex = 0;
            cmbAcciones.SelectedIndex = 0;
            cmbUsuarios.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            string clase = string.IsNullOrWhiteSpace(cmbClases.Text) ? null : cmbClases.Text;
            string accion = string.IsNullOrWhiteSpace(cmbAcciones.Text) ? null : cmbAcciones.Text;
            string usuario = string.IsNullOrWhiteSpace(cmbUsuarios.Text) ? null : cmbUsuarios.Text;

            var resultados = _bitacoraBLL.ObtenerEntradas(desde, hasta, null, clase, accion);

            if (!string.IsNullOrEmpty(usuario))
            {
                resultados = resultados
                    .Where(b => b.UsuarioNombre.Equals(usuario, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            dgvBitacora.DataSource = resultados;
            AjustarColumnas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstilizarGrid()
        {
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgvBitacora.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            dgvBitacora.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvBitacora.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBitacora.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            dgvBitacora.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvBitacora.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvBitacora.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dgvBitacora.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvBitacora.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9);

            dgvBitacora.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.ReadOnly = true;
        }

        private void AjustarColumnas()
        {
            if (dgvBitacora.Columns.Contains("Id"))
                dgvBitacora.Columns["Id"].Visible = false;

            if (dgvBitacora.Columns.Contains("FechaHora"))
                dgvBitacora.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }
    }
}
