namespace UI.Admins.Categoria
{
    partial class frmAltaCategoria
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblTipoCategoria = new System.Windows.Forms.Label();
            this.cmbTipoCategoria = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblGrupoTecnico = new System.Windows.Forms.Label();
            this.cmbGrupoTecnico = new System.Windows.Forms.ComboBox();
            this.chkAprobadorRequerido = new System.Windows.Forms.CheckBox();
            this.lblUsuarioAprobador = new System.Windows.Forms.Label();
            this.cmbClienteAprobador = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(40, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(160, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(40, 70);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 20);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(160, 70);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(240, 60);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblTipoCategoria
            // 
            this.lblTipoCategoria.Location = new System.Drawing.Point(40, 150);
            this.lblTipoCategoria.Name = "lblTipoCategoria";
            this.lblTipoCategoria.Size = new System.Drawing.Size(100, 20);
            this.lblTipoCategoria.TabIndex = 4;
            this.lblTipoCategoria.Text = "Tipo Categoría";
            // 
            // cmbTipoCategoria
            // 
            this.cmbTipoCategoria.Location = new System.Drawing.Point(160, 150);
            this.cmbTipoCategoria.Name = "cmbTipoCategoria";
            this.cmbTipoCategoria.Size = new System.Drawing.Size(240, 24);
            this.cmbTipoCategoria.TabIndex = 5;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.Location = new System.Drawing.Point(40, 190);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(100, 20);
            this.lblDepartamento.TabIndex = 6;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Location = new System.Drawing.Point(160, 190);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(240, 24);
            this.cmbDepartamento.TabIndex = 7;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // lblGrupoTecnico
            // 
            this.lblGrupoTecnico.Location = new System.Drawing.Point(40, 230);
            this.lblGrupoTecnico.Name = "lblGrupoTecnico";
            this.lblGrupoTecnico.Size = new System.Drawing.Size(100, 20);
            this.lblGrupoTecnico.TabIndex = 8;
            this.lblGrupoTecnico.Text = "Grupo Técnico";
            // 
            // cmbGrupoTecnico
            // 
            this.cmbGrupoTecnico.Location = new System.Drawing.Point(160, 230);
            this.cmbGrupoTecnico.Name = "cmbGrupoTecnico";
            this.cmbGrupoTecnico.Size = new System.Drawing.Size(240, 24);
            this.cmbGrupoTecnico.TabIndex = 9;
            // 
            // chkAprobadorRequerido
            // 
            this.chkAprobadorRequerido.Location = new System.Drawing.Point(160, 270);
            this.chkAprobadorRequerido.Name = "chkAprobadorRequerido";
            this.chkAprobadorRequerido.Size = new System.Drawing.Size(170, 24);
            this.chkAprobadorRequerido.TabIndex = 10;
            this.chkAprobadorRequerido.Text = "Aprobador requerido";
            // 
            // lblUsuarioAprobador
            // 
            this.lblUsuarioAprobador.Location = new System.Drawing.Point(20, 310);
            this.lblUsuarioAprobador.Name = "lblUsuarioAprobador";
            this.lblUsuarioAprobador.Size = new System.Drawing.Size(120, 20);
            this.lblUsuarioAprobador.TabIndex = 11;
            this.lblUsuarioAprobador.Text = "Cliente Aprobador";
            // 
            // cmbClienteAprobador
            // 
            this.cmbClienteAprobador.Location = new System.Drawing.Point(160, 310);
            this.cmbClienteAprobador.Name = "cmbClienteAprobador";
            this.cmbClienteAprobador.Size = new System.Drawing.Size(240, 24);
            this.cmbClienteAprobador.TabIndex = 12;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(40, 350);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 20);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "Prioridad";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.Location = new System.Drawing.Point(160, 350);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(240, 24);
            this.cmbPrioridad.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(160, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // frmAltaCategoria
            // 
            this.ClientSize = new System.Drawing.Size(480, 460);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblTipoCategoria);
            this.Controls.Add(this.cmbTipoCategoria);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.cmbDepartamento);
            this.Controls.Add(this.lblGrupoTecnico);
            this.Controls.Add(this.cmbGrupoTecnico);
            this.Controls.Add(this.chkAprobadorRequerido);
            this.Controls.Add(this.lblUsuarioAprobador);
            this.Controls.Add(this.cmbClienteAprobador);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.btnGuardar);
            this.Name = "frmAltaCategoria";
            this.Text = "Alta de Categoría";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblTipoCategoria;
        private System.Windows.Forms.ComboBox cmbTipoCategoria;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblGrupoTecnico;
        private System.Windows.Forms.ComboBox cmbGrupoTecnico;
        private System.Windows.Forms.CheckBox chkAprobadorRequerido;
        private System.Windows.Forms.Label lblUsuarioAprobador;
        private System.Windows.Forms.ComboBox cmbClienteAprobador;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Button btnGuardar;
    }
}
