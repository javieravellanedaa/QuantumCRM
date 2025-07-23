using System;
using System.Linq;
using System.Windows.Forms;
using BLL;        // TicketBLL, ComentarioBLL, etc.
using BE;         // Ticket, Comentario, TicketHistorico, Usuario
using BE.PN;      // Categoria, GrupoTecnico, TipoCategoria, ValorCampoTicket, TipoDatoCampo
using SERVICIOS;  // EventManagerService, SingletonSesion
using System.Collections.Generic;
using System.Drawing;

namespace UI
{
    public partial class VistaDeTicketCliente : Form
    {
        private readonly TicketBLL _ticketBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TecnicoBLL _tecnicoBLL;
        private readonly EstadoTicketBLL _estadoBLL;
        private readonly DepartamentoBLL _departamentoBLL;
        private readonly CategoriaCampoPersonalizadoBLL _catCampoBLL;
        private readonly DefinicionCampoPersonalizadoBLL _defCampoBLL;
        private readonly ValorCampoTicketBLL _valorCampoBLL;
        private readonly UsuarioBLL _usuarioBLL;

        private Ticket _ticket;
        private Dictionary<int, Control> _mapControles = new Dictionary<int, Control>();

        // Constructor modificado
        public VistaDeTicketCliente(Ticket ticket)
        {
            InitializeComponent();

            // Validar que el ticket no sea null y tenga datos básicos
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            if (ticket.TicketId == Guid.Empty)
                throw new ArgumentException("El ticket debe tener un ID válido");

            // Inicializo todos los BLLs
            _ticketBLL = new TicketBLL();
            _comentarioBLL = new ComentarioBLL();
            _clienteBLL = new ClienteBLL();
            _grupoTecnicoBLL = new GrupoTecnicoBLL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _tecnicoBLL = new TecnicoBLL();
            _estadoBLL = new EstadoTicketBLL();
            _departamentoBLL = new DepartamentoBLL();
            _catCampoBLL = new CategoriaCampoPersonalizadoBLL();
            _defCampoBLL = new DefinicionCampoPersonalizadoBLL();
            _valorCampoBLL = new ValorCampoTicketBLL();
            _usuarioBLL = new UsuarioBLL();

            _ticket = ticket;
            this.Text = $"Ticket #{_ticket.Numero} - Detalle";

            // Cargo datos relacionados
            _ticket.Categoria = _categoriaBLL.ObtenerCategoriaPorId(_ticket.CategoriaId);
            _ticket.ClienteCreador = _clienteBLL.ObtenerClientePorId(_ticket.ClienteCreadorId);
            if (_ticket.ClienteCreador.Departamento?.Nombre == null)
            {
                _ticket.ClienteCreador.Departamento =
                    _departamentoBLL.ObtenerDepartamentoPorId(_ticket.ClienteCreador.Departamento.Id);
            }
            if (_ticket.EstadoId > 0)
            {
                _ticket.Estado = _estadoBLL.ObtenerEstadoTicket(_ticket.EstadoId);
            }

            // Cargar el grupo técnico del ticket si no está cargado
            if (_ticket.GrupoTecnicoId.HasValue && _ticket.GrupoTecnico == null)
            {
                _ticket.GrupoTecnico = _grupoTecnicoBLL.ObtenerGrupoPorId(_ticket.GrupoTecnicoId.Value);
            }

            // CAMBIO DE ORDEN: Primero cargar combos, luego popular campos
            LoadCombos();
            PopulateFields(); // Ahora se ejecuta DESPUÉS de cargar los combos

            LoadCamposPersonalizados();
            LoadHistorial();
            LoadComentarios();

            // Eventos
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            btnGuardarCambios.Click += BtnGuardarCambios_Click;
            btnCancelarTicket.Click += btnCancelarTicket_Click;

            // Deshabilitar categoría después de todo
            cmbCategoria.Enabled = false;

            // Agregar validación en tiempo real (opcional)
            txtAsunto.Leave += (s, e) =>
            {
                txtAsunto.BackColor = string.IsNullOrWhiteSpace(txtAsunto.Text)
                    ? Color.MistyRose
                    : SystemColors.Window;
            };
            txtDescripcion.Leave += (s, e) =>
            {
                txtDescripcion.BackColor = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                    ? Color.MistyRose
                    : SystemColors.Window;
            };
        }

        private void LoadCamposPersonalizados()
        {
            // Configuro el FlowLayoutPanel
            flpCampos.FlowDirection = FlowDirection.TopDown;
            flpCampos.WrapContents = false;
            flpCampos.AutoScroll = true;

            _mapControles.Clear();
            flpCampos.Controls.Clear();

            // Obtengo TODOS los valores guardados para este ticket
            var valoresGuardados = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);
            if (valoresGuardados.Count == 0)
            {
                panelCamposPersonalizados.Visible = false;
                return;
            }

            // Agregar botón para abrir ventana detallada AL PRINCIPIO
            var panelHeader = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Width = flpCampos.Width - 25,
                Margin = new Padding(0, 0, 0, 10)
            };

            var btnVerDetalle = new Button
            {
                Text = "🔍 Ver todos los campos detallados",
                AutoSize = true,
                Margin = new Padding(0, 0, 10, 0),
                BackColor = Color.FromArgb(13, 110, 253),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular),
                Padding = new Padding(12, 6, 12, 6),
                Cursor = Cursors.Hand
            };
            btnVerDetalle.FlatAppearance.BorderSize = 0;
            btnVerDetalle.Click += BtnVerDetalleCampos_Click;

            var lblInfo = new Label
            {
                Text = $"({valoresGuardados.Count} campo{(valoresGuardados.Count == 1 ? "" : "s")} personalizado{(valoresGuardados.Count == 1 ? "" : "s")})",
                AutoSize = true,
                Margin = new Padding(0, 8, 0, 0),
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic),
                ForeColor = Color.FromArgb(108, 117, 125)
            };

            panelHeader.Controls.Add(btnVerDetalle);
            panelHeader.Controls.Add(lblInfo);
            flpCampos.Controls.Add(panelHeader);

            // Obtengo las asociaciones de la categoría actual para el orden
            var asociacionesActuales = _catCampoBLL
                .ListarPorCategoria(_ticket.CategoriaId)
                .ToDictionary(a => a.DefinicionCampoPersonalizadoId, a => a.OrdenVisualizacion);

            // Creo una lista de campos a mostrar, priorizando los de la categoría actual
            var camposAMostrar = new List<(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int orden)>();
            foreach (var valor in valoresGuardados)
            {
                var def = _defCampoBLL.ObtenerPorId(valor.DefinicionCampoPersonalizadoId);
                if (def == null) continue;
                bool esActual = asociacionesActuales.ContainsKey(def.Id);
                int orden = esActual ? asociacionesActuales[def.Id] : 9999;
                camposAMostrar.Add((def, valor, esActual, orden));
            }

            // Ordeno: primero los de categoría actual, luego históricos
            camposAMostrar = camposAMostrar
                .OrderBy(x => x.esCategoriaActual ? 0 : 1)
                .ThenBy(x => x.orden)
                .ThenBy(x => x.def.Etiqueta)
                .Take(4)
                .ToList();

            // Si hay campos de categorías anteriores, agrego advertencia
            if (valoresGuardados.Any(v =>
            {
                var def = _defCampoBLL.ObtenerPorId(v.DefinicionCampoPersonalizadoId);
                return def != null && !asociacionesActuales.ContainsKey(def.Id);
            }))
            {
                var lblAdvertencia = new Label
                {
                    Text = "⚠️ Este ticket fue recategorizado. Algunos campos no se muestran aquí.",
                    ForeColor = Color.Orange,
                    AutoSize = true,
                    Margin = new Padding(3, 0, 3, 10),
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic)
                };
                flpCampos.Controls.Add(lblAdvertencia);
            }

            // Muestro los primeros 4 campos en resumen
            foreach (var (def, valorGuardado, esActual, _) in camposAMostrar)
            {
                var fila = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    WrapContents = false,
                    Margin = new Padding(0, 3, 0, 3),
                    Width = flpCampos.Width - 25
                };

                var lbl = new Label
                {
                    Text = def.Etiqueta + (esActual ? ":" : " (Anterior):"),
                    AutoSize = true,
                    Margin = new Padding(3, 4, 10, 0),
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold),
                    ForeColor = esActual
                        ? Color.FromArgb(55, 71, 79)
                        : Color.Gray,
                    Width = 120
                };
                fila.Controls.Add(lbl);

                var valorTexto = ObtenerTextoValorResumen(def, valorGuardado);
                var lblValor = new Label
                {
                    Text = valorTexto,
                    AutoSize = true,
                    Margin = new Padding(0, 4, 3, 0),
                    Font = new Font("Microsoft Sans Serif", 8.25F),
                    ForeColor = esActual ? Color.Black : Color.Gray,
                    MaximumSize = new Size(200, 0)
                };
                fila.Controls.Add(lblValor);

                flpCampos.Controls.Add(fila);
            }

            // Si hay más de 4 campos, muestro indicador
            if (valoresGuardados.Count > 4)
            {
                var lblMas = new Label
                {
                    Text = $"... y {valoresGuardados.Count - 4} campo(s) más (ver ventana detallada)",
                    AutoSize = true,
                    Margin = new Padding(3, 8, 10, 0),
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(13, 110, 253),
                    Cursor = Cursors.Hand
                };
                lblMas.Click += BtnVerDetalleCampos_Click;
                flpCampos.Controls.Add(lblMas);
            }

            panelCamposPersonalizados.Visible = true;
        }

        private string ObtenerTextoValorResumen(DefinicionCampoPersonalizado def, ValorCampoTicket valor)
        {
            switch (def.TipoDato)
            {
                case TipoDatoCampo.Texto:
                    var texto = valor.ValorTexto ?? "";
                    return texto.Length > 30 ? texto.Substring(0, 30) + "..." : texto;
                case TipoDatoCampo.Numero:
                    return (valor.ValorNumero ?? 0).ToString();
                case TipoDatoCampo.Fecha:
                    return valor.ValorFecha?.ToString("dd/MM/yyyy") ?? "";
                case TipoDatoCampo.Lista:
                    return valor.ValorTexto ?? "";
                default:
                    return valor.ValorTexto ?? "";
            }
        }

        private void BtnVerDetalleCampos_Click(object sender, EventArgs e)
        {
            try
            {
                var ventana = new VentanaCamposPersonalizados(_ticket, _valorCampoBLL, _defCampoBLL, _catCampoBLL);
                ventana.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana de campos personalizados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LoadCombos modificado - Cargar TODOS los grupos técnicos
        private void LoadCombos()
        {
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";

            cmbTicketType.DataSource = Enum.GetValues(typeof(TipoCategoria)).Cast<TipoCategoria>().ToList();
            cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTicketType.Enabled = false;

            // CAMBIO IMPORTANTE: Cargar TODOS los grupos técnicos, no solo el de la categoría
            var todosGrupos = _grupoTecnicoBLL.ListarTodos(); // Asegúrate de tener este método
            cmbGrupoTecDestino.DataSource = todosGrupos;
            cmbGrupoTecDestino.DisplayMember = "Nombre";
            cmbGrupoTecDestino.ValueMember = "GrupoId";
            cmbGrupoTecDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoTecDestino.Enabled = false;

            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // Agregar el evento DESPUÉS de configurar todo
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;
        }

        // CmbCategoria_SelectedIndexChanged modificado - Solo para cambios reales
        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria selCat)
            {
                cmbTicketType.SelectedItem = selCat.tipoCategoria;

                // NO cambiar prioridad si ya editando
                if (!this.IsHandleCreated || cmbPrioridad.SelectedValue == null)
                    cmbPrioridad.SelectedItem = selCat.Prioridad.Nombre;

                // CAMBIO IMPORTANTE: Solo actualizar grupo técnico si es un cambio real del usuario
                // No durante la carga inicial del formulario
                if (this.IsHandleCreated && _ticket != null)
                {
                    // Solo cambiar si el usuario realmente cambió la categoría
                    // y no estamos en modo de solo lectura
                    if (_ticket.CategoriaId != selCat.CategoriaId && cmbCategoria.Enabled)
                    {
                        // En este caso, el usuario cambió la categoría, así que actualizamos el grupo
                        cmbGrupoTecDestino.SelectedValue = selCat.GrupoTecnico.GrupoId;
                    }
                }
            }
        }

        // PopulateFields modificado - Establecer el grupo técnico REAL del ticket
        private void PopulateFields()
        {
            if (string.IsNullOrWhiteSpace(_ticket.Asunto))
            {
                MessageBox.Show($"ADVERTENCIA: El ticket {_ticket.TicketId} tiene el asunto vacío en la base de datos.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lblOpenDateValue.Text = _ticket.FechaCreacion.ToString("g");
            lblLastUpdValue.Text = _ticket.FechaUltimaModif.ToString("g");

            txtCliente.Text = $"{_ticket.ClienteCreador.Apellido}, {_ticket.ClienteCreador.Nombre}";
            txtCreadoPor.Text = txtCliente.Text;
            txtUbicacion.Text = _ticket.ClienteCreador.Direccion ?? "";
            txtDepartamento.Text = _ticket.ClienteCreador.Departamento?.Nombre ?? "";

            txtAsunto.Text = _ticket.Asunto ?? "";
            txtDescripcion.Text = _ticket.Descripcion ?? "";

            // Temporalmente desconectar el evento para evitar cambios no deseados
            cmbCategoria.SelectedIndexChanged -= CmbCategoria_SelectedIndexChanged;
            cmbCategoria.SelectedValue = _ticket.CategoriaId;
            cmbTicketType.SelectedItem = _ticket.Categoria.tipoCategoria;
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;

            // CAMBIO IMPORTANTE: Establecer el grupo técnico REAL del ticket
            if (_ticket.GrupoTecnicoId.HasValue)
            {
                cmbGrupoTecDestino.SelectedValue = _ticket.GrupoTecnicoId.Value;
            }
            else if (_ticket.GrupoTecnico != null)
            {
                cmbGrupoTecDestino.SelectedValue = _ticket.GrupoTecnico.GrupoId;
            }

            if (_ticket.TecnicoId.HasValue)
            {
                var tech = _tecnicoBLL.ObtenerTecnicoPorId(_ticket.TecnicoId.Value);
                txtAssignedTech.Text = $"{tech.Apellido}, {tech.Nombre}";
            }

            cmbPrioridad.SelectedValue = _ticket.PrioridadId;
            txtEstado.Text = _ticket.Estado?.Nombre ?? "";
        }

        private void LoadHistorial()
        {
            var historicoBLL = new TicketHistoricoBLL();
            var lista = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);

            var plano = lista
                .Select(h =>
                {
                    // 1) Usuario
                    var usr = _usuarioBLL.ObtenerUsuarioPorId(h.UsuarioCambioId);
                    string nombreUsr = usr != null
                        ? $"{usr.Nombre} {usr.Apellido}"
                        : "Desconocido";

                    // 2) Mapeo de acción según TipoEvento, con protección contra IDs = 0
                    string accion;
                    switch (h.TipoEvento)
                    {
                        case "Prioridad":
                            string antesP = (h.ValorAnteriorId.GetValueOrDefault() > 0)
                                ? _prioridadBLL.ObtenerPrioridadPorId(h.ValorAnteriorId.Value)?.Nombre ?? "—"
                                : "—";
                            string nuevaP = (h.ValorNuevoId.GetValueOrDefault() > 0)
                                ? _prioridadBLL.ObtenerPrioridadPorId(h.ValorNuevoId.Value)?.Nombre ?? "—"
                                : "—";
                            accion = $"Prioridad: {antesP} → {nuevaP}";
                            break;

                        case "Categoría":
                            string antesC = (h.ValorAnteriorId.GetValueOrDefault() > 0)
                                ? _categoriaBLL.ObtenerCategoriaPorId(h.ValorAnteriorId.Value)?.Nombre ?? "—"
                                : "—";
                            string nuevaC = (h.ValorNuevoId.GetValueOrDefault() > 0)
                                ? _categoriaBLL.ObtenerCategoriaPorId(h.ValorNuevoId.Value)?.Nombre ?? "—"
                                : "—";
                            accion = $"Categoría: {antesC} → {nuevaC}";
                            break;

                        case "Estado":
                            string antesE = (h.ValorAnteriorId.GetValueOrDefault() > 0)
                                ? _estadoBLL.ObtenerEstadoTicket(h.ValorAnteriorId.Value)?.Nombre ?? "—"
                                : "—";
                            string nuevoE = (h.ValorNuevoId.GetValueOrDefault() > 0)
                                ? _estadoBLL.ObtenerEstadoTicket(h.ValorNuevoId.Value)?.Nombre ?? "—"
                                : "—";
                            accion = $"Estado: {antesE} → {nuevoE}";
                            break;

                        case "Grupo":
                            string antesG = (h.ValorAnteriorId.GetValueOrDefault() > 0)
                                ? _grupoTecnicoBLL.ObtenerGrupoPorId(h.ValorAnteriorId.Value)?.Nombre ?? "—"
                                : "—";
                            string nuevoG = (h.ValorNuevoId.GetValueOrDefault() > 0)
                                ? _grupoTecnicoBLL.ObtenerGrupoPorId(h.ValorNuevoId.Value)?.Nombre ?? "—"
                                : "—";
                            accion = $"Grupo: {antesG} → {nuevoG}";
                            break;

                        default:
                            // Otros eventos sin valores numéricos
                            accion = h.TipoEvento;
                            break;
                    }

                    return new
                    {
                        Fecha = h.FechaCambio.ToString("g"),
                        Usuario = nombreUsr,
                        Accion = accion,
                        Comentario = h.Comentario
                    };
                })
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();

            dgvHistorial.DataSource = plano;
        }

        private void LoadComentarios()
        {
            var lista = _comentarioBLL.ListarComentariosPorTicket(_ticket.TicketId);
            var plano = lista
                .SelectMany(c => ConstruirListadoPlano(c))
                .OrderBy(x => x.Fecha)
                .ToList();

            dgvComentarios.DataSource = plano;
        }

        private static List<dynamic> ConstruirListadoPlano(Comentario raiz)
        {
            var result = new List<dynamic>();
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

        // BtnGuardarCambios_Click mejorado con validación del grupo técnico
        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Si estamos agregando comentario
            if (panelAgregarComentario.Visible)
            {
                var texto = txtComentarioNuevo.Text.Trim();
                if (!string.IsNullOrEmpty(texto))
                {
                    var userId = _ticket.ClienteCreador.Id;
                    _comentarioBLL.AgregarComentario(_ticket.TicketId, userId, texto);

                    var historicoBLL = new TicketHistoricoBLL();
                    historicoBLL.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = userId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Comentario",
                        Comentario = $"Se agregó comentario: \"{texto}\""
                    });

                    LoadComentarios();
                    LoadHistorial();
                }

                panelAgregarComentario.Visible = false;
                txtComentarioNuevo.Clear();
                return;
            }

            // Validación de asunto y descripción
            var asuntoNuevo = txtAsunto.Text.Trim();
            var descripcionNueva = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(asuntoNuevo))
            {
                MessageBox.Show("El asunto del ticket no puede estar vacío.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAsunto.Focus();
                txtAsunto.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(descripcionNueva))
            {
                MessageBox.Show("La descripción del ticket no puede estar vacía.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                txtDescripcion.SelectAll();
                return;
            }

            try
            {
                // Guardar valores antiguos
                var antesPrio = _ticket.PrioridadId;
                var antesCat = _ticket.CategoriaId;
                var antesGrupo = _ticket.GrupoTecnicoId;
                var antesEstado = _ticket.EstadoId;

                // Actualizar campos del ticket en memoria
                _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
                _ticket.Categoria = (Categoria)cmbCategoria.SelectedItem;
                _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
                _ticket.Asunto = asuntoNuevo;
                _ticket.Descripcion = descripcionNueva;

                // CAMBIO: Actualizar grupo técnico correctamente
                if (cmbGrupoTecDestino.SelectedValue != null)
                {
                    _ticket.GrupoTecnicoId = (int)cmbGrupoTecDestino.SelectedValue;
                    _ticket.GrupoTecnico = (GrupoTecnico)cmbGrupoTecDestino.SelectedItem;
                }

                var histBLL = new TicketHistoricoBLL();
                var currentUserId = SingletonSesion.Instancia.Sesion.Usuario.Id;

                // Histórico de prioridad
                if (antesPrio != _ticket.PrioridadId)
                    histBLL.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = currentUserId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Prioridad",
                        ValorAnteriorId = antesPrio,
                        ValorNuevoId = _ticket.PrioridadId,
                        Comentario = "Cambio de prioridad"
                    });

                // Histórico de categoría
                if (antesCat != _ticket.CategoriaId)
                    histBLL.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = currentUserId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Categoría",
                        ValorAnteriorId = antesCat,
                        ValorNuevoId = _ticket.CategoriaId,
                        Comentario = "Cambio de categoría"
                    });

                // NUEVO: Histórico de grupo técnico
                if (antesGrupo != _ticket.GrupoTecnicoId)
                    histBLL.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = currentUserId,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Grupo",
                        ValorAnteriorId = antesGrupo,
                        ValorNuevoId = _ticket.GrupoTecnicoId,
                        Comentario = "Cambio de grupo técnico"
                    });

                // Persistir cambios en la base de datos
                _ticketBLL.ActualizarTicket(_ticket);

                // Recargar el ticket para obtener la nueva prioridad/estado
                _ticket = _ticketBLL.ObtenerTicketPorId(_ticket.TicketId);

                // Refrescar UI con los valores actualizados
                cmbPrioridad.SelectedValue = _ticket.PrioridadId;
                txtEstado.Text = _ticket.Estado?.Nombre ?? "";

                // Volver a cargar historial y comentarios
                LoadHistorial();
                LoadComentarios();

                MessageBox.Show("Los cambios se han guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: {ex.Message}", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            const int estadoCanceladoId = 7;
            int antesEstado = _ticket.EstadoId;

            // 1) Preparo el objeto para cancelar
            _ticket.EstadoId = estadoCanceladoId;
            _ticket.FechaCierre = DateTime.Now;
            _ticket.FechaUltimaModif = DateTime.Now;

            try
            {
                // 2) Persisto el cambio en la base de datos
                _ticketBLL.ActualizarTicket(_ticket);

                // 3) Registro en histórico (si quieres mantener tu lógica manual).
                //    En muchos casos tu BLL ya lo hace, así que podrías omitirlo.
                var historicoBLL = new TicketHistoricoBLL();
                historicoBLL.AgregarHistorico(new TicketHistorico
                {
                    TicketId = _ticket.TicketId,
                    UsuarioCambioId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                    FechaCambio = DateTime.Now,
                    TipoEvento = "Cancelación",
                    ValorAnteriorId = antesEstado,
                    ValorNuevoId = estadoCanceladoId,
                    Comentario = "Ticket cancelado por cliente"
                });

                // 4) Mensaje al usuario y cierro el formulario con OK
                MessageBox.Show(
                    "El ticket ha sido cancelado exitosamente.",
                    "Cancelado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cancelar el ticket: {ex.Message}",
                    "Error al cancelar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void splitContainerMain_Panel1_Paint(object sender, PaintEventArgs e)
        {
            // no-op
        }

        // Stub for the lblFechaDeCreacion.Click event (designer wired this up but you have no click logic)
        private void lblOpenDate_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void VistaDeTicketCliente_Load(object sender, EventArgs e)
        {
            // no-op
        }
    }
}