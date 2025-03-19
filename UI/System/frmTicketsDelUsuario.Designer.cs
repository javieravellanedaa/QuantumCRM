namespace UI
{
    partial class frmTicketsDelUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlTickets;
        private System.Windows.Forms.TabPage tabPageMisTickets;
        private System.Windows.Forms.TabPage tabPageDeptTickets;
        private System.Windows.Forms.DataGridView dgvMisTickets;
        private System.Windows.Forms.DataGridView dgvDeptTickets;
        private System.Windows.Forms.Button btnAbrirTicketUsuario;
        private System.Windows.Forms.Button btnVerComentariosUsuario;
        private System.Windows.Forms.Button btnAbrirTicketDept;
        private System.Windows.Forms.Button btnVerComentariosDept;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support – do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlTickets = new System.Windows.Forms.TabControl();
            this.tabPageMisTickets = new System.Windows.Forms.TabPage();
            this.btnVerComentariosUsuario = new System.Windows.Forms.Button();
            this.btnAbrirTicketUsuario = new System.Windows.Forms.Button();
            this.dgvMisTickets = new System.Windows.Forms.DataGridView();
            this.tabPageDeptTickets = new System.Windows.Forms.TabPage();
            this.btnVerComentariosDept = new System.Windows.Forms.Button();
            this.btnAbrirTicketDept = new System.Windows.Forms.Button();
            this.dgvDeptTickets = new System.Windows.Forms.DataGridView();
            this.tabControlTickets.SuspendLayout();
            this.tabPageMisTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisTickets)).BeginInit();
            this.tabPageDeptTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlTickets
            // 
            this.tabControlTickets.Controls.Add(this.tabPageMisTickets);
            this.tabControlTickets.Controls.Add(this.tabPageDeptTickets);
            this.tabControlTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTickets.Location = new System.Drawing.Point(0, 0);
            this.tabControlTickets.Name = "tabControlTickets";
            this.tabControlTickets.SelectedIndex = 0;
            this.tabControlTickets.Size = new System.Drawing.Size(800, 450);
            this.tabControlTickets.TabIndex = 0;
            // 
            // tabPageMisTickets
            // 
            this.tabPageMisTickets.Controls.Add(this.btnVerComentariosUsuario);
            this.tabPageMisTickets.Controls.Add(this.btnAbrirTicketUsuario);
            this.tabPageMisTickets.Controls.Add(this.dgvMisTickets);
            this.tabPageMisTickets.Location = new System.Drawing.Point(4, 22);
            this.tabPageMisTickets.Name = "tabPageMisTickets";
            this.tabPageMisTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMisTickets.Size = new System.Drawing.Size(792, 424);
            this.tabPageMisTickets.TabIndex = 0;
            this.tabPageMisTickets.Text = "Mis Tickets";
            this.tabPageMisTickets.UseVisualStyleBackColor = true;
            // 
            // btnVerComentariosUsuario
            // 
            this.btnVerComentariosUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerComentariosUsuario.Location = new System.Drawing.Point(6, 395);
            this.btnVerComentariosUsuario.Name = "btnVerComentariosUsuario";
            this.btnVerComentariosUsuario.Size = new System.Drawing.Size(120, 23);
            this.btnVerComentariosUsuario.TabIndex = 2;
            this.btnVerComentariosUsuario.Text = "Ver Comentarios";
            this.btnVerComentariosUsuario.UseVisualStyleBackColor = true;
            this.btnVerComentariosUsuario.Click += new System.EventHandler(this.btnVerComentariosUsuario_Click);
            // 
            // btnAbrirTicketUsuario
            // 
            this.btnAbrirTicketUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirTicketUsuario.Location = new System.Drawing.Point(666, 395);
            this.btnAbrirTicketUsuario.Name = "btnAbrirTicketUsuario";
            this.btnAbrirTicketUsuario.Size = new System.Drawing.Size(120, 23);
            this.btnAbrirTicketUsuario.TabIndex = 1;
            this.btnAbrirTicketUsuario.Text = "Abrir Ticket";
            this.btnAbrirTicketUsuario.UseVisualStyleBackColor = true;
            this.btnAbrirTicketUsuario.Click += new System.EventHandler(this.btnAbrirTicketUsuario_Click);
            // 
            // dgvMisTickets
            // 
            this.dgvMisTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMisTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisTickets.Location = new System.Drawing.Point(6, 6);
            this.dgvMisTickets.Name = "dgvMisTickets";
            this.dgvMisTickets.Size = new System.Drawing.Size(780, 383);
            this.dgvMisTickets.TabIndex = 0;
            // 
            // tabPageDeptTickets
            // 
            this.tabPageDeptTickets.Controls.Add(this.btnVerComentariosDept);
            this.tabPageDeptTickets.Controls.Add(this.btnAbrirTicketDept);
            this.tabPageDeptTickets.Controls.Add(this.dgvDeptTickets);
            this.tabPageDeptTickets.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeptTickets.Name = "tabPageDeptTickets";
            this.tabPageDeptTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeptTickets.Size = new System.Drawing.Size(792, 424);
            this.tabPageDeptTickets.TabIndex = 1;
            this.tabPageDeptTickets.Text = "Tickets del Departamento";
            this.tabPageDeptTickets.UseVisualStyleBackColor = true;
            // 
            // btnVerComentariosDept
            // 
            this.btnVerComentariosDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerComentariosDept.Location = new System.Drawing.Point(6, 395);
            this.btnVerComentariosDept.Name = "btnVerComentariosDept";
            this.btnVerComentariosDept.Size = new System.Drawing.Size(120, 23);
            this.btnVerComentariosDept.TabIndex = 2;
            this.btnVerComentariosDept.Text = "Ver Comentarios";
            this.btnVerComentariosDept.UseVisualStyleBackColor = true;
            this.btnVerComentariosDept.Click += new System.EventHandler(this.btnVerComentariosDept_Click);
            // 
            // btnAbrirTicketDept
            // 
            this.btnAbrirTicketDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbrirTicketDept.Location = new System.Drawing.Point(666, 395);
            this.btnAbrirTicketDept.Name = "btnAbrirTicketDept";
            this.btnAbrirTicketDept.Size = new System.Drawing.Size(120, 23);
            this.btnAbrirTicketDept.TabIndex = 1;
            this.btnAbrirTicketDept.Text = "Abrir Ticket";
            this.btnAbrirTicketDept.UseVisualStyleBackColor = true;
            this.btnAbrirTicketDept.Click += new System.EventHandler(this.btnAbrirTicketDept_Click);
            // 
            // dgvDeptTickets
            // 
            this.dgvDeptTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeptTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptTickets.Location = new System.Drawing.Point(6, 6);
            this.dgvDeptTickets.Name = "dgvDeptTickets";
            this.dgvDeptTickets.Size = new System.Drawing.Size(780, 383);
            this.dgvDeptTickets.TabIndex = 0;
            // 
            // frmTicketsDelUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlTickets);
            this.Name = "frmTicketsDelUsuario";
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.frmTicketsDelUsuario_Load);
            this.tabControlTickets.ResumeLayout(false);
            this.tabPageMisTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisTickets)).EndInit();
            this.tabPageDeptTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptTickets)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
