namespace UI
{
    partial class frmNuevoIdioma
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
            this.dgvNuevoIdioma = new System.Windows.Forms.DataGridView();
            this.lblNombreIdiomaNuevo = new System.Windows.Forms.Label();
            this.txtNombreIdiomaNuevo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuevoIdioma)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNuevoIdioma
            // 
            this.dgvNuevoIdioma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuevoIdioma.Location = new System.Drawing.Point(45, 102);
            this.dgvNuevoIdioma.Name = "dgvNuevoIdioma";
            this.dgvNuevoIdioma.Size = new System.Drawing.Size(495, 261);
            this.dgvNuevoIdioma.TabIndex = 0;
            // 
            // lblNombreIdiomaNuevo
            // 
            this.lblNombreIdiomaNuevo.AutoSize = true;
            this.lblNombreIdiomaNuevo.Location = new System.Drawing.Point(42, 37);
            this.lblNombreIdiomaNuevo.Name = "lblNombreIdiomaNuevo";
            this.lblNombreIdiomaNuevo.Size = new System.Drawing.Size(113, 13);
            this.lblNombreIdiomaNuevo.TabIndex = 1;
            this.lblNombreIdiomaNuevo.Text = "Nombre Idioma Nuevo";
            // 
            // txtNombreIdiomaNuevo
            // 
            this.txtNombreIdiomaNuevo.Location = new System.Drawing.Point(197, 37);
            this.txtNombreIdiomaNuevo.Name = "txtNombreIdiomaNuevo";
            this.txtNombreIdiomaNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtNombreIdiomaNuevo.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(448, 423);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(367, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmNuevoIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 458);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombreIdiomaNuevo);
            this.Controls.Add(this.lblNombreIdiomaNuevo);
            this.Controls.Add(this.dgvNuevoIdioma);
            this.Name = "frmNuevoIdioma";
            this.Text = "frmNuevoIdioma";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuevoIdioma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNuevoIdioma;
        private System.Windows.Forms.Label lblNombreIdiomaNuevo;
        private System.Windows.Forms.TextBox txtNombreIdiomaNuevo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}