using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmPreviewTicket : Form
    {
        public frmPreviewTicket(Ticket ticket)
        {
            InitializeComponent();
            MapearTicket(ticket);
        }

        private void MapearTicket(Ticket ticket)
        {
            txtTicket.Text = ticket.TicketId.ToString();  // Asumiendo que Ticket tiene una propiedad TicketId
            txtDepartamentoOrigen.Text = ticket.UsuarioCreador.Departamento?.Nombre; // Asegúrate de que tengas acceso al nombre
            txtUsuarioCreador.Text = ticket.UsuarioCreador?.Nombre; // Usuario Creador
            txtDepartamentoDestino.Text = ticket.Categoria.Departamento?.Nombre; // Departamento de destino
            txtAsunto.Text = ticket.Asunto;
            txtDescripcion.Text = ticket.Descripcion;
            txtFechaDeCreacion.Text = ticket.FechaCreacion.ToString("dd/MM/yyyy");

            // Estado y prioridad, si están en ComboBox, deben seleccionarse
            cmbEstado.SelectedValue = ticket.EstadoId; // Asumiendo que EstadoId es el ID relacionado con los items de ComboBox
            cmbPrioridad.SelectedValue = ticket.PrioridadId; // Selección de la prioridad

            txtCategoria.Text = ticket.Categoria?.Nombre; // Nombre de la categoría si está definido
        }
    }
}
