using BE;
using BE.PN; // Para TipoDatoCampo y DefinicionCampoPersonalizado
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

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
        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            // Fecha y datos de usuario/departamento
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            txtCliente.Text = $"{usuario.Apellido}, {usuario.Nombre}";
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(usuario.Id);
            var depto = _departamentoBLL.ObtenerDepartamentoPorId(cliente.Departamento.Id);
            txtDepartamentoOrigen.Text = depto.Nombre;

            // Configuro flpCampos para apilar verticalmente
            flpCampos.FlowDirection = FlowDirection.TopDown;
            flpCampos.WrapContents = false;
            flpCampos.AutoScroll = true;

            // Cargo categorías
            _categorias = _categoriaBLL.ListarCategorias();
            if (_categorias.Count > 0)
            {
                cmbCategorias.DataSource = _categorias;
                cmbCategorias.DisplayMember = "Nombre";
                cmbCategorias.ValueMember = "CategoriaId";
            }
            else
            {
                cmbCategorias.Items.Clear();
                cmbCategorias.Text = "No hay categorías";
                btnBuscar.Enabled = false;
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reseteo UI
            txtPrioridad.Clear();
            txtAsunto.Clear();
            txtDescripcion.Clear();
            txtAsunto.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            btnGuardar.Visible = false;
            txtEstado.Clear();

            _mapControles.Clear();
            _camposObligatorios.Clear();
            flpCampos.Controls.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(cmbCategorias.SelectedItem is Categoria categoria)) return;

            // Prioridad + habilitación de asunto/descr.
            var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            txtPrioridad.Text = prioridad.Nombre;
            txtAsunto.ReadOnly = false;
            txtDescripcion.ReadOnly = false;
            btnGuardar.Visible = true;
            txtEstado.Text = categoria.AprobadorRequerido ? "En Aprobacion" : "Derivado";

            // Mensaje de aprobación
            if (categoria.AprobadorRequerido)
            {
                MessageBox.Show(
                    $"Esta categoría requiere aprobación de: {categoria.ClienteAprobador.Nombre}\n\n" +
                    $"Desc: {categoria.Descripcion}",
                    "Requiere Aprobación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    $"Categoría: {categoria.Nombre}\n{categoria.Descripcion}",
                    "Sin Aprobación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            // === Generar campos dinámicos en el orden definido ===
            _mapControles.Clear();
            _camposObligatorios.Clear();
            flpCampos.Controls.Clear();

            var asociaciones = _catCampoBLL
                .ListarPorCategoria(categoria.CategoriaId)
                .OrderBy(a => a.OrdenVisualizacion)
                .ToList();

            foreach (var asoc in asociaciones)
            {
                if (asoc.DefinicionCampoPersonalizadoId <= 0) continue;
                var def = _defCampoBLL.ObtenerPorId(asoc.DefinicionCampoPersonalizadoId);
                Debug.WriteLine($"Id={def.Id}, Etiqueta={def.Etiqueta}, TipoDato={(int)def.TipoDato}");

                // Cada fila es un FlowLayoutPanel horizontal
                var fila = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    WrapContents = false,
                    Margin = new Padding(0, 5, 0, 5)
                };

                // Label
                var lbl = new Label
                {
                    Text = def.Etiqueta + (asoc.EsObligatorio ? "*" : ""),
                    AutoSize = true,
                    Margin = new Padding(3, 6, 3, 0)
                };
                fila.Controls.Add(lbl);

                // Control según el enum que ahora va de 1 a 4
                Control ctrl;
                switch (def.TipoDato)
                {
                    case TipoDatoCampo.Texto:  // 1
                        ctrl = new TextBox { Width = 200 };
                        break;
                    case TipoDatoCampo.Numero: // 2
                        ctrl = new NumericUpDown
                        {
                            Width = 100,
                            DecimalPlaces = 0,
                            Maximum = 100000
                        };
                        break;
                    case TipoDatoCampo.Fecha:  // 3
                        ctrl = new DateTimePicker
                        {
                            Width = 140,
                            Format = DateTimePickerFormat.Short
                        };
                        break;
                    case TipoDatoCampo.Lista:  // 4
                        var cb = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Width = 200
                        };
                        if (!string.IsNullOrEmpty(def.OpcionesJson))
                        {
                            var items = def.OpcionesJson
                                           .Trim('[', ']')
                                           .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(x => x.Trim('"'));
                            cb.Items.AddRange(items.ToArray());
                        }
                        ctrl = cb;
                        break;
                    default:
                        ctrl = new TextBox { Width = 200 };
                        break;
                }

                fila.Controls.Add(ctrl);
                flpCampos.Controls.Add(fila);

                // Guardamos ambos:
                _mapControles[def.Id] = ctrl;
                _camposObligatorios[def.Id] = asoc.EsObligatorio;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación mínima asunto/descr.
            if (string.IsNullOrWhiteSpace(txtAsunto.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Debe completar Asunto y Descripción.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            // --- Validar campos personalizados obligatorios ---
            foreach (var kvp in _mapControles)
            {
                var defId = kvp.Key;
                var control = kvp.Value;
                var esObligatorio = _camposObligatorios.TryGetValue(defId, out bool req) && req;
                if (!esObligatorio) continue;

                bool vacio = false;
                switch (control)
                {
                    case TextBox tb:
                        vacio = string.IsNullOrWhiteSpace(tb.Text);
                        break;
                    case ComboBox cb:
                        vacio = cb.SelectedIndex < 0;
                        break;
                    case NumericUpDown nud:
                        vacio = nud.Value == 0;
                        break;
                    case DateTimePicker dtp:
                        // aquí podrías decidir un umbral de “valor válido”
                        vacio = false;
                        break;
                }

                if (vacio)
                {
                    // recupero la etiqueta para el mensaje
                    var def = _defCampoBLL.ObtenerPorId(defId);
                    MessageBox.Show(
                        $"El campo «{def.Etiqueta}» es obligatorio y debe completarse.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                    return;
                }
            }

            // Si pasamos validaciones, construyo el Ticket
            var categoria = (Categoria)cmbCategorias.SelectedItem;
            var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(usuario.Id);

            var ticket = new Ticket
            {
                Asunto = txtAsunto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CategoriaId = categoria.CategoriaId,
                Categoria = categoria,
                ClienteCreador = cliente,
                ClienteCreadorId = cliente.ClienteId,
                FechaCreacion = DateTime.Now,
                FechaUltimaModif = DateTime.Now,
                EstadoId = categoria.AprobadorRequerido ? 6 : 2,
                PrioridadId = prioridad.Id,
                Prioridad = prioridad,
                UsuarioAprobadorId = categoria.AprobadorRequerido
                                              ? categoria.ClienteAprobador.ClienteId
                                              : (int?)null,
                GrupoTecnicoId = categoria.GrupoTecnico.GrupoId,
                ValoresCamposPersonalizados = new List<ValorCampoTicket>()
            };

            // Recojo valores dinámicos
            foreach (var kvp in _mapControles)
            {
                var defId = kvp.Key;
                var ctrl = kvp.Value;
                var val = new ValorCampoTicket { DefinicionCampoPersonalizadoId = defId };

                switch (ctrl)
                {
                    case TextBox tb:
                        val.ValorTexto = tb.Text;
                        break;
                    case NumericUpDown nud:
                        val.ValorNumero = nud.Value;
                        break;
                    case DateTimePicker dtp:
                        val.ValorFecha = dtp.Value;
                        break;
                    case ComboBox cbx:
                        val.ValorTexto = cbx.SelectedItem?.ToString();
                        break;
                }

                ticket.ValoresCamposPersonalizados.Add(val);
            }

            // Guardo
            try
            {
                _ticketBLL.CrearTicket(ticket);
                MessageBox.Show(
                    $"Ticket #{ticket.TicketId} creado con éxito.",
                    "Confirmación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                _eventManagerService.Notify("TicketCreated", ticket);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al crear el ticket: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
