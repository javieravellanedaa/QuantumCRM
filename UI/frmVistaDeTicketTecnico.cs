using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;        // TicketBLL, ComentarioBLL, etc.
using BE;         // Ticket, Comentario, TicketHistorico, Cliente, Categoria, Prioridad, Tecnico, EstadoTicket, GrupoTecnico, Departamento
using BE.PN;      // TipoCategoria, TipoDatoCampo, ValorCampoTicket, etc.
using SERVICIOS;  // SingletonSesion, etc.
using System.Drawing;

namespace UI
{
    public partial class frmVistaDeTicketTecnico : Form
    {
        private readonly CategoriaGrupoTecnicoVisibleBLL _catGrupoVisBLL = new CategoriaGrupoTecnicoVisibleBLL();
   
        private readonly TicketBLL _ticketBLL;
        private readonly ComentarioBLL _comentarioBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TecnicoBLL _tecnicoBLL;
        private readonly EstadoTicketBLL _estadoBLL;
        private readonly DepartamentoBLL _departamentoBLL;
        private readonly GrupoTecnicoBLL _grupoTecnicoBLL;

        // BLLs para campos personalizados
        private readonly CategoriaCampoPersonalizadoBLL _catCampoBLL;
        private readonly DefinicionCampoPersonalizadoBLL _defCampoBLL;
        private readonly ValorCampoTicketBLL _valorCampoBLL;
        private readonly UsuarioBLL _usuarioBLL;

        private Ticket _ticket;
        private Dictionary<int, Control> _mapControles = new Dictionary<int, Control>();

        public frmVistaDeTicketTecnico(Ticket ticket)
        {
            InitializeComponent();

            // Validar que el ticket no sea null y tenga datos básicos
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));
            if (ticket.TicketId == Guid.Empty)
                throw new ArgumentException("El ticket debe tener un ID válido");

            _ticketBLL = new TicketBLL();
            _comentarioBLL = new ComentarioBLL();
            _clienteBLL = new ClienteBLL();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _tecnicoBLL = new TecnicoBLL();
            _estadoBLL = new EstadoTicketBLL();
            _departamentoBLL = new DepartamentoBLL();
            _grupoTecnicoBLL = new GrupoTecnicoBLL();

            // Inicializar BLLs para campos personalizados
            _catCampoBLL = new CategoriaCampoPersonalizadoBLL();
            _defCampoBLL = new DefinicionCampoPersonalizadoBLL();
            _valorCampoBLL = new ValorCampoTicketBLL();
            _usuarioBLL = new UsuarioBLL();

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

            // Configurar el panel de campos personalizados para que sea más grande
            ConfigurarPanelCamposPersonalizados();

            LoadCamposPersonalizadosParaCategoria(_ticket.CategoriaId); // Cargar campos editables desde el inicio
            LoadHistorial();
            LoadComentarios();

            // Subscripción a eventos
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            btnGuardarCambios.Click += BtnGuardarCambios_Click;
            btnCancelarTicket.Click += btnCancelarTicket_Click;
        }

        // Método para configurar el tamaño del panel de campos personalizados
        private void ConfigurarPanelCamposPersonalizados()
        {
            // Hacer el panel de campos personalizados MUCHO más grande
            if (panelCamposPersonalizados != null)
            {
                // Aumentar significativamente la altura del panel de campos personalizados
                panelCamposPersonalizados.Height = Math.Max(200, panelCamposPersonalizados.Height * 2);

                // Asegurar que el FlowLayoutPanel tenga suficiente espacio
                if (flpCampos != null)
                {
                    flpCampos.MinimumSize = new Size(flpCampos.Width, 150);
                    flpCampos.Height = Math.Max(150, flpCampos.Height * 2);
                }
            }

            // Si hay un SplitContainer o contenedor principal, ajustar las proporciones
            AjustarProporcionesPaneles();
        }

        // Método para ajustar las proporciones de los paneles
        private void AjustarProporcionesPaneles()
        {
            // Buscar el control padre que contiene los paneles principales
            Control contenedorPrincipal = this;

            // Si hay un SplitContainer en el formulario, ajustar sus proporciones
            foreach (Control control in this.Controls)
            {
                if (control is SplitContainer splitContainer)
                {
                    // Ajustar para dar MUCHO más espacio al panel de campos personalizados
                    int alturaTotal = splitContainer.Height;
                    int nuevaDistancia = (int)(alturaTotal * 0.75); // 75% para el panel superior

                    splitContainer.SplitterDistance = nuevaDistancia;
                    splitContainer.Panel1MinSize = 400; // Tamaño mínimo mucho más grande
                    splitContainer.Panel2MinSize = 150; // Tamaño mínimo para el panel inferior
                    break;
                }
            }

            // También buscar en controles anidados
            BuscarYAjustarSplitContainers(this);
        }

        // Método recursivo para buscar y ajustar SplitContainers anidados
        private void BuscarYAjustarSplitContainers(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is SplitContainer split)
                {
                    // Si el SplitContainer contiene el panel de campos personalizados
                    if (ContienePanel(split, "panelCamposPersonalizados") ||
                        ContienePanel(split, "flpCampos"))
                    {
                        int alturaTotal = split.Height;

                        // Ajustar para dar MUCHO más espacio visual
                        if (split.Orientation == Orientation.Horizontal)
                        {
                            // 75% para la parte superior, 25% para la inferior
                            split.SplitterDistance = (int)(alturaTotal * 0.75);
                            split.Panel1MinSize = 400;
                            split.Panel2MinSize = 120;
                        }
                    }
                }
                else if (control.HasChildren)
                {
                    BuscarYAjustarSplitContainers(control);
                }
            }
        }

        // Método auxiliar para verificar si un SplitContainer contiene un panel específico
        private bool ContienePanel(SplitContainer split, string nombrePanel)
        {
            return ContieneControlPorNombre(split.Panel1, nombrePanel) ||
                   ContieneControlPorNombre(split.Panel2, nombrePanel);
        }

        // Método auxiliar para buscar un control por nombre recursivamente
        private bool ContieneControlPorNombre(Control contenedor, string nombreBuscado)
        {
            if (contenedor.Name == nombreBuscado)
                return true;

            foreach (Control control in contenedor.Controls)
            {
                if (control.Name == nombreBuscado || ContieneControlPorNombre(control, nombreBuscado))
                    return true;
            }

            return false;
        }
        private void LoadCamposPersonalizadosParaCategoria(int categoriaId)
        {
            // Limpiar controles existentes
            flpCampos.Controls.Clear();
            _mapControles.Clear();

            // Configuro el FlowLayoutPanel para distribución horizontal como en frmCrearTicket
            flpCampos.FlowDirection = FlowDirection.LeftToRight;
            flpCampos.WrapContents = true;
            flpCampos.AutoScroll = true;
            flpCampos.Padding = new Padding(20);

            // DEBUG: Verificar qué campos hay para esta categoría
            var asociaciones = _catCampoBLL.ListarPorCategoria(categoriaId)
                .OrderBy(a => a.OrdenVisualizacion)
                .ToList();

            // DEBUG: Mostrar información
            System.Diagnostics.Debug.WriteLine($"Categoría ID: {categoriaId}");
            System.Diagnostics.Debug.WriteLine($"Asociaciones encontradas: {asociaciones.Count}");

            // Obtener valores guardados para este ticket
            var valoresGuardados = _valorCampoBLL.ListarPorTicket(_ticket.TicketId)
                .ToDictionary(v => v.DefinicionCampoPersonalizadoId, v => v);

            // DEBUG: Mostrar valores guardados
            System.Diagnostics.Debug.WriteLine($"Valores guardados: {valoresGuardados.Count}");

            // Agregar botón para ver ventana detallada SIEMPRE que haya valores guardados
            var todosLosValores = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);
            if (todosLosValores.Count > 0)
            {
                var btnContainer = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(10, 5, 30, 5)
                };

                //var btnVerDetalle = new Button
                //{
                //    Text = "🔍 Ver todos los campos detallados",
                //    AutoSize = true,
                //    BackColor = Color.FromArgb(13, 110, 253),
                //    ForeColor = Color.White,
                //    FlatStyle = FlatStyle.Flat,
                //    Font = new Font("Microsoft Sans Serif", 8.25F),
                //    Padding = new Padding(12, 6, 12, 6),
                //    Cursor = Cursors.Hand,
                //    Location = new Point(0, 0)
                //};
                //btnVerDetalle.FlatAppearance.BorderSize = 0;
                //btnVerDetalle.Click += BtnVerDetalleCampos_Click;

                //var lblCount = new Label
                //{
                //    Text = $"({todosLosValores.Count} campo{(todosLosValores.Count == 1 ? "" : "s")})",
                //    AutoSize = true,
                //    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic),
                //    ForeColor = Color.FromArgb(108, 117, 125),
                //    Location = new Point(0, btnVerDetalle.Height + 5)
                //};

                //btnContainer.Controls.Add(btnVerDetalle);
                //btnContainer.Controls.Add(lblCount);
                flpCampos.Controls.Add(btnContainer);
            }

            // Si no hay campos de la categoría actual pero sí hay valores históricos, mostrar mensaje
            if (asociaciones.Count == 0 && todosLosValores.Count > 0)
            {
                var msgContainer = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(10, 5, 30, 5)
                };

                var lblAdvertencia = new Label
                {
                    Text = "⚠️ Esta categoría no tiene campos personalizados,\npero el ticket tiene campos de categorías anteriores.",
                    ForeColor = Color.Orange,
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic),
                    Location = new Point(0, 0)
                };

                msgContainer.Controls.Add(lblAdvertencia);
                flpCampos.Controls.Add(msgContainer);
                panelCamposPersonalizados.Visible = true;
                return;
            }

            // Si no hay campos ni valores, ocultar panel
            if (asociaciones.Count == 0 && todosLosValores.Count == 0)
            {
                panelCamposPersonalizados.Visible = false;
                return;
            }

            // Crear controles para cada campo de la categoría (distribución horizontal)
            foreach (var asociacion in asociaciones)
            {
                var definicion = _defCampoBLL.ObtenerPorId(asociacion.DefinicionCampoPersonalizadoId);
                if (definicion == null) continue;

                // DEBUG: Mostrar qué campo se está procesando
                System.Diagnostics.Debug.WriteLine($"Procesando campo: {definicion.Etiqueta}");

                // Panel que crece con su contenido (similar a frmCrearTicket)
                var campoContainer = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(15, 10, 15, 10)
                };

                // Etiqueta del campo
                var lbl = new Label
                {
                    Text = definicion.Etiqueta + (definicion.EsObligatorio ? " *:" : ":"),
                    AutoSize = true,
                    Font = new Font("Segoe UI Semibold", 9F),
                    ForeColor = Color.FromArgb(33, 150, 243),
                    Location = new Point(0, 0)
                };

                // Crear control según tipo de dato
                Control control = CrearControlParaCampoHorizontal(definicion);

                // Posicionar control después de la etiqueta
                control.Location = new Point(0, lbl.PreferredHeight + 5);

                // Cargar valor existente si existe
                if (valoresGuardados.ContainsKey(definicion.Id))
                {
                    CargarValorEnControl(control, definicion, valoresGuardados[definicion.Id]);
                }

                campoContainer.Controls.Add(lbl);
                campoContainer.Controls.Add(control);
                flpCampos.Controls.Add(campoContainer);

                // Guardar referencia del control
                _mapControles[definicion.Id] = control;
            }

            panelCamposPersonalizados.Visible = true;
        }

        // Método para mostrar resumen cuando no hay campos actuales pero sí históricos (eliminado - ya no se usa)
        // La funcionalidad se integró en LoadCamposPersonalizadosParaCategoria

        // Método para crear control según tipo de campo (versión horizontal)
        private Control CrearControlParaCampoHorizontal(DefinicionCampoPersonalizado definicion)
        {
            switch (definicion.TipoDato)
            {
                case TipoDatoCampo.Texto:
                    return new TextBox
                    {
                        Width = 150,
                        Font = new Font("Segoe UI", 9F),
                        Margin = new Padding(0, 0, 0, 0)
                    };

                case TipoDatoCampo.Numero:
                    return new NumericUpDown
                    {
                        Width = 80,
                        DecimalPlaces = 2,
                        Maximum = 100000,
                        Font = new Font("Segoe UI", 9F),
                        Margin = new Padding(0, 0, 0, 0)
                    };

                case TipoDatoCampo.Fecha:
                    return new DateTimePicker
                    {
                        Width = 100,
                        Format = DateTimePickerFormat.Short,
                        Font = new Font("Segoe UI", 9F),
                        Margin = new Padding(0, 0, 0, 0)
                    };

                case TipoDatoCampo.Lista:
                    var combo = new ComboBox
                    {
                        Width = 150,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Font = new Font("Segoe UI", 9F),
                        Margin = new Padding(0, 0, 0, 0)
                    };

                    // Cargar opciones de la lista desde OpcionesJson
                    if (!string.IsNullOrEmpty(definicion.OpcionesJson))
                    {
                        try
                        {
                            // Si OpcionesJson contiene opciones separadas por comas o como JSON array
                            var opciones = definicion.OpcionesJson.Trim('[', ']').Split(',')
                                .Select(o => o.Trim('\"').Trim())
                                .Where(o => !string.IsNullOrEmpty(o))
                                .ToArray();
                            combo.Items.AddRange(opciones);
                        }
                        catch
                        {
                            // Si falla el parsing, usar OpcionesJson directamente
                            combo.Items.Add(definicion.OpcionesJson);
                        }
                    }

                    return combo;

                default:
                    return new TextBox
                    {
                        Width = 150,
                        Font = new Font("Segoe UI", 9F),
                        Margin = new Padding(0, 0, 0, 0)
                    };
            }
        }

        // Método para cargar valor en control
        private void CargarValorEnControl(Control control, DefinicionCampoPersonalizado definicion, ValorCampoTicket valor)
        {
            switch (definicion.TipoDato)
            {
                case TipoDatoCampo.Texto:
                    if (control is TextBox txt)
                        txt.Text = valor.ValorTexto ?? "";
                    break;

                case TipoDatoCampo.Numero:
                    if (control is NumericUpDown num)
                        num.Value = valor.ValorNumero ?? 0;
                    break;

                case TipoDatoCampo.Fecha:
                    if (control is DateTimePicker fecha)
                        fecha.Value = valor.ValorFecha ?? DateTime.Now;
                    break;

                case TipoDatoCampo.Lista:
                    if (control is ComboBox combo && valor.ValorTexto != null)
                    {
                        combo.SelectedItem = valor.ValorTexto;
                    }
                    break;
            }
        }

        // Método para guardar valores de campos personalizados
        private void GuardarCamposPersonalizados()
        {
            try
            {
                var valoresActualizados = new List<ValorCampoTicket>();

                foreach (var kvp in _mapControles)
                {
                    int definicionId = kvp.Key;
                    Control control = kvp.Value;

                    var definicion = _defCampoBLL.ObtenerPorId(definicionId);
                    if (definicion == null) continue;

                    // Obtener valor del control
                    var nuevoValor = new ValorCampoTicket
                    {
                        TicketId = _ticket.TicketId,
                        DefinicionCampoPersonalizadoId = definicionId
                    };

                    bool tieneValor = false;

                    switch (definicion.TipoDato)
                    {
                        case TipoDatoCampo.Texto:
                            if (control is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
                            {
                                nuevoValor.ValorTexto = txt.Text.Trim();
                                tieneValor = true;
                            }
                            break;

                        case TipoDatoCampo.Numero:
                            if (control is NumericUpDown num)
                            {
                                nuevoValor.ValorNumero = num.Value;
                                tieneValor = true;
                            }
                            break;

                        case TipoDatoCampo.Fecha:
                            if (control is DateTimePicker fecha)
                            {
                                nuevoValor.ValorFecha = fecha.Value;
                                tieneValor = true;
                            }
                            break;

                        case TipoDatoCampo.Lista:
                            if (control is ComboBox combo && combo.SelectedItem != null)
                            {
                                nuevoValor.ValorTexto = combo.SelectedItem.ToString();
                                tieneValor = true;
                            }
                            break;
                    }

                    // Agregar a la lista si tiene valor
                    if (tieneValor)
                    {
                        valoresActualizados.Add(nuevoValor);
                    }
                }

                // Usar el método ActualizarValoresPorTicket que maneja la actualización eficientemente
                if (valoresActualizados.Any())
                {
                    _valorCampoBLL.ActualizarValoresPorTicket(_ticket.TicketId, valoresActualizados);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar campos personalizados: {ex.Message}", ex);
            }
        }

        // Método auxiliar para obtener texto resumido de valores
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

        // Evento para abrir ventana detallada de campos personalizados
        private void BtnVerDetalleCampos_Click(object sender, EventArgs e)
        {
            try
            {
                // Usar la ventana original pero con lógica mejorada
                var ventana = new VentanaCamposPersonalizados(_ticket, _valorCampoBLL, _defCampoBLL, _catCampoBLL);
                ventana.ShowDialog(this);

                // Recargar campos después de cerrar la ventana por si hubo cambios
                LoadCamposPersonalizadosParaCategoria(_ticket.CategoriaId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana de campos personalizados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombos()
        {
            // 1) Categorías: sólo las visibles para el grupo técnico del usuario
            var usuarioActual = SingletonSesion.Instancia.Sesion.Usuario;
            var tecnicoActual = _tecnicoBLL.ObtenerTecnicoPorUsuarioId(usuarioActual.Id);
            int grupoId = tecnicoActual?.GruposTecnicos?.FirstOrDefault()?.GrupoId ?? 0;

            List<Categoria> cats;
            if (grupoId > 0)
            {
                // obtengo los IDs de las categorías permitidas para este grupo
                var allowedCatIds = _catGrupoVisBLL.ListarCategoriasVisibles(grupoId);
                // filtro el catálogo completo
                cats = _categoriaBLL.ListarCategorias()
                         .Where(c => allowedCatIds.Contains(c.CategoriaId))
                         .ToList();
            }
            else
            {
                // si no encontré grupo, muestro ninguna (o podrías usar ListarCategorias())
                cats = new List<Categoria>();
            }

            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;

            // 2) Tipo de ticket (lectura)
            cmbTicketType.DataSource = Enum
                .GetValues(typeof(TipoCategoria))
                .Cast<TipoCategoria>()
                .ToList();
            cmbTicketType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTicketType.Enabled = false;

            // 3) Grupo técnico destino (lectura)
            cmbGrupoTecDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupoTecDestino.Enabled = false;

            // 4) Prioridades
            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";

            // 5) Técnicos - Sólo del mismo grupo
            List<Tecnico> tecnicos;
            try
            {
                if (tecnicoActual != null && tecnicoActual.GruposTecnicos.Any())
                {
                    var primerGrupo = tecnicoActual.GruposTecnicos.First().GrupoId;
                    tecnicos = _tecnicoBLL.ListarTecnicosPorGrupo(primerGrupo);
                }
                else
                {
                    tecnicos = new List<Tecnico> { tecnicoActual };
                    MessageBox.Show(
                        "El técnico actual no pertenece a ningún grupo técnico.\nSolo podrá asignarse tickets a sí mismo.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo determinar el grupo del técnico actual: {ex.Message}\nSe mostrarán todos los técnicos.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                tecnicos = _tecnicoBLL.ListarTecnicosActivos();
            }

            cmbTecnico.DataSource = tecnicos;
            cmbTecnico.DisplayMember = "NombreCompleto";
            cmbTecnico.ValueMember = "TecnicoId";
            cmbTecnico.DropDownStyle = ComboBoxStyle.DropDownList;

            // 6) Estados
            var estados = _estadoBLL.ListarEstadosTicket();
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "EstadoId";
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            // 7) Iniciar selección
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = 0;
                CmbCategoria_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }


        // Cambio de categoría actualiza campos personalizados editables
        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria selCat)
            {
                // Actualizar combos existentes
                cmbTicketType.SelectedItem = selCat.tipoCategoria;
                cmbPrioridad.SelectedValue = selCat.Prioridad.Id;
                cmbGrupoTecDestino.DataSource = new[] { selCat.GrupoTecnico };
                cmbGrupoTecDestino.DisplayMember = "Nombre";
                cmbGrupoTecDestino.ValueMember = "GrupoId";

                // Actualizar técnicos para el nuevo grupo
                if (selCat.GrupoTecnico != null && selCat.GrupoTecnico.GrupoId > 0)
                {
                    var techs = _tecnicoBLL.ListarTecnicosPorGrupo(selCat.GrupoTecnico.GrupoId);
                    cmbTecnico.DataSource = techs;
                    cmbTecnico.DisplayMember = "NombreCompleto";
                    cmbTecnico.ValueMember = "TecnicoId";
                }
                else
                {
                    cmbTecnico.DataSource = null;
                }

                // Recargar campos personalizados para mostrar los de la nueva categoría
                LoadCamposPersonalizadosParaCategoria(selCat.CategoriaId);
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

            // Bloquear asunto y descripción para edición
            txtAsunto.Text = _ticket.Asunto;
            txtAsunto.ReadOnly = true;
            txtAsunto.BackColor = Color.WhiteSmoke;

            txtDescripcion.Text = _ticket.Descripcion;
            txtDescripcion.ReadOnly = true;
            txtDescripcion.BackColor = Color.WhiteSmoke;
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

                        case "Técnico":
                            string antesT = (h.ValorAnteriorId.GetValueOrDefault() > 0)
                                ? _tecnicoBLL.ObtenerTecnicoPorId(h.ValorAnteriorId.Value)?.NombreCompleto ?? "—"
                                : "—";
                            string nuevoT = (h.ValorNuevoId.GetValueOrDefault() > 0)
                                ? _tecnicoBLL.ObtenerTecnicoPorId(h.ValorNuevoId.Value)?.NombreCompleto ?? "—"
                                : "—";
                            accion = $"Técnico: {antesT} → {nuevoT}";
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
                            if (!string.IsNullOrEmpty(h.Comentario))
                                accion += $": {h.Comentario}";
                            break;
                    }

                    return new
                    {
                        Fecha = h.FechaCambio.ToString("g"),
                        Usuario = nombreUsr,
                        Accion = accion
                    };
                })
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();

            dgvHistorial.DataSource = plano;
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

        // Incluye guardado de campos personalizados
        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            // 1) Si estamos en modo comentario, procesamos y salimos
            if (panelAgregarComentario.Visible)
            {
                var texto = txtComentarioNuevo.Text.Trim();
                if (!string.IsNullOrEmpty(texto))
                {
                    var usrId = SingletonSesion.Instancia.Sesion.Usuario.Id;
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

            try
            {
                // 2) Guardamos valores anteriores
                int antesTec = _ticket.TecnicoId ?? 0;
                int antesEstado = _ticket.EstadoId;
                int antesPrio = _ticket.PrioridadId;
                int antesCat = _ticket.CategoriaId;
                int antesGrupo = _ticket.GrupoTecnicoId ?? 0;

                // 3) Leemos nuevos valores
                _ticket.TecnicoId = (int)cmbTecnico.SelectedValue;
                _ticket.EstadoId = (int)cmbEstado.SelectedValue;
                _ticket.Estado = _estadoBLL.ObtenerEstadoTicket(_ticket.EstadoId);
                _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
                _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
                _ticket.GrupoTecnicoId = (int)cmbGrupoTecDestino.SelectedValue;

                var usr = SingletonSesion.Instancia.Sesion.Usuario.Id;
                var historico = new TicketHistoricoBLL();

                // 4) Histórico de cambios
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
                if (antesPrio != _ticket.PrioridadId)
                    historico.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = usr,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Prioridad",
                        ValorAnteriorId = antesPrio,
                        ValorNuevoId = _ticket.PrioridadId,
                        Comentario = "Prioridad cambiada"
                    });
                if (antesCat != _ticket.CategoriaId)
                    historico.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = usr,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Categoría",
                        ValorAnteriorId = antesCat,
                        ValorNuevoId = _ticket.CategoriaId,
                        Comentario = "Categoría cambiada"
                    });
                if (antesGrupo != _ticket.GrupoTecnicoId)
                    historico.AgregarHistorico(new TicketHistorico
                    {
                        TicketId = _ticket.TicketId,
                        UsuarioCambioId = usr,
                        FechaCambio = DateTime.Now,
                        TipoEvento = "Grupo",
                        ValorAnteriorId = antesGrupo,
                        ValorNuevoId = _ticket.GrupoTecnicoId,
                        Comentario = "Grupo técnico actualizado según nueva categoría"
                    });

                // 5) Guardar campos personalizados
                GuardarCamposPersonalizados();

                // 6) Guardamos ticket en BD
                _ticketBLL.ActualizarTicket(_ticket);

                // 7) Refrescamos y cerramos
                LoadHistorial();
                LoadComentarios();
                MessageBox.Show("Cambios guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            int antes = _ticket.EstadoId;
            const int idCan = 7;

            try
            {
                _ticket.EstadoId = idCan;
                _ticket.FechaCierre = DateTime.Now;
                _ticket.FechaUltimaModif = DateTime.Now;

                // Actualizar en BD
                _ticketBLL.ActualizarTicket(_ticket);

                // Registrar en historial
                new TicketHistoricoBLL().AgregarHistorico(new TicketHistorico
                {
                    TicketId = _ticket.TicketId,
                    UsuarioCambioId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                    FechaCambio = DateTime.Now,
                    TipoEvento = "Estado",
                    ValorAnteriorId = antes,
                    ValorNuevoId = idCan,
                    Comentario = "Ticket cancelado por técnico"
                });

                MessageBox.Show("Ticket cancelado correctamente", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar el ticket: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // No usados
        private void lblOpenDate_Click(object sender, EventArgs e) { }
        private void splitContainerMain_Panel1_Paint(object sender, PaintEventArgs e) { }
    }
}