using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            // Suscribimos el evento DataError a cada DataGridView para manejar posibles errores de formateo
            dgvMisTickets.DataError += dgv_DataError;
            dgvDeptTickets.DataError += dgv_DataError;

            CargarTicketsUsuario();
            CargarTicketsDept();
        }

        /// <summary>
        /// Maneja el error de formateo en los DataGridView, evitando que aparezca el cuadro de diálogo.
        /// </summary>
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        /// <summary>
        /// Carga los tickets creados por el usuario actual y define manualmente las columnas a mostrar.
        /// </summary>
        private void CargarTicketsUsuario()
        {
            try
            {
                Guid usuarioId = SingletonSesion.Instancia.Sesion.Usuario.Id;
                ticketsUsuario = ticketBLL.ListarTicketsDelUsuario(usuarioId);

                // Deshabilitar la generación automática de columnas
                dgvMisTickets.AutoGenerateColumns = false;
                dgvMisTickets.Columns.Clear();

                // Definir manualmente las columnas que se desean mostrar
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TicketId",
                    HeaderText = "ID Ticket",
                    ReadOnly = true
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Asunto",
                    HeaderText = "Asunto",
                    ReadOnly = true
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripción",
                    ReadOnly = true
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaCreacion",
                    HeaderText = "Creado",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "g" } // Ejemplo: muestra fecha y hora
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaUltimaModif",
                    HeaderText = "Última Modificación",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "g" }
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "EstadoId",
                    HeaderText = "Estado",
                    ReadOnly = true
                });
                dgvMisTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrioridadId",
                    HeaderText = "Prioridad",
                    ReadOnly = true
                });
                // Agrega más columnas si lo deseas (por ejemplo, TecnicoId, CategoriaId, etc.)

                // Asignar la lista como DataSource
                dgvMisTickets.DataSource = ticketsUsuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tickets del usuario: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga los tickets del departamento del usuario y define manualmente las columnas a mostrar.
        /// </summary>
        private void CargarTicketsDept()
        {
            try
            {
                var cliente = (Cliente)SingletonSesion.Instancia.Sesion.Usuario;
                ticketsDepartamento = ticketBLL.ListarTicketsDelDepartamento(cliente.DepartamentoId);

                // Deshabilitar la generación automática de columnas
                dgvDeptTickets.AutoGenerateColumns = false;
                dgvDeptTickets.Columns.Clear();

                // Definir manualmente las columnas que se desean mostrar
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TicketId",
                    HeaderText = "ID Ticket",
                    ReadOnly = true
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Asunto",
                    HeaderText = "Asunto",
                    ReadOnly = true
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Descripcion",
                    HeaderText = "Descripción",
                    ReadOnly = true
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaCreacion",
                    HeaderText = "Creado",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "g" }
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FechaUltimaModif",
                    HeaderText = "Última Modificación",
                    ReadOnly = true,
                    DefaultCellStyle = { Format = "g" }
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "EstadoId",
                    HeaderText = "Estado",
                    ReadOnly = true
                });
                dgvDeptTickets.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrioridadId",
                    HeaderText = "Prioridad",
                    ReadOnly = true
                });
                // Agrega más columnas si lo deseas (por ejemplo, TecnicoId, CategoriaId, etc.)

                // Asignar la lista como DataSource
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
