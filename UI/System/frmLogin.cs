using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.DigitVerifier;

namespace UI
{
    public partial class frmLogin : Form
    {
        UsuarioBLL _usuarioBLL;
        SesionBLL _sesionBLL;

        public frmLogin()
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();
            _sesionBLL = new SesionBLL();
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
            // 1) Validación de campos
            if (!ValidarCampos()) return;

            try
            {
                // 2) Autenticación
                var usuario = _usuarioBLL.Login(txtMail.Text, txtConstraseña.Text);

                // 3) Verificación de integridad (DVH/DVV)
                var integrity = new DigitVerifierManager().VerifyIntegrity();
                if (!integrity.Result)
                {
                    // Construyo la lista de mensajes
                    var mensajes = integrity.DVHErrors.Select(err => err.Message)
                                      .Concat(integrity.DVVErrors.Select(err => err.Message));
                    var texto = "Se detectaron errores de integridad:\n\n"
                                + string.Join("\n", mensajes)
                                + "\n\n¿Desea recalcular ahora los dígitos verificadores?";

                    var dlg = MessageBox.Show(
                        texto,
                        "Error de Integridad",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (dlg == DialogResult.Yes)
                    {
                        try
                        {
                            // 4) Recalculo todos los DVH/DVV
                            new DigitVerifierManager().RecalcularDV();

                            MessageBox.Show(
                                "DVH y DVV recalculados correctamente.\n" +
                                "La aplicación se cerrará para que inicies una nueva sesión.",
                                "Recalcular Dígitos Verificadores",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"Error al recalcular dígitos verificadores:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }

                        // 5) Cierro la aplicación para forzar un nuevo login limpio
                        Application.Exit();
                        return;
                    }

                    // Si eliges “No”, abortamos el login y quedamos en la pantalla de login
                    return;
                }

                // 6) Si la integridad es correcta, abrimos el form según el rol
                var sesion = SingletonSesion.Instancia.Sesion;
                if (sesion.IsLogged() && sesion.Usuario.UltimoRolId > -1)
                {
                    switch (sesion.Usuario.UltimoRolId)
                    {
                        case 1: new frmPpalAdmin().Show(); break;
                        case 3: new frmPpalTecnico().Show(); break;
                        case 2: new frmPpalCliente().Show(); break;
                        default:
                            MessageBox.Show("No tiene un rol asignado");
                            this.Close();
                            return;
                    }
                }
                else if (sesion.IsLogged() && sesion.Usuario.UltimoRolId == -1)
                {
                    if (sesion.Usuario.Roles.Any(r => r.Nombre == "Administrador"))
                        new frmPpalAdmin().Show();
                    else if (sesion.Usuario.Roles.Any(r => r.Nombre == "Tecnico"))
                        new frmPpalTecnico().Show();
                    else if (sesion.Usuario.Roles.Any(r => r.Nombre == "Cliente"))
                        new frmPpalCliente().Show();
                    else
                    {
                        MessageBox.Show("No tiene ningún rol asociado, contáctese con el administrador");
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar sesión");
                    this.Close();
                    return;
                }

                // 7) Oculto el login
                this.Hide();
            }
            catch (LoginException error)
            {
                switch (error.Result)
                {
                    case LoginResult.InvalidUsername:
                        MessageBox.Show("Usuario incorrecto");
                        break;
                    case LoginResult.InvalidPassword:
                        MessageBox.Show("Password incorrecto");
                        break;
                    case LoginResult.NoRolesAssigned:
                        MessageBox.Show("No tiene roles asignados");
                        break;
                    default:
                        MessageBox.Show("Error desconocido");
                        break;
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
