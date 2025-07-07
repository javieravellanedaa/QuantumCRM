using System;
using System.Linq;
using System.Windows.Forms;
using BLL;        // TicketBLL, ComentarioBLL, etc.
using BE;         // Ticket, Comentario, TicketHistorico, Usuario
using BE.PN;      // Categoria, GrupoTecnico, TipoCategoria, ValorCampoTicket, TipoDatoCampo
using SERVICIOS;  // EventManagerService, SingletonSesion
using System.Collections.Generic;

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
        private readonly CategoriaCampoPersonalizadoBLL _catCampoBLL;
        private readonly DefinicionCampoPersonalizadoBLL _defCampoBLL;
        private readonly ValorCampoTicketBLL _valorCampoBLL;

        private Ticket _ticket;
        private Dictionary<int, Control> _mapControles = new Dictionary<int, Control>();

        public VistaDeTicketCliente(Ticket ticket)
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
            _catCampoBLL = new CategoriaCampoPersonalizadoBLL();
            _defCampoBLL = new DefinicionCampoPersonalizadoBLL();
            _valorCampoBLL = new ValorCampoTicketBLL();

            _ticket = ticket;

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
            LoadCombos();
            PopulateFields();
            LoadCamposPersonalizados();
            LoadHistorial();
            LoadComentarios();

            // Eventos
            btnNuevoComentario.Click += BtnNuevoComentario_Click;
            btnGuardarCambios.Click += BtnGuardarCambios_Click;
            btnCancelarTicket.Click += btnCancelarTicket_Click;
        }

        private void LoadCamposPersonalizados()
        {
            // Configuro el FlowLayoutPanel
            flpCampos.FlowDirection = FlowDirection.TopDown;
            flpCampos.WrapContents = false;
            flpCampos.AutoScroll = true;

            _mapControles.Clear();
            flpCampos.Controls.Clear();

            // Obtengo las asociaciones de campos para esta categoría
            var asociaciones = _catCampoBLL
                .ListarPorCategoria(_ticket.CategoriaId)
                .OrderBy(a => a.OrdenVisualizacion)
                .ToList();

            // Obtengo los valores guardados para este ticket
            var valoresGuardados = _valorCampoBLL.ListarPorTicket(_ticket.TicketId);

            foreach (var asoc in asociaciones)
            {
                if (asoc.DefinicionCampoPersonalizadoId <= 0) continue;

                var def = _defCampoBLL.ObtenerPorId(asoc.DefinicionCampoPersonalizadoId);

                // Busco el valor guardado para este campo
                var valorGuardado = valoresGuardados.FirstOrDefault(v =>
                    v.DefinicionCampoPersonalizadoId == def.Id);

                // Creo una fila horizontal para el campo
                var fila = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    WrapContents = false,
                    Margin = new Padding(0, 5, 0, 5),
                    Width = flpCampos.Width - 25
                };

                // Label
                var lbl = new Label
                {
                    Text = def.Etiqueta + ":",
                    AutoSize = true,
                    Margin = new Padding(3, 6, 10, 0),
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.FromArgb(55, 71, 79)
                };
                fila.Controls.Add(lbl);

                // Control según el tipo de dato
                Control ctrl;
                switch (def.TipoDato)
                {
                    case TipoDatoCampo.Texto:
                        var txt = new TextBox
                        {
                            Width = 300,
                            ReadOnly = true,
                            BackColor = System.Drawing.Color.WhiteSmoke,
                            Text = valorGuardado?.ValorTexto ?? ""
                        };
                        ctrl = txt;
                        break;

                    case TipoDatoCampo.Numero:
                        var num = new NumericUpDown
                        {
                            Width = 100,
                            DecimalPlaces = 0,
                            Maximum = 100000,
                            ReadOnly = true,
                            BackColor = System.Drawing.Color.WhiteSmoke,
                            Value = valorGuardado?.ValorNumero ?? 0
                        };
                        ctrl = num;
                        break;

                    case TipoDatoCampo.Fecha:
                        var dtp = new DateTimePicker
                        {
                            Width = 140,
                            Format = DateTimePickerFormat.Short,
                            Enabled = false
                        };
                        if (valorGuardado?.ValorFecha != null)
                        {
                            dtp.Value = valorGuardado.ValorFecha.Value;
                        }
                        ctrl = dtp;
                        break;

                    case TipoDatoCampo.Lista:
                        var cb = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Width = 300,
                            Enabled = false,
                            BackColor = System.Drawing.Color.WhiteSmoke
                        };

                        // Cargo las opciones
                        if (!string.IsNullOrEmpty(def.OpcionesJson))
                        {
                            var items = def.OpcionesJson
                                .Trim('[', ']')
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Trim('"'));
                            cb.Items.AddRange(items.ToArray());
                        }

                        // Selecciono el valor guardado
                        if (!string.IsNullOrEmpty(valorGuardado?.ValorTexto))
                        {
                            cb.SelectedItem = valorGuardado.ValorTexto;
                        }
                        ctrl = cb;
                        break;

                    default:
                        ctrl = new TextBox
                        {
                            Width = 300,
                            ReadOnly = true,
                            BackColor = System.Drawing.Color.WhiteSmoke
                        };
                        break;
                }

                fila.Controls.Add(ctrl);
                flpCampos.Controls.Add(fila);

                _mapControles[def.Id] = ctrl;
            }

            // Si no hay campos personalizados, oculto el panel
            if (asociaciones.Count == 0)
            {
                panelCamposPersonalizados.Visible = false;
            }
        }

        private void LoadCombos()
        {
            var cats = _categoriaBLL.ListarCategorias();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaId";

            cmbTicketType.DataSource = Enum.GetValues(typeof(TipoCategoria)).Cast<TipoCategoria>().ToList();
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
                var tech = _tecnicoBLL.ObtenerTecnicoPorId(_ticket.TecnicoId.Value);
                txtAssignedTech.Text = $"{tech.Apellido}, {tech.Nombre}";
            }

            cmbPrioridad.SelectedValue = _ticket.PrioridadId;
            txtEstado.Text = _ticket.Estado?.Nombre ?? "";
            txtAsunto.Text = _ticket.Asunto;
            txtDescripcion.Text = _ticket.Descripcion;
        }

        private void LoadHistorial()
        {
            var historicoBLL = new TicketHistoricoBLL();
            var listaHistorialCompleta = historicoBLL.ObtenerHistorialPorTicket(_ticket.TicketId);

            var listaPlano = listaHistorialCompleta
                .Select(h => new
                {
                    Fecha = h.FechaCambio.ToString("g"),
                    Usuario = h.UsuarioCambioId.ToString(),
                    Accion = $"{h.TipoEvento}: {h.ValorAnteriorId ?? 0} → {h.ValorNuevoId ?? 0}",
                    Comentario = h.Comentario
                })
                .OrderBy(x => DateTime.Parse(x.Fecha))
                .ToList();

            dgvHistorial.DataSource = listaPlano;
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

            // Actualizar ticket
            var antesPrio = _ticket.PrioridadId;
            var antesCat = _ticket.CategoriaId;
            var antesGrupo = _ticket.GrupoTecnicoId;
            var antesEstado = _ticket.EstadoId;

            _ticket.CategoriaId = (int)cmbCategoria.SelectedValue;
            _ticket.Categoria = (Categoria)cmbCategoria.SelectedItem;
            _ticket.PrioridadId = (int)cmbPrioridad.SelectedValue;
            _ticket.Asunto = txtAsunto.Text.Trim();
            _ticket.Descripcion = txtDescripcion.Text.Trim();
            if (cmbGrupoTecDestino.SelectedItem is GrupoTecnico gt)
            {
                _ticket.GrupoTecnicoId = gt.GrupoId;
                _ticket.GrupoTecnico = gt;
            }

            var histBLL = new TicketHistoricoBLL();
            var currentUserId = SingletonSesion.Instancia.Sesion.Usuario.Id;

            // Registrar históricos si hubo cambios
            if (antesPrio != _ticket.PrioridadId)
            {
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
            }

            if (antesCat != _ticket.CategoriaId)
            {
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
            }

            _ticketBLL.ActualizarTicket(_ticket);
            MessageBox.Show("Cambios guardados", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            const int estadoCanceladoId = 7;
            var antesEstado = _ticket.EstadoId;

            _ticket.EstadoId = estadoCanceladoId;
            _ticket.Estado = _estadoBLL.ObtenerEstadoTicket(estadoCanceladoId);

            var historicoBLL = new TicketHistoricoBLL();
            historicoBLL.AgregarHistorico(new TicketHistorico
            {
                TicketId = _ticket.TicketId,
                UsuarioCambioId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                FechaCambio = DateTime.Now,
                TipoEvento = "Estado",
                ValorAnteriorId = antesEstado,
                ValorNuevoId = estadoCanceladoId,
                Comentario = "Ticket cancelado"
            });

            MessageBox.Show("Ticket cancelado", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        // Eventos vacíos
        private void txtAssignedTech_TextChanged(object sender, EventArgs e) { }
        private void lblOpenDate_Click(object sender, EventArgs e) { }
        private void splitContainerMain_Panel1_Paint(object sender, PaintEventArgs e) { }
    }
}