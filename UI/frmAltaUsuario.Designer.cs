using System;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    partial class frmAltaUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContent;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblLegajo;
        private NumericUpDown nudLegajo;
        private Label lblFechaAlta;
        private DateTimePicker dtpFechaAlta;
        private Button btnGuardar;
        private Button btnCancelar;

        private void InitializeComponent()
        {
            this.pnlContent = new Panel();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblApellido = new Label();
            this.txtApellido = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblLegajo = new Label();
            this.nudLegajo = new NumericUpDown();
            this.lblFechaAlta = new Label();
            this.dtpFechaAlta = new DateTimePicker();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudLegajo)).BeginInit();
            this.SuspendLayout();
            // 
            // frmAltaUsuario
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ClientSize = new Size(400, 320);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "frmAltaUsuario";
            this.Text = "Alta de Usuario";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = Color.White;
            this.pnlContent.Padding = new Padding(10);
            this.pnlContent.Controls.Add(this.lblEmail);
            this.pnlContent.Controls.Add(this.txtEmail);
            this.pnlContent.Controls.Add(this.lblNombre);
            this.pnlContent.Controls.Add(this.txtNombre);
            this.pnlContent.Controls.Add(this.lblApellido);
            this.pnlContent.Controls.Add(this.txtApellido);
            this.pnlContent.Controls.Add(this.lblPassword);
            this.pnlContent.Controls.Add(this.txtPassword);
            this.pnlContent.Controls.Add(this.lblLegajo);
            this.pnlContent.Controls.Add(this.nudLegajo);
            this.pnlContent.Controls.Add(this.lblFechaAlta);
            this.pnlContent.Controls.Add(this.dtpFechaAlta);
            this.pnlContent.Controls.Add(this.btnGuardar);
            this.pnlContent.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlContent);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblEmail.Location = new Point(20, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new Point(140, 18);
            this.txtEmail.Size = new Size(220, 27);
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblNombre.Location = new Point(20, 55);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(140, 53);
            this.txtNombre.Size = new Size(220, 27);
            this.txtNombre.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new Font("Segoe UI", 9F);
            this.lblApellido.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblApellido.Location = new Point(20, 90);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new Point(140, 88);
            this.txtApellido.Size = new Size(220, 27);
            this.txtApellido.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 9F);
            this.lblPassword.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblPassword.Location = new Point(20, 125);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(140, 123);
            this.txtPassword.Size = new Size(220, 27);
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Font = new Font("Segoe UI", 9F);
            this.lblLegajo.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblLegajo.Location = new Point(20, 160);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Text = "Legajo:";
            // 
            // nudLegajo
            // 
            this.nudLegajo.Location = new Point(140, 158);
            this.nudLegajo.Size = new Size(100, 27);
            this.nudLegajo.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Font = new Font("Segoe UI", 9F);
            this.lblFechaAlta.ForeColor = Color.FromArgb(55, 71, 79);
            this.lblFechaAlta.Location = new Point(20, 195);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Text = "Fecha Alta:";
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Location = new Point(140, 193);
            this.dtpFechaAlta.Size = new Size(120, 27);
            this.dtpFechaAlta.Format = DateTimePickerFormat.Short;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Color.FromArgb(76, 175, 80);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(140, 230);
            this.btnGuardar.Size = new Size(100, 35);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = Color.FromArgb(244, 67, 54);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(260, 230);
            this.btnCancelar.Size = new Size(100, 35);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            // 
            // Finalize
            // 
            ((System.ComponentModel.ISupportInitialize)(this.nudLegajo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
