using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BE;
using BE.PN;
using SERVICIOS;
using System.Collections.Generic;
using System.Drawing;

namespace UI
{
    public partial class VistaDeTicketAprobador : Form
    {
        private Button btnExportarPDF;
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
        private readonly int _aprobadorId;

        private Ticket _ticket;

        public VistaDeTicketAprobador(Ticket ticket, int aprobadorId)
        {
           

            InitializeComponent();
             ConfigurarBotonExportarPDF();
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
            _aprobadorId = aprobadorId;
        
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

            // Inicializo UI
            ConfigurarControlesComoSoloLectura();
            PopulateFields();
            LoadCamposPersonalizados();
            LoadHistorial();
            LoadComentarios();

            // Eventos - solo para agregar comentarios
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            btnGuardarComentario.Click += BtnGuardarComentario_Click;
            btnCancelarComentario.Click += BtnCancelarComentario_Click;

            // Cambiar título del formulario
            this.Text = "Vista de Ticket - Modo Aprobador (Solo Lectura)";
        }
        private void ConfigurarBotonExportarPDF()
        {
            btnExportarPDF = new Button
            {
                Text = "📄 Exportar a PDF",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(206, 10),
                Size = new Size(187, 30),
                Cursor = Cursors.Hand
            };
            btnExportarPDF.FlatAppearance.BorderSize = 0;
            btnExportarPDF.Click += BtnExportarPDF_Click;

            splitContainerMain.Panel2.Controls.Add(btnExportarPDF);
        }
        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Preparar los datos para el servicio PDF
                var datosExport = PrepararDatosParaPDF();

                // Mostrar diálogo para guardar
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = $"Ticket_{_ticket.Numero}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    Title = "Guardar Ticket como PDF"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var pdfService = new TicketPDFExportService();
                    bool resultado = pdfService.ExportarTicket(datosExport, saveDialog.FileName, true);

                    if (resultado)
                    {
                        MessageBox.Show("PDF exportado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TicketPDFExportService.TicketExportData PrepararDatosParaPDF()
        {
            // 1) Instancia y asignar el ticket
            var datos = new TicketPDFExportService.TicketExportData
            {
                Ticket = _ticket
            };

            // 2) Campos personalizados y sus definiciones
            var valores = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);
            datos.CamposPersonalizados = valores;

            var defs = new Dictionary<int, DefinicionCampoPersonalizado>();
            foreach (var v in valores)
            {
                var def = _defCampoBLL.ObtenerPorId(v.DefinicionCampoPersonalizadoId);
                if (def != null && !defs.ContainsKey(def.Id))
                    defs.Add(def.Id, def);
            }
            datos.DefinicionesCampos = defs;

            // 3) Historial de cambios
            var historicoBLL = new TicketHistoricoBLL();
            var historial = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);
            datos.Historial = historial;

            // 4) Comentarios (incluye respuestas anidadas)
            var comentarios = _comentarioBLL.ListarComentariosPorTicket(_ticket.TicketId);
            datos.Comentarios = comentarios;

            // 5) Usuarios usados en historial y comentarios
            var userDict = new Dictionary<Guid, string>();
            // → del historial
            foreach (var h in historial)
            {
                if (!userDict.ContainsKey(h.UsuarioCambioId))
                {
                    var usr = _usuarioBLL.ObtenerUsuarioPorId(h.UsuarioCambioId);
                    userDict[h.UsuarioCambioId] =
                        usr != null
                            ? $"{usr.Nombre} {usr.Apellido}"
                            : "Desconocido";
                }
            }
            // → de los comentarios
            foreach (var c in comentarios)
            {
                if (!userDict.ContainsKey(c.UsuarioId))
                {
                    var usr = _usuarioBLL.ObtenerUsuarioPorId(c.UsuarioId);
                    userDict[c.UsuarioId] =
                        usr != null
                            ? $"{usr.Nombre} {usr.Apellido}"
                            : "Desconocido";
                }
            }
            datos.UsuariosNombres = userDict;

            // 6) Diccionario de prioridades
            datos.PrioridadesNombres = _prioridadBLL
                .GetAllPrioridades()
                .ToDictionary(p => p.Id, p => p.Nombre);

            // 7) Diccionario de categorías
            datos.CategoriasNombres = _categoriaBLL
                .ListarCategorias()
                .ToDictionary(c => c.CategoriaId, c => c.Nombre);

            // 8) Diccionario de estados (se obtiene dinámicamente de los IDs)
            var estadoIds = new HashSet<int>();
            if (_ticket.EstadoId > 0) estadoIds.Add(_ticket.EstadoId);
            foreach (var h in historial)
            {
                if (h.ValorAnteriorId.HasValue) estadoIds.Add(h.ValorAnteriorId.Value);
                if (h.ValorNuevoId.HasValue) estadoIds.Add(h.ValorNuevoId.Value);
            }

            var estadosDict = new Dictionary<int, string>();
            foreach (var id in estadoIds)
            {
                var est = _estadoBLL.ObtenerEstadoTicket(id);
                estadosDict[id] = est?.Nombre ?? "—";
            }
            datos.EstadosNombres = estadosDict;

            // 9) Prioridad actual (nombre)
            datos.NombrePrioridadActual =
                _prioridadBLL
                    .ObtenerPrioridadPorId(_ticket.PrioridadId)?
                    .Nombre
                ?? "—";

            return datos;
        }
        private void ConfigurarControlesComoSoloLectura()
        {
            // Hacer todos los campos de solo lectura
            txtCliente.ReadOnly = true;
            txtCreadoPor.ReadOnly = true;
            txtUbicacion.ReadOnly = true;
            txtDepartamento.ReadOnly = true;
            txtAssignedTech.ReadOnly = true;
            txtAsunto.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtEstado.ReadOnly = true;

            // Deshabilitar combos
            cmbCategoria.Enabled = false;
            cmbTicketType.Enabled = false;
            cmbGrupoTecDestino.Enabled = false;
            cmbPrioridad.Enabled = false;

            // Cambiar color de fondo para indicar solo lectura
            var colorSoloLectura = Color.FromArgb(245, 245, 245);
            txtAsunto.BackColor = colorSoloLectura;
            txtDescripcion.BackColor = colorSoloLectura;
        }

        private void PopulateFields()
        {
            lblOpenDateValue.Text = _ticket.FechaCreacion.ToString("g");
            lblLastUpdValue.Text = _ticket.FechaUltimaModif.ToString("g");

            txtCliente.Text = $"{_ticket.ClienteCreador.Apellido}, {_ticket.ClienteCreador.Nombre}";
            txtCreadoPor.Text = txtCliente.Text;
            txtUbicacion.Text = _ticket.ClienteCreador.Direccion ?? "";
            txtDepartamento.Text = _ticket.ClienteCreador.Departamento?.Nombre ?? "";

            txtAsunto.Text = _ticket.Asunto ?? "";
            txtDescripcion.Text = _ticket.Descripcion ?? "";

            // Cargar datos en combos pero deshabilitados
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";
            cmbCategoria.SelectedValue = _ticket.CategoriaId;

            cmbTicketType.DataSource = Enum.GetValues(typeof(TipoCategoria)).Cast<TipoCategoria>().ToList();
            cmbTicketType.SelectedItem = _ticket.Categoria.tipoCategoria;

            cmbGrupoTecDestino.DataSource = new[] { _ticket.Categoria.GrupoTecnico };
            cmbGrupoTecDestino.DisplayMember = "Nombre";
            cmbGrupoTecDestino.ValueMember = "GrupoId";

            cmbPrioridad.DataSource = _prioridadBLL.GetAllPrioridades();
            cmbPrioridad.DisplayMember = "Nombre";
            cmbPrioridad.ValueMember = "Id";
            cmbPrioridad.SelectedValue = _ticket.PrioridadId;

            if (_ticket.TecnicoId.HasValue)
            {
                var tech = _tecnicoBLL.ObtenerTecnicoPorId(_ticket.TecnicoId.Value);
                txtAssignedTech.Text = $"{tech.Apellido}, {tech.Nombre}";
            }

            txtEstado.Text = _ticket.Estado?.Nombre ?? "";
        }

        private void LoadCamposPersonalizados()
        {
            // Configuro el FlowLayoutPanel
            flpCampos.FlowDirection = FlowDirection.TopDown;
            flpCampos.WrapContents = false;
            flpCampos.AutoScroll = true;
            flpCampos.Controls.Clear();

            // Obtengo TODOS los valores guardados para este ticket
            var valoresGuardados = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);
            if (valoresGuardados.Count == 0)
            {
                panelCamposPersonalizados.Visible = false;
                return;
            }

            // Agregar botón para abrir ventana detallada
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

            // Muestro los primeros 4 campos en resumen
            var camposAMostrar = new List<(DefinicionCampoPersonalizado def, ValorCampoTicket valor, bool esCategoriaActual, int orden)>();
            foreach (var valor in valoresGuardados)
            {
                var def = _defCampoBLL.ObtenerPorId(valor.DefinicionCampoPersonalizadoId);
                if (def == null) continue;
                bool esActual = asociacionesActuales.ContainsKey(def.Id);
                int orden = esActual ? asociacionesActuales[def.Id] : 9999;
                camposAMostrar.Add((def, valor, esActual, orden));
            }

            camposAMostrar = camposAMostrar
                .OrderBy(x => x.esCategoriaActual ? 0 : 1)
                .ThenBy(x => x.orden)
                .ThenBy(x => x.def.Etiqueta)
                .Take(4)
                .ToList();

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
                    ForeColor = esActual ? Color.FromArgb(55, 71, 79) : Color.Gray,
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
                // Abrir la ventana de campos personalizados en modo solo lectura
                var ventana = new VentanaCamposPersonalizados(_ticket, _valorCampoBLL, _defCampoBLL, _catCampoBLL);
                ventana.Text = "Campos Personalizados - Vista Solo Lectura";
                ventana.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la ventana de campos personalizados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHistorial()
        {
            var historicoBLL = new TicketHistoricoBLL();
            var lista = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);

            var plano = lista
                .Select(h =>
                {
                    var usr = _usuarioBLL.ObtenerUsuarioPorId(h.UsuarioCambioId);
                    string nombreUsr = usr != null
                        ? $"{usr.Nombre} {usr.Apellido}"
                        : "Desconocido";

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

        private void BtnGuardarComentario_Click(object sender, EventArgs e)
        {
            var texto = txtComentarioNuevo.Text.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                MessageBox.Show("El comentario no puede estar vacío.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
              
                var cliente_aprobador =_clienteBLL.ObtenerClientePorId(_aprobadorId); // Validar que el cliente exista
                // Agregar el comentario usando el ID del aprobador
                _comentarioBLL.AgregarComentario(_ticket.TicketId, cliente_aprobador.Id, texto);

                // Registrar en histórico
                var historicoBLL = new TicketHistoricoBLL();
                historicoBLL.AgregarHistorico(new TicketHistorico
                {
                    TicketId = _ticket.TicketId,
                    UsuarioCambioId = cliente_aprobador.Id,
                    FechaCambio = DateTime.Now,
                    TipoEvento = "Comentario",
                    Comentario = $"El aprobador agregó comentario: \"{texto}\""
                });

                // Recargar comentarios e historial
                LoadComentarios();
                LoadHistorial();

                // Limpiar y ocultar panel
                panelAgregarComentario.Visible = false;
                txtComentarioNuevo.Clear();

                MessageBox.Show("Comentario agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar comentario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelarComentario_Click(object sender, EventArgs e)
        {
            panelAgregarComentario.Visible = false;
            txtComentarioNuevo.Clear();
        }

    
    }
}