using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;
using SERVICIOS;

namespace UI
{
    public partial class frmTicketsDelUsuario : Form
    {
        private TicketBLL ticketBLL;
        private List<Ticket> ticketsUsuario;
        private List<Ticket> ticketsDepartamento;

        public frmTicketsDelUsuario()
        {
            InitializeComponent();
            ticketBLL = new TicketBLL();
        }

        private void frmTicketsDelUsuario_Load(object sender, EventArgs e)
        {
            CargarTicketsUsuario();
            CargarTicketsDept();
        }

        // Carga los tickets creados por el usuario actual
        private void CargarTicketsUsuario()
        {
            try
            {
                Guid usuarioId = SingletonSesion.Instancia.Sesion.Usuario.Id;
                // Se asume que TicketBLL.ListarTicketsDelUsuario retorna List<Ticket>
                ticketsUsuario = ticketBLL.ListarTicketsDelUsuario(usuarioId);
                dgvMisTickets.DataSource = ticketsUsuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tickets del usuario: " + ex.Message);
            }
        }

        // Carga los tickets del departamento del usuario
        private void CargarTicketsDept()
        {
            try
            {
               var cliente= (Cliente)SingletonSesion.Instancia.Sesion.Usuario; 
                // Asegúrate de tener esta propiedad
                // Se asume que TicketBLL.ListarTicketsDelDepartamento retorna List<Ticket>
                ticketsDepartamento = ticketBLL.ListarTicketsDelDepartamento(cliente.DepartamentoId);
                dgvDeptTickets.DataSource = ticketsDepartamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tickets del departamento: " + ex.Message);
            }
        }

        // Abre el ticket seleccionado en la pestaña "Mis Tickets"
        private void btnAbrirTicketUsuario_Click(object sender, EventArgs e)
        {
            if (dgvMisTickets.SelectedRows.Count > 0)
            {
                Ticket ticketSeleccionado = (Ticket)dgvMisTickets.SelectedRows[0].DataBoundItem;
                AbrirPreviewTicket(ticketSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para abrir.");
            }
        }

        // Abre el ticket seleccionado en la pestaña "Tickets del Departamento"
        private void btnAbrirTicketDept_Click(object sender, EventArgs e)
        {
            if (dgvDeptTickets.SelectedRows.Count > 0)
            {
                Ticket ticketSeleccionado = (Ticket)dgvDeptTickets.SelectedRows[0].DataBoundItem;
                AbrirPreviewTicket(ticketSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para abrir.");
            }
        }

        // Método para abrir el formulario de preview y permitir modificaciones o agregar comentarios
        private void AbrirPreviewTicket(Ticket ticket)
        {
            using (frmPreviewTicket frmPreview = new frmPreviewTicket(ticket))
            {
                frmPreview.ShowDialog();
                // Actualizar ambas listas tras posibles modificaciones
                CargarTicketsUsuario();
                CargarTicketsDept();
            }
        }

        // Muestra el linaje de comentarios del ticket seleccionado en "Mis Tickets"
        private void btnVerComentariosUsuario_Click(object sender, EventArgs e)
        {
            if (dgvMisTickets.SelectedRows.Count > 0)
            {
                Ticket ticketSeleccionado = (Ticket)dgvMisTickets.SelectedRows[0].DataBoundItem;
                MostrarComentarios(ticketSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para ver sus comentarios.");
            }
        }

        // Muestra el linaje de comentarios del ticket seleccionado en "Tickets del Departamento"
        private void btnVerComentariosDept_Click(object sender, EventArgs e)
        {
            if (dgvDeptTickets.SelectedRows.Count > 0)
            {
                Ticket ticketSeleccionado = (Ticket)dgvDeptTickets.SelectedRows[0].DataBoundItem;
                MostrarComentarios(ticketSeleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para ver sus comentarios.");
            }
        }

        // Muestra en un MessageBox (o en otro formulario) el linaje de comentarios del ticket
        private void MostrarComentarios(Ticket ticket)
        {
            if (ticket.Comentarios == null || ticket.Comentarios.Count == 0)
            {
                MessageBox.Show("No hay comentarios para este ticket.");
                return;
            }

            string comentariosText = "Comentarios:\n";
            foreach (var c in ticket.Comentarios)
            {
                comentariosText += $"{c.Fecha:dd/MM/yyyy HH:mm} - {c.Texto}\n";
            }
            MessageBox.Show(comentariosText, "Linaje de Comentarios");
        }
    }
}
