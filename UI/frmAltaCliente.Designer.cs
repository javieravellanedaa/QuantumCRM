namespace UI
{
    partial class frmAltaCliente
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.ComboBox cbDepartamentos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtEmailContacto;
        private System.Windows.Forms.TextBox txtPreferenciaContacto;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.CheckBox chkEsAprobador;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblEmailContacto;
        private System.Windows.Forms.Label lblPreferencia;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEsAprobador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFilters = new System.Windows.Forms.Panel();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.cbDepartamentos = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmailContacto = new System.Windows.Forms.TextBox();
            this.txtPreferenciaContacto = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.chkEsAprobador = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblEmailContacto = new System.Windows.Forms.Label();
            this.lblPreferencia = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEsAprobador = new System.Windows.Forms.Label();

            this.panelFilters.SuspendLayout();
            this.SuspendLayout();

            // panelFilters
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFilters.BackColor = System.Drawing.Color.LightGray;
            this.panelFilters.Controls.Add(this.lblUsuario);
            this.panelFilters.Controls.Add(this.cbUsuarios);
            this.panelFilters.Controls.Add(this.lblDepartamento);
            this.panelFilters.Controls.Add(this.cbDepartamentos);
            this.panelFilters.Controls.Add(this.lblTelefono);
            this.panelFilters.Controls.Add(this.txtTelefono);
            this.panelFilters.Controls.Add(this.lblDireccion);
            this.panelFilters.Controls.Add(this.txtDireccion);
            this.panelFilters.Controls.Add(this.lblEmailContacto);
            this.panelFilters.Controls.Add(this.txtEmailContacto);
            this.panelFilters.Controls.Add(this.lblPreferencia);
            this.panelFilters.Controls.Add(this.txtPreferenciaContacto);
            this.panelFilters.Controls.Add(this.lblObservaciones);
            this.panelFilters.Controls.Add(this.txtObservaciones);
            this.panelFilters.Controls.Add(this.lblEstado);
            this.panelFilters.Controls.Add(this.chkActivo);
            this.panelFilters.Controls.Add(this.lblEsAprobador);
            this.panelFilters.Controls.Add(this.chkEsAprobador);
            this.panelFilters.Controls.Add(this.btnGuardar);
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(600, 500);
            this.panelFilters.TabIndex = 0;

            // lblUsuario
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new System.Drawing.Point(30, 20);
            this.cbUsuarios.Location = new System.Drawing.Point(160, 20);
            this.cbUsuarios.Size = new System.Drawing.Size(250, 23);

            // lblDepartamento
            this.lblDepartamento.Text = "Departamento:";
            this.lblDepartamento.Location = new System.Drawing.Point(30, 60);
            this.cbDepartamentos.Location = new System.Drawing.Point(160, 60);
            this.cbDepartamentos.Size = new System.Drawing.Size(250, 23);

            // lblTelefono
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(30, 100);
            this.txtTelefono.Location = new System.Drawing.Point(160, 100);
            this.txtTelefono.Size = new System.Drawing.Size(250, 23);

            // lblDireccion
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(30, 140);
            this.txtDireccion.Location = new System.Drawing.Point(160, 140);
            this.txtDireccion.Size = new System.Drawing.Size(250, 23);

            // lblEmailContacto
            this.lblEmailContacto.Text = "Email de Contacto:";
            this.lblEmailContacto.Location = new System.Drawing.Point(30, 180);
            this.txtEmailContacto.Location = new System.Drawing.Point(160, 180);
            this.txtEmailContacto.Size = new System.Drawing.Size(250, 23);

            // lblPreferencia
            this.lblPreferencia.Text = "Preferencia de Contacto:";
            this.lblPreferencia.Location = new System.Drawing.Point(30, 220);
            this.txtPreferenciaContacto.Location = new System.Drawing.Point(160, 220);
            this.txtPreferenciaContacto.Size = new System.Drawing.Size(250, 23);

            // lblObservaciones
            this.lblObservaciones.Text = "Observaciones:";
            this.lblObservaciones.Location = new System.Drawing.Point(30, 260);
            this.txtObservaciones.Location = new System.Drawing.Point(160, 260);
            this.txtObservaciones.Size = new System.Drawing.Size(250, 60);
            this.txtObservaciones.Multiline = true;

            // lblEstado
            this.lblEstado.Text = "Activo:";
            this.lblEstado.Location = new System.Drawing.Point(30, 330);
            this.chkActivo.Location = new System.Drawing.Point(160, 330);

            // lblEsAprobador
            this.lblEsAprobador.Text = "¿Es Aprobador?";
            this.lblEsAprobador.Location = new System.Drawing.Point(30, 360);
            this.chkEsAprobador.Location = new System.Drawing.Point(160, 360);

            // btnGuardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(160, 400);
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // frmAltaCliente
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panelFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAltaCliente";
            this.Text = "Alta de Cliente";

            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
