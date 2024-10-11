namespace UI
{
    partial class frmPpal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPerfilMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestores = new System.Windows.Forms.ToolStripMenuItem();
            this.gestorDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestorDeGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovedades = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableroGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelLoginUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.crearCamposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.menuGestores,
            this.menuEmpleados,
            this.menuNovedades,
            this.estadisticasToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPerfilMenuItem,
            this.iniciarSesiónToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.sesiónToolStripMenuItem.Text = "Perfil";
            // 
            // verPerfilMenuItem
            // 
            this.verPerfilMenuItem.Name = "verPerfilMenuItem";
            this.verPerfilMenuItem.Size = new System.Drawing.Size(143, 22);
            this.verPerfilMenuItem.Text = "Ver Perfil";
            this.verPerfilMenuItem.Click += new System.EventHandler(this.verPerfilMenuItem_Click);
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            this.iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            this.iniciarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            this.iniciarSesiónToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesiónToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // menuGestores
            // 
            this.menuGestores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestorDePermisosToolStripMenuItem,
            this.gestorDeGruposToolStripMenuItem});
            this.menuGestores.Name = "menuGestores";
            this.menuGestores.Size = new System.Drawing.Size(64, 22);
            this.menuGestores.Text = "Gestores";
            // 
            // gestorDePermisosToolStripMenuItem
            // 
            this.gestorDePermisosToolStripMenuItem.Name = "gestorDePermisosToolStripMenuItem";
            this.gestorDePermisosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestorDePermisosToolStripMenuItem.Text = "Gestor de Permisos";
            this.gestorDePermisosToolStripMenuItem.Click += new System.EventHandler(this.gestorDePermisosToolStripMenuItem_Click);
            // 
            // gestorDeGruposToolStripMenuItem
            // 
            this.gestorDeGruposToolStripMenuItem.Name = "gestorDeGruposToolStripMenuItem";
            this.gestorDeGruposToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestorDeGruposToolStripMenuItem.Text = "Gestor de Usuarios";
            this.gestorDeGruposToolStripMenuItem.Click += new System.EventHandler(this.gestorDeGruposToolStripMenuItem_Click);
            // 
            // menuEmpleados
            // 
            this.menuEmpleados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem,
            this.agregarToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.menuEmpleados.Name = "menuEmpleados";
            this.menuEmpleados.Size = new System.Drawing.Size(77, 22);
            this.menuEmpleados.Text = "Empleados";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // menuNovedades
            // 
            this.menuNovedades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem1});
            this.menuNovedades.Name = "menuNovedades";
            this.menuNovedades.Size = new System.Drawing.Size(78, 22);
            this.menuNovedades.Text = "Novedades";
            // 
            // verToolStripMenuItem1
            // 
            this.verToolStripMenuItem1.Name = "verToolStripMenuItem1";
            this.verToolStripMenuItem1.Size = new System.Drawing.Size(90, 22);
            this.verToolStripMenuItem1.Text = "Ver";
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableroGeneralToolStripMenuItem,
            this.misTicketsToolStripMenuItem});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // tableroGeneralToolStripMenuItem
            // 
            this.tableroGeneralToolStripMenuItem.Name = "tableroGeneralToolStripMenuItem";
            this.tableroGeneralToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tableroGeneralToolStripMenuItem.Text = "Tablero General";
            // 
            // misTicketsToolStripMenuItem
            // 
            this.misTicketsToolStripMenuItem.Name = "misTicketsToolStripMenuItem";
            this.misTicketsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.misTicketsToolStripMenuItem.Text = "Mis tickets";
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearPedidoToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.crearCamposToolStripMenuItem,
            this.crearCategoriasToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // crearPedidoToolStripMenuItem
            // 
            this.crearPedidoToolStripMenuItem.Name = "crearPedidoToolStripMenuItem";
            this.crearPedidoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearPedidoToolStripMenuItem.Text = "Crear Ticket";
            this.crearPedidoToolStripMenuItem.Click += new System.EventHandler(this.crearPedidoToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioGeneralToolStripMenuItem,
            this.inventarioProyectoToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // inventarioGeneralToolStripMenuItem
            // 
            this.inventarioGeneralToolStripMenuItem.Name = "inventarioGeneralToolStripMenuItem";
            this.inventarioGeneralToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.inventarioGeneralToolStripMenuItem.Text = "Inventario General";
            // 
            // inventarioProyectoToolStripMenuItem
            // 
            this.inventarioProyectoToolStripMenuItem.Name = "inventarioProyectoToolStripMenuItem";
            this.inventarioProyectoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.inventarioProyectoToolStripMenuItem.Text = "Inventario Proyecto";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarToolStripMenuItem,
            this.actualToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.idiomaToolStripMenuItem.Text = "Idioma";
            this.idiomaToolStripMenuItem.TextChanged += new System.EventHandler(this.idiomaToolStripMenuItem_TextChanged);
            // 
            // cambiarToolStripMenuItem
            // 
            this.cambiarToolStripMenuItem.Name = "cambiarToolStripMenuItem";
            this.cambiarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarToolStripMenuItem.Text = "Administrar";
            this.cambiarToolStripMenuItem.Click += new System.EventHandler(this.cambiarToolStripMenuItem_Click);
            // 
            // actualToolStripMenuItem
            // 
            this.actualToolStripMenuItem.Name = "actualToolStripMenuItem";
            this.actualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.actualToolStripMenuItem.Text = "Actual";
            this.actualToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.actualToolStripMenuItem_DropDownItemClicked);
            this.actualToolStripMenuItem.Click += new System.EventHandler(this.actualToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripLabelLoginUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(777, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "Usuario";
            // 
            // toolStripLabelLoginUser
            // 
            this.toolStripLabelLoginUser.Name = "toolStripLabelLoginUser";
            this.toolStripLabelLoginUser.Size = new System.Drawing.Size(110, 17);
            this.toolStripLabelLoginUser.Text = "[Sesión no iniciada]";
            // 
            // crearCamposToolStripMenuItem
            // 
            this.crearCamposToolStripMenuItem.Name = "crearCamposToolStripMenuItem";
            this.crearCamposToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearCamposToolStripMenuItem.Text = "Crear Campos";
            this.crearCamposToolStripMenuItem.Click += new System.EventHandler(this.crearCamposToolStripMenuItem_Click);
            // 
            // crearCategoriasToolStripMenuItem
            // 
            this.crearCategoriasToolStripMenuItem.Name = "crearCategoriasToolStripMenuItem";
            this.crearCategoriasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearCategoriasToolStripMenuItem.Text = "Crear Categorias";
            this.crearCategoriasToolStripMenuItem.Click += new System.EventHandler(this.crearCategoriasToolStripMenuItem_Click);
            // 
            // frmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPpal";
            this.Text = "Internal CRM Software";
            this.Load += new System.EventHandler(this.frmPpal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPerfilMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGestores;
        private System.Windows.Forms.ToolStripMenuItem gestorDePermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuEmpleados;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNovedades;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelLoginUser;
        private System.Windows.Forms.ToolStripMenuItem gestorDeGruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableroGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misTicketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearCamposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearCategoriasToolStripMenuItem;
    }
}