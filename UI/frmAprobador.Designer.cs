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
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicketId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;

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
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.dgvAprobaciones = new System.Windows.Forms.DataGridView();
            this.colTicketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAprobaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(800, 60);
            this.panelFilters.TabIndex = 0;
            this.panelFilters.Controls.Add(this.btnAprobar);
            this.panelFilters.Controls.Add(this.btnRechazar);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprobar.Location = new System.Drawing.Point(540, 15);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(100, 30);
            this.btnAprobar.TabIndex = 1;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRechazar.Location = new System.Drawing.Point(650, 15);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(100, 30);
            this.btnRechazar.TabIndex = 2;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // dgvAprobaciones
            // 
            this.dgvAprobaciones.AllowUserToAddRows = false;
            this.dgvAprobaciones.AllowUserToDeleteRows = false;
            this.dgvAprobaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAprobaciones.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAprobaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAprobaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTicketId,
            this.colFechaCreacion,
            this.colAsunto,
            this.colDescripcion,
            this.colCliente});
            this.dgvAprobaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAprobaciones.Location = new System.Drawing.Point(0, 60);
            this.dgvAprobaciones.MultiSelect = false;
            this.dgvAprobaciones.Name = "dgvAprobaciones";
            this.dgvAprobaciones.ReadOnly = true;
            this.dgvAprobaciones.RowTemplate.Height = 24;
            this.dgvAprobaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAprobaciones.Size = new System.Drawing.Size(800, 390);
            this.dgvAprobaciones.TabIndex = 3;
            // 
            // colTicketId
            // 
            this.colTicketId.DataPropertyName = "TicketId";
            this.colTicketId.HeaderText = "Ticket Nro";
            this.colTicketId.Name = "colTicketId";
            this.colTicketId.ReadOnly = true;
            this.colTicketId.Visible = true;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.DataPropertyName = "FechaCreacion";
            this.colFechaCreacion.HeaderText = "Fecha Creación";
            this.colFechaCreacion.Name = "colFechaCreacion";
            this.colFechaCreacion.ReadOnly = true;
            // 
            // colAsunto
            // 
            this.colAsunto.DataPropertyName = "Asunto";
            this.colAsunto.HeaderText = "Asunto";
            this.colAsunto.Name = "colAsunto";
            this.colAsunto.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // frmAprobador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAprobaciones);
            this.Controls.Add(this.panelFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAprobador";
            this.Text = "Mis Aprobaciones";
            this.Load += new System.EventHandler(this.frmAprobador_Load);
            this.panelFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAprobaciones)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
