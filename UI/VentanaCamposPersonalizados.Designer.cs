namespace UI
{
    partial class VentanaCamposPersonalizados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Componentes principales
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelScrollable;
        private System.Windows.Forms.TableLayoutPanel tblCampos;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelAdvertencia;
        private System.Windows.Forms.Label lblAdvertencia;
        private System.Windows.Forms.PictureBox iconoAdvertencia;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelScrollable = new System.Windows.Forms.Panel();
            this.tblCampos = new System.Windows.Forms.TableLayoutPanel();
            this.panelAdvertencia = new System.Windows.Forms.Panel();
            this.iconoAdvertencia = new System.Windows.Forms.PictureBox();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelScrollable.SuspendLayout();
            this.panelAdvertencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoAdvertencia)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.panelHeader.Size = new System.Drawing.Size(1000, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(30, 58);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(318, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Información detallada de los campos personalizados";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitulo.Location = new System.Drawing.Point(25, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(340, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Campos Personalizados";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelContenido.Controls.Add(this.panelScrollable);
            this.panelContenido.Controls.Add(this.panelAdvertencia);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 90);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(30, 15, 30, 15);
            this.panelContenido.Size = new System.Drawing.Size(1000, 525);
            this.panelContenido.TabIndex = 1;
            // 
            // panelScrollable
            // 
            this.panelScrollable.AutoScroll = true;
            this.panelScrollable.BackColor = System.Drawing.Color.Transparent;
            this.panelScrollable.Controls.Add(this.tblCampos);
            this.panelScrollable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScrollable.Location = new System.Drawing.Point(30, 75);
            this.panelScrollable.Name = "panelScrollable";
            this.panelScrollable.Padding = new System.Windows.Forms.Padding(0, 10, 20, 10);
            this.panelScrollable.Size = new System.Drawing.Size(940, 435);
            this.panelScrollable.TabIndex = 2;
            // 
            // tblCampos
            // 
            this.tblCampos.AutoSize = true;
            this.tblCampos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblCampos.BackColor = System.Drawing.Color.Transparent;
            this.tblCampos.ColumnCount = 1;
            this.tblCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCampos.Location = new System.Drawing.Point(0, 10);
            this.tblCampos.Name = "tblCampos";
            this.tblCampos.RowCount = 1;
            this.tblCampos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCampos.Size = new System.Drawing.Size(0, 0);
            this.tblCampos.TabIndex = 0;
            // 
            // panelAdvertencia
            // 
            this.panelAdvertencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.panelAdvertencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelAdvertencia.Controls.Add(this.iconoAdvertencia);
            this.panelAdvertencia.Controls.Add(this.lblAdvertencia);
            this.panelAdvertencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdvertencia.Location = new System.Drawing.Point(30, 15);
            this.panelAdvertencia.Name = "panelAdvertencia";
            this.panelAdvertencia.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelAdvertencia.Size = new System.Drawing.Size(940, 60);
            this.panelAdvertencia.TabIndex = 0;
            this.panelAdvertencia.Visible = false;
            // 
            // iconoAdvertencia
            // 
            this.iconoAdvertencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.iconoAdvertencia.Location = new System.Drawing.Point(20, 18);
            this.iconoAdvertencia.Name = "iconoAdvertencia";
            this.iconoAdvertencia.Size = new System.Drawing.Size(28, 28);
            this.iconoAdvertencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconoAdvertencia.TabIndex = 1;
            this.iconoAdvertencia.TabStop = false;
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(100)))), ((int)(((byte)(4)))));
            this.lblAdvertencia.Location = new System.Drawing.Point(60, 22);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(476, 17);
            this.lblAdvertencia.TabIndex = 0;
            this.lblAdvertencia.Text = "Este ticket fue recategorizado. Se muestran todos los valores guardados.";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelFooter.Controls.Add(this.btnGuardar);
            this.panelFooter.Controls.Add(this.btnCerrar);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 615);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(30, 20, 30, 25);
            this.panelFooter.Size = new System.Drawing.Size(1000, 85);
            this.panelFooter.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(136)))), ((int)(((byte)(56)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(142)))), ((int)(((byte)(58)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(710, 25);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 45);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(98)))), ((int)(((byte)(104)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(106)))), ((int)(((byte)(112)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(880, 25);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 45);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // VentanaCamposPersonalizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaCamposPersonalizados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Campos Personalizados - Sistema de Tickets";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelScrollable.ResumeLayout(false);
            this.panelScrollable.PerformLayout();
            this.panelAdvertencia.ResumeLayout(false);
            this.panelAdvertencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoAdvertencia)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}