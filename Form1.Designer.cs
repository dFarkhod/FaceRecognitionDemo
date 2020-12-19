namespace FaceRecognitionDemo
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.meniBosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kameraniOchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yuzlarniAniqlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRecognizedFace2 = new System.Windows.Forms.TextBox();
            this.txtRecognizedFace1 = new System.Windows.Forms.TextBox();
            this.txtRecognizedFace0 = new System.Windows.Forms.TextBox();
            this.pbDetectedFace2 = new System.Windows.Forms.PictureBox();
            this.pbDetectedFace1 = new System.Windows.Forms.PictureBox();
            this.pbDetectedFace0 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace0)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 431);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meniBosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // meniBosToolStripMenuItem
            // 
            this.meniBosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kameraniOchToolStripMenuItem,
            this.yuzlarniAniqlaToolStripMenuItem});
            this.meniBosToolStripMenuItem.Name = "meniBosToolStripMenuItem";
            this.meniBosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.meniBosToolStripMenuItem.Text = "Meni bos";
            // 
            // kameraniOchToolStripMenuItem
            // 
            this.kameraniOchToolStripMenuItem.Name = "kameraniOchToolStripMenuItem";
            this.kameraniOchToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.kameraniOchToolStripMenuItem.Text = "Kamerani och";
            this.kameraniOchToolStripMenuItem.Click += new System.EventHandler(this.kameraniOchToolStripMenuItem_Click);
            // 
            // yuzlarniAniqlaToolStripMenuItem
            // 
            this.yuzlarniAniqlaToolStripMenuItem.Name = "yuzlarniAniqlaToolStripMenuItem";
            this.yuzlarniAniqlaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.yuzlarniAniqlaToolStripMenuItem.Text = "Yuzlarni Aniqla";
            this.yuzlarniAniqlaToolStripMenuItem.Click += new System.EventHandler(this.yuzlarniAniqlaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRecognizedFace2);
            this.panel1.Controls.Add(this.txtRecognizedFace1);
            this.panel1.Controls.Add(this.txtRecognizedFace0);
            this.panel1.Controls.Add(this.pbDetectedFace2);
            this.panel1.Controls.Add(this.pbDetectedFace1);
            this.panel1.Controls.Add(this.pbDetectedFace0);
            this.panel1.Location = new System.Drawing.Point(735, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 450);
            this.panel1.TabIndex = 4;
            // 
            // txtRecognizedFace2
            // 
            this.txtRecognizedFace2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecognizedFace2.Enabled = false;
            this.txtRecognizedFace2.Location = new System.Drawing.Point(4, 416);
            this.txtRecognizedFace2.Name = "txtRecognizedFace2";
            this.txtRecognizedFace2.ReadOnly = true;
            this.txtRecognizedFace2.Size = new System.Drawing.Size(100, 13);
            this.txtRecognizedFace2.TabIndex = 10;
            this.txtRecognizedFace2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRecognizedFace1
            // 
            this.txtRecognizedFace1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecognizedFace1.Enabled = false;
            this.txtRecognizedFace1.Location = new System.Drawing.Point(4, 264);
            this.txtRecognizedFace1.Name = "txtRecognizedFace1";
            this.txtRecognizedFace1.ReadOnly = true;
            this.txtRecognizedFace1.Size = new System.Drawing.Size(100, 13);
            this.txtRecognizedFace1.TabIndex = 9;
            this.txtRecognizedFace1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRecognizedFace0
            // 
            this.txtRecognizedFace0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecognizedFace0.Enabled = false;
            this.txtRecognizedFace0.Location = new System.Drawing.Point(5, 112);
            this.txtRecognizedFace0.Name = "txtRecognizedFace0";
            this.txtRecognizedFace0.ReadOnly = true;
            this.txtRecognizedFace0.Size = new System.Drawing.Size(100, 13);
            this.txtRecognizedFace0.TabIndex = 8;
            this.txtRecognizedFace0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbDetectedFace2
            // 
            this.pbDetectedFace2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDetectedFace2.Location = new System.Drawing.Point(5, 311);
            this.pbDetectedFace2.Name = "pbDetectedFace2";
            this.pbDetectedFace2.Size = new System.Drawing.Size(100, 100);
            this.pbDetectedFace2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetectedFace2.TabIndex = 6;
            this.pbDetectedFace2.TabStop = false;
            // 
            // pbDetectedFace1
            // 
            this.pbDetectedFace1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDetectedFace1.Location = new System.Drawing.Point(5, 158);
            this.pbDetectedFace1.Name = "pbDetectedFace1";
            this.pbDetectedFace1.Size = new System.Drawing.Size(100, 100);
            this.pbDetectedFace1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetectedFace1.TabIndex = 5;
            this.pbDetectedFace1.TabStop = false;
            // 
            // pbDetectedFace0
            // 
            this.pbDetectedFace0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDetectedFace0.Location = new System.Drawing.Point(5, 8);
            this.pbDetectedFace0.Name = "pbDetectedFace0";
            this.pbDetectedFace0.Size = new System.Drawing.Size(100, 100);
            this.pbDetectedFace0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetectedFace0.TabIndex = 4;
            this.pbDetectedFace0.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 475);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yuz Aniqlagich";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetectedFace0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem meniBosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kameraniOchToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbDetectedFace2;
        private System.Windows.Forms.PictureBox pbDetectedFace1;
        private System.Windows.Forms.PictureBox pbDetectedFace0;
        private System.Windows.Forms.ToolStripMenuItem yuzlarniAniqlaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtRecognizedFace2;
        private System.Windows.Forms.TextBox txtRecognizedFace1;
        private System.Windows.Forms.TextBox txtRecognizedFace0;
    }
}

