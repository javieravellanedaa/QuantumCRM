using BE;
using BE.PN;  // Asegúrate de que la clase Prioridad de BE.PN está aquí
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PN_Prioridad = BE.PN.Prioridad; // Alias para BE.PN.Prioridad

namespace UI
{
    public partial class frmPreviewTicket : Form
    {
        private List<Categoria> categorias; // Para almacenar la lista de categorías
        private Ticket _ticket;             // Ticket original
        private string originalAsunto;      // Para almacenar el asunto original
        private string originalDescripcion; // Para almacenar la descripción original

        public frmPreviewTicket(Ticket ticket)
        {
            InitializeComponent();
            _ticket = ticket;
            CargarCategorias();      // Cargar o pasar las categorías
            MapearTicket(_ticket);   // Mapear la información del ticket en la UI
            BloquearControles();     // Bloquear controles que no deben modificarse
            // Guardar los valores originales para comparación
            originalAsunto = _ticket.Asunto;
            originalDescripcion = _ticket.Descripcion;
        }

        private void CargarCategorias()
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categorias = categoriaBLL.ListarCategorias();

            cmbCategorias.DataSource = categorias;
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "CategoriaId";
        }

        // Mapea la información del ticket en los controles del formulario
        private void MapearTicket(Ticket ticket)
        {
            txtTicket.Text = ticket.TicketId.ToString();
            txtDepartamentoOrigen.Text = ticket.ClienteCreador.Departamento?.Nombre;
            txtUsuarioCreador.Text = ticket.ClienteCreador?.Nombre;
            txtAsunto.Text = ticket.Asunto;
            txtDescripcion.Text = ticket.Descripcion;
            txtFechaDeCreacion.Text = ticket.FechaCreacion.ToString("dd/MM/yyyy");

            if (ticket.Categoria?.Departamento != null)
                txtDepartamentoDestino.Text = ticket.Categoria.Departamento.Nombre;

            cmbEstado.SelectedValue = ticket.EstadoId;
            cmbCategorias.SelectedValue = ticket.CategoriaId;

            // Se obtiene la prioridad en base a la categoría del ticket
            PrioridadBLL prioridadBLL = new PrioridadBLL();
            PN_Prioridad prioridadObtenida = prioridadBLL.ObtenerPrioridadCategoria(ticket.Categoria);
            cmbPrioridad.Text = prioridadObtenida != null ? prioridadObtenida.Nombre : "No asignada";

            // Se obtiene el estado del ticket mediante el BLL de estados y se muestra en el combo
            EstadoTicketBLL estadoTicketBLL = new EstadoTicketBLL();
            EstadoTicket estadoTicket = estadoTicketBLL.ObtenerEstadoTicket(ticket.EstadoId);
            cmbEstado.Text = estadoTicket != null ? estadoTicket.Nombre : "Desconocido";
        }

        // Bloquea todos los controles para que sean de solo lectura, excepto txtAsunto y txtDescripcion
        private void BloquearControles()
        {
            // Bloquear TextBoxes para información que no se puede editar
            txtTicket.ReadOnly = true;
            txtDepartamentoOrigen.ReadOnly = true;
            txtUsuarioCreador.ReadOnly = true;
            txtFechaDeCreacion.ReadOnly = true;
            txtDepartamentoDestino.ReadOnly = true;
            // Los ComboBoxes se bloquean deshabilitándolos
            cmbEstado.Enabled = false;
            cmbCategorias.Enabled = false;
            cmbPrioridad.Enabled = false;
            // txtAsunto y txtDescripcion permanecen habilitados para permitir modificaciones
        }

        // Evento del botón Aceptar para guardar cambios si se detectaron modificaciones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar si hubo modificaciones en el Asunto o en la Descripción

        }

        private void txtUsuarioCreador_TextChanged(object sender, EventArgs e)
        {
            // Método generado por el diseñador, puede quedar vacío.
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            TicketBLL ticketBLL = new TicketBLL();
            bool huboModificaciones = false;

            // Verificar si hubo modificaciones en Asunto o Descripción
            if (originalAsunto != txtAsunto.Text || originalDescripcion != txtDescripcion.Text)
            {
                // Actualizar el ticket con los nuevos valores
                _ticket.Asunto = txtAsunto.Text;
                _ticket.Descripcion = txtDescripcion.Text;

                // Actualizar el ticket en la base de datos
                ticketBLL.ActualizarTicket(_ticket);
                MessageBox.Show("Ticket actualizado con éxito.");
                huboModificaciones = true;
            }
            else
            {
                MessageBox.Show("No se detectaron cambios en el ticket.");
            }

            // Llamar al formulario de comentarios para agregar un comentario al ticket
            using (frmTicketComentario frmComentario = new frmTicketComentario())
            {
                if (frmComentario.ShowDialog(this) == DialogResult.OK)
                {
                    string comentario = frmComentario.Comentario;
                    if (!string.IsNullOrWhiteSpace(comentario))
                    {
                        // Llamar al método de la BLL para agregar el comentario al ticket
                        ticketBLL.AgregarComentario(_ticket, SingletonSesion.Instancia.Sesion.Usuario,  comentario);
                        MessageBox.Show("Comentario agregado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se ingresó ningún comentario.");
                    }
                }
            }

            this.Close();
        }

    }
}
