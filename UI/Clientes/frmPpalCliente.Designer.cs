namespace UI
{
    partial class frmPpalCliente
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
            this.components = new System.ComponentModel.Container();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.iconBtnDesloguear = new FontAwesome.Sharp.IconButton();
            this.iconBtnConfiguracion = new FontAwesome.Sharp.IconButton();
            this.iconBtnAdministracion = new FontAwesome.Sharp.IconButton();
            this.iconBtnDepartamentos = new FontAwesome.Sharp.IconButton();
            this.iconBtnTickets = new FontAwesome.Sharp.IconButton();
            this.iconBtnGeneral = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icbApellidoNombre = new FontAwesome.Sharp.IconButton();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnMaximaze = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.PanelDesktop = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dwnGeneral = new UI.Design.DropDownMenu(this.components);
            this.MiCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPerfilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactoSoporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwnIcono = new UI.Design.DropDownMenu(this.components);
            this.miPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosPersonalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwnTickets = new UI.Design.DropDownMenu(this.components);
            this.nuevoTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTicketsParaAprobar = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelTitleBar.SuspendLayout();
            this.dwnGeneral.SuspendLayout();
            this.dwnIcono.SuspendLayout();
            this.dwnTickets.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(87)))), ((int)(((byte)(192)))));
            this.PanelMenu.Controls.Add(this.iconBtnDesloguear);
            this.PanelMenu.Controls.Add(this.iconBtnConfiguracion);
            this.PanelMenu.Controls.Add(this.iconBtnAdministracion);
            this.PanelMenu.Controls.Add(this.iconBtnDepartamentos);
            this.PanelMenu.Controls.Add(this.iconBtnTickets);
            this.PanelMenu.Controls.Add(this.iconBtnGeneral);
            this.PanelMenu.Controls.Add(this.panel1);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(307, 655);
            this.PanelMenu.TabIndex = 0;
            // 
            // iconBtnDesloguear
            // 
            this.iconBtnDesloguear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconBtnDesloguear.FlatAppearance.BorderSize = 0;
            this.iconBtnDesloguear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnDesloguear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnDesloguear.ForeColor = System.Drawing.Color.White;
            this.iconBtnDesloguear.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconBtnDesloguear.IconColor = System.Drawing.Color.White;
            this.iconBtnDesloguear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnDesloguear.IconSize = 30;
            this.iconBtnDesloguear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDesloguear.Location = new System.Drawing.Point(0, 598);
            this.iconBtnDesloguear.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnDesloguear.Name = "iconBtnDesloguear";
            this.iconBtnDesloguear.Padding = new System.Windows.Forms.Padding(13, 0, 0, 18);
            this.iconBtnDesloguear.Size = new System.Drawing.Size(307, 57);
            this.iconBtnDesloguear.TabIndex = 7;
            this.iconBtnDesloguear.Tag = "Desloguear";
            this.iconBtnDesloguear.Text = "Desloguear";
            this.iconBtnDesloguear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDesloguear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnDesloguear.UseVisualStyleBackColor = true;
            this.iconBtnDesloguear.Click += new System.EventHandler(this.iconBtnDesloguear_Click);
            // 
            // iconBtnConfiguracion
            // 
            this.iconBtnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnConfiguracion.FlatAppearance.BorderSize = 0;
            this.iconBtnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnConfiguracion.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnConfiguracion.ForeColor = System.Drawing.Color.White;
            this.iconBtnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.iconBtnConfiguracion.IconColor = System.Drawing.Color.White;
            this.iconBtnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnConfiguracion.IconSize = 30;
            this.iconBtnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnConfiguracion.Location = new System.Drawing.Point(0, 354);
            this.iconBtnConfiguracion.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnConfiguracion.Name = "iconBtnConfiguracion";
            this.iconBtnConfiguracion.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.iconBtnConfiguracion.Size = new System.Drawing.Size(307, 59);
            this.iconBtnConfiguracion.TabIndex = 5;
            this.iconBtnConfiguracion.Tag = "Configuracion";
            this.iconBtnConfiguracion.Text = "Configuracion";
            this.iconBtnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // iconBtnAdministracion
            // 
            this.iconBtnAdministracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnAdministracion.FlatAppearance.BorderSize = 0;
            this.iconBtnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnAdministracion.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnAdministracion.ForeColor = System.Drawing.Color.White;
            this.iconBtnAdministracion.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.iconBtnAdministracion.IconColor = System.Drawing.Color.White;
            this.iconBtnAdministracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnAdministracion.IconSize = 30;
            this.iconBtnAdministracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnAdministracion.Location = new System.Drawing.Point(0, 295);
            this.iconBtnAdministracion.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnAdministracion.Name = "iconBtnAdministracion";
            this.iconBtnAdministracion.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.iconBtnAdministracion.Size = new System.Drawing.Size(307, 59);
            this.iconBtnAdministracion.TabIndex = 4;
            this.iconBtnAdministracion.Tag = "Administracion";
            this.iconBtnAdministracion.Text = "Administracion";
            this.iconBtnAdministracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnAdministracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnAdministracion.UseVisualStyleBackColor = true;
            // 
            // iconBtnDepartamentos
            // 
            this.iconBtnDepartamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnDepartamentos.FlatAppearance.BorderSize = 0;
            this.iconBtnDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnDepartamentos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnDepartamentos.ForeColor = System.Drawing.Color.White;
            this.iconBtnDepartamentos.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.iconBtnDepartamentos.IconColor = System.Drawing.Color.White;
            this.iconBtnDepartamentos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnDepartamentos.IconSize = 30;
            this.iconBtnDepartamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDepartamentos.Location = new System.Drawing.Point(0, 236);
            this.iconBtnDepartamentos.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnDepartamentos.Name = "iconBtnDepartamentos";
            this.iconBtnDepartamentos.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.iconBtnDepartamentos.Size = new System.Drawing.Size(307, 59);
            this.iconBtnDepartamentos.TabIndex = 3;
            this.iconBtnDepartamentos.Tag = "Departamentos";
            this.iconBtnDepartamentos.Text = "Dashboard";
            this.iconBtnDepartamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDepartamentos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnDepartamentos.UseVisualStyleBackColor = true;
            this.iconBtnDepartamentos.Click += new System.EventHandler(this.iconBtnDepartamentos_Click);
            // 
            // iconBtnTickets
            // 
            this.iconBtnTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnTickets.FlatAppearance.BorderSize = 0;
            this.iconBtnTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnTickets.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnTickets.ForeColor = System.Drawing.Color.White;
            this.iconBtnTickets.IconChar = FontAwesome.Sharp.IconChar.Tarp;
            this.iconBtnTickets.IconColor = System.Drawing.Color.White;
            this.iconBtnTickets.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnTickets.IconSize = 30;
            this.iconBtnTickets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnTickets.Location = new System.Drawing.Point(0, 177);
            this.iconBtnTickets.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnTickets.Name = "iconBtnTickets";
            this.iconBtnTickets.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.iconBtnTickets.Size = new System.Drawing.Size(307, 59);
            this.iconBtnTickets.TabIndex = 2;
            this.iconBtnTickets.Tag = "Tickets";
            this.iconBtnTickets.Text = "Tickets";
            this.iconBtnTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnTickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnTickets.UseVisualStyleBackColor = true;
            this.iconBtnTickets.Click += new System.EventHandler(this.iconBtnTickets_Click);
            // 
            // iconBtnGeneral
            // 
            this.iconBtnGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnGeneral.FlatAppearance.BorderSize = 0;
            this.iconBtnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnGeneral.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnGeneral.ForeColor = System.Drawing.Color.White;
            this.iconBtnGeneral.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconBtnGeneral.IconColor = System.Drawing.Color.White;
            this.iconBtnGeneral.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnGeneral.IconSize = 30;
            this.iconBtnGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnGeneral.Location = new System.Drawing.Point(0, 118);
            this.iconBtnGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.iconBtnGeneral.Name = "iconBtnGeneral";
            this.iconBtnGeneral.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.iconBtnGeneral.Size = new System.Drawing.Size(307, 59);
            this.iconBtnGeneral.TabIndex = 1;
            this.iconBtnGeneral.Tag = "General";
            this.iconBtnGeneral.Text = "General";
            this.iconBtnGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnGeneral.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnGeneral.UseVisualStyleBackColor = true;
            this.iconBtnGeneral.Click += new System.EventHandler(this.iconBtnGeneral_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.icbApellidoNombre);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 118);
            this.panel1.TabIndex = 0;
            // 
            // icbApellidoNombre
            // 
            this.icbApellidoNombre.FlatAppearance.BorderSize = 0;
            this.icbApellidoNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icbApellidoNombre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbApellidoNombre.ForeColor = System.Drawing.Color.White;
            this.icbApellidoNombre.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icbApellidoNombre.IconColor = System.Drawing.Color.Transparent;
            this.icbApellidoNombre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icbApellidoNombre.Location = new System.Drawing.Point(136, 7);
            this.icbApellidoNombre.Margin = new System.Windows.Forms.Padding(4);
            this.icbApellidoNombre.Name = "icbApellidoNombre";
            this.icbApellidoNombre.Size = new System.Drawing.Size(83, 28);
            this.icbApellidoNombre.TabIndex = 4;
            this.icbApellidoNombre.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(253, 7);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(53, 36);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.avatarCliente;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.Color.White;
            this.PanelTitleBar.Controls.Add(this.lblTitulo);
            this.PanelTitleBar.Controls.Add(this.btnMinimize);
            this.PanelTitleBar.Controls.Add(this.btnMaximaze);
            this.PanelTitleBar.Controls.Add(this.btnExit);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelTitleBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PanelTitleBar.Location = new System.Drawing.Point(307, 0);
            this.PanelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(862, 74);
            this.PanelTitleBar.TabIndex = 1;
            this.PanelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTitleBar_Paint);
            this.PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            this.PanelTitleBar.Resize += new System.EventHandler(this.PanelTitleBar_Resize);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei Light", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(69, 7);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTitulo.Size = new System.Drawing.Size(311, 64);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "DASHBOARD";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(185)))), ((int)(((byte)(218)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(690, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(53, 31);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximaze
            // 
            this.btnMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximaze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.btnMaximaze.FlatAppearance.BorderSize = 0;
            this.btnMaximaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximaze.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkAlt;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximaze.IconSize = 20;
            this.btnMaximaze.Location = new System.Drawing.Point(740, 0);
            this.btnMaximaze.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.Size = new System.Drawing.Size(63, 31);
            this.btnMaximaze.TabIndex = 0;
            this.btnMaximaze.UseVisualStyleBackColor = false;
            this.btnMaximaze.Click += new System.EventHandler(this.btnMaximaze_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(94)))), ((int)(((byte)(131)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(802, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 31);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PanelDesktop
            // 
            this.PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktop.Location = new System.Drawing.Point(307, 74);
            this.PanelDesktop.Margin = new System.Windows.Forms.Padding(4);
            this.PanelDesktop.Name = "PanelDesktop";
            this.PanelDesktop.Size = new System.Drawing.Size(862, 581);
            this.PanelDesktop.TabIndex = 2;
            this.PanelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDesktop_Paint);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // dwnGeneral
            // 
            this.dwnGeneral.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dwnGeneral.IsMainMenu = false;
            this.dwnGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCuentaToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.contactoSoporteToolStripMenuItem});
            this.dwnGeneral.MenuItemHeight = 25;
            this.dwnGeneral.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dwnGeneral.Name = "dropDownMenu1";
            this.dwnGeneral.PrimaryColor = System.Drawing.Color.Empty;
            this.dwnGeneral.Size = new System.Drawing.Size(196, 76);
            // 
            // MiCuentaToolStripMenuItem
            // 
            this.MiCuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPerfilToolStripMenuItem1});
            this.MiCuentaToolStripMenuItem.Name = "MiCuentaToolStripMenuItem";
            this.MiCuentaToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.MiCuentaToolStripMenuItem.Text = "Mi cuenta";
            // 
            // miPerfilToolStripMenuItem1
            // 
            this.miPerfilToolStripMenuItem1.Name = "miPerfilToolStripMenuItem1";
            this.miPerfilToolStripMenuItem1.Size = new System.Drawing.Size(146, 26);
            this.miPerfilToolStripMenuItem1.Text = "Mi Perfil";
            this.miPerfilToolStripMenuItem1.Click += new System.EventHandler(this.miPerfilToolStripMenuItem1_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // contactoSoporteToolStripMenuItem
            // 
            this.contactoSoporteToolStripMenuItem.Name = "contactoSoporteToolStripMenuItem";
            this.contactoSoporteToolStripMenuItem.Size = new System.Drawing.Size(195, 24);
            this.contactoSoporteToolStripMenuItem.Text = "Contacto Soporte";
            // 
            // dwnIcono
            // 
            this.dwnIcono.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dwnIcono.IsMainMenu = false;
            this.dwnIcono.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPerfilToolStripMenuItem,
            this.cambiarRolToolStripMenuItem,
            this.cambiarIdiomaToolStripMenuItem});
            this.dwnIcono.MenuItemHeight = 25;
            this.dwnIcono.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dwnIcono.Name = "dropDownMenu2";
            this.dwnIcono.PrimaryColor = System.Drawing.Color.Empty;
            this.dwnIcono.Size = new System.Drawing.Size(186, 76);
            // 
            // miPerfilToolStripMenuItem
            // 
            this.miPerfilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosPersonalesToolStripMenuItem});
            this.miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            this.miPerfilToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.miPerfilToolStripMenuItem.Text = "Mi Perfil";
            // 
            // datosPersonalesToolStripMenuItem
            // 
            this.datosPersonalesToolStripMenuItem.Name = "datosPersonalesToolStripMenuItem";
            this.datosPersonalesToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.datosPersonalesToolStripMenuItem.Text = "Datos personales";
            this.datosPersonalesToolStripMenuItem.Click += new System.EventHandler(this.datosPersonalesToolStripMenuItem_Click);
            // 
            // cambiarRolToolStripMenuItem
            // 
            this.cambiarRolToolStripMenuItem.Name = "cambiarRolToolStripMenuItem";
            this.cambiarRolToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.cambiarRolToolStripMenuItem.Text = "Cambiar Rol";
            this.cambiarRolToolStripMenuItem.DropDownOpening += new System.EventHandler(this.cambiarRolToolStripMenuItem_DropDownOpening);
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            this.cambiarIdiomaToolStripMenuItem.DropDownOpening += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_DropDownOpening);
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_Click);
            // 
            // dwnTickets
            // 
            this.dwnTickets.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dwnTickets.IsMainMenu = false;
            this.dwnTickets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTicketToolStripMenuItem,
            this.misTicketsToolStripMenuItem,
            this.buscarTicketToolStripMenuItem,
            this.tsmTicketsParaAprobar});
            this.dwnTickets.MenuItemHeight = 25;
            this.dwnTickets.MenuItemTextColor = System.Drawing.Color.Empty;
            this.dwnTickets.Name = "dwnTickets";
            this.dwnTickets.PrimaryColor = System.Drawing.Color.Empty;
            this.dwnTickets.Size = new System.Drawing.Size(217, 128);
            // 
            // nuevoTicketToolStripMenuItem
            // 
            this.nuevoTicketToolStripMenuItem.Name = "nuevoTicketToolStripMenuItem";
            this.nuevoTicketToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.nuevoTicketToolStripMenuItem.Text = "Nuevo Ticket";
            this.nuevoTicketToolStripMenuItem.Click += new System.EventHandler(this.nuevoTicketToolStripMenuItem_Click);
            // 
            // misTicketsToolStripMenuItem
            // 
            this.misTicketsToolStripMenuItem.Name = "misTicketsToolStripMenuItem";
            this.misTicketsToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.misTicketsToolStripMenuItem.Text = "Mis Tickets";
            this.misTicketsToolStripMenuItem.Click += new System.EventHandler(this.misTicketsToolStripMenuItem_Click);
            // 
            // buscarTicketToolStripMenuItem
            // 
            this.buscarTicketToolStripMenuItem.Name = "buscarTicketToolStripMenuItem";
            this.buscarTicketToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.buscarTicketToolStripMenuItem.Text = "Buscar Ticket";
            // 
            // tsmTicketsParaAprobar
            // 
            this.tsmTicketsParaAprobar.Name = "tsmTicketsParaAprobar";
            this.tsmTicketsParaAprobar.Size = new System.Drawing.Size(216, 24);
            this.tsmTicketsParaAprobar.Text = "Tickets para Aprobar";
            this.tsmTicketsParaAprobar.Click += new System.EventHandler(this.tsmTicketsParaAprobar_Click);
            // 
            // frmPpalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 655);
            this.Controls.Add(this.PanelDesktop);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPpalCliente";
            this.Text = "frmPpalNew";
            this.Load += new System.EventHandler(this.frmPpalNew_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPpalNew_MouseDown);
            this.Resize += new System.EventHandler(this.frmPpalNew_Resize);
            this.PanelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            this.dwnGeneral.ResumeLayout(false);
            this.dwnIcono.ResumeLayout(false);
            this.dwnTickets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelTitleBar;
        private System.Windows.Forms.Panel PanelDesktop;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconBtnGeneral;
        private FontAwesome.Sharp.IconButton iconBtnDesloguear;
        private FontAwesome.Sharp.IconButton iconBtnConfiguracion;
        private FontAwesome.Sharp.IconButton iconBtnAdministracion;
        private FontAwesome.Sharp.IconButton iconBtnDepartamentos;
        private FontAwesome.Sharp.IconButton iconBtnTickets;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMaximaze;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private System.Windows.Forms.Label lblTitulo;
        private Design.DropDownMenu dwnGeneral;
        private System.Windows.Forms.ToolStripMenuItem MiCuentaToolStripMenuItem;
        private FontAwesome.Sharp.IconButton icbApellidoNombre;
        private Design.DropDownMenu dwnIcono;
        private System.Windows.Forms.ToolStripMenuItem miPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosPersonalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miPerfilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactoSoporteToolStripMenuItem;
        private Design.DropDownMenu dwnTickets;
        private System.Windows.Forms.ToolStripMenuItem nuevoTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misTicketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTicketsParaAprobar;
    }
}