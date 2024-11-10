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
            // Suscribir al observador de eventos al evento "TicketCreated"
            //SingletonSesion.Instancia.SuscribirEvento("TicketCreated", _notificador);
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

        // Método para crear un nuevo ticket
        private void btnCrearTicket_Click(object sender, EventArgs e)
        {
            // Lógica para crear un ticket
            var nuevoTicket = new Ticket
            {
                // Aquí puedes asignar propiedades del ticket como título, descripción, categoría, etc.
            };

            // Notificar a los observadores sobre el nuevo ticket
            //SingletonSesion.Instancia.NotifyEvent("TicketCreated", nuevoTicket);

            // Mensaje de confirmación (opcional)
            MessageBox.Show("Ticket creado exitosamente.");
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
                                         categoria.NombreUsuarioAprobador + "\n\n" +
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
            }
            else
            {
                Categoria categoria = (Categoria)cmbCategorias.SelectedItem;
                
                BE.Cliente cliente = SingletonSesion.Instancia.Sesion.ObtenerCliente();
                Ticket ticket = new Ticket
                {
                   
                    
                    Asunto = txtAsunto.Text,
                    Descripcion = txtDescripcion.Text,
                    CategoriaId = categoria.CategoriaId,
                    Categoria = categoria,
                    UsuarioCreadorId = SingletonSesion.Instancia.Sesion.Usuario.Id,
                    UsuarioCreador = cliente,
                    FechaCreacion = DateTime.Now,
                    FechaUltimaModif = DateTime.Now,
                    EstadoId = 1, // Método para obtener el ID del estado inicial, por ejemplo, "Abierto"
                    Prioridad = categoriaBLL.Obtener_prioridad(categoria),
                    PrioridadId = categoriaBLL.Obtener_prioridad(categoria).Prioridad_id,
                    TecnicoId = 0, // Asignación inicial si no hay técnico asignado, actualízalo según tus necesidades
                    Comentarios = new List<Comentario>()
                };

             

                    // Llamada a la capa BLL para guardar el ticket
                    TicketBLL ticketBLL = new TicketBLL();
                ticketBLL.CrearTicket(ticket);
                if (categoria.AprobadorRequerido)
                {
                    MessageBox.Show("El ticket ha sido creado y está pendiente de aprobación por el usuario: " + categoria.NombreUsuarioAprobador);
                    _eventManagerService?.Notify("FormularioCerrado", this);
                    this.Close();

                    frmPreviewTicket frmPreviewTicket = new frmPreviewTicket(ticket);
                    frmPreviewTicket.ShowDialog();
                    

                }
                else

                { 
                    MessageBox.Show("Ticket creado con éxito");
                    
               _eventManagerService?.Notify("FormularioCerrado", this);
                this.Close();
                    frmPreviewTicket frmPreviewTicket = new frmPreviewTicket(ticket);
                    frmPreviewTicket.ShowDialog();

                }

            }
        }

    }

    }
