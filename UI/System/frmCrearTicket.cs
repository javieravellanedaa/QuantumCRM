// frmCrearTicket.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BE;
using BE.PN;                  // Para TipoDatoCampo y DefinicionCampoPersonalizado
using BLL;
using SERVICIOS;

namespace UI
{
    public partial class frmCrearTicket : Form
    {
        private readonly CategoriaBLL _categoriaBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TicketBLL _ticketBLL;
        private readonly DepartamentoBLL _departamentoBLL;
        private readonly CategoriaCampoPersonalizadoBLL _catCampoBLL;
        private readonly DefinicionCampoPersonalizadoBLL _defCampoBLL;
        private readonly EventManagerService _eventManagerService;

        private List<Categoria> _categorias;
        private Dictionary<int, Control> _mapControles = new Dictionary<int, Control>();
        private Dictionary<int, bool> _camposObligatorios = new Dictionary<int, bool>();
        private List<ToolTip> _allToolTips = new List<ToolTip>();
        private bool _f1Down = false;

        private SplitContainer splitContainer;

        public frmCrearTicket(EventManagerService eventManagerService)
        {
            InitializeComponent();

            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _clienteBLL = new ClienteBLL();
            _ticketBLL = new TicketBLL();
            _departamentoBLL = new DepartamentoBLL();
            _catCampoBLL = new CategoriaCampoPersonalizadoBLL();
            _defCampoBLL = new DefinicionCampoPersonalizadoBLL();
            _eventManagerService = eventManagerService;
            _eventManagerService.Subscribe("TicketCreated", new NotificadorTicket());

            // Permitir capturar F1
            this.KeyPreview = true;
            this.KeyDown += frmCrearTicket_KeyDown;
            this.KeyUp += frmCrearTicket_KeyUp;
        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            txtCliente.Text = $"{usuario.Apellido}, {usuario.Nombre}";
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(usuario.Id);
            var depto = _departamentoBLL.ObtenerDepartamentoPorId(cliente.Departamento.Id);
            txtDepartamentoOrigen.Text = depto.Nombre;

            // Configuración inicial del panel de campos
            flpCampos.FlowDirection = FlowDirection.LeftToRight;
            flpCampos.WrapContents = true;
            flpCampos.AutoScroll = false;

            ConfigurarAreaCamposDinamicos();

            _categorias = _categoriaBLL.ListarCategoriasVisiblesPorDepartamento(depto.Id);
            if (_categorias.Any())
            {
                cmbCategorias.DataSource = _categorias;
                cmbCategorias.DisplayMember = "Nombre";
                cmbCategorias.ValueMember = "CategoriaId";
            }
            else
            {
                cmbCategorias.Items.Clear();
                cmbCategorias.Text = "No hay categorías disponibles";
                btnBuscar.Enabled = false;
            }
        }

        private void ConfigurarAreaCamposDinamicos()
        {
            var originalLocation = flpCampos.Location;
            var originalSize = flpCampos.Size;

            groupBox1.Controls.Remove(flpCampos);

            // Bajar 10px para separar del borde superior
            var adjustedLoc = new Point(originalLocation.X, originalLocation.Y + 10);

            splitContainer = new SplitContainer
            {
                Location = adjustedLoc,
                Size = originalSize,
                Orientation = Orientation.Horizontal,
                Panel1MinSize = 150,
                Panel2MinSize = 30,
                SplitterDistance = originalSize.Height - 40,
                BorderStyle = BorderStyle.FixedSingle
            };

            var panelCampos = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            flpCampos.FlowDirection = FlowDirection.LeftToRight;
            flpCampos.WrapContents = true;
            flpCampos.AutoScroll = true;
            flpCampos.AutoSize = false;
            flpCampos.Dock = DockStyle.Fill;
            flpCampos.Padding = new Padding(30);  // Espacio interior
            flpCampos.BackColor = Color.White;

            panelCampos.Controls.Add(flpCampos);
            splitContainer.Panel1.Controls.Add(panelCampos);

            var labelInfo = new Label
            {
                Text = "Presione F1 para ver ayuda de los campos",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(55, 71, 79),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic)
            };
            splitContainer.Panel2.Controls.Add(labelInfo);

            groupBox1.Controls.Add(splitContainer);

            AjustarControlesInferiores();
        }

        private void AjustarControlesInferiores()
        {
            int nuevaY = splitContainer.Bottom + 10;
            lblPrioridad.Top = nuevaY;
            txtPrioridad.Top = nuevaY;
            lblEstado.Top = nuevaY;
            txtEstado.Top = nuevaY;
            btnGuardar.Top = nuevaY;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(cmbCategorias.SelectedItem is Categoria categoria)) return;

            var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            txtPrioridad.Text = prioridad.Nombre;
            txtAsunto.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            btnGuardar.Visible = true;
            txtEstado.Text = categoria.AprobadorRequerido ? "En Aprobación" : "Derivado";

            if (categoria.AprobadorRequerido)
            {
                MessageBox.Show(
                    $"Esta categoría requiere aprobación de: {categoria.ClienteAprobador.Nombre}\n\nDesc: {categoria.Descripcion}",
                    "Requiere Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(
                    $"Categoría: {categoria.Nombre}\n{categoria.Descripcion}",
                    "Sin Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Limpiar controles anteriores
            flpCampos.Controls.Clear();
            _mapControles.Clear();
            _camposObligatorios.Clear();
            _allToolTips.Clear();

            var asociaciones = _catCampoBLL
                .ListarPorCategoria(categoria.CategoriaId)
                .OrderBy(a => a.OrdenVisualizacion)
                .ToList();

            foreach (var asoc in asociaciones)
            {
                if (asoc.DefinicionCampoPersonalizadoId <= 0) continue;
                var def = _defCampoBLL.ObtenerPorId(asoc.DefinicionCampoPersonalizadoId);

                // Panel que crece con su contenido
                var campoContainer = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(30, 15, 30, 15)
                };

                var lbl = new Label
                {
                    Text = def.Etiqueta + (asoc.EsObligatorio ? " *" : ""),
                    AutoSize = true,
                    Font = new Font("Segoe UI Semibold", 9F),
                    ForeColor = Color.FromArgb(33, 150, 243),
                    Location = new Point(0, 0)
                };

                Control ctrl;
                int anchoControl;
                switch (def.TipoDato)
                {
                    case TipoDatoCampo.Texto:
                        anchoControl = 150;
                        ctrl = new TextBox { Width = anchoControl, Font = new Font("Segoe UI", 9F) };
                        break;
                    case TipoDatoCampo.Numero:
                        anchoControl = 80;
                        ctrl = new NumericUpDown { Width = anchoControl, DecimalPlaces = 0, Maximum = 100000, Font = new Font("Segoe UI", 9F) };
                        break;
                    case TipoDatoCampo.Fecha:
                        anchoControl = 100;
                        ctrl = new DateTimePicker { Width = anchoControl, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9F) };
                        break;
                    case TipoDatoCampo.Lista:
                        anchoControl = 150;
                        var cb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = anchoControl, Font = new Font("Segoe UI", 9F) };
                        if (!string.IsNullOrEmpty(def.OpcionesJson))
                        {
                            var items = def.OpcionesJson.Trim('[', ']').Split(',').Select(x => x.Trim('\"')).ToArray();
                            cb.Items.AddRange(items);
                        }
                        ctrl = cb;
                        break;
                    default:
                        anchoControl = 150;
                        ctrl = new TextBox { Width = anchoControl, Font = new Font("Segoe UI", 9F) };
                        break;
                }

                // Position control right after the label
                ctrl.Location = new Point(lbl.PreferredWidth + 10, 0);

                campoContainer.Controls.Add(lbl);
                campoContainer.Controls.Add(ctrl);
                flpCampos.Controls.Add(campoContainer);

                _mapControles[def.Id] = ctrl;
                _camposObligatorios[def.Id] = asoc.EsObligatorio;

                if (!string.IsNullOrEmpty(def.TextoAyuda))
                {
                    _allToolTips.Add(CreatePersistentToolTip(lbl, def.TextoAyuda));
                    _allToolTips.Add(CreatePersistentToolTip(ctrl, def.TextoAyuda));
                }
            }
        }

        /// <summary>
        /// Muestra todos los tooltips al mantener F1 presionado
        /// </summary>
        private void frmCrearTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && !_f1Down)
            {
                _f1Down = true;
                foreach (var tip in _allToolTips)
                {
                    try
                    {
                        var field = tip.GetType().GetField("tools", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (field?.GetValue(tip) is Hashtable tools)
                        {
                            foreach (Control ctrl in tools.Keys)
                            {
                                var text = tip.GetToolTip(ctrl);
                                if (!string.IsNullOrEmpty(text) && ctrl.Visible)
                                    tip.Show(text, ctrl, 0, ctrl.Height, int.MaxValue);
                            }
                        }
                    }
                    catch { }
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// Oculta todos los tooltips al soltar F1
        /// </summary>
        private void frmCrearTicket_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && _f1Down)
            {
                _f1Down = false;
                foreach (var tip in _allToolTips)
                {
                    try
                    {
                        var field = tip.GetType().GetField("tools", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (field?.GetValue(tip) is Hashtable tools)
                        {
                            foreach (Control ctrl in tools.Keys)
                                tip.Hide(ctrl);
                        }
                    }
                    catch { }
                }
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica al cambiar de categoría (si se necesita)
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1) Validar asunto y descripción
            if (string.IsNullOrWhiteSpace(txtAsunto.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Debe completar Asunto y Descripción.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            // 2) Validar campos obligatorios
            foreach (var kvp in _mapControles)
            {
                int defId = kvp.Key;
                Control ctrl = kvp.Value;
                bool requerido = _camposObligatorios.TryGetValue(defId, out bool req) && req;
                if (!requerido) continue;

                bool vacio = false;
                if (ctrl is TextBox tb) vacio = string.IsNullOrWhiteSpace(tb.Text);
                else if (ctrl is ComboBox cb) vacio = cb.SelectedIndex < 0;
                else if (ctrl is NumericUpDown nud) vacio = nud.Value == 0m;

                if (vacio)
                {
                    var def = _defCampoBLL.ObtenerPorId(defId);
                    MessageBox.Show(
                        $"El campo «{def.Etiqueta}» es obligatorio y debe completarse.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
            }

            // 3) Recategorizar si categoría 1
            var selectedCategoria = (Categoria)cmbCategorias.SelectedItem;
            var categoriaToSave = selectedCategoria.CategoriaId == 1
                ? _categoriaBLL.ObtenerCategoriaPorId(2)
                : selectedCategoria;

            // 4) Prioridad, usuario y cliente
            var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoriaToSave);
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(usuario.Id);

            // 5) Construir ticket
            var ticket = new Ticket
            {
                Asunto = txtAsunto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CategoriaId = categoriaToSave.CategoriaId,
                Categoria = categoriaToSave,
                ClienteCreador = cliente,
                ClienteCreadorId = cliente.ClienteId,
                FechaCreacion = DateTime.Now,
                FechaUltimaModif = DateTime.Now,
                EstadoId = categoriaToSave.AprobadorRequerido ? 6 : 2,
                PrioridadId = prioridad.Id,
                Prioridad = prioridad,
                UsuarioAprobadorId = categoriaToSave.AprobadorRequerido
                                            ? categoriaToSave.ClienteAprobador.ClienteId
                                            : (int?)null,
                GrupoTecnicoId = categoriaToSave.GrupoTecnico.GrupoId,
                ValoresCamposPersonalizados = new List<ValorCampoTicket>()
            };

            // 6) Recoger valores dinámicos
            foreach (var kvp in _mapControles)
            {
                int defId = kvp.Key;
                Control ctrl = kvp.Value;
                var val = new ValorCampoTicket { DefinicionCampoPersonalizadoId = defId };

                if (ctrl is TextBox tb2) val.ValorTexto = tb2.Text;
                else if (ctrl is NumericUpDown nud2) val.ValorNumero = nud2.Value;
                else if (ctrl is DateTimePicker dtp2) val.ValorFecha = dtp2.Value;
                else if (ctrl is ComboBox cb2) val.ValorTexto = cb2.SelectedItem?.ToString();

                ticket.ValoresCamposPersonalizados.Add(val);
            }

            // 7) Guardar y notificar
            try
            {
                _ticketBLL.CrearTicket(ticket);

                // Mensaje más llamativo con número de ticket en vez de ID
                MessageBox.Show(
                    $"🎉 ¡Ticket #{ticket.Numero} creado con éxito! 🎉\n\n" +
                    "Guarda este número para futuras búsquedas.",
                    "¡Éxito!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _eventManagerService.Notify("TicketCreated", ticket);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"🚨 Error al crear el ticket:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private ToolTip CreatePersistentToolTip(Control owner, string text)
        {
            var tip = new ToolTip
            {
                AutoPopDelay = int.MaxValue,
                InitialDelay = 0,
                ReshowDelay = 0,
                ShowAlways = true
            };
            tip.SetToolTip(owner, text);
            return tip;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // No-op
        }
    }
}
