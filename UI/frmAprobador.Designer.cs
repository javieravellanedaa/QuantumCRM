namespace UI
{
    partial class frmAprobador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.DataGridView dgvAprobaciones;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelTitulo;

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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.dgvAprobaciones = new System.Windows.Forms.DataGridView();
            this.panelFilters.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAprobaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.Controls.Add(this.panelBotones);
            this.panelFilters.Controls.Add(this.panelTitulo);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelFilters.Size = new System.Drawing.Size(1200, 90);
            this.panelFilters.TabIndex = 0;
            // 
            // panelTitulo
            // 
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Controls.Add(this.lblSubtitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitulo.Location = new System.Drawing.Point(20, 15);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(400, 60);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tickets Pendientes";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 35);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(285, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gestione los tickets que requieren aprobación";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnRechazar);
            this.panelBotones.Controls.Add(this.btnAprobar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotones.Location = new System.Drawing.Point(950, 15);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(230, 60);
            this.panelBotones.TabIndex = 1;
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAprobar.FlatAppearance.BorderSize = 0;
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Location = new System.Drawing.Point(10, 15);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(100, 35);
            this.btnAprobar.TabIndex = 1;
            this.btnAprobar.Text = "✓ Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRechazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRechazar.FlatAppearance.BorderSize = 0;
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRechazar.ForeColor = System.Drawing.Color.White;
            this.btnRechazar.Location = new System.Drawing.Point(120, 15);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(100, 35);
            this.btnRechazar.TabIndex = 2;
            this.btnRechazar.Text = "✗ Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // dgvAprobaciones
            // 
            this.dgvAprobaciones.AllowUserToAddRows = false;
            this.dgvAprobaciones.AllowUserToDeleteRows = false;
            this.dgvAprobaciones.AllowUserToResizeRows = false;
            this.dgvAprobaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAprobaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvAprobaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAprobaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAprobaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAprobaciones.ColumnHeadersHeight = 45;
            this.dgvAprobaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAprobaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAprobaciones.EnableHeadersVisualStyles = false;
            this.dgvAprobaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvAprobaciones.Location = new System.Drawing.Point(0, 90);
            this.dgvAprobaciones.Margin = new System.Windows.Forms.Padding(20);
            this.dgvAprobaciones.MultiSelect = false;
            this.dgvAprobaciones.Name = "dgvAprobaciones";
            this.dgvAprobaciones.ReadOnly = true;
            this.dgvAprobaciones.RowHeadersVisible = false;
            this.dgvAprobaciones.RowTemplate.Height = 50;
            this.dgvAprobaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAprobaciones.Size = new System.Drawing.Size(1200, 560);
            this.dgvAprobaciones.TabIndex = 3;
            // 
            // frmAprobadorinven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dgvAprobaciones);
            this.Controls.Add(this.panelFilters);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmAprobador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets para aprobar";
            this.Load += new System.EventHandler(this.frmAprobador_Load);
            this.panelFilters.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAprobaciones)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}