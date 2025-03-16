namespace UI
{
    partial class frmAdministrarIdioma
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. 
        /// No modifiques el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlIdioma = new System.Windows.Forms.TabControl();
            this.tabPageTraducciones = new System.Windows.Forms.TabPage();
            this.btnGuardarTraducciones = new System.Windows.Forms.Button();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.tabPageIdiomas = new System.Windows.Forms.TabPage();
            this.groupBoxAgregarIdioma = new System.Windows.Forms.GroupBox();
            this.btnAgregarNuevoIdioma = new System.Windows.Forms.Button();
            this.txtNombreIdioma = new System.Windows.Forms.TextBox();
            this.lblNombreIdioma = new System.Windows.Forms.Label();
            this.groupBoxIdiomasActuales = new System.Windows.Forms.GroupBox();
            this.lstIdiomasActivos = new System.Windows.Forms.ListBox();
            this.tabPageInactivos = new System.Windows.Forms.TabPage();
            this.groupBoxIdiomasInactivos = new System.Windows.Forms.GroupBox();
            this.lstIdiomasInactivos = new System.Windows.Forms.ListBox();

            // NUEVO GROUPBOX para traducciones de idiomas inactivos:
            this.groupBoxCompletarTraduccionesInactivos = new System.Windows.Forms.GroupBox();
            this.dgvTraduccionesInactivos = new System.Windows.Forms.DataGridView();
            this.btnActivarIdiomaInactivo = new System.Windows.Forms.Button();

            this.tabPageBorrar = new System.Windows.Forms.TabPage();
            this.groupBoxBorrarIdiomas = new System.Windows.Forms.GroupBox();
            this.btnBorrarIdioma = new System.Windows.Forms.Button();
            this.lstIdiomasBorrar = new System.Windows.Forms.ListBox();
            this.lblBorrarIdioma = new System.Windows.Forms.Label();
            this.btnCerrarFormulario = new System.Windows.Forms.Button();

            this.tabControlIdioma.SuspendLayout();
            this.tabPageTraducciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.tabPageIdiomas.SuspendLayout();
            this.groupBoxAgregarIdioma.SuspendLayout();
            this.groupBoxIdiomasActuales.SuspendLayout();
            this.tabPageInactivos.SuspendLayout();
            this.groupBoxIdiomasInactivos.SuspendLayout();
            this.groupBoxCompletarTraduccionesInactivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraduccionesInactivos)).BeginInit();
            this.tabPageBorrar.SuspendLayout();
            this.groupBoxBorrarIdiomas.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlIdioma
            // 
            this.tabControlIdioma.Controls.Add(this.tabPageTraducciones);
            this.tabControlIdioma.Controls.Add(this.tabPageIdiomas);
            this.tabControlIdioma.Controls.Add(this.tabPageInactivos);
            this.tabControlIdioma.Controls.Add(this.tabPageBorrar);
            this.tabControlIdioma.Location = new System.Drawing.Point(12, 10);
            this.tabControlIdioma.Name = "tabControlIdioma";
            this.tabControlIdioma.SelectedIndex = 0;
            this.tabControlIdioma.Size = new System.Drawing.Size(776, 430);
            this.tabControlIdioma.TabIndex = 1;
            // 
            // tabPageTraducciones
            // 
            this.tabPageTraducciones.Controls.Add(this.btnGuardarTraducciones);
            this.tabPageTraducciones.Controls.Add(this.dgvTraducciones);
            this.tabPageTraducciones.Controls.Add(this.lblIdioma);
            this.tabPageTraducciones.Controls.Add(this.cmbIdioma);
            this.tabPageTraducciones.Location = new System.Drawing.Point(4, 22);
            this.tabPageTraducciones.Name = "tabPageTraducciones";
            this.tabPageTraducciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTraducciones.Size = new System.Drawing.Size(768, 404);
            this.tabPageTraducciones.TabIndex = 0;
            this.tabPageTraducciones.Text = "Traducciones";
            this.tabPageTraducciones.UseVisualStyleBackColor = true;
            // 
            // btnGuardarTraducciones
            // 
            this.btnGuardarTraducciones.Location = new System.Drawing.Point(687, 365);
            this.btnGuardarTraducciones.Name = "btnGuardarTraducciones";
            this.btnGuardarTraducciones.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTraducciones.TabIndex = 3;
            this.btnGuardarTraducciones.Text = "Guardar";
            this.btnGuardarTraducciones.UseVisualStyleBackColor = true;
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.Location = new System.Drawing.Point(6, 37);
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.Size = new System.Drawing.Size(756, 311);
            this.dgvTraducciones.TabIndex = 2;
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(6, 13);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 1;
            this.lblIdioma.Text = "Idioma:";
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(50, 10);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(282, 21);
            this.cmbIdioma.TabIndex = 0;
            // 
            // tabPageIdiomas
            // 
            this.tabPageIdiomas.Controls.Add(this.groupBoxAgregarIdioma);
            this.tabPageIdiomas.Controls.Add(this.groupBoxIdiomasActuales);
            this.tabPageIdiomas.Location = new System.Drawing.Point(4, 22);
            this.tabPageIdiomas.Name = "tabPageIdiomas";
            this.tabPageIdiomas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIdiomas.Size = new System.Drawing.Size(768, 404);
            this.tabPageIdiomas.TabIndex = 1;
            this.tabPageIdiomas.Text = "Idiomas Activos";
            this.tabPageIdiomas.UseVisualStyleBackColor = true;
            // 
            // groupBoxAgregarIdioma
            // 
            this.groupBoxAgregarIdioma.Controls.Add(this.btnAgregarNuevoIdioma);
            this.groupBoxAgregarIdioma.Controls.Add(this.txtNombreIdioma);
            this.groupBoxAgregarIdioma.Controls.Add(this.lblNombreIdioma);
            this.groupBoxAgregarIdioma.Location = new System.Drawing.Point(356, 6);
            this.groupBoxAgregarIdioma.Name = "groupBoxAgregarIdioma";
            this.groupBoxAgregarIdioma.Size = new System.Drawing.Size(406, 82);
            this.groupBoxAgregarIdioma.TabIndex = 4;
            this.groupBoxAgregarIdioma.TabStop = false;
            this.groupBoxAgregarIdioma.Text = "Agregar un nuevo idioma";
            // 
            // btnAgregarNuevoIdioma
            // 
            this.btnAgregarNuevoIdioma.Location = new System.Drawing.Point(9, 45);
            this.btnAgregarNuevoIdioma.Name = "btnAgregarNuevoIdioma";
            this.btnAgregarNuevoIdioma.Size = new System.Drawing.Size(391, 23);
            this.btnAgregarNuevoIdioma.TabIndex = 2;
            this.btnAgregarNuevoIdioma.Text = "Agregar Idioma";
            this.btnAgregarNuevoIdioma.UseVisualStyleBackColor = true;
            // 
            // txtNombreIdioma
            // 
            this.txtNombreIdioma.Location = new System.Drawing.Point(50, 19);
            this.txtNombreIdioma.MaxLength = 50;
            this.txtNombreIdioma.Name = "txtNombreIdioma";
            this.txtNombreIdioma.Size = new System.Drawing.Size(350, 20);
            this.txtNombreIdioma.TabIndex = 1;
            // 
            // lblNombreIdioma
            // 
            this.lblNombreIdioma.AutoSize = true;
            this.lblNombreIdioma.Location = new System.Drawing.Point(6, 22);
            this.lblNombreIdioma.Name = "lblNombreIdioma";
            this.lblNombreIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblNombreIdioma.TabIndex = 0;
            this.lblNombreIdioma.Text = "Idioma:";
            // 
            // groupBoxIdiomasActuales
            // 
            this.groupBoxIdiomasActuales.Controls.Add(this.lstIdiomasActivos);
            this.groupBoxIdiomasActuales.Location = new System.Drawing.Point(6, 6);
            this.groupBoxIdiomasActuales.Name = "groupBoxIdiomasActuales";
            this.groupBoxIdiomasActuales.Size = new System.Drawing.Size(344, 392);
            this.groupBoxIdiomasActuales.TabIndex = 3;
            this.groupBoxIdiomasActuales.TabStop = false;
            this.groupBoxIdiomasActuales.Text = "Idiomas Activos";
            // 
            // lstIdiomasActivos
            // 
            this.lstIdiomasActivos.FormattingEnabled = true;
            this.lstIdiomasActivos.Location = new System.Drawing.Point(6, 19);
            this.lstIdiomasActivos.Name = "lstIdiomasActivos";
            this.lstIdiomasActivos.Size = new System.Drawing.Size(332, 368);
            this.lstIdiomasActivos.TabIndex = 1;
            // 
            // tabPageInactivos
            // 
            this.tabPageInactivos.Controls.Add(this.groupBoxCompletarTraduccionesInactivos);
            this.tabPageInactivos.Controls.Add(this.groupBoxIdiomasInactivos);
            this.tabPageInactivos.Location = new System.Drawing.Point(4, 22);
            this.tabPageInactivos.Name = "tabPageInactivos";
            this.tabPageInactivos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInactivos.Size = new System.Drawing.Size(768, 404);
            this.tabPageInactivos.TabIndex = 2;
            this.tabPageInactivos.Text = "Idiomas Inactivos";
            this.tabPageInactivos.UseVisualStyleBackColor = true;
            // 
            // groupBoxIdiomasInactivos
            // 
            this.groupBoxIdiomasInactivos.Controls.Add(this.lstIdiomasInactivos);
            this.groupBoxIdiomasInactivos.Location = new System.Drawing.Point(6, 6);
            this.groupBoxIdiomasInactivos.Name = "groupBoxIdiomasInactivos";
            this.groupBoxIdiomasInactivos.Size = new System.Drawing.Size(344, 392);
            this.groupBoxIdiomasInactivos.TabIndex = 4;
            this.groupBoxIdiomasInactivos.TabStop = false;
            this.groupBoxIdiomasInactivos.Text = "Lista de Idiomas Inactivos";
            // 
            // lstIdiomasInactivos
            // 
            this.lstIdiomasInactivos.FormattingEnabled = true;
            this.lstIdiomasInactivos.Location = new System.Drawing.Point(6, 19);
            this.lstIdiomasInactivos.Name = "lstIdiomasInactivos";
            this.lstIdiomasInactivos.Size = new System.Drawing.Size(332, 368);
            this.lstIdiomasInactivos.TabIndex = 0;
            // 
            // groupBoxCompletarTraduccionesInactivos
            // 
            this.groupBoxCompletarTraduccionesInactivos.Controls.Add(this.dgvTraduccionesInactivos);
            this.groupBoxCompletarTraduccionesInactivos.Controls.Add(this.btnActivarIdiomaInactivo);
            this.groupBoxCompletarTraduccionesInactivos.Location = new System.Drawing.Point(356, 6);
            this.groupBoxCompletarTraduccionesInactivos.Name = "groupBoxCompletarTraduccionesInactivos";
            this.groupBoxCompletarTraduccionesInactivos.Size = new System.Drawing.Size(406, 392);
            this.groupBoxCompletarTraduccionesInactivos.TabIndex = 5;
            this.groupBoxCompletarTraduccionesInactivos.TabStop = false;
            this.groupBoxCompletarTraduccionesInactivos.Text = "Completar Traducciones Faltantes";
            // 
            // dgvTraduccionesInactivos
            // 
            this.dgvTraduccionesInactivos.AllowUserToAddRows = false;
            this.dgvTraduccionesInactivos.AllowUserToDeleteRows = false;
            this.dgvTraduccionesInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraduccionesInactivos.Location = new System.Drawing.Point(9, 19);
            this.dgvTraduccionesInactivos.Name = "dgvTraduccionesInactivos";
            this.dgvTraduccionesInactivos.Size = new System.Drawing.Size(391, 329);
            this.dgvTraduccionesInactivos.TabIndex = 1;
            // 
            // btnActivarIdiomaInactivo
            // 
            this.btnActivarIdiomaInactivo.Location = new System.Drawing.Point(9, 354);
            this.btnActivarIdiomaInactivo.Name = "btnActivarIdiomaInactivo";
            this.btnActivarIdiomaInactivo.Size = new System.Drawing.Size(391, 23);
            this.btnActivarIdiomaInactivo.TabIndex = 0;
            this.btnActivarIdiomaInactivo.Text = "Activar Idioma Seleccionado";
            this.btnActivarIdiomaInactivo.UseVisualStyleBackColor = true;
            // 
            // tabPageBorrar
            // 
            this.tabPageBorrar.Controls.Add(this.groupBoxBorrarIdiomas);
            this.tabPageBorrar.Location = new System.Drawing.Point(4, 22);
            this.tabPageBorrar.Name = "tabPageBorrar";
            this.tabPageBorrar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBorrar.Size = new System.Drawing.Size(768, 404);
            this.tabPageBorrar.TabIndex = 3;
            this.tabPageBorrar.Text = "Borrar Idiomas";
            this.tabPageBorrar.UseVisualStyleBackColor = true;
            // 
            // groupBoxBorrarIdiomas
            // 
            this.groupBoxBorrarIdiomas.Controls.Add(this.btnBorrarIdioma);
            this.groupBoxBorrarIdiomas.Controls.Add(this.lstIdiomasBorrar);
            this.groupBoxBorrarIdiomas.Controls.Add(this.lblBorrarIdioma);
            this.groupBoxBorrarIdiomas.Location = new System.Drawing.Point(6, 6);
            this.groupBoxBorrarIdiomas.Name = "groupBoxBorrarIdiomas";
            this.groupBoxBorrarIdiomas.Size = new System.Drawing.Size(366, 392);
            this.groupBoxBorrarIdiomas.TabIndex = 0;
            this.groupBoxBorrarIdiomas.TabStop = false;
            this.groupBoxBorrarIdiomas.Text = "Eliminar Idiomas";
            // 
            // btnBorrarIdioma
            // 
            this.btnBorrarIdioma.Location = new System.Drawing.Point(9, 356);
            this.btnBorrarIdioma.Name = "btnBorrarIdioma";
            this.btnBorrarIdioma.Size = new System.Drawing.Size(351, 23);
            this.btnBorrarIdioma.TabIndex = 2;
            this.btnBorrarIdioma.Text = "Borrar Idioma Seleccionado";
            this.btnBorrarIdioma.UseVisualStyleBackColor = true;
            // 
            // lstIdiomasBorrar
            // 
            this.lstIdiomasBorrar.FormattingEnabled = true;
            this.lstIdiomasBorrar.Location = new System.Drawing.Point(9, 37);
            this.lstIdiomasBorrar.Name = "lstIdiomasBorrar";
            this.lstIdiomasBorrar.Size = new System.Drawing.Size(351, 303);
            this.lstIdiomasBorrar.TabIndex = 1;
            // 
            // lblBorrarIdioma
            // 
            this.lblBorrarIdioma.AutoSize = true;
            this.lblBorrarIdioma.Location = new System.Drawing.Point(6, 21);
            this.lblBorrarIdioma.Name = "lblBorrarIdioma";
            this.lblBorrarIdioma.Size = new System.Drawing.Size(139, 13);
            this.lblBorrarIdioma.TabIndex = 0;
            this.lblBorrarIdioma.Text = "Seleccione un idioma a borrar";
            // 
            // btnCerrarFormulario
            // 
            this.btnCerrarFormulario.Location = new System.Drawing.Point(713, 446);
            this.btnCerrarFormulario.Name = "btnCerrarFormulario";
            this.btnCerrarFormulario.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarFormulario.TabIndex = 2;
            this.btnCerrarFormulario.Text = "Cerrar";
            this.btnCerrarFormulario.UseVisualStyleBackColor = true;
            // 
            // frmAdministrarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.btnCerrarFormulario);
            this.Controls.Add(this.tabControlIdioma);
            this.Name = "frmAdministrarIdioma";
            this.Text = "Administrar Idiomas y Traducciones";

            // Eventos
            this.Load += new System.EventHandler(this.frmAdministrarIdioma_Load);
            this.btnCerrarFormulario.Click += new System.EventHandler(this.btnCerrarFormulario_Click);
            this.btnGuardarTraducciones.Click += new System.EventHandler(this.btnGuardarTraducciones_Click);
            this.btnAgregarNuevoIdioma.Click += new System.EventHandler(this.btnAgregarNuevoIdioma_Click);
            this.lstIdiomasActivos.SelectedIndexChanged += new System.EventHandler(this.lstIdiomasActivos_SelectedIndexChanged);
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            this.btnBorrarIdioma.Click += new System.EventHandler(this.btnBorrarIdioma_Click);
            this.lstIdiomasInactivos.SelectedIndexChanged += new System.EventHandler(this.lstIdiomasInactivos_SelectedIndexChanged);
            this.btnActivarIdiomaInactivo.Click += new System.EventHandler(this.btnActivarIdiomaInactivo_Click);

            this.tabControlIdioma.ResumeLayout(false);
            this.tabPageTraducciones.ResumeLayout(false);
            this.tabPageTraducciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.tabPageIdiomas.ResumeLayout(false);
            this.groupBoxAgregarIdioma.ResumeLayout(false);
            this.groupBoxAgregarIdioma.PerformLayout();
            this.groupBoxIdiomasActuales.ResumeLayout(false);
            this.tabPageInactivos.ResumeLayout(false);
            this.groupBoxIdiomasInactivos.ResumeLayout(false);
            this.groupBoxCompletarTraduccionesInactivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraduccionesInactivos)).EndInit();
            this.tabPageBorrar.ResumeLayout(false);
            this.groupBoxBorrarIdiomas.ResumeLayout(false);
            this.groupBoxBorrarIdiomas.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlIdioma;
        private System.Windows.Forms.TabPage tabPageTraducciones;
        private System.Windows.Forms.Button btnGuardarTraducciones;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.TabPage tabPageIdiomas;
        private System.Windows.Forms.GroupBox groupBoxAgregarIdioma;
        private System.Windows.Forms.Button btnAgregarNuevoIdioma;
        private System.Windows.Forms.TextBox txtNombreIdioma;
        private System.Windows.Forms.Label lblNombreIdioma;
        private System.Windows.Forms.GroupBox groupBoxIdiomasActuales;
        private System.Windows.Forms.ListBox lstIdiomasActivos;
        private System.Windows.Forms.Button btnCerrarFormulario;
        private System.Windows.Forms.TabPage tabPageInactivos;
        private System.Windows.Forms.GroupBox groupBoxIdiomasInactivos;
        private System.Windows.Forms.ListBox lstIdiomasInactivos;

        // NUEVO:
        private System.Windows.Forms.GroupBox groupBoxCompletarTraduccionesInactivos;
        private System.Windows.Forms.DataGridView dgvTraduccionesInactivos;
        private System.Windows.Forms.Button btnActivarIdiomaInactivo;

        private System.Windows.Forms.TabPage tabPageBorrar;
        private System.Windows.Forms.GroupBox groupBoxBorrarIdiomas;
        private System.Windows.Forms.Button btnBorrarIdioma;
        private System.Windows.Forms.ListBox lstIdiomasBorrar;
        private System.Windows.Forms.Label lblBorrarIdioma;
    }
}
