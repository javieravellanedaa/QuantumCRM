namespace UI
{
    partial class frmPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblUltimoInicioSesion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUltimoInicioSesion = new System.Windows.Forms.TextBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.txtIdiomaPreferido = new System.Windows.Forms.TextBox();
            this.lblFechaDeAlta = new System.Windows.Forms.Label();
            this.txtFechaAlta = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCorreo
            // 
            this.txtCorreo.Enabled = false;
            this.txtCorreo.Location = new System.Drawing.Point(368, 166);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(215, 20);
            this.txtCorreo.TabIndex = 13;
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(368, 131);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(215, 20);
            this.txtApellido.TabIndex = 12;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(136, 128);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(104, 20);
            this.txtNombre.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Correo electrónico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(224, 318);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Aceptar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(24, 166);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(136, 163);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(104, 20);
            this.txtUsuario.TabIndex = 11;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(24, 207);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLegajo.Size = new System.Drawing.Size(39, 13);
            this.lblLegajo.TabIndex = 8;
            this.lblLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(136, 207);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(104, 20);
            this.txtLegajo.TabIndex = 11;
            // 
            // lblUltimoInicioSesion
            // 
            this.lblUltimoInicioSesion.AutoSize = true;
            this.lblUltimoInicioSesion.Location = new System.Drawing.Point(254, 207);
            this.lblUltimoInicioSesion.Name = "lblUltimoInicioSesion";
            this.lblUltimoInicioSesion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUltimoInicioSesion.Size = new System.Drawing.Size(111, 13);
            this.lblUltimoInicioSesion.TabIndex = 8;
            this.lblUltimoInicioSesion.Text = "Ultimo inicio de sesion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.avatarAdmin;
            this.pictureBox1.Location = new System.Drawing.Point(186, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // txtUltimoInicioSesion
            // 
            this.txtUltimoInicioSesion.Enabled = false;
            this.txtUltimoInicioSesion.Location = new System.Drawing.Point(368, 204);
            this.txtUltimoInicioSesion.Name = "txtUltimoInicioSesion";
            this.txtUltimoInicioSesion.Size = new System.Drawing.Size(215, 20);
            this.txtUltimoInicioSesion.TabIndex = 15;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(24, 254);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIdioma.Size = new System.Drawing.Size(38, 13);
            this.lblIdioma.TabIndex = 8;
            this.lblIdioma.Text = "Idioma";
            // 
            // txtIdiomaPreferido
            // 
            this.txtIdiomaPreferido.Enabled = false;
            this.txtIdiomaPreferido.Location = new System.Drawing.Point(136, 254);
            this.txtIdiomaPreferido.Name = "txtIdiomaPreferido";
            this.txtIdiomaPreferido.Size = new System.Drawing.Size(104, 20);
            this.txtIdiomaPreferido.TabIndex = 11;
            // 
            // lblFechaDeAlta
            // 
            this.lblFechaDeAlta.AutoSize = true;
            this.lblFechaDeAlta.Location = new System.Drawing.Point(275, 254);
            this.lblFechaDeAlta.Name = "lblFechaDeAlta";
            this.lblFechaDeAlta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFechaDeAlta.Size = new System.Drawing.Size(72, 13);
            this.lblFechaDeAlta.TabIndex = 8;
            this.lblFechaDeAlta.Text = "Fecha de alta";
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.Enabled = false;
            this.txtFechaAlta.Location = new System.Drawing.Point(368, 251);
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.Size = new System.Drawing.Size(215, 20);
            this.txtFechaAlta.TabIndex = 15;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 369);
            this.Controls.Add(this.txtFechaAlta);
            this.Controls.Add(this.txtUltimoInicioSesion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtIdiomaPreferido);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFechaDeAlta);
            this.Controls.Add(this.lblUltimoInicioSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.lblLegajo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrar);
            this.Name = "frmPerfil";
            this.Text = "Datos Personales";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblUltimoInicioSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUltimoInicioSesion;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.TextBox txtIdiomaPreferido;
        private System.Windows.Forms.Label lblFechaDeAlta;
        private System.Windows.Forms.TextBox txtFechaAlta;
        private System.Windows.Forms.ImageList imageList1;
    }
}