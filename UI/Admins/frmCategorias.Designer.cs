namespace UI
{
    partial class frmCategorias
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
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNombreDeLaCategoria = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.cmbTiposCategoria = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbGruposTecnicos = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblGrupoTecnico = new System.Windows.Forms.Label();
            this.cmbAprobador = new System.Windows.Forms.ComboBox();
            this.lblAprobador = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAprobacion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.gbxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(402, 119);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 2;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(569, 146);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(116, 32);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Borrar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(706, 146);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(134, 32);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNombreDeLaCategoria
            // 
            this.lblNombreDeLaCategoria.AutoSize = true;
            this.lblNombreDeLaCategoria.Location = new System.Drawing.Point(6, 19);
            this.lblNombreDeLaCategoria.Name = "lblNombreDeLaCategoria";
            this.lblNombreDeLaCategoria.Size = new System.Drawing.Size(117, 13);
            this.lblNombreDeLaCategoria.TabIndex = 7;
            this.lblNombreDeLaCategoria.Text = "Nombre de la categoria";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(142, 16);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(329, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(12, 231);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.Size = new System.Drawing.Size(855, 254);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellContentClick);
            this.dgvCategorias.SelectionChanged += new System.EventHandler(this.dgvCategorias_SelectionChanged);
            // 
            // gbxDatos
            // 
            this.gbxDatos.Controls.Add(this.cmbAprobacion);
            this.gbxDatos.Controls.Add(this.label1);
            this.gbxDatos.Controls.Add(this.cmbTiposCategoria);
            this.gbxDatos.Controls.Add(this.lblTipo);
            this.gbxDatos.Controls.Add(this.cmbGruposTecnicos);
            this.gbxDatos.Controls.Add(this.btnEliminar);
            this.gbxDatos.Controls.Add(this.cmbDepartamento);
            this.gbxDatos.Controls.Add(this.lblGrupoTecnico);
            this.gbxDatos.Controls.Add(this.cmbAprobador);
            this.gbxDatos.Controls.Add(this.lblAprobador);
            this.gbxDatos.Controls.Add(this.btnGuardar);
            this.gbxDatos.Controls.Add(this.lblEstado);
            this.gbxDatos.Controls.Add(this.lblDepartamento);
            this.gbxDatos.Controls.Add(this.txtDescripcion);
            this.gbxDatos.Controls.Add(this.lblDescripcion);
            this.gbxDatos.Controls.Add(this.lblNombreDeLaCategoria);
            this.gbxDatos.Controls.Add(this.txtNombre);
            this.gbxDatos.Controls.Add(this.chkEstado);
            this.gbxDatos.Location = new System.Drawing.Point(12, 26);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Size = new System.Drawing.Size(855, 184);
            this.gbxDatos.TabIndex = 10;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos";
            // 
            // cmbTiposCategoria
            // 
            this.cmbTiposCategoria.FormattingEnabled = true;
            this.cmbTiposCategoria.Location = new System.Drawing.Point(142, 145);
            this.cmbTiposCategoria.Name = "cmbTiposCategoria";
            this.cmbTiposCategoria.Size = new System.Drawing.Size(163, 21);
            this.cmbTiposCategoria.TabIndex = 19;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(6, 153);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 18;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbGruposTecnicos
            // 
            this.cmbGruposTecnicos.FormattingEnabled = true;
            this.cmbGruposTecnicos.Location = new System.Drawing.Point(593, 95);
            this.cmbGruposTecnicos.Name = "cmbGruposTecnicos";
            this.cmbGruposTecnicos.Size = new System.Drawing.Size(247, 21);
            this.cmbGruposTecnicos.TabIndex = 17;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(593, 36);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(247, 21);
            this.cmbDepartamento.TabIndex = 16;
            // 
            // lblGrupoTecnico
            // 
            this.lblGrupoTecnico.AutoSize = true;
            this.lblGrupoTecnico.Location = new System.Drawing.Point(509, 98);
            this.lblGrupoTecnico.Name = "lblGrupoTecnico";
            this.lblGrupoTecnico.Size = new System.Drawing.Size(78, 13);
            this.lblGrupoTecnico.TabIndex = 15;
            this.lblGrupoTecnico.Text = "Grupo Técnico";
            // 
            // cmbAprobador
            // 
            this.cmbAprobador.FormattingEnabled = true;
            this.cmbAprobador.Location = new System.Drawing.Point(142, 115);
            this.cmbAprobador.Name = "cmbAprobador";
            this.cmbAprobador.Size = new System.Drawing.Size(163, 21);
            this.cmbAprobador.TabIndex = 14;
            this.cmbAprobador.SelectedIndexChanged += new System.EventHandler(this.cmbAprobador_SelectedIndexChanged);
            // 
            // lblAprobador
            // 
            this.lblAprobador.AutoSize = true;
            this.lblAprobador.Location = new System.Drawing.Point(6, 115);
            this.lblAprobador.Name = "lblAprobador";
            this.lblAprobador.Size = new System.Drawing.Size(56, 13);
            this.lblAprobador.TabIndex = 13;
            this.lblAprobador.Text = "Aprobador";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(339, 120);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "Estado";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(509, 39);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(74, 13);
            this.lblDepartamento.TabIndex = 10;
            this.lblDepartamento.Text = "Departamento";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(142, 51);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(329, 46);
            this.txtDescripcion.TabIndex = 9;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 54);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Aprobacion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbAprobacion
            // 
            this.cmbAprobacion.FormattingEnabled = true;
            this.cmbAprobacion.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbAprobacion.Location = new System.Drawing.Point(402, 145);
            this.cmbAprobacion.Name = "cmbAprobacion";
            this.cmbAprobacion.Size = new System.Drawing.Size(69, 21);
            this.cmbAprobacion.TabIndex = 22;
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 515);
            this.Controls.Add(this.gbxDatos);
            this.Controls.Add(this.dgvCategorias);
            this.Name = "frmCategorias";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNombreDeLaCategoria;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbGruposTecnicos;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblGrupoTecnico;
        private System.Windows.Forms.ComboBox cmbAprobador;
        private System.Windows.Forms.Label lblAprobador;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTiposCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAprobacion;
    }
}