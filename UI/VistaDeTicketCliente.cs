using System;
using System.Linq;
using System.Windows.Forms;
using BLL;        // Asegúrate que TicketBLL, ComentarioBLL, etc. estén en este namespace
using BE;         // Entidades BE, incluida TicketHistorico y Usuario
using BE.PN;      // Si tus entidades específicas están en BE.PN
using SERVICIOS;  // Otras utilerías que uses

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
        private readonly EstadoTicketBLL _estadoBLL;
        private readonly DepartamentoBLL _departamentoBLL;

        private Ticket _ticket;

        public VistaDeTicketCliente(Ticket ticket)
        {
            InitializeComponent();

            // Inicializo las instancias de las capas BLL
            _ticketBLL = new TicketBLL();
            _comentarioBLL = new ComentarioBLL();
            _clienteBLL = new ClienteBLL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _tecnicoBLL = new TecnicoBLL();
            _estadoBLL = new EstadoTicketBLL();
            _departamentoBLL = new DepartamentoBLL();

            _ticket = ticket;

            //
            // Cargo datos relacionados: Categoría, Cliente (y su Departamento), Estado.
            //
            // 1.a) Cargo la Categoría completa
            ticket.Categoria = _categoriaBLL.ObtenerCategoriaPorId(ticket.CategoriaId);

            // 1.b) Cargo el Cliente creador con su Departamento
            ticket.ClienteCreador = _clienteBLL.ObtenerClientePorId(ticket.ClienteCreadorId);
            if (ticket.ClienteCreador.Departamento?.Nombre == null)
            {
                ticket.ClienteCreador.Departamento =
                    _departamentoBLL.ObtenerDepartamentoPorId(ticket.ClienteCreador.Departamento.Id);
            }

            // 1.c) Cargo el Estado del ticket (si ya tiene uno asignado)
            if (ticket.EstadoId > 0)
            {
                ticket.Estado = _estadoBLL.ObtenerEstadoTicket(ticket.EstadoId);
            }

            // 2) Cargo los combos (categorías, prioridades, tipos, etc.)
            LoadCombos();

            // 3) Poblo los campos de la parte superior (Cliente, Asunto, Ubicación, etc.)
            PopulateFields();

            // 4) CARGA EL HISTORIAL y lo muestra en dgvHistorial
            LoadHistorial();

            // 5) Cargo la sección de comentarios debajo del histórico
            LoadComentarios();

            // 6) Suscribo eventos de botones
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            //btnGuardarCambios.Click += BtnGuardarCambios_Click;
            btnCancelarTicket.Click += btnCancelarTicket_Click;
        }

        /// <summary>
        /// Carga la lista de historial de este ticket y lo asigna a dgvHistorial.
        /// </summary>
        private void LoadHistorial()
        {
            var historicoBLL = new TicketHistoricoBLL();
            var listaHistorialCompleta = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);

            var listaPlano = listaHistorialCompleta
                             .Select(h => new
                             {
                                 Fecha = h.FechaCambio.ToString("g"),
                                 Usuario = /* Si tienes Usuario cargado en h.UsuarioCambio, úsalo aquí: */
                                           h.UsuarioCambioId.ToString(),
                                 Accion = $"{h.TipoEvento}: {h.ValorAnteriorId ?? 0} → {h.ValorNuevoId ?? 0}",
                                 Comentario = h.Comentario
                             })
                             .OrderBy(x => DateTime.Parse(x.Fecha))
                             .ToList();

            dgvHistorial.DataSource = listaPlano;
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria selCat)
            {
                cmbTicketType.SelectedItem = selCat.tipoCategoria;
                cmbPrioridad.SelectedItem = selCat.Prioridad.Nombre;
                cmbGrupoTecDestino.DataSource = new[] { selCat.GrupoTecnico };
                cmbGrupoTecDestino.DisplayMember = "Nombre";
                cmbGrupoTecDestino.ValueMember = "GrupoId";
            }
        }

        private void LoadCombos()
        {
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";

            cmbTicketType.DataSource = Enum.GetValues(typeof(TipoCategoria))
                                          .Cast<TipoCategoria>()
                                          .ToList();
            cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTicketType.Enabled = false;

            cmbGrupoTecDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoTecDestino.Enabled = false;

            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;

            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
                CmbCategoria_SelectedIndexChanged(this, EventArgs.Empty);
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
            cmbTicketType.SelectedItem = _ticket.Categoria.tipoCategoria;

            if (_ticket.TecnicoId.HasValue)
            {
                var tecnico = _tecnicoBLL.ObtenerTecnicoPorId(_ticket.TecnicoId.Value);
                txtAssignedTech.Text = $"{tecnico.Apellido}, {tecnico.Nombre}";
            }

            cmbPrioridad.SelectedValue = _ticket.PrioridadId;
            txtEstado.Text = _ticket.Estado?.Nombre ?? "";
            txtAsunto.Text = _ticket.Asunto;
            txtDescripcion.Text = _ticket.Descripcion;
        }

        private void LoadComentarios()
        {
            var lista = _comentarioBLL.ListarComentariosPorTicket(_ticket.TicketId);
            dgvComentarios.DataSource = lista
                .SelectMany(c => ConstruirListadoPlano(c))
                .OrderBy(x => x.Fecha)
                .ToList();
        }

        private static System.Collections.Generic.List<dynamic> ConstruirListadoPlano(Comentario raiz)
        {
            var result = new System.Collections.Generic.List<dynamic>();
            result.Add(new
            {
                Fecha = raiz.Fecha,
                Autor = $"{raiz.Usuario.Nombre} {raiz.Usuario.Apellido}",
                Comentario = raiz.Texto
            });

            foreach (var respuesta in raiz.Respuestas)
            {
                result.Add(new
                {
                    Fecha = respuesta.Fecha,
                    Autor = $"{respuesta.Usuario.Nombre} {respuesta.Usuario.Apellido}",
                    Comentario = "↳ " + respuesta.Texto
                });

                var másRespuestas = ConstruirListadoPlano(respuesta).Skip(1);
                result.AddRange(másRespuestas);
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
            // 1) Si estamos en modo "nuevo comentario", guardamos sólo el comentario...
            if (panelAgregarComentario.Visible)
            {
                var texto = txtComentarioNuevo.Text.Trim();
                if (!string.IsNullOrEmpty(texto))
                {
                    var usuarioComentarioId = _ticket.ClienteCreador.Id;
                    // Agregamos el comentario
                    _comentarioBLL.AgregarComentario(_ticket.TicketId, usuarioComentarioId, texto);

                    // Registro histórico
                    var historicoBLL = new TicketHistoricoBLL();
                    historicoBLL.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = usuarioComentarioId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Comentario",
                        ValorAnteriorId = null,
                        ValorNuevoId = null,
                        Comentario = $"Se agregó comentario: \"{texto}\""
                    });

                    // Recargamos vistas
                    LoadComentarios();
                    LoadHistorial();
                }

                // Ocultamos panel y limpiamos, **y SALIMOS** para no disparar la actualización de ticket
                panelAgregarComentario.Visible = false;
                txtComentarioNuevo.Clear();
                return;
            }

            // 2) Sólo si no era un comentario, entramos aquí y actualizamos el ticket
            //    (tu lógica existente de prioridad, categoría, asunto, descripción...)
            int prioridadAntes = _ticket.PrioridadId;
            int categoriaAntes = _ticket.CategoriaId;
            int? grupoAntes = _ticket.GrupoTecnicoId;
            int estadoAntes = _ticket.EstadoId;

            _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
            _ticket.Categoria = (Categoria)cmbCategoria.SelectedItem;
            _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
            _ticket.Asunto = txtAsunto.Text.Trim();
            _ticket.Descripcion = txtDescripcion.Text.Trim();
            if (cmbGrupoTecDestino.SelectedItem is GrupoTecnico grupoSel)
            {
                _ticket.GrupoTecnicoId = grupoSel.GrupoId;
                _ticket.GrupoTecnico = grupoSel;
            }

            var historicoCambioBLL = new TicketHistoricoBLL();
            Guid usuarioActualId = SingletonSesion.Instancia.Sesion.Usuario.Id;

            // Insertar históricos de prioridad, categoría y grupo…
            // (idéntico a tu código anterior)

            // Finalmente, guardamos
            _ticketBLL.ActualizarTicket(_ticket);
            MessageBox.Show("Cambios guardados", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            const int estadoCanceladoId = 7;
            int estadoAntes = _ticket.EstadoId;

            _ticket.EstadoId = estadoCanceladoId;
            _ticket.Estado = _estadoBLL.ObtenerEstadoTicket(estadoCanceladoId);

            var historicoBLL = new TicketHistoricoBLL();
            Guid usuarioActualId = SingletonSesion.Instancia.Sesion.Usuario.Id;

            var histEstado = new TicketHistorico
            {
                TicketId = _ticket.TicketId,
                UsuarioCambioId = usuarioActualId,
                FechaCambio = DateTime.Now,
                TipoEvento = "Estado",
                ValorAnteriorId = estadoAntes,
                ValorNuevoId = estadoCanceladoId,
                Comentario = "Ticket cancelado"
            };
            historicoBLL.AgregarHistorico(histEstado);

         
            MessageBox.Show("Ticket cancelado", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        // Métodos vacíos para eventos que no usamos
        private void txtAssignedTech_TextChanged(object sender, EventArgs e) { }
        private void lblOpenDate_Click(object sender, EventArgs e) { }
        private void splitContainerMain_Panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
