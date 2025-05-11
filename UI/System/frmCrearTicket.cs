using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SERVICIOS;

namespace UI
{
    public partial class frmCrearTicket : Form
    {
        CategoriaBLL categoriaBLL = new CategoriaBLL();
        BLL.UsuarioBLL _bllUsuarios;
        private NotificadorTicket _notificador; // Nueva instancia de observador de tickets
        private List<Categoria> categorias;
        private readonly EventManagerService _eventManagerService;
       
        public frmCrearTicket(EventManagerService eventManagerService)
        {
            categorias = categoriaBLL.ListarCategorias();
            InitializeComponent();
            _bllUsuarios = new BLL.UsuarioBLL();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239);
            // Instanciar el observador para tickets
            _notificador = new NotificadorTicket();
            // mismo color que frmPpalAdmin
            _eventManagerService = eventManagerService;

            _eventManagerService.Subscribe("TicketCreated", _notificador);
        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            // Obtener la lista de categorías

            if (categorias != null && categorias.Count > 0)
            {
                // Asignar la lista completa de categorías al ComboBox
                cmbCategorias.DataSource = categorias;

                // Especificar qué propiedad de la clase Categoria se mostrará en el ComboBox
                cmbCategorias.DisplayMember = "Nombre";

                // Opcional: Especificar qué propiedad se utilizará como valor de la categoría
                cmbCategorias.ValueMember = "CategoriaId";
            }
            else
            {
                // Manejar el caso en que no haya categorías disponibles
                cmbCategorias.Items.Clear();
                cmbCategorias.Text = "No hay categorías disponibles";
            }
        }


        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (Categoria categoria in categorias)
            {
                if (categoria == (Categoria)cmbCategorias.SelectedItem)
                {
                    if (categoria.AprobadorRequerido)
                    {
                        // Crear el mensaje con la descripción adicional
                        string mensaje = "Esta categoría requiere aprobación del usuario:\n\n" +
                                         categoria.ClienteAprobador.Nombre + "\n\n" +
                                         "Descripción:\n" + categoria.Descripcion;

                        // Mostrar el MessageBox con los botones Aceptar y Cancelar
                        DialogResult result = MessageBox.Show(
                            mensaje,
                            "Aprobación Requerida",
                            MessageBoxButtons.OKCancel, // Agrega los botones Aceptar (OK) y Cancelar
                            MessageBoxIcon.Information // Puedes cambiar el icono si lo deseas
                        );
                        txtAsunto.ReadOnly = false;
                        txtDescripcion.ReadOnly = false;
                        btnGuardar.Visible = true;
                    }

                    else if (!categoria.AprobadorRequerido)
                    {
                        // Crear el mensaje con una mejor presentación y saltos de línea adicionales
                        string mensaje = "Categoría encontrada.\n" +
                                         "Esta categoría no requiere aprobación.\n\n" +
                                         "Descripción:\n" +
                                         categoria.Descripcion;

                        // Mostrar el MessageBox con el botón Aceptar
                        MessageBox.Show(
                            mensaje,
                            "Aprobación No Requerida",
                            MessageBoxButtons.OK, // Solo el botón Aceptar
                            MessageBoxIcon.Information // Icono informativo
                        );
                        txtAsunto.ReadOnly = false;
                        txtDescripcion.ReadOnly = false;
                        btnGuardar.Visible = true;
                        btnGuardar.Enabled = true;
                    }



                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtAsunto.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            // Se obtiene la categoría seleccionada
            Categoria categoria = (Categoria)cmbCategorias.SelectedItem;

            // Se obtiene la prioridad asociada a la categoría (única llamada para evitar redundancia)
            BE.PN.Prioridad prioridadObtenida = categoriaBLL.Obtener_prioridad(categoria);
            MessageBox.Show(SingletonSesion.Instancia.Sesion.Usuario.GetType().ToString());

            // Se construye el objeto ticket con la información ingresada y los datos de la sesión
            Ticket ticket = new Ticket
            {
                Asunto = txtAsunto.Text,
                Descripcion = txtDescripcion.Text,
                CategoriaId = categoria.CategoriaId,
                Categoria = categoria,
                UsuarioCreadorId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                UsuarioCreador = (Cliente)SingletonSesion.Instancia.Sesion.Usuario,
                FechaCreacion = DateTime.Now,
                FechaUltimaModif = DateTime.Now,
                // Si la categoría requiere aprobación, el ticket se crea con estado 6; de lo contrario, con estado 2
                EstadoId = categoria.AprobadorRequerido ? 6 : 2,
                Prioridad = prioridadObtenida,
                PrioridadId = prioridadObtenida.Id,
                TecnicoId = 0,
                Comentarios = new List<Comentario>()
            };

            // Se guarda el ticket a través de la capa BLL
            TicketBLL ticketBLL = new TicketBLL();
            ticketBLL.CrearTicket(ticket);

            // Se muestra un mensaje y se notifica el cierre según si se requiere aprobación
            if (categoria.AprobadorRequerido)
            {
                MessageBox.Show("El ticket ha sido creado y está pendiente de aprobación por el usuario: " + categoria.ClienteAprobador.Nombre);
            }
            else
            {
                MessageBox.Show("Ticket creado con éxito");
            }

            // Se notifica el cierre del formulario y se cierra el mismo
            _eventManagerService?.Notify("FormularioCerrado", this);
            this.Close();

            // Se muestra la vista previa del ticket
            frmPreviewTicket frmPreviewTicket = new frmPreviewTicket(ticket);
            frmPreviewTicket.ShowDialog();
        }

    }

}
