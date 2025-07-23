    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Drawing;
    using BLL;
    using BE;
    using SERVICIOS;

    namespace UI
    {
        public partial class frmMisTicketsCliente : Form
        {
            private readonly TicketBLL _ticketBLL;
            private readonly CategoriaBLL _categoriaBLL;
            private readonly EstadoTicketBLL _estadoBLL;
            private readonly ClienteBLL _clienteBLL;
            private readonly TecnicoBLL _tecnicoBLL;
            private readonly PrioridadBLL _prioridadBLL;

            public frmMisTicketsCliente(EventManagerService eventManagerService)
            {
                InitializeComponent();

                _ticketBLL = new TicketBLL();
                _categoriaBLL = new CategoriaBLL();
                _estadoBLL = new EstadoTicketBLL();
                _clienteBLL = new ClienteBLL();
                _tecnicoBLL = new TecnicoBLL();
                _prioridadBLL = new PrioridadBLL();

                // Event handlers
                this.Load += frmMisTicketsCliente_Load;
                dgvTickets.CellFormatting += dgvTickets_CellFormatting;
                btnBuscar.Click += btnBuscar_Click;
                btnLimpiar.Click += btnLimpiar_Click;
                btnAbrirTicket.Click += btnAbrirTicket_Click;
            }

            private void frmMisTicketsCliente_Load(object sender, EventArgs e)
            {
                // Bind categorías
                var categorias = _categoriaBLL.ListarCategorias();
                categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todos" });
                cmbCategoriaFilter.DataSource = categorias;
                cmbCategoriaFilter.DisplayMember = "Nombre";
                cmbCategoriaFilter.ValueMember = "CategoriaId";

                // Bind estados
                var estados = _estadoBLL.ListarEstadosTicket();
                estados.Insert(0, new EstadoTicket { EstadoId = 0, Nombre = "Todos" });
                cmbEstadoFilter.DataSource = estados;
                cmbEstadoFilter.DisplayMember = "Nombre";
                cmbEstadoFilter.ValueMember = "EstadoId";

                // Fechas por defecto
                dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
                dtpFechaHasta.Value = DateTime.Now;

                // Carga inicial
                CargarTickets();
            }

            private void dgvTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if (dgvTickets.Columns[e.ColumnIndex].Name != "Prioridad" || e.Value == null)
                    return;

                switch (e.Value.ToString())
                {
                    case "Baja":
                        e.CellStyle.BackColor = Color.FromArgb(198, 239, 206);
                        break;
                    case "Media":
                        e.CellStyle.BackColor = Color.FromArgb(255, 235, 156);
                        break;
                    case "Alta":
                        e.CellStyle.BackColor = Color.FromArgb(255, 199, 206);
                        break;
                    case "Urgente":
                        e.CellStyle.BackColor = Color.FromArgb(244, 88, 88);
                        e.CellStyle.ForeColor = Color.White;
                        return;
                }
                e.CellStyle.ForeColor = Color.Black;
            }

            private void CargarTickets()
            {
                var usuario = SingletonSesion.Instancia.Sesion.Usuario;
                var cliente = _clienteBLL.ObtenerClientePorIdUsuario(usuario.Id);

                var query = _ticketBLL.ListarTicketsDeCliente(cliente).AsEnumerable();

                // Filtro por número de ticket
                if (int.TryParse(txtTicketNumber.Text.Trim(), out int num))
                    query = query.Where(t => t.Numero == num);

                // Filtro por categoría
                if (cmbCategoriaFilter.SelectedItem is Categoria selCat && selCat.CategoriaId != 0)
                    query = query.Where(t => t.CategoriaId == selCat.CategoriaId);

                // Filtro por estado
                if (cmbEstadoFilter.SelectedItem is EstadoTicket selEst && selEst.EstadoId != 0)
                    query = query.Where(t => t.EstadoId == selEst.EstadoId);

                // Filtro por rango de fechas
                var desde = dtpFechaDesde.Value.Date;
                var hasta = dtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(t => t.FechaCreacion >= desde && t.FechaCreacion <= hasta);

                // Proyección
                var listadoPlano = query
                    .Select(t =>
                    {
                        var cat = _categoriaBLL.ObtenerCategoriaPorId(t.CategoriaId)?.Nombre ?? "";
                        var est = _estadoBLL.ObtenerEstadoTicket(t.EstadoId)?.Nombre ?? "";
                        var pri = _prioridadBLL.ObtenerPrioridadPorId(t.PrioridadId)?.Nombre ?? "";
                        var apr = t.UsuarioAprobadorId.HasValue
                            ? $"{_clienteBLL.ObtenerClientePorId(t.UsuarioAprobadorId.Value).Apellido}, {_clienteBLL.ObtenerClientePorId(t.UsuarioAprobadorId.Value).Nombre}"
                            : "";
                        var tec = t.TecnicoId.HasValue
                            ? $"{_tecnicoBLL.ObtenerTecnicoPorId(t.TecnicoId.Value).Apellido}, {_tecnicoBLL.ObtenerTecnicoPorId(t.TecnicoId.Value).Nombre}"
                            : "";

                        return new
                        {
                            Numero = t.Numero,
                            TicketId = t.TicketId,
                            FechaCreacion = t.FechaCreacion,
                            Asunto = t.Asunto,
                            DetalleDescripcion = t.Descripcion,
                            Categoria = cat,
                            Estado = est,
                            Aprobador = apr,
                            Prioridad = pri,
                            TecnicoAsignado = tec
                        };
                    })
                    .ToList();

                dgvTickets.DataSource = listadoPlano;
                FormatearGrilla();

                // Selecciono la primera fila para evitar CurrentRow == null
                if (dgvTickets.Rows.Count > 0)
                {
                    dgvTickets.ClearSelection();
                    dgvTickets.Rows[0].Selected = true;
                    dgvTickets.CurrentCell = dgvTickets.Rows[0].Cells["Numero"];
                }
            }

            private void FormatearGrilla()
            {
                foreach (DataGridViewColumn col in dgvTickets.Columns)
                    col.Visible = false;

                var cols = new[]
                {
                    ("Numero", "Nro Ticket"),
                    ("FechaCreacion", "Fecha Creación"),
                    ("Asunto", "Asunto"),
                    ("DetalleDescripcion", "Detalle Descripción"),
                    ("Categoria", "Categoría"),
                    ("Estado", "Estado"),
                    ("Aprobador", "Usuario Aprobador"),
                    ("Prioridad", "Prioridad"),
                    ("TecnicoAsignado", "Técnico Asignado")
                };

                foreach (var (prop, header) in cols)
                {
                    if (dgvTickets.Columns.Contains(prop))
                    {
                        var c = dgvTickets.Columns[prop];
                        c.Visible = true;
                        c.HeaderText = header;
                    }
                }

                if (dgvTickets.Columns.Contains("TicketId"))
                    dgvTickets.Columns["TicketId"].Visible = false;

                dgvTickets.AutoResizeColumns();
            }

            private void btnBuscar_Click(object sender, EventArgs e)
            {
                CargarTickets();
            }

            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                txtTicketNumber.Clear();
                cmbCategoriaFilter.SelectedIndex = 0;
                cmbEstadoFilter.SelectedIndex = 0;
                dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
                dtpFechaHasta.Value = DateTime.Now;
                CargarTickets();
            }

            private void btnAbrirTicket_Click(object sender, EventArgs e)
            {
                if (dgvTickets.CurrentRow == null) return;

                var id = (Guid)dgvTickets.CurrentRow.Cells["TicketId"].Value;
                var ticket = _ticketBLL.ObtenerTicketPorId(id);
                lblHeaderTitle.Text = $"Ticket #{ticket.Numero}";
                var vista = new VistaDeTicketCliente(ticket);
                CargarSubformEnPanel(vista);
            }

            private void CargarSubformEnPanel(Form subform)
            {
            
                panelFilters.Visible = false;

                if (Controls.Contains(dgvTickets))
                    Controls.Remove(dgvTickets);
                foreach (var frm in Controls.OfType<Form>().ToList())
                    Controls.Remove(frm);

                subform.TopLevel = false;
                subform.FormBorderStyle = FormBorderStyle.None;
                subform.ControlBox = false;
                subform.Dock = DockStyle.Fill;

                Controls.Add(subform);
                subform.BringToFront();
                subform.Show();

                subform.FormClosed += (s, e) =>
                {
                    lblHeaderTitle.Text = "Seleccione un ticket para ver su detalle";
                    Controls.Remove(subform);
                    panelFilters.Visible = true;
                    Controls.Add(dgvTickets);
                    dgvTickets.Dock = DockStyle.Fill;
                    dgvTickets.BringToFront();
                    CargarTickets();
                };
            }
        }
    }
