using System.Windows.Forms;

namespace UI
{
    partial class frmBitacora
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelFiltros;
        private ComboBox cmbClases;
        private ComboBox cmbAcciones;
        private ComboBox cmbUsuarios;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnCerrar;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblClase;
        private Label lblAccion;
        private Label lblUsuario;
        private DataGridView dgvBitacora;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblClase = new System.Windows.Forms.Label();
            this.cmbClases = new System.Windows.Forms.ComboBox();
            this.lblAccion = new System.Windows.Forms.Label();
            this.cmbAcciones = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblClase);
            this.panelFiltros.Controls.Add(this.cmbClases);
            this.panelFiltros.Controls.Add(this.lblAccion);
            this.panelFiltros.Controls.Add(this.cmbAcciones);
            this.panelFiltros.Controls.Add(this.lblUsuario);
            this.panelFiltros.Controls.Add(this.cmbUsuarios);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.btnCerrar);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(950, 160);
            this.panelFiltros.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.Location = new System.Drawing.Point(10, 10);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(54, 23);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(70, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(150, 22);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(10, 40);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(54, 23);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(70, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(150, 22);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblClase
            // 
            this.lblClase.Location = new System.Drawing.Point(250, 10);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(100, 23);
            this.lblClase.TabIndex = 4;
            this.lblClase.Text = "Clase:";
            // 
            // cmbClases
            // 
            this.cmbClases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClases.Location = new System.Drawing.Point(253, 40);
            this.cmbClases.Name = "cmbClases";
            this.cmbClases.Size = new System.Drawing.Size(150, 24);
            this.cmbClases.TabIndex = 5;
            // 
            // lblAccion
            // 
            this.lblAccion.Location = new System.Drawing.Point(450, 10);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(100, 23);
            this.lblAccion.TabIndex = 6;
            this.lblAccion.Text = "Acción:";
            // 
            // cmbAcciones
            // 
            this.cmbAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcciones.Location = new System.Drawing.Point(453, 39);
            this.cmbAcciones.Name = "cmbAcciones";
            this.cmbAcciones.Size = new System.Drawing.Size(150, 24);
            this.cmbAcciones.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(650, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario:";
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.Location = new System.Drawing.Point(635, 41);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(150, 24);
            this.cmbUsuarios.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(820, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 35);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(820, 80);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dgvBitacora.ColumnHeadersHeight = 29;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.Location = new System.Drawing.Point(0, 160);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.RowHeadersWidth = 51;
            this.dgvBitacora.Size = new System.Drawing.Size(950, 440);
            this.dgvBitacora.TabIndex = 0;
            // 
            // frmBitacora
            // 
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.dgvBitacora);
            this.Controls.Add(this.panelFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBitacora";
            this.Text = "Bitácora del Sistema";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.panelFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
