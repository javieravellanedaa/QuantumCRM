namespace UI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.txtConstraseña = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.alphaBlendTextBox3 = new ZBobb.AlphaBlendTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.alphaBlendTextBox2 = new ZBobb.AlphaBlendTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.alphaBlendTextBox1 = new ZBobb.AlphaBlendTextBox();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox7);
            this.bunifuGradientPanel1.Controls.Add(this.txtConstraseña);
            this.bunifuGradientPanel1.Controls.Add(this.txtMail);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox6);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox5);
            this.bunifuGradientPanel1.Controls.Add(this.alphaBlendTextBox3);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox3);
            this.bunifuGradientPanel1.Controls.Add(this.panel2);
            this.bunifuGradientPanel1.Controls.Add(this.alphaBlendTextBox2);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel1.Controls.Add(this.panel1);
            this.bunifuGradientPanel1.Controls.Add(this.alphaBlendTextBox1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(104)))), ((int)(((byte)(220)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(78)))), ((int)(((byte)(214)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(78)))), ((int)(((byte)(214)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(77)))), ((int)(((byte)(155)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(441, 624);
            this.bunifuGradientPanel1.TabIndex = 0;
            this.bunifuGradientPanel1.Click += new System.EventHandler(this.bunifuGradientPanel1_Click);
            this.bunifuGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuGradientPanel1_Paint);
            this.bunifuGradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bunifuGradientPanel1_MouseDown);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::UI.Properties.Resources.exit;
            this.pictureBox7.Location = new System.Drawing.Point(385, 563);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 38);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // txtConstraseña
            // 
            this.txtConstraseña.BackColor = System.Drawing.Color.White;
            this.txtConstraseña.ForeColor = System.Drawing.Color.Black;
            this.txtConstraseña.Location = new System.Drawing.Point(100, 338);
            this.txtConstraseña.Multiline = true;
            this.txtConstraseña.Name = "txtConstraseña";
            this.txtConstraseña.PasswordChar = '*';
            this.txtConstraseña.Size = new System.Drawing.Size(237, 26);
            this.txtConstraseña.TabIndex = 11;
            // 
            // txtMail
            // 
            this.txtMail.ForeColor = System.Drawing.Color.Black;
            this.txtMail.Location = new System.Drawing.Point(100, 250);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(237, 26);
            this.txtMail.TabIndex = 10;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::UI.Properties.Resources.login_button_png_18030;
            this.pictureBox6.Location = new System.Drawing.Point(105, 441);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(189, 46);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::UI.Properties.Resources.Logo;
            this.pictureBox5.Location = new System.Drawing.Point(153, 29);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(141, 95);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // alphaBlendTextBox3
            // 
            this.alphaBlendTextBox3.BackAlpha = 0;
            this.alphaBlendTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.alphaBlendTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox3.ForeColor = System.Drawing.Color.White;
            this.alphaBlendTextBox3.Location = new System.Drawing.Point(182, 144);
            this.alphaBlendTextBox3.Multiline = true;
            this.alphaBlendTextBox3.Name = "alphaBlendTextBox3";
            this.alphaBlendTextBox3.Size = new System.Drawing.Size(78, 27);
            this.alphaBlendTextBox3.TabIndex = 7;
            this.alphaBlendTextBox3.Text = "LOG IN";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::UI.Properties.Resources.unlock;
            this.pictureBox3.Location = new System.Drawing.Point(31, 332);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Location = new System.Drawing.Point(31, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 3);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 50);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // alphaBlendTextBox2
            // 
            this.alphaBlendTextBox2.BackAlpha = 0;
            this.alphaBlendTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.alphaBlendTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox2.ForeColor = System.Drawing.Color.White;
            this.alphaBlendTextBox2.Location = new System.Drawing.Point(100, 316);
            this.alphaBlendTextBox2.Multiline = true;
            this.alphaBlendTextBox2.Name = "alphaBlendTextBox2";
            this.alphaBlendTextBox2.ReadOnly = true;
            this.alphaBlendTextBox2.Size = new System.Drawing.Size(131, 27);
            this.alphaBlendTextBox2.TabIndex = 4;
            this.alphaBlendTextBox2.Text = "Contraseña";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::UI.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(31, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(31, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 3);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // alphaBlendTextBox1
            // 
            this.alphaBlendTextBox1.BackAlpha = 0;
            this.alphaBlendTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.alphaBlendTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox1.ForeColor = System.Drawing.Color.White;
            this.alphaBlendTextBox1.Location = new System.Drawing.Point(100, 223);
            this.alphaBlendTextBox1.Multiline = true;
            this.alphaBlendTextBox1.Name = "alphaBlendTextBox1";
            this.alphaBlendTextBox1.ReadOnly = true;
            this.alphaBlendTextBox1.Size = new System.Drawing.Size(51, 27);
            this.alphaBlendTextBox1.TabIndex = 1;
            this.alphaBlendTextBox1.Text = "Mail";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 624);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "Login";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox2;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtConstraseña;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}