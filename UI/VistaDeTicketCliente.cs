using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BE;
using BE.PN;
using SERVICIOS;

namespace UI
{
    public partial class VistaDeTicketCliente : Form
    {
        private readonly TicketBLL _ticketBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TecnicoBLL _tecnicoBLL;

        private Ticket _ticket;

        public VistaDeTicketCliente(Ticket ticket)
        {
            InitializeComponent();

            _ticketBLL = new TicketBLL();
            _comentarioBLL = new ComentarioBLL();
            _clienteBLL = new ClienteBLL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _tecnicoBLL = new TecnicoBLL();

            _ticket = ticket;
            ticket.Categoria = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId);
            ticket.ClienteCreador = _clienteBLL.ObtenerClientePorId(ticket.ClienteCreadorId);

            LoadCombos();
            PopulateFields();
            LoadComentarios();
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria selCat)
            {
                cmbTicketType.SelectedItem = selCat.tipoCategoria;
                cmbPrioridad.SelectedItem = selCat.Prioridad.Nombre;

                // Grupo técnico asociado a la categoría
                cmbGrupoTecDestino.DataSource = new[] { selCat.GrupoTecnico };
                cmbGrupoTecDestino.DisplayMember = "Nombre";
                cmbGrupoTecDestino.ValueMember = "GrupoId";
            }
        }

        private void LoadCombos()
        {
            // Categorías
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";

            // Tipo de ticket (solo lectura)
            cmbTicketType.DataSource = Enum.GetValues(typeof(BE.PN.TipoCategoria))
                                         .Cast<BE.PN.TipoCategoria>()
                                         .ToList();
            cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTicketType.Enabled = false;

            // Grupo técnico (bloqueado para usuario)
            cmbGrupoTecDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoTecDestino.Enabled = false;

            // Prioridad
            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // Eventos
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;

            // Forzar selección inicial
            if (cmbCategoria.Items.Count > 0)
                CmbCategoria_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void PopulateFields()
        {
            lblOpenDateValue.Text = _ticket.FechaCreacion.ToString("g");
            lblLastUpdValue.Text = _ticket.FechaUltimaModif.ToString("g");

            txtCliente.Text = $"{_ticket.ClienteCreador.Apellido}, {_ticket.ClienteCreador.Nombre}";
            txtCreadoPor.Text = txtCliente.Text;
            txtUbicacion.Text = _ticket.ClienteCreador.Direccion ?? "";
            txtDepartamento.Text = _ticket.ClienteCreador.Departamento?.Nombre ?? "";

            // Categoría
            //cmbCategoria.SelectedValue = _ticket.CategoriaId;
            //cmbCategoria.

            // Tipo de ticket
            //cmbTicketType.SelectedItem = _ticket.Categoria.tipoCategoria;

            // Grupo técnico (solo uno disponible en combo)
            //cmbGrupoTecDestino.DataSource = new[] { _ticket.Categoria.GrupoTecnico };
            //cmbGrupoTecDestino.DisplayMember = "Nombre";
            //cmbGrupoTecDestino.ValueMember = "GrupoId";

            // Técnico asignado
            if (_ticket.TecnicoId.HasValue)
            {
                Tecnico tecnico = _tecnicoBLL.ObtenerTecnicoPorId(_ticket.TecnicoId.Value);
                txtAssignedTech.Text = $"{tecnico.Apellido}, {tecnico.Nombre}";
            }

            // Prioridad
            cmbPrioridad.SelectedValue = _ticket.PrioridadId;

            // Asunto y descripción
            txtAsunto.Text = _ticket.Asunto;
            txtDescripcion.Text = _ticket.Descripcion;
        }

        private void LoadComentarios()
        {
            var list = _comentarioBLL.ListarComentariosPorTicket(_ticket.TicketId);
            dgvComentarios.DataSource = list
                .OrderBy(c => c.Fecha)
                .Select(c => new {
                    Fecha = c.Fecha,
                    Autor = c.Usuario.NombreUsuario,
                    Comentario = c.Texto
                })
                .ToList();
        }

        private void btnNuevoComentario_Click(object sender, EventArgs e)
        {
            // Lógica para nuevo comentario (comentada por ahora)
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
            _ticket.Categoria = (Categoria)cmbCategoria.SelectedItem;
            _ticket.Categoria.tipoCategoria = (TipoCategoria)cmbTicketType.SelectedItem;

            _ticket.GrupoTecnicoId = ((GrupoTecnico)cmbGrupoTecDestino.SelectedItem).GrupoId;
            _ticket.GrupoTecnico = (GrupoTecnico)cmbGrupoTecDestino.SelectedItem;

            _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
            _ticket.Prioridad = (Prioridad)cmbPrioridad.SelectedItem;

            _ticket.Asunto = txtAsunto.Text.Trim();
            _ticket.Descripcion = txtDescripcion.Text.Trim();

            _ticketBLL.ActualizarTicket(_ticket);
            MessageBox.Show("Cambios guardados", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            var cancelado = new EstadoTicketBLL()
                               .ListarEstadosTicket()
                               .FirstOrDefault(st => st.Nombre == "Cancelado");

            if (cancelado != null)
            {
                _ticket.EstadoId = cancelado.EstadoId;
                _ticket.Estado = cancelado;
                _ticketBLL.ActualizarTicket(_ticket);
                MessageBox.Show("Ticket cancelado", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void txtAssignedTech_TextChanged(object sender, EventArgs e) { }

        private void lblOpenDate_Click(object sender, EventArgs e) { }
    }
}
