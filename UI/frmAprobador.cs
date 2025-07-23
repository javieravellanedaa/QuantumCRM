using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using BE;
using BLL;
using SERVICIOS;
using INTERFACES;

namespace UI
{
    public partial class frmAprobador : Form, IEventListener
    {
        private readonly TicketBLL _ticketBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly EventManagerService _eventManagerService;
        private readonly int _usuarioAprobadorId;
        private List<Ticket> _ticketsPendientes;

        public frmAprobador(EventManagerService eventManagerService, int usuarioAprobadorId)
        {
            InitializeComponent();
            _eventManagerService = eventManagerService;
            _ticketBLL = new TicketBLL();
            _clienteBLL = new ClienteBLL();
            _usuarioAprobadorId = usuarioAprobadorId;

            _eventManagerService.Subscribe("FormularioCerrado", this);
            dgvAprobaciones.CellDoubleClick += DgvAprobaciones_CellDoubleClick;

            // Aplicar estilos modernos
            AplicarEstilosModernos();
        }

        private void AplicarEstilosModernos()
        {
            // Configurar el formulario principal
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Estilo del panel superior
            panelFilters.BackColor = Color.White;
            panelFilters.Paint += PanelFilters_Paint;

            // Estilo de los botones
            ConfigurarBoton(btnAprobar, Color.FromArgb(40, 167, 69), Color.White);
            ConfigurarBoton(btnRechazar, Color.FromArgb(220, 53, 69), Color.White);

            // Estilo del DataGridView
            ConfigurarDataGridView();
        }

        private void ConfigurarBoton(Button btn, Color backColor, Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;

            // Agregar efectos hover
            btn.MouseEnter += (s, e) => {
                btn.BackColor = Color.FromArgb(
                    Math.Max(0, backColor.R - 20),
                    Math.Max(0, backColor.G - 20),
                    Math.Max(0, backColor.B - 20)
                );
            };

            btn.MouseLeave += (s, e) => {
                btn.BackColor = backColor;
            };
        }

        private void ConfigurarDataGridView()
        {
            // Configuración general
            dgvAprobaciones.BackgroundColor = Color.White;
            dgvAprobaciones.GridColor = Color.FromArgb(230, 230, 230);
            dgvAprobaciones.BorderStyle = BorderStyle.None;
            dgvAprobaciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAprobaciones.RowHeadersVisible = false;
            dgvAprobaciones.AllowUserToResizeRows = false;
            dgvAprobaciones.RowTemplate.Height = 45;
            dgvAprobaciones.Font = new Font("Segoe UI", 9F);

            // Estilo de las cabeceras
            dgvAprobaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvAprobaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            dgvAprobaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvAprobaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvAprobaciones.ColumnHeadersDefaultCellStyle.Padding = new Padding(15, 0, 0, 0);
            dgvAprobaciones.ColumnHeadersHeight = 40;
            dgvAprobaciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvAprobaciones.EnableHeadersVisualStyles = false;

            // Estilo de las celdas
            dgvAprobaciones.DefaultCellStyle.BackColor = Color.White;
            dgvAprobaciones.DefaultCellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            dgvAprobaciones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 255);
            dgvAprobaciones.DefaultCellStyle.SelectionForeColor = Color.FromArgb(73, 80, 87);
            dgvAprobaciones.DefaultCellStyle.Padding = new Padding(15, 8, 15, 8);
            dgvAprobaciones.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Estilo de filas alternadas
            dgvAprobaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvAprobaciones.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 255);
            dgvAprobaciones.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(73, 80, 87);
        }

        private void PanelFilters_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar sombra sutil en la parte inferior del panel
            using (var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
            {
                e.Graphics.DrawLine(pen, 0, panelFilters.Height - 1, panelFilters.Width, panelFilters.Height - 1);
            }
        }

        private void frmAprobador_Load(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void CargarTickets()
        {
            _ticketsPendientes = _ticketBLL
                .ListarTicketsPendientesDeAprobacion(_usuarioAprobadorId);

            var fuente = _ticketsPendientes
                .Select(t =>
                {
                    var cliente = _clienteBLL.ObtenerClientePorId(t.ClienteCreadorId);
                    return new
                    {
                        Numero = t.Numero,
                        TicketId = t.TicketId,
                        FechaCreacion = t.FechaCreacion,
                        Asunto = t.Asunto,
                        Descripcion = t.Descripcion,
                        Cliente = $"{cliente.Apellido}, {cliente.Nombre}"
                    };
                })
                .ToList();

            dgvAprobaciones.DataSource = fuente;

            // Configurar columnas
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            // Ocultar el GUID del TicketId
            if (dgvAprobaciones.Columns.Contains("TicketId"))
                dgvAprobaciones.Columns["TicketId"].Visible = false;

            // Configurar columna Número
            if (dgvAprobaciones.Columns.Contains("Numero"))
            {
                dgvAprobaciones.Columns["Numero"].HeaderText = "Nº Ticket";
                dgvAprobaciones.Columns["Numero"].Width = 100;
                dgvAprobaciones.Columns["Numero"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvAprobaciones.Columns["Numero"].DefaultCellStyle.ForeColor = Color.FromArgb(13, 110, 253);
            }

            // Configurar columna Fecha
            if (dgvAprobaciones.Columns.Contains("FechaCreacion"))
            {
                dgvAprobaciones.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
                dgvAprobaciones.Columns["FechaCreacion"].Width = 130;
                dgvAprobaciones.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // Configurar columna Asunto
            if (dgvAprobaciones.Columns.Contains("Asunto"))
            {
                dgvAprobaciones.Columns["Asunto"].HeaderText = "Asunto";
                dgvAprobaciones.Columns["Asunto"].Width = 200;
                dgvAprobaciones.Columns["Asunto"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            // Configurar columna Descripción
            if (dgvAprobaciones.Columns.Contains("Descripcion"))
            {
                dgvAprobaciones.Columns["Descripcion"].HeaderText = "Descripción";
                dgvAprobaciones.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAprobaciones.Columns["Descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            // Configurar columna Cliente
            if (dgvAprobaciones.Columns.Contains("Cliente"))
            {
                dgvAprobaciones.Columns["Cliente"].HeaderText = "Cliente";
                dgvAprobaciones.Columns["Cliente"].Width = 150;
                dgvAprobaciones.Columns["Cliente"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
        }

        private Guid? GetTicketIdSeleccionado()
        {
            if (dgvAprobaciones.CurrentRow == null)
                return null;

            var cell = dgvAprobaciones.CurrentRow.Cells["TicketId"];
            if (cell != null && cell.Value is Guid guid)
                return guid;

            return null;
        }

        private void DgvAprobaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var ticketId = GetTicketIdSeleccionado();
            if (!ticketId.HasValue) return;

            var ticket = _ticketsPendientes
                .FirstOrDefault(t => t.TicketId == ticketId.Value);

            if (ticket == null)
            {
                MostrarMensaje(
                    "No se pudo encontrar la información del ticket.",
                    "Error", MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var vista = new VistaDeTicketAprobador(ticket, _usuarioAprobadorId))
                {
                    vista.ShowDialog(this);
                }
                CargarTickets();
            }
            catch (Exception ex)
            {
                MostrarMensaje(
                    $"Error al abrir el ticket: {ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            var id = GetTicketIdSeleccionado();
            if (!id.HasValue)
            {
                MostrarMensaje("Por favor seleccione un ticket.", "Información", MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Está seguro que desea APROBAR este ticket?",
                "Confirmar Aprobación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _ticketBLL.AprobarTicket(id.Value, _usuarioAprobadorId);
                MostrarMensaje(
                    "Ticket aprobado correctamente.",
                    "Operación Exitosa", MessageBoxIcon.Information);
                CargarTickets();
            }
            catch (Exception ex)
            {
                MostrarMensaje(
                    $"Error al aprobar el ticket: {ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            var id = GetTicketIdSeleccionado();
            if (!id.HasValue)
            {
                MostrarMensaje("Por favor seleccione un ticket.", "Información", MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Está seguro que desea RECHAZAR este ticket?",
                "Confirmar Rechazo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _ticketBLL.RechazarTicket(id.Value, _usuarioAprobadorId);
                MostrarMensaje(
                    "Ticket rechazado correctamente.",
                    "Operación Exitosa", MessageBoxIcon.Information);
                CargarTickets();
            }
            catch (Exception ex)
            {
                MostrarMensaje(
                    $"Error al rechazar el ticket: {ex.Message}",
                    "Error", MessageBoxIcon.Error);
            }
        }

        private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        public void Update(string eventType, object data)
        {
            if (eventType == "FormularioCerrado")
                CargarTickets();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Agregar bordes suaves al formulario si es necesario
        }
    }
}