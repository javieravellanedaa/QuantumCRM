using INTERFACES;
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

namespace UI
{
    public partial class frmPerfil : Form
    {
        private IUsuario _usuario;
        public frmPerfil()
        {
            InitializeComponent();
            if (SingletonSesion.Instancia.IsLogged())
            {
                _usuario = SingletonSesion.Instancia.Usuario;
                txtApellido.Text = _usuario.Apellido;
                txtNombre.Text = _usuario.Nombre;
                txtCorreo.Text = _usuario.Email;
            }
            else
            {
                MessageBox.Show("Sesión no iniciada");
            }


        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {

        }

        private void frmPerfil_Load_1(object sender, EventArgs e)
        {

        }
    }
}
