namespace BlueSolAsoc
{
    partial class MeniuForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumeFirma = new System.Windows.Forms.Label();
            this.lblCeas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMama = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.lblNumeFirma);
            this.panel1.Controls.Add(this.lblCeas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 30);
            this.panel1.TabIndex = 2;
            // 
            // lblNumeFirma
            // 
            this.lblNumeFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumeFirma.AutoSize = true;
            this.lblNumeFirma.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeFirma.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeFirma.Location = new System.Drawing.Point(798, 4);
            this.lblNumeFirma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeFirma.Name = "lblNumeFirma";
            this.lblNumeFirma.Size = new System.Drawing.Size(189, 22);
            this.lblNumeFirma.TabIndex = 1;
            this.lblNumeFirma.Text = "BlueBit Data SRL";
            // 
            // lblCeas
            // 
            this.lblCeas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCeas.AutoSize = true;
            this.lblCeas.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCeas.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblCeas.Location = new System.Drawing.Point(815, 2);
            this.lblCeas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCeas.Name = "lblCeas";
            this.lblCeas.Size = new System.Drawing.Size(67, 24);
            this.lblCeas.TabIndex = 0;
            this.lblCeas.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlMama
            // 
            this.pnlMama.BackColor = System.Drawing.Color.Transparent;
            this.pnlMama.BackgroundImage = global::BlueSolAsoc.Properties.Resources.BLUE_BIT_LOGO_FINAL_1;
            this.pnlMama.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlMama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMama.Location = new System.Drawing.Point(0, 112);
            this.pnlMama.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMama.Name = "pnlMama";
            this.pnlMama.Size = new System.Drawing.Size(1008, 617);
            this.pnlMama.TabIndex = 5;
            // 
            // MeniuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.pnlMama);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Name = "MeniuForm";
            this.Text = "MeniuForm";
            this.Load += new System.EventHandler(this.MeniuForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMama;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCeas;
        private System.Windows.Forms.Label lblNumeFirma;
    }
}