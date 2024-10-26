using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmLogin : Form
    {
        UsuarioBLL _usuarioBLL;
        public frmLogin()
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool ValidarMail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("El campo de correo electrónico no puede estar vacío.");
                return false;
            }

            if (!ValidarMail(txtMail.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConstraseña.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.");
                return false;
            }

            return true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var res = _usuarioBLL.Login(this.txtMail.Text, this.txtConstraseña.Text);

                    frmPpal frm = new frmPpal();
                    frm.ValidarForm();
                    frm.Show(); // Abrimos el formulario principal
                    this.Hide(); // Ocultamos el formulario actual
            

                    
                }
                catch (LoginException error)
                {
                    switch (error.Result)
                    {
                        case LoginResult.InvalidUsername:
                            MessageBox.Show("Usuario incorrecto");
                            return;
                            break;
                        case LoginResult.InvalidPassword:
                            MessageBox.Show("Password Incorrecto");
                            return;
                            break;

                        default:
                            MessageBox.Show("Error desconocido");
                            return;
                            break;
                    }
                }



                MessageBox.Show("Login exitoso");
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
