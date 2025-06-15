using System;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    partial class frmControlDeCambiosGeneral
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContent;
        private Panel panelFilters;
        private Label lblEntidad;
        private ListBox lstEntidades;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnFiltrar;
        private Button btnCerrar;
        private Button btnRevertir;  // Nuevo botón para revertir estado
        private DataGridView dgvCambios;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvCambios = new System.Windows.Forms.DataGridView();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnRevertir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lstEntidades = new System.Windows.Forms.ListBox();
            this.lblEntidad = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.dgvCambios);
            this.pnlContent.Controls.Add(this.panelFilters);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlContent.Size = new System.Drawing.Size(800, 500);
            this.pnlContent.TabIndex = 0;
            // 
            // dgvCambios
            // 
            this.dgvCambios.AllowUserToAddRows = false;
            this.dgvCambios.AllowUserToDeleteRows = false;
            this.dgvCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambios.BackgroundColor = System.Drawing.Color.White;
            this.dgvCambios.ColumnHeadersHeight = 29;
            this.dgvCambios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCambios.Location = new System.Drawing.Point(15, 95);
            this.dgvCambios.Name = "dgvCambios";
            this.dgvCambios.ReadOnly = true;
            this.dgvCambios.RowHeadersWidth = 51;
            this.dgvCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCambios.Size = new System.Drawing.Size(770, 390);
            this.dgvCambios.TabIndex = 1;
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.Transparent;
            this.panelFilters.Controls.Add(this.btnRevertir);
            this.panelFilters.Controls.Add(this.btnCerrar);
            this.panelFilters.Controls.Add(this.btnFiltrar);
            this.panelFilters.Controls.Add(this.dtpHasta);
            this.panelFilters.Controls.Add(this.lblHasta);
            this.panelFilters.Controls.Add(this.dtpDesde);
            this.panelFilters.Controls.Add(this.lblDesde);
            this.panelFilters.Controls.Add(this.lstEntidades);
            this.panelFilters.Controls.Add(this.lblEntidad);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(15, 15);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(770, 80);
            this.panelFilters.TabIndex = 0;
            // 
            // btnRevertir
            // 
            this.btnRevertir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRevertir.FlatAppearance.BorderSize = 0;
            this.btnRevertir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevertir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRevertir.ForeColor = System.Drawing.Color.White;
            this.btnRevertir.Location = new System.Drawing.Point(610, 20);
            this.btnRevertir.Name = "btnRevertir";
            this.btnRevertir.Size = new System.Drawing.Size(157, 42);
            this.btnRevertir.TabIndex = 8;
            this.btnRevertir.Text = "Volver estado anterior";
            this.btnRevertir.UseVisualStyleBackColor = false;
            this.btnRevertir.Click += new System.EventHandler(this.BtnRevertir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(510, 20);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 42);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(410, 20);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 42);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(294, 35);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 27);
            this.dtpHasta.TabIndex = 5;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblHasta.Location = new System.Drawing.Point(290, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(50, 20);
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(174, 35);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 27);
            this.dtpDesde.TabIndex = 3;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDesde.Location = new System.Drawing.Point(170, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(54, 20);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            // 
            // lstEntidades
            // 
            this.lstEntidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEntidades.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstEntidades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lstEntidades.ItemHeight = 20;
            this.lstEntidades.Location = new System.Drawing.Point(14, 40);
            this.lstEntidades.Name = "lstEntidades";
            this.lstEntidades.Size = new System.Drawing.Size(140, 22);
            this.lstEntidades.TabIndex = 1;
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblEntidad.Location = new System.Drawing.Point(10, 12);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(63, 20);
            this.lblEntidad.TabIndex = 0;
            this.lblEntidad.Text = "Entidad:";
            // 
            // frmControlDeCambiosGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmControlDeCambiosGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Control de Cambios";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
