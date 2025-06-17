namespace UI
{
    partial class frmBandejaDeTicketsTecnico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Label lblCategoriaFilter;
        private System.Windows.Forms.ComboBox cmbCategoriaFilter;
        private System.Windows.Forms.Label lblEstadoFilter;
        private System.Windows.Forms.ComboBox cmbEstadoFilter;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAbrirTicket;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvTickets;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support – do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.lblCategoriaFilter = new System.Windows.Forms.Label();
            this.cmbCategoriaFilter = new System.Windows.Forms.ComboBox();
            this.lblEstadoFilter = new System.Windows.Forms.Label();
            this.cmbEstadoFilter = new System.Windows.Forms.ComboBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAbrirTicket = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelFilters.Controls.Add(this.lblTicketNumber);
            this.panelFilters.Controls.Add(this.txtTicketNumber);
            this.panelFilters.Controls.Add(this.lblCategoriaFilter);
            this.panelFilters.Controls.Add(this.cmbCategoriaFilter);
            this.panelFilters.Controls.Add(this.lblEstadoFilter);
            this.panelFilters.Controls.Add(this.cmbEstadoFilter);
            this.panelFilters.Controls.Add(this.lblFechaDesde);
            this.panelFilters.Controls.Add(this.dtpFechaDesde);
            this.panelFilters.Controls.Add(this.lblFechaHasta);
            this.panelFilters.Controls.Add(this.dtpFechaHasta);
            this.panelFilters.Controls.Add(this.btnBuscar);
            this.panelFilters.Controls.Add(this.btnAbrirTicket);
            this.panelFilters.Controls.Add(this.btnLimpiar);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilters.Size = new System.Drawing.Size(1916, 117);
            this.panelFilters.TabIndex = 1;
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTicketNumber.ForeColor = System.Drawing.Color.White;
            this.lblTicketNumber.Location = new System.Drawing.Point(23, 36);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(80, 20);
            this.lblTicketNumber.TabIndex = 0;
            this.lblTicketNumber.Text = "Nro Ticket:";
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTicketNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTicketNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTicketNumber.Location = new System.Drawing.Point(126, 23);
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(269, 27);
            this.txtTicketNumber.TabIndex = 1;
            // 
            // lblCategoriaFilter
            // 
            this.lblCategoriaFilter.AutoSize = true;
            this.lblCategoriaFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoriaFilter.ForeColor = System.Drawing.Color.White;
            this.lblCategoriaFilter.Location = new System.Drawing.Point(450, 33);
            this.lblCategoriaFilter.Name = "lblCategoriaFilter";
            this.lblCategoriaFilter.Size = new System.Drawing.Size(77, 20);
            this.lblCategoriaFilter.TabIndex = 2;
            this.lblCategoriaFilter.Text = "Categoría:";
            // 
            // cmbCategoriaFilter
            // 
            this.cmbCategoriaFilter.BackColor = System.Drawing.Color.White;
            this.cmbCategoriaFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoriaFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoriaFilter.FormattingEnabled = true;
            this.cmbCategoriaFilter.Location = new System.Drawing.Point(533, 30);
            this.cmbCategoriaFilter.Name = "cmbCategoriaFilter";
            this.cmbCategoriaFilter.Size = new System.Drawing.Size(300, 28);
            this.cmbCategoriaFilter.TabIndex = 3;
            // 
            // lblEstadoFilter
            // 
            this.lblEstadoFilter.AutoSize = true;
            this.lblEstadoFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstadoFilter.ForeColor = System.Drawing.Color.White;
            this.lblEstadoFilter.Location = new System.Drawing.Point(470, 80);
            this.lblEstadoFilter.Name = "lblEstadoFilter";
            this.lblEstadoFilter.Size = new System.Drawing.Size(57, 20);
            this.lblEstadoFilter.TabIndex = 4;
            this.lblEstadoFilter.Text = "Estado:";
            // 
            // cmbEstadoFilter
            // 
            this.cmbEstadoFilter.BackColor = System.Drawing.Color.White;
            this.cmbEstadoFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEstadoFilter.FormattingEnabled = true;
            this.cmbEstadoFilter.Location = new System.Drawing.Point(533, 76);
            this.cmbEstadoFilter.Name = "cmbEstadoFilter";
            this.cmbEstadoFilter.Size = new System.Drawing.Size(200, 28);
            this.cmbEstadoFilter.TabIndex = 5;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.White;
            this.lblFechaDesde.Location = new System.Drawing.Point(23, 77);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(54, 20);
            this.lblFechaDesde.TabIndex = 6;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(97, 75);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(120, 27);
            this.dtpFechaDesde.TabIndex = 7;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.White;
            this.lblFechaHasta.Location = new System.Drawing.Point(233, 77);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(50, 20);
            this.lblFechaHasta.TabIndex = 8;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(319, 72);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(120, 27);
            this.dtpFechaHasta.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(861, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 30);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAbrirTicket
            // 
            this.btnAbrirTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAbrirTicket.FlatAppearance.BorderSize = 0;
            this.btnAbrirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAbrirTicket.ForeColor = System.Drawing.Color.White;
            this.btnAbrirTicket.Location = new System.Drawing.Point(861, 69);
            this.btnAbrirTicket.Name = "btnAbrirTicket";
            this.btnAbrirTicket.Size = new System.Drawing.Size(250, 30);
            this.btnAbrirTicket.TabIndex = 11;
            this.btnAbrirTicket.Text = "Abrir Ticket";
            this.btnAbrirTicket.UseVisualStyleBackColor = false;
            this.btnAbrirTicket.Click += new System.EventHandler(this.btnAbrirTicket_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(1015, 33);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 30);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTickets.ColumnHeadersHeight = 35;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTickets.EnableHeadersVisualStyles = false;
            this.dgvTickets.Location = new System.Drawing.Point(0, 117);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 28;
            this.dgvTickets.Size = new System.Drawing.Size(1916, 699);
            this.dgvTickets.TabIndex = 13;
            // 
            // frmBandejaDeTicketsTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 816);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.panelFilters);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBandejaDeTicketsTecnico";
            this.Load += new System.EventHandler(this.frmBandejaDeTicketsTecnico_Load);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
