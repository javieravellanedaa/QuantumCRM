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
using BLL;
using SERVICIOS;

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





        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(texEmail.Text))
            {
                MessageBox.Show("El campo de correo electrónico no puede estar vacío.");
                return false;
            }

            if (!ValidarMail(texEmail.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.");
                return false;
            }

            return true;
        }

        private bool ValidarMail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    var res = _usuarioBLL.Login(this.texEmail.Text, this.textPassword.Text);
                    frmPpal frm = (frmPpal)this.MdiParent;
                    frm.ValidarForm();

                    this.Close();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
