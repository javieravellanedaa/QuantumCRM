using System;
using System.Linq;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class frmControlDeCambiosGeneral : Form
    {
        private readonly ControlDeCambiosBLL _ccBll;

        public frmControlDeCambiosGeneral()
        {
            InitializeComponent();
            _ccBll = new ControlDeCambiosBLL();

            // Eventos
            Load += FrmControlDeCambiosGeneral_Load;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnCerrar.Click += (s, e) => Close();
            btnRevertir.Click += BtnRevertir_Click;
            dgvCambios.CellDoubleClick += DgvCambios_CellDoubleClick;
        }

        private void FrmControlDeCambiosGeneral_Load(object sender, EventArgs e)
        {
            // 1) Cargar lista de entidades (tablas auditadas)
            lstEntidades.DataSource = _ccBll.ListarTablas().ToList();

            // 2) Fechas por defecto: últimos 7 días
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            // 3) Al abrir, muestro TODO el historial sin filtrar
            CargarGrid(tabla: null);
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            // Si no hay entidad seleccionada, no hacemos nada
            if (lstEntidades.SelectedItem == null) return;

            // Cargamos usando sólo la tabla seleccionada
            CargarGrid(lstEntidades.SelectedItem.ToString());
        }

        /// <summary>
        /// Llena el DataGridView. Si tabla == null, trae todos los registros;
        /// en caso contrario, filtra por esa tabla.
        /// </summary>
        private void CargarGrid(string tabla)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            var datos = _ccBll
                .ListarCambios(tabla, entityId: null, desde: desde, hasta: hasta)
                .Select(c => new
                {
                    EntityId = c.EntityId,
                    Fecha = c.FechaCambio,
                    Usuario = c.CambiadoPor,
                    Propiedad = c.Propiedad,
                    ValorAnterior = c.ValorViejo,
                    ValorNuevo = c.ValorNuevo,
                    Operacion = c.TipoOperacion
                })
                .ToList();

            dgvCambios.DataSource = datos;
            if (dgvCambios.Columns.Contains("EntityId"))
                dgvCambios.Columns["EntityId"].Visible = false;
            if (dgvCambios.Columns.Contains("ValorNuevo"))
                dgvCambios.Columns["ValorNuevo"].Name = "ValorNuevo";
        }

        private void DgvCambios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var column = dgvCambios.Columns[e.ColumnIndex];
            if (!string.Equals(column.Name, "ValorNuevo", StringComparison.OrdinalIgnoreCase))
                return;
            var contenido = dgvCambios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string;
            if (string.IsNullOrWhiteSpace(contenido)) return;
            using (var dlg = new frmDetalleValor(contenido))
                dlg.ShowDialog(this);
        }

        private void BtnRevertir_Click(object sender, EventArgs e)
        {
            if (dgvCambios.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciona una única fila para revertir el cambio.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCambios.SelectedRows[0];
            var valorAnterior = row.Cells["ValorAnterior"].Value as string;
            if (string.IsNullOrWhiteSpace(valorAnterior))
            {
                MessageBox.Show("Esta fila no contiene un valor anterior para revertir.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(row.Cells["EntityId"].Value is Guid entityId))
            {
                MessageBox.Show("No se pudo obtener el identificador de la entidad.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var propiedad = row.Cells["Propiedad"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(propiedad))
            {
                MessageBox.Show("No se pudo obtener la propiedad a revertir.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tabla = lstEntidades.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(tabla))
            {
                MessageBox.Show("No se ha seleccionado ninguna tabla.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _ccBll.RevertirCambio(tabla, entityId, propiedad, valorAnterior);
                MessageBox.Show("El cambio se ha revertido correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refrescar manteniendo el filtro actual
                CargarGrid(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al revertir el cambio:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
