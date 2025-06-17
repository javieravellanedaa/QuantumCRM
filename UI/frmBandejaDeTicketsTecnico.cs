using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using BLL;
using BE;
using SERVICIOS;
using System.Drawing;

namespace UI
{
    public partial class frmBandejaDeTicketsTecnico : Form
    {
        private readonly TicketBLL _ticketBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly EstadoTicketBLL _estadoBLL;
        private readonly GrupoTecnicoBLL _grupoBLL;
        private readonly TecnicoBLL _tecnicoBLL;

        public frmBandejaDeTicketsTecnico()
        {
            InitializeComponent();

            _ticketBLL = new TicketBLL();
            _categoriaBLL = new CategoriaBLL();
            _estadoBLL = new EstadoTicketBLL();
            _grupoBLL = new GrupoTecnicoBLL();
            _tecnicoBLL = new TecnicoBLL();

            dgvTickets.CellFormatting += dgvTickets_CellFormatting;
        }

        private void frmBandejaDeTicketsTecnico_Load(object sender, EventArgs e)
        {
            // --- Bind de categorías ---
            var categorias = _categoriaBLL.ListarCategorias();
            categorias.Insert(0, new Categoria { CategoriaId = 0, Nombre = "Todos" });
            cmbCategoriaFilter.DataSource = categorias;
            cmbCategoriaFilter.DisplayMember = "Nombre";
            cmbCategoriaFilter.ValueMember = "CategoriaId";

            // --- Bind de estados ---
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
            // Solo nos interesa la columna "Prioridad"
            if (dgvTickets.Columns[e.ColumnIndex].Name != "Prioridad" || e.Value == null)
                return;

            var val = e.Value.ToString();
            switch (val)
            {
                case "Baja":
                    e.CellStyle.BackColor = Color.FromArgb(198, 239, 206);
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case "Media":
                    e.CellStyle.BackColor = Color.FromArgb(255, 235, 156);
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case "Alta":
                    e.CellStyle.BackColor = Color.FromArgb(255, 199, 206);
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case "Urgente":
                    e.CellStyle.BackColor = Color.FromArgb(244, 88, 88);
                    e.CellStyle.ForeColor = Color.White;
                    break;
                default:
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                    break;
            }
        }

        private void CargarTickets()
        {
            // 0) Obtener usuario y su técnico
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            var tecnico = _tecnicoBLL
                .ListarTecnicosActivos()
                .FirstOrDefault(t => t.Id == usuario.Id)
                ?? throw new InvalidOperationException("No se encontró el registro de técnico para este usuario.");

            // 1) Obtener grupos del técnico
            var grupos = _grupoBLL.ObtenerGruposAsignados(tecnico.TecnicoId);

            // 2) Cargar tickets de todos los grupos
            var query = grupos
                .SelectMany(g => _ticketBLL.ListarTicketsPorGrupo(g.GrupoId))
                .AsEnumerable();

            // 3) Filtro por número de ticket
            var filtroNum = txtTicketNumber.Text.Trim();
            if (!string.IsNullOrEmpty(filtroNum))
                query = query.Where(t => t.TicketId.ToString().Contains(filtroNum));

            // 4) Filtro por categoría
            if (cmbCategoriaFilter.SelectedItem is Categoria selCat && selCat.CategoriaId != 0)
                query = query.Where(t => t.CategoriaId == selCat.CategoriaId);

            // 5) Filtro por estado
            if (cmbEstadoFilter.SelectedItem is EstadoTicket selEst && selEst.EstadoId != 0)
                query = query.Where(t => t.EstadoId == selEst.EstadoId);

            // 6) Filtro por rango de fechas
            var desde = dtpFechaDesde.Value.Date;
            var hasta = dtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1);
            query = query.Where(t => t.FechaCreacion >= desde && t.FechaCreacion <= hasta);

            // 7) Proyección plana
            var listadoPlano = query
                .Select(t =>
                {
                    var categoriaObj = _categoriaBLL.ObtenerCategoriaPorId(t.CategoriaId);
                    var estadoObj = _estadoBLL.ObtenerEstadoTicket(t.EstadoId);
                    var prioridadObj = _categoriaBLL.Obtener_prioridad(categoriaObj);

                    // Aprobador (si aplica)
                    string aprobadorTexto = string.Empty;
                    if (t.UsuarioAprobadorId.HasValue)
                    {
                        var apro = new ClienteBLL().ObtenerClientePorId(t.UsuarioAprobadorId.Value);
                        aprobadorTexto = $"{apro.Apellido}, {apro.Nombre}";
                    }

                    // Técnico asignado (si aplica)
                    string tecnicoTexto = string.Empty;
                    if (t.TecnicoId.HasValue)
                    {
                        var tec = _tecnicoBLL.ObtenerTecnicoPorId(t.TecnicoId.Value);
                        tecnicoTexto = $"{tec.Apellido}, {tec.Nombre}";
                    }

                    return new
                    {
                        TicketNro = t.TicketId,
                        FechaCreacion = t.FechaCreacion,
                        Asunto = t.Asunto,
                        DetalleDescripcion = t.Descripcion,
                        Categoria = categoriaObj?.Nombre ?? string.Empty,
                        Estado = estadoObj?.Nombre ?? string.Empty,
                        Aprobador = aprobadorTexto,
                        Prioridad = prioridadObj?.Nombre ?? string.Empty,
                        TecnicoAsignado = tecnicoTexto
                    };
                })
                .ToList();

            dgvTickets.DataSource = listadoPlano;
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            // Oculta todas las columnas
            foreach (DataGridViewColumn col in dgvTickets.Columns)
                col.Visible = false;

            // Columnas a mostrar
            var columnas = new[]
            {
                ("TicketNro",          "Ticket Nro"),
                ("FechaCreacion",      "Fecha Creación"),
                ("Asunto",             "Asunto"),
                ("DetalleDescripcion", "Detalle Descripción"),
                ("Categoria",          "Categoría"),
                ("Estado",             "Estado"),
                ("Aprobador",          "Usuario Aprobador"),
                ("Prioridad",          "Prioridad"),
                ("TecnicoAsignado",    "Técnico Asignado")
            };

            foreach (var (prop, header) in columnas)
            {
                if (dgvTickets.Columns.Contains(prop))
                {
                    var col = dgvTickets.Columns[prop];
                    col.Visible = true;
                    col.HeaderText = header;
                }
            }

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

            var id = (Guid)dgvTickets.CurrentRow.Cells["TicketNro"].Value;
            var ticket = _ticketBLL.ObtenerTicketPorId(id);
            var vista = new frmVistaDeTicketTecnico(ticket);

            CargarSubformEnPanel(vista);
        }

        private void CargarSubformEnPanel(Form subform)
        {
            // Ocultar filtros y grilla
            panelFilters.Visible = false;
            if (this.Controls.Contains(dgvTickets))
                this.Controls.Remove(dgvTickets);

            // Eliminar hijos previos
            foreach (var frm in this.Controls.OfType<Form>().ToList())
                this.Controls.Remove(frm);

            // Configurar subform
            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.ControlBox = false;
            subform.Dock = DockStyle.Fill;

            // Inyectar
            this.Controls.Add(subform);
            subform.BringToFront();
            subform.Show();

            // Al cerrar, restaurar
            subform.FormClosed += (s, e) =>
            {
                this.Controls.Remove(subform);
                panelFilters.Visible = true;
                this.Controls.Add(dgvTickets);
                dgvTickets.Dock = DockStyle.Fill;
                dgvTickets.BringToFront();
                CargarTickets();
            };
        }
    }
}
