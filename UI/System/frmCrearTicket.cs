using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCrearTicket : Form
    {
        private readonly CategoriaBLL _categoriaBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly PrioridadBLL _prioridadBLL;
        private readonly TicketBLL _ticketBLL;
        private readonly EventManagerService _eventManagerService;
        private readonly DepartamentoBLL _departamentoBLL;
        private List<Categoria> _categorias;

        public frmCrearTicket(EventManagerService eventManagerService)
        {
            InitializeComponent();
            _categoriaBLL = new CategoriaBLL();
            _prioridadBLL = new PrioridadBLL();
            _clienteBLL = new ClienteBLL();
            _ticketBLL = new TicketBLL();
            _departamentoBLL = new DepartamentoBLL();
            _eventManagerService = eventManagerService;
            _eventManagerService.Subscribe("TicketCreated", new NotificadorTicket());
        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            // Cargar cliente actual
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var usuario = SingletonSesion.Instancia.Sesion.Usuario;
            txtCliente.Text = usuario.Apellido + "," + usuario.Nombre;
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(SingletonSesion.Instancia.Sesion.Usuario.Id);
            var departamento =_departamentoBLL.ObtenerDepartamentoPorId(cliente.Departamento.Id);
            txtDepartamentoOrigen.Text = departamento.Nombre.ToString();

            // Cargar categorías
            _categorias = _categoriaBLL.ListarCategorias();
            if (_categorias?.Count > 0)
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
            // Cada vez que cambia categoría, limpiar campos y ocultar guardar
            txtPrioridad.Clear();
            txtAsunto.Clear();
            txtDescripcion.Clear();
            txtAsunto.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            btnGuardar.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedItem is Categoria categoria)
            {
                // Mostrar prioridad para la categoría seleccionada
                var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
                txtPrioridad.Text = prioridad.Nombre;

                // Mostrar descripción y control de aprobación
                txtAsunto.ReadOnly = false;
                txtDescripcion.ReadOnly = false;
                btnGuardar.Visible = true;

                if (categoria.AprobadorRequerido)
                {
                    var msg = $"Esta categoría requiere aprobación del usuario: {categoria.ClienteAprobador.Nombre}\n\n" +
                              $"Descripción de categoría:\n{categoria.Descripcion}";
                    MessageBox.Show(msg, "Requiere Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEstado.Text = "En Aprobacion";
                }
                else
                {
                    MessageBox.Show($"Categoría: {categoria.Nombre} ({categoria.Descripcion})", "Sin Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAsunto.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe completar Asunto y Descripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var categoria = cmbCategorias.SelectedItem as Categoria;
            var prioridad = _prioridadBLL.ObtenerPrioridadCategoria(categoria);
            var cliente = _clienteBLL.ObtenerClientePorIdUsuario(SingletonSesion.Instancia.Sesion.Usuario.Id);

            var ticket = new Ticket
            {
                Asunto = txtAsunto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                CategoriaId = categoria.CategoriaId,
                Categoria = categoria,                                                                                                                                                                                                                                      
                ClienteCreador =cliente,
                ClienteCreadorId = cliente.ClienteId,
                FechaCreacion = DateTime.Now,
                FechaUltimaModif = DateTime.Now,
                EstadoId = categoria.AprobadorRequerido ? 6 : 2,
                PrioridadId = prioridad.Id,
                UsuarioAprobadorId = categoria.AprobadorRequerido ? categoria.ClienteAprobador.ClienteId : (int?)null,
                Prioridad = prioridad,
                GrupoTecnicoId = categoria.GrupoTecnico.GrupoId
                
            };

            try
            {
                _ticketBLL.CrearTicket(ticket);
                MessageBox.Show($"Ticket # {ticket.TicketId} \ncreado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _eventManagerService.Notify("TicketCreated", ticket);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
