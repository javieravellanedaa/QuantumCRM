namespace UI
{
    partial class frmBackup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnCrearBackup;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnVerHistorial;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnCerrar;

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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnCrearBackup = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelFilters.Controls.Add(this.lblTitulo);
            this.panelFilters.Controls.Add(this.lblDescripcion);
            this.panelFilters.Controls.Add(this.txtDescripcion);
            this.panelFilters.Controls.Add(this.btnCrearBackup);
            this.panelFilters.Controls.Add(this.btnRestaurar);
            this.panelFilters.Controls.Add(this.btnVerHistorial);
            this.panelFilters.Controls.Add(this.btnSincronizar);
            this.panelFilters.Controls.Add(this.btnCerrar);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(914, 128);
            this.panelFilters.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(23, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(226, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Backup";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(26, 60);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(152, 16);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción del backup:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(279, 37);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(252, 62);
            this.txtDescripcion.TabIndex = 2;
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.BackColor = System.Drawing.Color.White;
            this.btnCrearBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearBackup.Location = new System.Drawing.Point(537, 12);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.Size = new System.Drawing.Size(137, 47);
            this.btnCrearBackup.TabIndex = 3;
            this.btnCrearBackup.Text = "Crear Backup";
            this.btnCrearBackup.UseVisualStyleBackColor = false;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBackup_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.White;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Location = new System.Drawing.Point(686, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(137, 47);
            this.btnRestaurar.TabIndex = 4;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.BackColor = System.Drawing.Color.White;
            this.btnVerHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerHistorial.Location = new System.Drawing.Point(537, 79);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(137, 43);
            this.btnVerHistorial.TabIndex = 5;
            this.btnVerHistorial.Text = "Ver Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = false;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.BackColor = System.Drawing.Color.White;
            this.btnSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSincronizar.Location = new System.Drawing.Point(686, 79);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(137, 43);
            this.btnSincronizar.TabIndex = 6;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = false;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(834, 47);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 29);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvBackups
            // 
            this.dgvBackups.AllowUserToAddRows = false;
            this.dgvBackups.AllowUserToDeleteRows = false;
            this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackups.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBackups.Location = new System.Drawing.Point(0, 128);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.RowHeadersWidth = 51;
            this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackups.Size = new System.Drawing.Size(914, 352);
            this.dgvBackups.TabIndex = 0;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 480);
            this.Controls.Add(this.dgvBackups);
            this.Controls.Add(this.panelFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBackup";
            this.Text = "Gestión de Backup";
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
