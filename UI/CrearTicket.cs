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
    public partial class CrearTicket : Form
    {
        CategoriaBLL categoriaBLL = new CategoriaBLL();
        BLL.UsuarioBLL _bllUsuarios;
        private NotificadorTicket _notificador; // Nueva instancia de observador de tickets

        public CrearTicket()
        {
            InitializeComponent();
            _bllUsuarios = new BLL.UsuarioBLL();

            // Instanciar el observador para tickets
            _notificador = new NotificadorTicket();

            // Suscribir al observador de eventos al evento "TicketCreated"
            //SingletonSesion.Instancia.SuscribirEvento("TicketCreated", _notificador);
        }

        private void CrearTicket_Load(object sender, EventArgs e)
        {
            var categorias = categoriaBLL.ListarCategorias(); // Obtener la lista de categorías

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
    }
}
