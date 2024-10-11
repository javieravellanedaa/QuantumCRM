namespace UI
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCorreoElectronico = new System.Windows.Forms.Label();
            this.texEmail = new System.Windows.Forms.TextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCorreoElectronico
            // 
            this.lblCorreoElectronico.AutoSize = true;
            this.lblCorreoElectronico.Location = new System.Drawing.Point(40, 60);
            this.lblCorreoElectronico.Name = "lblCorreoElectronico";
            this.lblCorreoElectronico.Size = new System.Drawing.Size(93, 13);
            this.lblCorreoElectronico.TabIndex = 1;
            this.lblCorreoElectronico.Text = "Correo electrónico";
            // 
            // texEmail
            // 
            this.texEmail.Location = new System.Drawing.Point(230, 53);
            this.texEmail.Name = "texEmail";
            this.texEmail.Size = new System.Drawing.Size(123, 20);
            this.texEmail.TabIndex = 2;
            this.texEmail.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Location = new System.Drawing.Point(40, 115);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(61, 13);
            this.lblContrasenia.TabIndex = 3;
            this.lblContrasenia.Text = "Contraseña";
            // 
            // btnAcceder
            // 
            this.btnAcceder.Location = new System.Drawing.Point(43, 176);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(117, 23);
            this.btnAcceder.TabIndex = 5;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = true;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(245, 176);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(117, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(230, 112);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(123, 20);
            this.textPassword.TabIndex = 4;
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(430, 276);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.texEmail);
            this.Controls.Add(this.lblCorreoElectronico);
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblCorreoElectronico;
        private System.Windows.Forms.TextBox texEmail;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox textPassword;
    }
}

