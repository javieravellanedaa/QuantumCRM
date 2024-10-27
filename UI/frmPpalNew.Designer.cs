namespace UI
{
    partial class frmPpalNew
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.PanelDesktop = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.iconBtnGeneral = new FontAwesome.Sharp.IconButton();
            this.iconBtnTickets = new FontAwesome.Sharp.IconButton();
            this.iconBtnDepartamentos = new FontAwesome.Sharp.IconButton();
            this.iconBtnAdministracion = new FontAwesome.Sharp.IconButton();
            this.iconBtnConfiguracion = new FontAwesome.Sharp.IconButton();
            this.iconBtnIdioma = new FontAwesome.Sharp.IconButton();
            this.iconBtnDesloguear = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnMaximaze = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(87)))), ((int)(((byte)(192)))));
            this.PanelMenu.Controls.Add(this.iconBtnDesloguear);
            this.PanelMenu.Controls.Add(this.iconBtnIdioma);
            this.PanelMenu.Controls.Add(this.iconBtnConfiguracion);
            this.PanelMenu.Controls.Add(this.iconBtnAdministracion);
            this.PanelMenu.Controls.Add(this.iconBtnDepartamentos);
            this.PanelMenu.Controls.Add(this.iconBtnTickets);
            this.PanelMenu.Controls.Add(this.iconBtnGeneral);
            this.PanelMenu.Controls.Add(this.panel1);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(230, 450);
            this.PanelMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 96);
            this.panel1.TabIndex = 0;
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.Color.White;
            this.PanelTitleBar.Controls.Add(this.label1);
            this.PanelTitleBar.Controls.Add(this.btnMinimize);
            this.PanelTitleBar.Controls.Add(this.btnMaximaze);
            this.PanelTitleBar.Controls.Add(this.btnExit);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelTitleBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PanelTitleBar.Location = new System.Drawing.Point(230, 0);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(570, 60);
            this.PanelTitleBar.TabIndex = 1;
            this.PanelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTitleBar_Paint);
            this.PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            this.PanelTitleBar.Resize += new System.EventHandler(this.PanelTitleBar_Resize);
            // 
            // PanelDesktop
            // 
            this.PanelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktop.Location = new System.Drawing.Point(230, 60);
            this.PanelDesktop.Name = "PanelDesktop";
            this.PanelDesktop.Size = new System.Drawing.Size(570, 390);
            this.PanelDesktop.TabIndex = 2;
            this.PanelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDesktop_Paint);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(176, 3);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(54, 45);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // iconBtnGeneral
            // 
            this.iconBtnGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnGeneral.FlatAppearance.BorderSize = 0;
            this.iconBtnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnGeneral.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnGeneral.ForeColor = System.Drawing.Color.White;
            this.iconBtnGeneral.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.iconBtnGeneral.IconColor = System.Drawing.Color.White;
            this.iconBtnGeneral.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnGeneral.IconSize = 30;
            this.iconBtnGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnGeneral.Location = new System.Drawing.Point(0, 96);
            this.iconBtnGeneral.Name = "iconBtnGeneral";
            this.iconBtnGeneral.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnGeneral.Size = new System.Drawing.Size(230, 48);
            this.iconBtnGeneral.TabIndex = 1;
            this.iconBtnGeneral.Tag = "General";
            this.iconBtnGeneral.Text = "General";
            this.iconBtnGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnGeneral.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnGeneral.UseVisualStyleBackColor = true;
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
            this.iconBtnTickets.Location = new System.Drawing.Point(0, 144);
            this.iconBtnTickets.Name = "iconBtnTickets";
            this.iconBtnTickets.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnTickets.Size = new System.Drawing.Size(230, 48);
            this.iconBtnTickets.TabIndex = 2;
            this.iconBtnTickets.Tag = "Tickets";
            this.iconBtnTickets.Text = "Tickets";
            this.iconBtnTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnTickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnTickets.UseVisualStyleBackColor = true;
            // 
            // iconBtnDepartamentos
            // 
            this.iconBtnDepartamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnDepartamentos.FlatAppearance.BorderSize = 0;
            this.iconBtnDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnDepartamentos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnDepartamentos.ForeColor = System.Drawing.Color.White;
            this.iconBtnDepartamentos.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.iconBtnDepartamentos.IconColor = System.Drawing.Color.White;
            this.iconBtnDepartamentos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnDepartamentos.IconSize = 30;
            this.iconBtnDepartamentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDepartamentos.Location = new System.Drawing.Point(0, 192);
            this.iconBtnDepartamentos.Name = "iconBtnDepartamentos";
            this.iconBtnDepartamentos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnDepartamentos.Size = new System.Drawing.Size(230, 48);
            this.iconBtnDepartamentos.TabIndex = 3;
            this.iconBtnDepartamentos.Tag = "Departamentos";
            this.iconBtnDepartamentos.Text = "Departamentos";
            this.iconBtnDepartamentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDepartamentos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnDepartamentos.UseVisualStyleBackColor = true;
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
            this.iconBtnAdministracion.Location = new System.Drawing.Point(0, 240);
            this.iconBtnAdministracion.Name = "iconBtnAdministracion";
            this.iconBtnAdministracion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnAdministracion.Size = new System.Drawing.Size(230, 48);
            this.iconBtnAdministracion.TabIndex = 4;
            this.iconBtnAdministracion.Tag = "Administracion";
            this.iconBtnAdministracion.Text = "Administracion";
            this.iconBtnAdministracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnAdministracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnAdministracion.UseVisualStyleBackColor = true;
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
            this.iconBtnConfiguracion.Location = new System.Drawing.Point(0, 288);
            this.iconBtnConfiguracion.Name = "iconBtnConfiguracion";
            this.iconBtnConfiguracion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnConfiguracion.Size = new System.Drawing.Size(230, 48);
            this.iconBtnConfiguracion.TabIndex = 5;
            this.iconBtnConfiguracion.Tag = "Configuracion";
            this.iconBtnConfiguracion.Text = "Configuracion";
            this.iconBtnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // iconBtnIdioma
            // 
            this.iconBtnIdioma.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconBtnIdioma.FlatAppearance.BorderSize = 0;
            this.iconBtnIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnIdioma.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconBtnIdioma.ForeColor = System.Drawing.Color.White;
            this.iconBtnIdioma.IconChar = FontAwesome.Sharp.IconChar.Zhihu;
            this.iconBtnIdioma.IconColor = System.Drawing.Color.White;
            this.iconBtnIdioma.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnIdioma.IconSize = 30;
            this.iconBtnIdioma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnIdioma.Location = new System.Drawing.Point(0, 336);
            this.iconBtnIdioma.Name = "iconBtnIdioma";
            this.iconBtnIdioma.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconBtnIdioma.Size = new System.Drawing.Size(230, 48);
            this.iconBtnIdioma.TabIndex = 6;
            this.iconBtnIdioma.Tag = "Idioma";
            this.iconBtnIdioma.Text = "Idioma";
            this.iconBtnIdioma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnIdioma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnIdioma.UseVisualStyleBackColor = true;
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
            this.iconBtnDesloguear.Location = new System.Drawing.Point(0, 404);
            this.iconBtnDesloguear.Name = "iconBtnDesloguear";
            this.iconBtnDesloguear.Padding = new System.Windows.Forms.Padding(10, 0, 0, 15);
            this.iconBtnDesloguear.Size = new System.Drawing.Size(230, 46);
            this.iconBtnDesloguear.TabIndex = 7;
            this.iconBtnDesloguear.Tag = "Desloguear";
            this.iconBtnDesloguear.Text = "Desloguear";
            this.iconBtnDesloguear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconBtnDesloguear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconBtnDesloguear.UseVisualStyleBackColor = true;
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
            this.btnExit.Location = new System.Drawing.Point(525, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnMaximaze.Location = new System.Drawing.Point(479, 0);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.Size = new System.Drawing.Size(47, 25);
            this.btnMaximaze.TabIndex = 0;
            this.btnMaximaze.UseVisualStyleBackColor = false;
            this.btnMaximaze.Click += new System.EventHandler(this.btnMaximaze_Click);
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
            this.btnMinimize.Location = new System.Drawing.Point(441, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 25);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Size = new System.Drawing.Size(245, 51);
            this.label1.TabIndex = 4;
            this.label1.Text = "DASHBOARD";
            // 
            // frmPpalNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelDesktop);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.Name = "frmPpalNew";
            this.Text = "frmPpalNew";
            this.Load += new System.EventHandler(this.frmPpalNew_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPpalNew_MouseDown);
            this.Resize += new System.EventHandler(this.frmPpalNew_Resize);
            this.PanelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private FontAwesome.Sharp.IconButton iconBtnIdioma;
        private FontAwesome.Sharp.IconButton iconBtnConfiguracion;
        private FontAwesome.Sharp.IconButton iconBtnAdministracion;
        private FontAwesome.Sharp.IconButton iconBtnDepartamentos;
        private FontAwesome.Sharp.IconButton iconBtnTickets;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMaximaze;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private System.Windows.Forms.Label label1;
    }
}