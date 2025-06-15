using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class frmDetalleValor
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtDetalle;
        private Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDetalle = new TextBox();
            this.btnCerrar = new Button();
            this.SuspendLayout();
            // 
            // txtDetalle
            // 
            this.txtDetalle.Dock = DockStyle.Top;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.ScrollBars = ScrollBars.Both;
            this.txtDetalle.Font = new Font("Consolas", 10F);
            this.txtDetalle.Height = 400;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Dock = DockStyle.Bottom;
            this.btnCerrar.Height = 30;
            this.btnCerrar.Name = "btnCerrar";
            // 
            // frmDetalleValor
            // 
            this.ClientSize = new Size(600, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtDetalle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Detalle de valor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
