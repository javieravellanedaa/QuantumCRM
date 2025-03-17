namespace UI
{
    partial class frmFamiliaPermisos
    {
        /// <summary>
        /// Variable del diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Nuevos controles de cabecera
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdAgregarPatente;
        private System.Windows.Forms.ComboBox cboPatentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdSeleccionar2;
        private System.Windows.Forms.ComboBox cboFamilias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeConfigurarFamilia;
        private System.Windows.Forms.Button cmdGuardarFamilia;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Button eliminarFamiliaBtn;
        private System.Windows.Forms.ComboBox cboFamilias2;
        private System.Windows.Forms.Button cmdSeleccionar;

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
        /// Método requerido para el Diseñador - no modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPatentes = new System.Windows.Forms.ComboBox();
            this.cmdAgregarPatente = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFamilias = new System.Windows.Forms.ComboBox();
            this.cboFamilias2 = new System.Windows.Forms.ComboBox();
            this.cmdSeleccionar2 = new System.Windows.Forms.Button();
            this.eliminarFamiliaBtn = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeConfigurarFamilia = new System.Windows.Forms.TreeView();
            this.cmdGuardarFamilia = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(2416, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnCerrar);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1546, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestionar familia de permisos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboPatentes);
            this.groupBox1.Controls.Add(this.cmdAgregarPatente);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(16, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 454);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permisos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Todos los permisos:";
            // 
            // cboPatentes
            // 
            this.cboPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatentes.Location = new System.Drawing.Point(10, 50);
            this.cboPatentes.Name = "cboPatentes";
            this.cboPatentes.Size = new System.Drawing.Size(335, 31);
            this.cboPatentes.TabIndex = 1;
            this.cboPatentes.SelectedIndexChanged += new System.EventHandler(this.cboPatentes_SelectedIndexChanged);
            // 
            // cmdAgregarPatente
            // 
            this.cmdAgregarPatente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAgregarPatente.Location = new System.Drawing.Point(10, 90);
            this.cmdAgregarPatente.Name = "cmdAgregarPatente";
            this.cmdAgregarPatente.Size = new System.Drawing.Size(160, 41);
            this.cmdAgregarPatente.TabIndex = 2;
            this.cmdAgregarPatente.Text = "Añadir";
            this.cmdAgregarPatente.Click += new System.EventHandler(this.cmdAgregarPatente_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(185, 90);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 41);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Borrar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TxtDescription);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox4.Location = new System.Drawing.Point(10, 161);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 270);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descripción";
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(14, 24);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.ReadOnly = true;
            this.TxtDescription.Size = new System.Drawing.Size(315, 240);
            this.TxtDescription.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboFamilias);
            this.groupBox2.Controls.Add(this.cboFamilias2);
            this.groupBox2.Controls.Add(this.cmdSeleccionar2);
            this.groupBox2.Controls.Add(this.eliminarFamiliaBtn);
            this.groupBox2.Controls.Add(this.cmdSeleccionar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.Location = new System.Drawing.Point(794, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 266);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Familias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Todas las familias:";
            // 
            // cboFamilias
            // 
            this.cboFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias.Location = new System.Drawing.Point(10, 50);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(335, 31);
            this.cboFamilias.TabIndex = 1;
            this.cboFamilias.SelectedIndexChanged += new System.EventHandler(this.cboFamilias_SelectedIndexChanged);
            // 
            // cboFamilias2
            // 
            this.cboFamilias2.BackColor = System.Drawing.Color.Black;
            this.cboFamilias2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias2.ForeColor = System.Drawing.Color.White;
            this.cboFamilias2.Location = new System.Drawing.Point(10, 90);
            this.cboFamilias2.Name = "cboFamilias2";
            this.cboFamilias2.Size = new System.Drawing.Size(335, 31);
            this.cboFamilias2.TabIndex = 2;
            // 
            // cmdSeleccionar2
            // 
            this.cmdSeleccionar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeleccionar2.Location = new System.Drawing.Point(10, 130);
            this.cmdSeleccionar2.Name = "cmdSeleccionar2";
            this.cmdSeleccionar2.Size = new System.Drawing.Size(160, 46);
            this.cmdSeleccionar2.TabIndex = 3;
            this.cmdSeleccionar2.Text = "Añadir";
            this.cmdSeleccionar2.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // eliminarFamiliaBtn
            // 
            this.eliminarFamiliaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminarFamiliaBtn.Location = new System.Drawing.Point(185, 130);
            this.eliminarFamiliaBtn.Name = "eliminarFamiliaBtn";
            this.eliminarFamiliaBtn.Size = new System.Drawing.Size(160, 46);
            this.eliminarFamiliaBtn.TabIndex = 4;
            this.eliminarFamiliaBtn.Text = "Borrar";
            this.eliminarFamiliaBtn.Click += new System.EventHandler(this.eliminarFamiliaBtn_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeleccionar.Location = new System.Drawing.Point(6, 198);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(335, 44);
            this.cmdSeleccionar.TabIndex = 5;
            this.cmdSeleccionar.Text = "Configurar";
            this.cmdSeleccionar.Visible = false;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtNombreFamilia);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox5.Location = new System.Drawing.Point(794, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 160);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nueva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre:";
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(10, 50);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(315, 27);
            this.txtNombreFamilia.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(10, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(315, 42);
            this.button4.TabIndex = 2;
            this.button4.Text = "Guardar";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeConfigurarFamilia);
            this.groupBox3.Controls.Add(this.cmdGuardarFamilia);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(419, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 454);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurar";
            // 
            // treeConfigurarFamilia
            // 
            this.treeConfigurarFamilia.Location = new System.Drawing.Point(10, 25);
            this.treeConfigurarFamilia.Name = "treeConfigurarFamilia";
            this.treeConfigurarFamilia.Size = new System.Drawing.Size(335, 350);
            this.treeConfigurarFamilia.TabIndex = 0;
            // 
            // cmdGuardarFamilia
            // 
            this.cmdGuardarFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGuardarFamilia.Location = new System.Drawing.Point(10, 385);
            this.cmdGuardarFamilia.Name = "cmdGuardarFamilia";
            this.cmdGuardarFamilia.Size = new System.Drawing.Size(335, 46);
            this.cmdGuardarFamilia.TabIndex = 1;
            this.cmdGuardarFamilia.Text = "Guardar";
            this.cmdGuardarFamilia.Click += new System.EventHandler(this.cmdGuardarFamilia_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox6.Location = new System.Drawing.Point(1174, 70);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(360, 160);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Borrar Familia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(10, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Borrar";
            this.button1.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(6, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(335, 28);
            this.comboBox1.TabIndex = 7;
            // 
            // frmFamiliaPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(116)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1546, 608);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFamiliaPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar familia de permisos";
            this.Load += new System.EventHandler(this.frmFamiliaPatente_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
