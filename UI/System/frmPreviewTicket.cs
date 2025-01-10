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

namespace UI
{
    public partial class frmPreviewTicket : Form
    {
        private List<Categoria> categorias; // para almacenar la lista de categorías
        private Ticket _ticket; // Guardamos el ticket para referencia
        public frmPreviewTicket(Ticket ticket)
        {

            InitializeComponent();
            _ticket = ticket;
            CargarCategorias(); // Cargar o pasar las categorías
            MapearTicket(_ticket);

        }
        private void CargarCategorias()
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categorias = categoriaBLL.ListarCategorias();

            cmbCategorias.DataSource = categorias;
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "CategoriaId";
        }

        

        // Este método se llama después de CargarCategorias()
        private void MapearTicket(Ticket ticket)
        {
            txtTicket.Text = ticket.TicketId.ToString();
            txtDepartamentoOrigen.Text = ticket.UsuarioCreador.Departamento?.Nombre;
            txtUsuarioCreador.Text = ticket.UsuarioCreador?.Nombre;
            txtDepartamentoDestino.Text = ticket.Categoria.Departamento?.Nombre;
            txtAsunto.Text = ticket.Asunto;
            txtDescripcion.Text = ticket.Descripcion;
            txtFechaDeCreacion.Text = ticket.FechaCreacion.ToString("dd/MM/yyyy");
            txtDepartamentoDestino.Text = ticket.Categoria.Departamento.Nombre.ToString();
            // Estado y prioridad
            cmbEstado.SelectedValue = ticket.EstadoId;
            cmbPrioridad.SelectedValue = ticket.PrioridadId;

            // Aquí ya se asume que cmbCategorias tiene su DataSource cargado en CargarCategorias()
            cmbCategorias.SelectedValue = ticket.CategoriaId;
        }

        private void txtUsuarioCreador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
