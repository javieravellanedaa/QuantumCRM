namespace UI
{
    partial class frmPreviewTicket
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
            this.lblTicketId = new System.Windows.Forms.Label();
            this.lblDepartamentoOrigen = new System.Windows.Forms.Label();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.txtDepartamentoOrigen = new System.Windows.Forms.TextBox();
            this.lblUsuarioCreador = new System.Windows.Forms.Label();
            this.lblDepartamentoDestino = new System.Windows.Forms.Label();
            this.txtUsuarioCreador = new System.Windows.Forms.TextBox();
            this.txtDepartamentoDestino = new System.Windows.Forms.TextBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFechaDeCreacion = new System.Windows.Forms.Label();
            this.txtFechaDeCreacion = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.lblAprobador = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTicketId
            // 
            this.lblTicketId.AutoSize = true;
            this.lblTicketId.Location = new System.Drawing.Point(9, 63);
            this.lblTicketId.Name = "lblTicketId";
            this.lblTicketId.Size = new System.Drawing.Size(37, 13);
            this.lblTicketId.TabIndex = 0;
            this.lblTicketId.Text = "Ticket";
            // 
            // lblDepartamentoOrigen
            // 
            this.lblDepartamentoOrigen.AutoSize = true;
            this.lblDepartamentoOrigen.Location = new System.Drawing.Point(9, 116);
            this.lblDepartamentoOrigen.Name = "lblDepartamentoOrigen";
            this.lblDepartamentoOrigen.Size = new System.Drawing.Size(108, 13);
            this.lblDepartamentoOrigen.TabIndex = 1;
            this.lblDepartamentoOrigen.Text = "Departamento Origen";
            // 
            // txtTicket
            // 
            this.txtTicket.Location = new System.Drawing.Point(67, 60);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(100, 20);
            this.txtTicket.TabIndex = 2;
            // 
            // txtDepartamentoOrigen
            // 
            this.txtDepartamentoOrigen.Location = new System.Drawing.Point(123, 113);
            this.txtDepartamentoOrigen.Name = "txtDepartamentoOrigen";
            this.txtDepartamentoOrigen.Size = new System.Drawing.Size(100, 20);
            this.txtDepartamentoOrigen.TabIndex = 2;
            // 
            // lblUsuarioCreador
            // 
            this.lblUsuarioCreador.AutoSize = true;
            this.lblUsuarioCreador.Location = new System.Drawing.Point(196, 63);
            this.lblUsuarioCreador.Name = "lblUsuarioCreador";
            this.lblUsuarioCreador.Size = new System.Drawing.Size(59, 13);
            this.lblUsuarioCreador.TabIndex = 0;
            this.lblUsuarioCreador.Text = "Creado por";
            // 
            // lblDepartamentoDestino
            // 
            this.lblDepartamentoDestino.AutoSize = true;
            this.lblDepartamentoDestino.Location = new System.Drawing.Point(272, 116);
            this.lblDepartamentoDestino.Name = "lblDepartamentoDestino";
            this.lblDepartamentoDestino.Size = new System.Drawing.Size(113, 13);
            this.lblDepartamentoDestino.TabIndex = 1;
            this.lblDepartamentoDestino.Text = "Departamento Destino";
            // 
            // txtUsuarioCreador
            // 
            this.txtUsuarioCreador.Location = new System.Drawing.Point(275, 60);
            this.txtUsuarioCreador.Name = "txtUsuarioCreador";
            this.txtUsuarioCreador.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioCreador.TabIndex = 2;
            this.txtUsuarioCreador.TextChanged += new System.EventHandler(this.txtUsuarioCreador_TextChanged);
            // 
            // txtDepartamentoDestino
            // 
            this.txtDepartamentoDestino.Location = new System.Drawing.Point(412, 113);
            this.txtDepartamentoDestino.Name = "txtDepartamentoDestino";
            this.txtDepartamentoDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDepartamentoDestino.TabIndex = 2;
            // 
            // lblAsunto
            // 
            this.lblAsunto.AutoSize = true;
            this.lblAsunto.Location = new System.Drawing.Point(16, 235);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(40, 13);
            this.lblAsunto.TabIndex = 1;
            this.lblAsunto.Text = "Asunto";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(130, 232);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(438, 20);
            this.txtAsunto.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(9, 272);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(106, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Detalle de la petición";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(130, 269);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(438, 147);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(219, 494);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado";
            // 
            // lblFechaDeCreacion
            // 
            this.lblFechaDeCreacion.AutoSize = true;
            this.lblFechaDeCreacion.Location = new System.Drawing.Point(391, 63);
            this.lblFechaDeCreacion.Name = "lblFechaDeCreacion";
            this.lblFechaDeCreacion.Size = new System.Drawing.Size(96, 13);
            this.lblFechaDeCreacion.TabIndex = 1;
            this.lblFechaDeCreacion.Text = "Fecha de creación";
            // 
            // txtFechaDeCreacion
            // 
            this.txtFechaDeCreacion.Location = new System.Drawing.Point(493, 60);
            this.txtFechaDeCreacion.Name = "txtFechaDeCreacion";
            this.txtFechaDeCreacion.Size = new System.Drawing.Size(100, 20);
            this.txtFechaDeCreacion.TabIndex = 2;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(271, 491);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 3;
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Location = new System.Drawing.Point(24, 494);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(48, 13);
            this.lblPrioridad.TabIndex = 1;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(76, 491);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(121, 21);
            this.cmbPrioridad.TabIndex = 3;
            // 
            // lblAprobador
            // 
            this.lblAprobador.AutoSize = true;
            this.lblAprobador.Location = new System.Drawing.Point(434, 491);
            this.lblAprobador.Name = "lblAprobador";
            this.lblAprobador.Size = new System.Drawing.Size(0, 13);
            this.lblAprobador.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(16, 188);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 1;
            this.lblCategoria.Text = "Categoria";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(437, 550);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(130, 180);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(424, 21);
            this.cmbCategorias.TabIndex = 18;
            // 
            // frmPreviewTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 585);
            this.Controls.Add(this.cmbCategorias);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtFechaDeCreacion);
            this.Controls.Add(this.txtDepartamentoDestino);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.txtDepartamentoOrigen);
            this.Controls.Add(this.lblFechaDeCreacion);
            this.Controls.Add(this.txtUsuarioCreador);
            this.Controls.Add(this.lblDepartamentoDestino);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtTicket);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblAsunto);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.lblUsuarioCreador);
            this.Controls.Add(this.lblAprobador);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblDepartamentoOrigen);
            this.Controls.Add(this.lblTicketId);
            this.Name = "frmPreviewTicket";
            this.Tag = "Resumen del ticket";
            this.Text = "Resumen del ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTicketId;
        private System.Windows.Forms.Label lblDepartamentoOrigen;
        private System.Windows.Forms.TextBox txtTicket;
        private System.Windows.Forms.TextBox txtDepartamentoOrigen;
        private System.Windows.Forms.Label lblUsuarioCreador;
        private System.Windows.Forms.Label lblDepartamentoDestino;
        private System.Windows.Forms.TextBox txtUsuarioCreador;
        private System.Windows.Forms.TextBox txtDepartamentoDestino;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaDeCreacion;
        private System.Windows.Forms.TextBox txtFechaDeCreacion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Label lblAprobador;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbCategorias;
    }
}