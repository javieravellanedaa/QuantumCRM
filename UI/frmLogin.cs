using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);


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

                    //frmPpal frm = new frmPpal();
                    if (SingletonSesion.Instancia.IsLogged() && SingletonSesion.Instancia.Usuario.NombreDeLosRoles != null)
                    {
                        if (SingletonSesion.Instancia.Usuario.NombreDeLosRoles.Contains("Administrador"))
                        {
                            frmPpalAdmin frm = new frmPpalAdmin();
                            frm.Show();
                        }
                        else if (SingletonSesion.Instancia.Usuario.NombreDeLosRoles.Contains("Cliente"))
                        {
                            frmPpalCliente frm = new frmPpalCliente();
                            frm.Show();
                        }
                        else if (SingletonSesion.Instancia.Usuario.NombreDeLosRoles.Contains("Tecnico"))
                        {
                            frmPpalTecnico frm = new frmPpalTecnico();
                            frm.Show();
                        }

                    }
                    else if (SingletonSesion.Instancia.IsLogged() && SingletonSesion.Instancia.Usuario.NombreDeLosRoles == null)
                    {
                        MessageBox.Show("No tiene ningún rol asociado, contáctese con el administrador");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo iniciar sesión");
                        this.Close();
                    }
                    //frm.ValidarForm();
                    // Abrimos el formulario principal
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


                if (SingletonSesion.Instancia.Usuario.NombreDeLosRoles != null)
                        {
                    MessageBox.Show("Login exitoso");

                         }
                
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {
        

        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
    
}
