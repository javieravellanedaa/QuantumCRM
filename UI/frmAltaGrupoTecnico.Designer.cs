namespace UI
{
    partial class frmAltaGrupoTecnico
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblLider;
        private System.Windows.Forms.ComboBox cmbLider;
        private System.Windows.Forms.Label lblTecnicos;
        private System.Windows.Forms.ListBox lstTecnicos;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblLider = new System.Windows.Forms.Label();
            this.cmbLider = new System.Windows.Forms.ComboBox();
            this.lblTecnicos = new System.Windows.Forms.Label();
            this.lstTecnicos = new System.Windows.Forms.ListBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelFilters.Controls.Add(this.lblTitulo);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(686, 43);
            this.panelFilters.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(17, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(267, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Alta de Grupo Técnico";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(26, 61);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(55, 15);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(129, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(215, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(26, 95);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(75, 15);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(129, 93);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(215, 53);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblLider
            // 
            this.lblLider.AutoSize = true;
            this.lblLider.Location = new System.Drawing.Point(26, 160);
            this.lblLider.Name = "lblLider";
            this.lblLider.Size = new System.Drawing.Size(80, 15);
            this.lblLider.TabIndex = 6;
            this.lblLider.Text = "Técnico líder:";
            // 
            // cmbLider
            // 
            this.cmbLider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLider.Location = new System.Drawing.Point(129, 158);
            this.cmbLider.Name = "cmbLider";
            this.cmbLider.Size = new System.Drawing.Size(215, 21);
            this.cmbLider.TabIndex = 5;
            // 
            // lblTecnicos
            // 
            this.lblTecnicos.AutoSize = true;
            this.lblTecnicos.Location = new System.Drawing.Point(26, 195);
            this.lblTecnicos.Name = "lblTecnicos";
            this.lblTecnicos.Size = new System.Drawing.Size(118, 15);
            this.lblTecnicos.TabIndex = 4;
            this.lblTecnicos.Text = "Técnicos miembros:";
            // 
            // lstTecnicos
            // 
            this.lstTecnicos.FormattingEnabled = true;
            this.lstTecnicos.Location = new System.Drawing.Point(129, 195);
            this.lstTecnicos.Name = "lstTecnicos";
            this.lstTecnicos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTecnicos.Size = new System.Drawing.Size(215, 82);
            this.lstTecnicos.TabIndex = 3;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(129, 286);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(60, 19);
            this.chkActivo.TabIndex = 2;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(129, 321);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 26);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(257, 321);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 26);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // frmAltaGrupoTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 364);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.lstTecnicos);
            this.Controls.Add(this.lblTecnicos);
            this.Controls.Add(this.cmbLider);
            this.Controls.Add(this.lblLider);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panelFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAltaGrupoTecnico";
            this.Text = "Alta de Grupo Técnico";
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
