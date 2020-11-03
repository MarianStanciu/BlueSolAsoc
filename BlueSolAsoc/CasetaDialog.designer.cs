namespace CasetaDialogTag
{
    partial class CasetaDialog
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
            this.BoxIconitaMesaj = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSecundar = new System.Windows.Forms.Button();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.btnPrimar = new System.Windows.Forms.Button();
            this.btnFinal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BoxIconitaMesaj)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxIconitaMesaj
            // 
            this.BoxIconitaMesaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoxIconitaMesaj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BoxIconitaMesaj.Location = new System.Drawing.Point(12, 7);
            this.BoxIconitaMesaj.Name = "BoxIconitaMesaj";
            this.BoxIconitaMesaj.Size = new System.Drawing.Size(67, 66);
            this.BoxIconitaMesaj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BoxIconitaMesaj.TabIndex = 12;
            this.BoxIconitaMesaj.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 20);
            this.panel1.TabIndex = 11;
            // 
            // btnSecundar
            // 
            this.btnSecundar.Location = new System.Drawing.Point(207, 195);
            this.btnSecundar.Name = "btnSecundar";
            this.btnSecundar.Size = new System.Drawing.Size(148, 40);
            this.btnSecundar.TabIndex = 10;
            this.btnSecundar.Text = "btnSecundar";
            this.btnSecundar.UseVisualStyleBackColor = true;
            this.btnSecundar.Click += new System.EventHandler(this.btnSecundar_Click);
            // 
            // lblMesaj
            // 
            this.lblMesaj.AutoSize = true;
            this.lblMesaj.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesaj.Location = new System.Drawing.Point(243, 118);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(78, 24);
            this.lblMesaj.TabIndex = 9;
            this.lblMesaj.Text = "MESAJ";
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(99, 35);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitlu.Size = new System.Drawing.Size(75, 25);
            this.lblTitlu.TabIndex = 8;
            this.lblTitlu.Text = "TITLU";
            // 
            // btnPrimar
            // 
            this.btnPrimar.Location = new System.Drawing.Point(12, 195);
            this.btnPrimar.Name = "btnPrimar";
            this.btnPrimar.Size = new System.Drawing.Size(148, 40);
            this.btnPrimar.TabIndex = 7;
            this.btnPrimar.Text = "btnPrimar";
            this.btnPrimar.UseVisualStyleBackColor = true;
            this.btnPrimar.Click += new System.EventHandler(this.btnPrimar_Click);
            // 
            // btnFinal
            // 
            this.btnFinal.Location = new System.Drawing.Point(414, 195);
            this.btnFinal.Name = "btnFinal";
            this.btnFinal.Size = new System.Drawing.Size(148, 40);
            this.btnFinal.TabIndex = 13;
            this.btnFinal.Text = "btnFinal";
            this.btnFinal.UseVisualStyleBackColor = true;
            this.btnFinal.Click += new System.EventHandler(this.btnFinal_Click);
            // 
            // CasetaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(595, 259);
            this.ControlBox = false;
            this.Controls.Add(this.btnFinal);
            this.Controls.Add(this.BoxIconitaMesaj);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSecundar);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.btnPrimar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CasetaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MESAJ";
            this.Load += new System.EventHandler(this.CasetaDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BoxIconitaMesaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BoxIconitaMesaj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSecundar;
        private System.Windows.Forms.Label lblMesaj;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Button btnPrimar;
        private System.Windows.Forms.Button btnFinal;
    }
}