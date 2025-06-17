using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;        // TicketBLL, ComentarioBLL, etc.
using BE;         // Ticket, Comentario, TicketHistorico, Cliente, Categoria, Prioridad, Tecnico, EstadoTicket, GrupoTecnico, Departamento
using BE.PN;      // TipoCategoria, etc.
using SERVICIOS;  // SingletonSesion, etc.

namespace UI
{
    public partial class frmVistaDeTicketTecnico : Form
    {
        private readonly TicketBLL _ticketBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TecnicoBLL _tecnicoBLL;
        private readonly EstadoTicketBLL _estadoBLL;
        private readonly DepartamentoBLL _departamentoBLL;

        private Ticket _ticket;

        public frmVistaDeTicketTecnico(Ticket ticket)
        {
            InitializeComponent();

            _ticketBLL = new TicketBLL();
            _comentarioBLL = new ComentarioBLL();
            _clienteBLL = new ClienteBLL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _tecnicoBLL = new TecnicoBLL();
            _estadoBLL = new EstadoTicketBLL();
            _departamentoBLL = new DepartamentoBLL();

            _ticket = ticket;

            // Cargo relaciones
            ticket.Categoria = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId);
            ticket.ClienteCreador = _clienteBLL.ObtenerClientePorId(ticket.ClienteCreadorId);
            if (ticket.ClienteCreador.Departamento?.Nombre == null)
                ticket.ClienteCreador.Departamento =
                    _departamentoBLL.ObtenerDepartamentoPorId(ticket.ClienteCreador.Departamento.Id);
            if (ticket.EstadoId > 0)
                ticket.Estado = _estadoBLL.ObtenerEstadoTicket(ticket.EstadoId);

            // UI
            LoadCombos();
            PopulateFields();
            LoadHistorial();
            LoadComentarios();

            // Subscripción a eventos
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            //btnGuardarCambios.Click += BtnGuardarCambios_Click;
            btnCancelarTicket.Click += btnCancelarTicket_Click;  // coincide con el nombre del método
        }

        private void LoadCombos()
        {
            // Categorías
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;

            // Tipo de ticket (lectura)
            cmbTicketType.DataSource = Enum.GetValues(typeof(TipoCategoria)).Cast<TipoCategoria>().ToList();
            cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTicketType.Enabled = false;

            // Grupo técnico destino (lectura)
            cmbGrupoTecDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoTecDestino.Enabled = false;

            // Prioridades
            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // Técnicos
            var tecnicos = _tecnicoBLL.ListarTecnicosActivos();    // usa ListarTecnicos()
            cmbTecnico.DataSource = tecnicos;
            cmbTecnico.DisplayMember = "NombreCompleto";
            cmbTecnico.ValueMember = "TecnicoId";
            cmbTecnico.DropDownStyle = ComboBoxStyle.DropDownList;

            // Estados
            var estados = _estadoBLL.ListarEstadosTicket();       // usa ListarEstados()
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "EstadoId";
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            // Iniciar selección
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
                CmbCategoria_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria selCat)
            {
                cmbTicketType.SelectedItem = selCat.tipoCategoria;
                cmbPrioridad.SelectedValue = selCat.Prioridad.Id; // o selCat.PrioridadId según tu modelo
                cmbGrupoTecDestino.DataSource = new[] { selCat.GrupoTecnico };
                cmbGrupoTecDestino.DisplayMember = "Nombre";
                cmbGrupoTecDestino.ValueMember = "GrupoId";
            }
        }

        private void PopulateFields()
        {
            lblOpenDateValue.Text = _ticket.FechaCreacion.ToString("g");
            lblLastUpdValue.Text = _ticket.FechaUltimaModif.ToString("g");

            txtCliente.Text = $"{_ticket.ClienteCreador.Apellido}, {_ticket.ClienteCreador.Nombre}";
            txtCreadoPor.Text = txtCliente.Text;
            txtUbicacion.Text = _ticket.ClienteCreador.Direccion ?? "";
            txtDepartamento.Text = _ticket.ClienteCreador.Departamento?.Nombre ?? "";

            cmbCategoria.SelectedValue = _ticket.CategoriaId;
            cmbPrioridad.SelectedValue = _ticket.PrioridadId;

            if (_ticket.GrupoTecnicoId.HasValue)
                cmbGrupoTecDestino.SelectedValue = _ticket.GrupoTecnicoId.Value;

            if (_ticket.TecnicoId.HasValue)
                cmbTecnico.SelectedValue = _ticket.TecnicoId.Value;

            cmbEstado.SelectedValue = _ticket.EstadoId;

            txtAsunto.Text = _ticket.Asunto;
            txtDescripcion.Text = _ticket.Descripcion;
        }

        private void LoadHistorial()
        {
            var historicoBLL = new TicketHistoricoBLL();
            var lista = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);

            dgvHistorial.DataSource = lista
                .Select(h => new {
                    Fecha = h.FechaCambio.ToString("g"),
                    Usuario = h.UsuarioCambioId.ToString(),
                    Accion = $"{h.TipoEvento}: {h.ValorAnteriorId ?? 0} → {h.ValorNuevoId ?? 0}"
                })
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();
        }

        private void LoadComentarios()
        {
            var lista = _comentarioBLL.ListarComentariosPorTicket(_ticket.TicketId);
            dgvComentarios.DataSource = lista
                .SelectMany(c => ConstruirListadoPlano(c))
                .OrderBy(x => x.Fecha)
                .ToList();
        }

        private static IEnumerable<dynamic> ConstruirListadoPlano(Comentario raiz)
        {
            var result = new List<dynamic>();
            result.Add(new
            {
                Fecha = raiz.Fecha,
                Autor = $"{raiz.Usuario.Nombre} {raiz.Usuario.Apellido}",
                Comentario = raiz.Texto
            });
            foreach (var r in raiz.Respuestas)
            {
                result.Add(new
                {
                    Fecha = r.Fecha,
                    Autor = $"{r.Usuario.Nombre} {r.Usuario.Apellido}",
                    Comentario = "↳ " + r.Texto
                });
                result.AddRange(ConstruirListadoPlano(r).Skip(1));
            }
            return result;
        }

        private void BtnNuevoComentario_Click(object sender, EventArgs e)
        {
            panelAgregarComentario.Visible = true;
            txtComentarioNuevo.Clear();
            txtComentarioNuevo.Focus();
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            // modo comentario
            if (panelAgregarComentario.Visible)
            {
                var texto = txtComentarioNuevo.Text.Trim();
                if (!string.IsNullOrEmpty(texto))
                {
                    var usrId = _ticket.ClienteCreador.Id;
                    _comentarioBLL.AgregarComentario(_ticket.TicketId, usrId, texto);
                    new TicketHistoricoBLL().AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = usrId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Comentario",
                        Comentario = $"Se agregó comentario: \"{texto}\""
                    });
                    LoadComentarios();
                    LoadHistorial();
                }
                panelAgregarComentario.Visible = false;
                return;
            }

            // guardar cambios
            int antesTec = _ticket.TecnicoId ?? 0;
            int antesEstado = _ticket.EstadoId;

            _ticket.TecnicoId = (int)cmbTecnico.SelectedValue;
            _ticket.EstadoId = (int)cmbEstado.SelectedValue;
            _ticket.Estado = _estadoBLL.ObtenerEstadoTicket(_ticket.EstadoId);
            _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
            _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
            _ticket.Asunto = txtAsunto.Text.Trim();
            _ticket.Descripcion = txtDescripcion.Text.Trim();

            var usr = SingletonSesion.Instancia.Sesion.Usuario.Id;
            var historico = new TicketHistoricoBLL();

            if (antesTec != _ticket.TecnicoId)
                historico.AgregarHistorico(new TicketHistorico
                {
                    TicketId = _ticket.TicketId,
                    UsuarioCambioId = usr,
                    FechaCambio = DateTime.Now,
                    TipoEvento = "Técnico",
                    ValorAnteriorId = antesTec,
                    ValorNuevoId = _ticket.TecnicoId,
                    Comentario = "Técnico cambiado"
                });

            if (antesEstado != _ticket.EstadoId)
                historico.AgregarHistorico(new TicketHistorico
                {
                    TicketId = _ticket.TicketId,
                    UsuarioCambioId = usr,
                    FechaCambio = DateTime.Now,
                    TipoEvento = "Estado",
                    ValorAnteriorId = antesEstado,
                    ValorNuevoId = _ticket.EstadoId,
                    Comentario = "Estado cambiado"
                });

            _ticketBLL.ActualizarTicket(_ticket);
            MessageBox.Show("Cambios guardados", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            int antes = _ticket.EstadoId;
            const int idCan = 7;
            _ticket.EstadoId = idCan;

            new TicketHistoricoBLL().AgregarHistorico(new TicketHistorico
            {
                TicketId = _ticket.TicketId,
                UsuarioCambioId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                FechaCambio = DateTime.Now,
                TipoEvento = "Estado",
                ValorAnteriorId = antes,
                ValorNuevoId = idCan,
                Comentario = "Ticket cancelado"
            });

            MessageBox.Show("Ticket cancelado", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        // No usados
        private void lblOpenDate_Click(object sender, EventArgs e) { }
        private void splitContainerMain_Panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
