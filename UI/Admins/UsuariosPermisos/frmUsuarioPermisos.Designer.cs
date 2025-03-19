namespace UI.Admins.UsuariosPermisos
{
    partial class frmUsuarioPermisos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbFamilias = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbAsignarFamilias = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.cbUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(434, 187);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(237, 24);
            this.comboBox3.TabIndex = 0;
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(19, 37);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(237, 24);
            this.cbUsuarios.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbFamilias);
            this.groupBox3.Location = new System.Drawing.Point(12, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 108);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Grupo de permisos actuales";
            // 
            // cbFamilias
            // 
            this.cbFamilias.FormattingEnabled = true;
            this.cbFamilias.Location = new System.Drawing.Point(34, 59);
            this.cbFamilias.Name = "cbFamilias";
            this.cbFamilias.Size = new System.Drawing.Size(237, 24);
            this.cbFamilias.TabIndex = 0;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(507, 253);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(100, 44);
            this.btnAsignar.TabIndex = 1;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbAsignarFamilias);
            this.groupBox4.Location = new System.Drawing.Point(407, 73);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 108);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Asigna un nuevo Grupo de Permisos";
            // 
            // cbAsignarFamilias
            // 
            this.cbAsignarFamilias.FormattingEnabled = true;
            this.cbAsignarFamilias.Location = new System.Drawing.Point(26, 49);
            this.cbAsignarFamilias.Name = "cbAsignarFamilias";
            this.cbAsignarFamilias.Size = new System.Drawing.Size(237, 24);
            this.cbAsignarFamilias.TabIndex = 0;
            // 
            // frmUsuarioPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUsuarioPermisos";
            this.Text = "frmUsuarioPermisoscs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbFamilias;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbAsignarFamilias;
    }
}