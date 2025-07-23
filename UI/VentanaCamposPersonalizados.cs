using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BE;
using BE.PN;
using System.Collections.Generic;
using System.Drawing;
using SERVICIOS;

namespace UI
{
    public partial class VentanaCamposPersonalizados : Form
    {
        private readonly Ticket _ticket;
        private readonly ValorCampoTicketBLL _valorCampoBLL;
        private readonly DefinicionCampoPersonalizadoBLL _defCampoBLL;
        private readonly CategoriaCampoPersonalizadoBLL _catCampoBLL;
        private readonly Dictionary<int, Control> _mapControles = new Dictionary<int, Control>();
        private bool _esClienteCreador;

        public VentanaCamposPersonalizados(Ticket ticket,
            ValorCampoTicketBLL valorCampoBLL,
            DefinicionCampoPersonalizadoBLL defCampoBLL,
            CategoriaCampoPersonalizadoBLL catCampoBLL)
        {
            InitializeComponent();

            _ticket = ticket;
            _valorCampoBLL = valorCampoBLL;
            _defCampoBLL = defCampoBLL;
            _catCampoBLL = catCampoBLL;

            ConfigurarFormulario();
            DeterminarTipoUsuario();
            CargarCamposCompletos();
            ConfigurarEventos();
        }

        private void ConfigurarFormulario()
        {
            this.Text = $"Campos Personalizados - Ticket #{_ticket.TicketId}";
            lblSubtitulo.Text = $"Ticket #{_ticket.TicketId} - {_ticket.Asunto}";

            // Configurar tamaño y posición
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;

            // IMPORTANTE: Configurar el TableLayoutPanel para que ocupe todo el ancho disponible
            tblCampos.Dock = DockStyle.Top;
            tblCampos.Width = panelScrollable.ClientSize.Width - 20;
            tblCampos.AutoSize = true;
            tblCampos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void DeterminarTipoUsuario()
        {
            try
            {
                var usuarioActual = SingletonSesion.Instancia.Sesion.Usuario;
                var clienteBLL = new ClienteBLL();
                var clienteActual = clienteBLL.ObtenerClientePorIdUsuario(usuarioActual.Id);

                _esClienteCreador = clienteActual != null && clienteActual.ClienteId == _ticket.ClienteCreadorId;
            }
            catch
            {
                _esClienteCreador = false;
            }
        }

        private void ConfigurarEventos()
        {
            btnCerrar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;

            // Permitir cerrar con ESC
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };

            // Manejar el redimensionamiento
            this.Resize += (s, e) => AjustarAnchoTarjetas();
            panelScrollable.Resize += (s, e) => AjustarAnchoTarjetas();
        }

        private void AjustarAnchoTarjetas()
        {
            if (tblCampos.Controls.Count > 0)
            {
                int anchoDisponible = panelScrollable.ClientSize.Width - 40;
                foreach (Control control in tblCampos.Controls)
                {
                    if (control is Panel tarjeta)
                    {
                        tarjeta.Width = anchoDisponible;
                    }
                }
            }
        }

        private void CargarCamposCompletos()
        {
            var valoresGuardados = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);

            if (valoresGuardados == null || valoresGuardados.Count == 0)
            {
                MostrarMensajeVacio();
                return;
            }

            var camposOrdenados = ObtenerCamposOrdenados(valoresGuardados);
            var tieneHistoricos = camposOrdenados.Any(x => !x.esCategoriaActual);

            ConfigurarAdvertencia(tieneHistoricos);
            ConfigurarTablaCampos(camposOrdenados);
        }

        private void MostrarMensajeVacio()
        {
            panelAdvertencia.Visible = false;
            btnGuardar.Visible = false;

            var lblVacio = new Label
            {
                Text = "No hay campos personalizados registrados para este ticket.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 12F),
                ForeColor = Color.FromArgb(108, 117, 125),
                BackColor = Color.Transparent
            };

            tblCampos.Controls.Add(lblVacio);
            tblCampos.SetColumnSpan(lblVacio, 2);
        }

        private void ConfigurarAdvertencia(bool mostrar)
        {
            panelAdvertencia.Visible = mostrar;
        }

        private List<(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int orden)>
            ObtenerCamposOrdenados(List<ValorCampoTicket> valoresGuardados)
        {
            var asociacionesActuales = _catCampoBLL
                .ListarPorCategoria(_ticket.CategoriaId)
                .ToDictionary(a => a.DefinicionCampoPersonalizadoId, a => a.OrdenVisualizacion);

            var camposOrdenados = new List<(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int orden)>();

            foreach (var valor in valoresGuardados)
            {
                var def = _defCampoBLL.ObtenerPorId(valor.DefinicionCampoPersonalizadoId);
                if (def != null)
                {
                    bool esCategoriaActual = asociacionesActuales.ContainsKey(def.Id);
                    int orden = esCategoriaActual ? asociacionesActuales[def.Id] : 9999;

                    camposOrdenados.Add((def, valor, esCategoriaActual, orden));
                }
            }

            return camposOrdenados
                .OrderBy(x => x.esCategoriaActual ? 0 : 1)
                .ThenBy(x => x.orden)
                .ThenBy(x => x.def.Etiqueta)
                .ToList();
        }

        private void ConfigurarTablaCampos(List<(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int orden)> campos)
        {
            tblCampos.SuspendLayout();
            tblCampos.Controls.Clear();
            _mapControles.Clear();

            // Configurar tabla para mostrar todos los campos
            tblCampos.RowCount = campos.Count;
            tblCampos.ColumnCount = 1;

            // Configurar el ancho de la columna para que ocupe todo el espacio
            tblCampos.ColumnStyles.Clear();
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Configurar estilos de fila
            tblCampos.RowStyles.Clear();
            for (int i = 0; i < campos.Count; i++)
            {
                tblCampos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Calcular el ancho disponible para las tarjetas
            int anchoDisponible = panelScrollable.ClientSize.Width - 40;

            for (int i = 0; i < campos.Count; i++)
            {
                var (def, valor, esCategoriaActual, _) = campos[i];

                // Crear tarjeta profesional para cada campo
                var tarjeta = CrearTarjetaCampo(def, valor, esCategoriaActual, anchoDisponible);

                tblCampos.Controls.Add(tarjeta, 0, i);
            }

            // Mostrar botón guardar solo si es editable
            btnGuardar.Visible = _esClienteCreador;

            tblCampos.ResumeLayout();

            // Forzar el layout
            tblCampos.PerformLayout();
            panelScrollable.PerformLayout();
        }

        private Panel CrearTarjetaCampo(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int anchoDisponible)
        {
            var tarjeta = new Panel
            {
                Width = anchoDisponible,
                Height = 120, // Altura fija para que sea visible
                Margin = new Padding(5, 5, 5, 15),
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Borde y sombra mejorados
            tarjeta.Paint += (s, e) =>
            {
                var rect = tarjeta.ClientRectangle;

                // Borde principal
                using (var pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
                }

                // Borde izquierdo de color más grueso
                var colorBorde = esCategoriaActual ? Color.FromArgb(0, 123, 255) : Color.FromArgb(255, 193, 7);
                using (var brush = new SolidBrush(colorBorde))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 5, rect.Height);
                }
            };

            // Header con título y estado
            var lblTitulo = new Label
            {
                Text = def.Etiqueta,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(25, 15)
            };
            tarjeta.Controls.Add(lblTitulo);

            // Badge de estado
            var lblEstado = new Label
            {
                Text = esCategoriaActual ? "CATEGORÍA ACTUAL" : "CATEGORÍA ANTERIOR",
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = esCategoriaActual ? Color.FromArgb(0, 123, 255) : Color.FromArgb(255, 193, 7),
                Padding = new Padding(8, 3, 8, 3),
                AutoSize = true,
                Location = new Point(lblTitulo.Right + 15, 17)
            };
            tarjeta.Controls.Add(lblEstado);

            // Control del valor
            var control = CrearControlProfesional(def, valor, esCategoriaActual);
            control.Location = new Point(25, 45);
            tarjeta.Controls.Add(control);

            // Ajustar altura de la tarjeta según el contenido
            tarjeta.Height = Math.Max(120, control.Height + 65);

            return tarjeta;
        }

        private Control CrearControlProfesional(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual)
        {
            var esEditable = _esClienteCreador && esCategoriaActual;
            var colorFondo = esEditable ? Color.White : Color.FromArgb(248, 249, 250);
            var colorTexto = Color.FromArgb(33, 37, 41);
            var fuenteControl = new Font("Microsoft Sans Serif", 10F);

            Control control;

            switch (def.TipoDato)
            {
                case TipoDatoCampo.Texto:
                    var esMultilinea = (valor.ValorTexto?.Length ?? 0) > 50;
                    control = new TextBox
                    {
                        Text = valor.ValorTexto ?? "",
                        ReadOnly = !esEditable,
                        BackColor = colorFondo,
                        ForeColor = colorTexto,
                        Font = fuenteControl,
                        BorderStyle = BorderStyle.FixedSingle,
                        Multiline = esMultilinea,
                        Height = esMultilinea ? 60 : 25,
                        Width = 400,
                        ScrollBars = esMultilinea ? ScrollBars.Vertical : ScrollBars.None
                    };
                    break;

                case TipoDatoCampo.Numero:
                    control = new NumericUpDown
                    {
                        Value = valor.ValorNumero ?? 0,
                        ReadOnly = !esEditable,
                        BackColor = colorFondo,
                        ForeColor = colorTexto,
                        Font = fuenteControl,
                        DecimalPlaces = 2,
                        Maximum = 999999999,
                        Minimum = -999999999,
                        Width = 150,
                        Height = 25,
                        TextAlign = HorizontalAlignment.Right
                    };
                    break;

                case TipoDatoCampo.Fecha:
                    control = new DateTimePicker
                    {
                        Format = DateTimePickerFormat.Short,
                        Enabled = esEditable,
                        BackColor = colorFondo,
                        ForeColor = colorTexto,
                        Font = fuenteControl,
                        Width = 200,
                        Height = 25
                    };
                    if (valor.ValorFecha.HasValue)
                    {
                        ((DateTimePicker)control).Value = valor.ValorFecha.Value;
                    }
                    break;

                case TipoDatoCampo.Lista:
                    control = new ComboBox
                    {
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Enabled = esEditable,
                        BackColor = colorFondo,
                        ForeColor = colorTexto,
                        Font = fuenteControl,
                        Width = 250,
                        Height = 25,
                        FlatStyle = FlatStyle.Standard
                    };

                    if (!string.IsNullOrEmpty(def.OpcionesJson))
                    {
                        var items = def.OpcionesJson
                            .Trim('[', ']')
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim('"'));
                        ((ComboBox)control).Items.AddRange(items.ToArray());
                    }

                    if (!string.IsNullOrEmpty(valor.ValorTexto))
                    {
                        ((ComboBox)control).SelectedItem = valor.ValorTexto;
                    }
                    break;

                default:
                    control = new TextBox
                    {
                        Text = valor.ValorTexto ?? "",
                        ReadOnly = !esEditable,
                        BackColor = colorFondo,
                        ForeColor = colorTexto,
                        Font = fuenteControl,
                        BorderStyle = BorderStyle.FixedSingle,
                        Width = 400,
                        Height = 25
                    };
                    break;
            }

            // Agregar control al mapa para poder obtener su valor después
            if (esEditable)
            {
                _mapControles[def.Id] = control;
            }

            return control;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var valoresActualizados = new List<ValorCampoTicket>();

                foreach (var kvp in _mapControles)
                {
                    var defId = kvp.Key;
                    var control = kvp.Value;
                    var def = _defCampoBLL.ObtenerPorId(defId);

                    var nuevoValor = new ValorCampoTicket
                    {
                        TicketId = _ticket.TicketId,
                        DefinicionCampoPersonalizadoId = defId
                    };

                    // Extraer valor según el tipo de control
                    switch (def.TipoDato)
                    {
                        case TipoDatoCampo.Texto:
                            nuevoValor.ValorTexto = ((TextBox)control).Text;
                            break;
                        case TipoDatoCampo.Numero:
                            nuevoValor.ValorNumero = ((NumericUpDown)control).Value;
                            break;
                        case TipoDatoCampo.Fecha:
                            nuevoValor.ValorFecha = ((DateTimePicker)control).Value;
                            break;
                        case TipoDatoCampo.Lista:
                            nuevoValor.ValorTexto = ((ComboBox)control).SelectedItem?.ToString() ?? "";
                            break;
                    }

                    valoresActualizados.Add(nuevoValor);
                }

                // Guardar cambios
                _valorCampoBLL.ActualizarValoresPorTicket(_ticket.TicketId, valoresActualizados);

                MessageBox.Show("Los campos personalizados se han guardado correctamente.",
                    "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los campos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}