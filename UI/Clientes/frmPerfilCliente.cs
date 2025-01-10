using BE;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Clientes
{
    public partial class frmPerfilCliente : Form
    {
        private Cliente _cliente;
        private readonly EventManagerService _eventManagerService;
        public frmPerfilCliente(EventManagerService eventManagerService)
        {
            InitializeComponent();
            if (SingletonSesion.Instancia.Sesion.IsLogged())
            {
                _cliente = (Cliente)SingletonSesion.Instancia.Sesion.Usuario;
                txtApellido.Text = _cliente.Apellido;
                txtNombre.Text = _cliente.Nombre;
                txtCorreo.Text = _cliente.Email;
                txtLegajo.Text = _cliente.Legajo.ToString();
                txtUltimoInicioSesion.Text = _cliente.UltimoInicioSesion.ToString();
                txtIdiomaPreferido.Text = _cliente.Idioma.Nombre;
                txtUsuario.Text = _cliente.NombreUsuario;
                txtFechaAlta.Text = _cliente.FechaAlta.ToString();
                txtDepartamento.Text = _cliente.Departamento.Nombre.ToString();
                txtDireccion.Text = _cliente.Direccion.ToString();
                txtTelefono.Text = _cliente.Telefono.ToString();
               
                _eventManagerService = eventManagerService;

            }
            else
            {
                MessageBox.Show("Sesión no iniciada");
            }
            // Configura el formulario sin bordes y asigna el mismo color de fondo
            this.FormBorderStyle = FormBorderStyle.None;
            //this.BackColor = Color.FromArgb(173, 216, 230); // Un azul claro (LightBlue)
            //this.BackColor = Color.FromArgb(236, 240, 241); // es mas blanco
            this.BackColor = Color.FromArgb(224, 234, 241);


        }

        private void frmPerfilCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _eventManagerService?.Notify("FormularioCerrado", this);
            this.Close();
        }
    }
}
