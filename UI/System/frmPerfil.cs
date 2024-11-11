using INTERFACES;
using SERVICIOS;
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
    public partial class frmPerfil : Form
    {
       
        private Usuario _usuario;
        private readonly EventManagerService _eventManagerService;
        public frmPerfil(EventManagerService eventManagerService)
        {
            InitializeComponent();
            if (SingletonSesion.Instancia.Sesion.IsLogged())
            {
                _usuario = SingletonSesion.Instancia.Sesion.Usuario;
                txtApellido.Text = _usuario.Apellido;
                txtNombre.Text = _usuario.Nombre;
                txtCorreo.Text = _usuario.Email;
                txtLegajo.Text = _usuario.Legajo.ToString();
                txtUltimoInicioSesion.Text = _usuario.UltimoInicioSesion.ToString();
                txtIdiomaPreferido.Text = _usuario.Idioma.Nombre;
                txtUsuario.Text = _usuario.NombreUsuario;
                txtFechaAlta.Text = _usuario.FechaAlta.ToString();
                _eventManagerService = eventManagerService;

            }
            else
            {
                MessageBox.Show("Sesión no iniciada");
            }
            // Configura el formulario sin bordes y asigna el mismo color de fondo
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(96, 116, 239); // mismo color que frmPpalAdmin


        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _eventManagerService?.Notify("FormularioCerrado", this);
            this.Close();
        }


    }
}
