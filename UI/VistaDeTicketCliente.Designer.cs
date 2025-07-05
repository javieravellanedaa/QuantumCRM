namespace UI
{
    partial class VistaDeTicketCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles existentes
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelDates;
        private System.Windows.Forms.Label lblFechadeCreacion;
        private System.Windows.Forms.Label lblOpenDateValue;
        private System.Windows.Forms.Label lblLastUpd;
        private System.Windows.Forms.Label lblLastUpdValue;

        private System.Windows.Forms.TableLayoutPanel tblDetails;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.TextBox txtCreadoPor;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblTipoTicket;
        private System.Windows.Forms.ComboBox cmbTicketType;
        private System.Windows.Forms.Label lblGrupoTecDestino;
        private System.Windows.Forms.ComboBox cmbGrupoTecDestino;
        private System.Windows.Forms.Label lblAssignedTech;
        private System.Windows.Forms.TextBox txtAssignedTech;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;

        // Nuevo DataGridView para Historial
        private System.Windows.Forms.DataGridView dgvHistorial;

        private System.Windows.Forms.DataGridView dgvComentarios;
        private System.Windows.Forms.Button btnNuevoComentario;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnCancelarTicket;

        // Panel y controles para agregar comentario en Panel2
        private System.Windows.Forms.Panel panelAgregarComentario;
        private System.Windows.Forms.Label lblComentarioNuevo;
        private System.Windows.Forms.TextBox txtComentarioNuevo;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.dgvComentarios = new System.Windows.Forms.DataGridView();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDates = new System.Windows.Forms.Panel();
            this.lblFechadeCreacion = new System.Windows.Forms.Label();
            this.lblOpenDateValue = new System.Windows.Forms.Label();
            this.lblLastUpd = new System.Windows.Forms.Label();
            this.lblLastUpdValue = new System.Windows.Forms.Label();
            this.tblDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.txtCreadoPor = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblTipoTicket = new System.Windows.Forms.Label();
            this.cmbTicketType = new System.Windows.Forms.ComboBox();
            this.lblGrupoTecDestino = new System.Windows.Forms.Label();
            this.cmbGrupoTecDestino = new System.Windows.Forms.ComboBox();
            this.lblAssignedTech = new System.Windows.Forms.Label();
            this.txtAssignedTech = new System.Windows.Forms.TextBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.panelAgregarComentario = new System.Windows.Forms.Panel();
            this.lblComentarioNuevo = new System.Windows.Forms.Label();
            this.txtComentarioNuevo = new System.Windows.Forms.TextBox();
            this.btnNuevoComentario = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnCancelarTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelDates.SuspendLayout();
            this.tblDetails.SuspendLayout();
            this.panelAgregarComentario.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.dgvComentarios);
            this.splitContainerMain.Panel1.Controls.Add(this.dgvHistorial);
            this.splitContainerMain.Panel1.Controls.Add(this.panelDates);
            this.splitContainerMain.Panel1.Controls.Add(this.tblDetails);
            this.splitContainerMain.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerMain_Panel1_Paint);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelAgregarComentario);
            this.splitContainerMain.Panel2.Controls.Add(this.btnNuevoComentario);
            this.splitContainerMain.Panel2.Controls.Add(this.btnGuardarCambios);
            this.splitContainerMain.Panel2.Controls.Add(this.btnCancelarTicket);
            this.splitContainerMain.Size = new System.Drawing.Size(1104, 686);
            this.splitContainerMain.SplitterDistance = 449;
            this.splitContainerMain.TabIndex = 0;
            // 
            // dgvComentarios
            // 
            this.dgvComentarios.AllowUserToAddRows = false;
            this.dgvComentarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvComentarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComentarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComentarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComentarios.ColumnHeadersHeight = 29;
            this.dgvComentarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComentarios.EnableHeadersVisualStyles = false;
            this.dgvComentarios.Location = new System.Drawing.Point(0, 472);
            this.dgvComentarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvComentarios.Name = "dgvComentarios";
            this.dgvComentarios.ReadOnly = true;
            this.dgvComentarios.RowHeadersVisible = false;
            this.dgvComentarios.RowHeadersWidth = 51;
            this.dgvComentarios.Size = new System.Drawing.Size(1104, 0);
            this.dgvComentarios.TabIndex = 3;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorial.ColumnHeadersHeight = 29;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colUsuario,
            this.colAccion});
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHistorial.EnableHeadersVisualStyles = false;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 324);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1104, 148);
            this.dgvHistorial.TabIndex = 4;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.MinimumWidth = 6;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colAccion
            // 
            this.colAccion.DataPropertyName = "Accion";
            this.colAccion.HeaderText = "Acción";
            this.colAccion.MinimumWidth = 6;
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            // 
            // panelDates
            // 
            this.panelDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelDates.Controls.Add(this.lblFechadeCreacion);
            this.panelDates.Controls.Add(this.lblOpenDateValue);
            this.panelDates.Controls.Add(this.lblLastUpd);
            this.panelDates.Controls.Add(this.lblLastUpdValue);
            this.panelDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDates.Location = new System.Drawing.Point(0, 294);
            this.panelDates.Margin = new System.Windows.Forms.Padding(4);
            this.panelDates.Name = "panelDates";
            this.panelDates.Size = new System.Drawing.Size(1104, 30);
            this.panelDates.TabIndex = 0;
            // 
            // lblFechadeCreacion
            // 
            this.lblFechadeCreacion.ForeColor = System.Drawing.Color.White;
            this.lblFechadeCreacion.Location = new System.Drawing.Point(11, 6);
            this.lblFechadeCreacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechadeCreacion.Name = "lblFechadeCreacion";
            this.lblFechadeCreacion.Size = new System.Drawing.Size(133, 23);
            this.lblFechadeCreacion.TabIndex = 0;
            this.lblFechadeCreacion.Text = "Fecha de creación:";
            this.lblFechadeCreacion.Click += new System.EventHandler(this.lblOpenDate_Click);
            // 
            // lblOpenDateValue
            // 
            this.lblOpenDateValue.ForeColor = System.Drawing.Color.White;
            this.lblOpenDateValue.Location = new System.Drawing.Point(219, 2);
            this.lblOpenDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenDateValue.Name = "lblOpenDateValue";
            this.lblOpenDateValue.Size = new System.Drawing.Size(100, 23);
            this.lblOpenDateValue.TabIndex = 1;
            this.lblOpenDateValue.Text = "–";
            // 
            // lblLastUpd
            // 
            this.lblLastUpd.ForeColor = System.Drawing.Color.White;
            this.lblLastUpd.Location = new System.Drawing.Point(344, 6);
            this.lblLastUpd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpd.Name = "lblLastUpd";
            this.lblLastUpd.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpd.TabIndex = 4;
            this.lblLastUpd.Text = "Actualizado el";
            // 
            // lblLastUpdValue
            // 
            this.lblLastUpdValue.ForeColor = System.Drawing.Color.White;
            this.lblLastUpdValue.Location = new System.Drawing.Point(491, 6);
            this.lblLastUpdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpdValue.Name = "lblLastUpdValue";
            this.lblLastUpdValue.Size = new System.Drawing.Size(100, 23);
            this.lblLastUpdValue.TabIndex = 5;
            this.lblLastUpdValue.Text = "–";
            // 
            // tblDetails
            // 
            this.tblDetails.AutoSize = true;
            this.tblDetails.ColumnCount = 4;
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.13301F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.99015F));
            this.tblDetails.Controls.Add(this.lblClient, 0, 0);
            this.tblDetails.Controls.Add(this.txtCliente, 1, 0);
            this.tblDetails.Controls.Add(this.lblCreatedBy, 2, 0);
            this.tblDetails.Controls.Add(this.txtCreadoPor, 3, 0);
            this.tblDetails.Controls.Add(this.lblLocation, 0, 1);
            this.tblDetails.Controls.Add(this.txtUbicacion, 1, 1);
            this.tblDetails.Controls.Add(this.lblDepartment, 2, 1);
            this.tblDetails.Controls.Add(this.txtDepartamento, 3, 1);
            this.tblDetails.Controls.Add(this.lblCategoria, 0, 2);
            this.tblDetails.Controls.Add(this.cmbCategoria, 1, 2);
            this.tblDetails.Controls.Add(this.lblTipoTicket, 2, 2);
            this.tblDetails.Controls.Add(this.cmbTicketType, 3, 2);
            this.tblDetails.Controls.Add(this.lblGrupoTecDestino, 0, 3);
            this.tblDetails.Controls.Add(this.cmbGrupoTecDestino, 1, 3);
            this.tblDetails.Controls.Add(this.lblAssignedTech, 2, 3);
            this.tblDetails.Controls.Add(this.txtAssignedTech, 3, 3);
            this.tblDetails.Controls.Add(this.lblPrioridad, 0, 4);
            this.tblDetails.Controls.Add(this.cmbPrioridad, 1, 4);
            this.tblDetails.Controls.Add(this.lblAsunto, 0, 5);
            this.tblDetails.Controls.Add(this.txtAsunto, 1, 5);
            this.tblDetails.Controls.Add(this.lblDescripcion, 0, 6);
            this.tblDetails.Controls.Add(this.txtDescripcion, 1, 6);
            this.tblDetails.Controls.Add(this.lblEstado, 2, 4);
            this.tblDetails.Controls.Add(this.txtEstado, 3, 4);
            this.tblDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblDetails.Location = new System.Drawing.Point(0, 0);
            this.tblDetails.Margin = new System.Windows.Forms.Padding(4);
            this.tblDetails.Name = "tblDetails";
            this.tblDetails.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.tblDetails.RowCount = 7;
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDetails.Size = new System.Drawing.Size(1104, 294);
            this.tblDetails.TabIndex = 1;
            // 
            // lblClient
            // 
            this.lblClient.Location = new System.Drawing.Point(15, 10);
            this.lblClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(100, 23);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.Location = new System.Drawing.Point(144, 14);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(396, 22);
            this.txtCliente.TabIndex = 1;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Location = new System.Drawing.Point(554, 10);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(100, 23);
            this.lblCreatedBy.TabIndex = 2;
            this.lblCreatedBy.Text = "Creado Por:";
            // 
            // txtCreadoPor
            // 
            this.txtCreadoPor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCreadoPor.Location = new System.Drawing.Point(728, 14);
            this.txtCreadoPor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCreadoPor.Name = "txtCreadoPor";
            this.txtCreadoPor.ReadOnly = true;
            this.txtCreadoPor.Size = new System.Drawing.Size(224, 22);
            this.txtCreadoPor.TabIndex = 3;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(15, 40);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 23);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUbicacion.Location = new System.Drawing.Point(144, 44);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(396, 22);
            this.txtUbicacion.TabIndex = 5;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(554, 40);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(143, 23);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "Departamento:";
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDepartamento.Location = new System.Drawing.Point(728, 44);
            this.txtDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.ReadOnly = true;
            this.txtDepartamento.Size = new System.Drawing.Size(224, 22);
            this.txtDepartamento.TabIndex = 7;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Location = new System.Drawing.Point(15, 70);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(100, 23);
            this.lblCategoria.TabIndex = 8;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Location = new System.Drawing.Point(144, 74);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(396, 24);
            this.cmbCategoria.TabIndex = 9;
            // 
            // lblTipoTicket
            // 
            this.lblTipoTicket.Location = new System.Drawing.Point(554, 70);
            this.lblTipoTicket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoTicket.Name = "lblTipoTicket";
            this.lblTipoTicket.Size = new System.Drawing.Size(100, 23);
            this.lblTipoTicket.TabIndex = 10;
            this.lblTipoTicket.Text = "Tipo Ticket:";
            // 
            // cmbTicketType
            // 
            this.cmbTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTicketType.Location = new System.Drawing.Point(728, 74);
            this.cmbTicketType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTicketType.Name = "cmbTicketType";
            this.cmbTicketType.Size = new System.Drawing.Size(224, 24);
            this.cmbTicketType.TabIndex = 11;
            // 
            // lblGrupoTecDestino
            // 
            this.lblGrupoTecDestino.Location = new System.Drawing.Point(15, 102);
            this.lblGrupoTecDestino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupoTecDestino.Name = "lblGrupoTecDestino";
            this.lblGrupoTecDestino.Size = new System.Drawing.Size(100, 23);
            this.lblGrupoTecDestino.TabIndex = 12;
            this.lblGrupoTecDestino.Text = "Grupo Téc. Dest.:";
            // 
            // cmbGrupoTecDestino
            // 
            this.cmbGrupoTecDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoTecDestino.Location = new System.Drawing.Point(144, 106);
            this.cmbGrupoTecDestino.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrupoTecDestino.Name = "cmbGrupoTecDestino";
            this.cmbGrupoTecDestino.Size = new System.Drawing.Size(396, 24);
            this.cmbGrupoTecDestino.TabIndex = 13;
            // 
            // lblAssignedTech
            // 
            this.lblAssignedTech.Location = new System.Drawing.Point(554, 102);
            this.lblAssignedTech.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAssignedTech.Name = "lblAssignedTech";
            this.lblAssignedTech.Size = new System.Drawing.Size(100, 23);
            this.lblAssignedTech.TabIndex = 14;
            this.lblAssignedTech.Text = "Técnico:";
            // 
            // txtAssignedTech
            // 
            this.txtAssignedTech.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAssignedTech.Location = new System.Drawing.Point(728, 106);
            this.txtAssignedTech.Margin = new System.Windows.Forms.Padding(4);
            this.txtAssignedTech.Name = "txtAssignedTech";
            this.txtAssignedTech.ReadOnly = true;
            this.txtAssignedTech.Size = new System.Drawing.Size(224, 22);
            this.txtAssignedTech.TabIndex = 15;
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.Location = new System.Drawing.Point(15, 134);
            this.lblPrioridad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(100, 23);
            this.lblPrioridad.TabIndex = 16;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridad.Location = new System.Drawing.Point(144, 138);
            this.cmbPrioridad.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(396, 24);
            this.cmbPrioridad.TabIndex = 17;
            // 
            // lblAsunto
            // 
            this.lblAsunto.Location = new System.Drawing.Point(15, 166);
            this.lblAsunto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(100, 23);
            this.lblAsunto.TabIndex = 18;
            this.lblAsunto.Text = "Asunto:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblDetails.SetColumnSpan(this.txtAsunto, 3);
            this.txtAsunto.Location = new System.Drawing.Point(144, 170);
            this.txtAsunto.Margin = new System.Windows.Forms.Padding(4);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(809, 22);
            this.txtAsunto.TabIndex = 19;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(15, 196);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcion.TabIndex = 20;
            this.lblDescripcion.Text = "Detalle:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblDetails.SetColumnSpan(this.txtDescripcion, 3);
            this.txtDescripcion.Location = new System.Drawing.Point(144, 200);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(809, 80);
            this.txtDescripcion.TabIndex = 21;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(554, 134);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEstado.Location = new System.Drawing.Point(728, 138);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(224, 22);
            this.txtEstado.TabIndex = 15;
            // 
            // panelAgregarComentario
            // 
            this.panelAgregarComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelAgregarComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAgregarComentario.Controls.Add(this.lblComentarioNuevo);
            this.panelAgregarComentario.Controls.Add(this.txtComentarioNuevo);
            this.panelAgregarComentario.Location = new System.Drawing.Point(11, 49);
            this.panelAgregarComentario.Margin = new System.Windows.Forms.Padding(4);
            this.panelAgregarComentario.Name = "panelAgregarComentario";
            this.panelAgregarComentario.Size = new System.Drawing.Size(666, 66);
            this.panelAgregarComentario.TabIndex = 4;
            this.panelAgregarComentario.Visible = false;
            // 
            // lblComentarioNuevo
            // 
            this.lblComentarioNuevo.AutoSize = true;
            this.lblComentarioNuevo.Location = new System.Drawing.Point(5, 5);
            this.lblComentarioNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComentarioNuevo.Name = "lblComentarioNuevo";
            this.lblComentarioNuevo.Size = new System.Drawing.Size(139, 16);
            this.lblComentarioNuevo.TabIndex = 0;
            this.lblComentarioNuevo.Text = "Escribe tu comentario:";
            // 
            // txtComentarioNuevo
            // 
            this.txtComentarioNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentarioNuevo.Location = new System.Drawing.Point(5, 25);
            this.txtComentarioNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentarioNuevo.Multiline = true;
            this.txtComentarioNuevo.Name = "txtComentarioNuevo";
            this.txtComentarioNuevo.Size = new System.Drawing.Size(653, 36);
            this.txtComentarioNuevo.TabIndex = 1;
            // 
            // btnNuevoComentario
            // 
            this.btnNuevoComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnNuevoComentario.FlatAppearance.BorderSize = 0;
            this.btnNuevoComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoComentario.ForeColor = System.Drawing.Color.White;
            this.btnNuevoComentario.Location = new System.Drawing.Point(11, 10);
            this.btnNuevoComentario.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevoComentario.Name = "btnNuevoComentario";
            this.btnNuevoComentario.Size = new System.Drawing.Size(187, 30);
            this.btnNuevoComentario.TabIndex = 0;
            this.btnNuevoComentario.Text = "+ Nuevo comentario";
            this.btnNuevoComentario.UseVisualStyleBackColor = false;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(208, 10);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(160, 30);
            this.btnGuardarCambios.TabIndex = 1;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.BtnGuardarCambios_Click);
            // 
            // btnCancelarTicket
            // 
            this.btnCancelarTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCancelarTicket.FlatAppearance.BorderSize = 0;
            this.btnCancelarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarTicket.ForeColor = System.Drawing.Color.White;
            this.btnCancelarTicket.Location = new System.Drawing.Point(384, 10);
            this.btnCancelarTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarTicket.Name = "btnCancelarTicket";
            this.btnCancelarTicket.Size = new System.Drawing.Size(160, 30);
            this.btnCancelarTicket.TabIndex = 2;
            this.btnCancelarTicket.Text = "Cancelar Ticket";
            this.btnCancelarTicket.UseVisualStyleBackColor = false;
            this.btnCancelarTicket.Click += new System.EventHandler(this.btnCancelarTicket_Click);
            // 
            // VistaDeTicketCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 686);
            this.Controls.Add(this.splitContainerMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VistaDeTicketCliente";
            this.Text = "Detalle de Ticket";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelDates.ResumeLayout(false);
            this.tblDetails.ResumeLayout(false);
            this.tblDetails.PerformLayout();
            this.panelAgregarComentario.ResumeLayout(false);
            this.panelAgregarComentario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
    }
}
