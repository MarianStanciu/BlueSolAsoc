namespace BlueSolAsoc
{
    partial class CreareAsociatie
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
            this.DenumireCreareAsocBox = new System.Windows.Forms.TextBox();
            this.lblDenCreareAsoc = new System.Windows.Forms.Label();
            this.ButonSalvareAsocCreata = new System.Windows.Forms.Button();
            this.ButonAnulareCreareAsoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DenumireCreareAsocBox
            // 
            this.DenumireCreareAsocBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DenumireCreareAsocBox.Font = new System.Drawing.Font("Mongolian Baiti", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DenumireCreareAsocBox.Location = new System.Drawing.Point(234, 151);
            this.DenumireCreareAsocBox.Multiline = true;
            this.DenumireCreareAsocBox.Name = "DenumireCreareAsocBox";
            this.DenumireCreareAsocBox.Size = new System.Drawing.Size(521, 39);
            this.DenumireCreareAsocBox.TabIndex = 0;
            // 
            // lblDenCreareAsoc
            // 
            this.lblDenCreareAsoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDenCreareAsoc.AutoSize = true;
            this.lblDenCreareAsoc.Font = new System.Drawing.Font("Mongolian Baiti", 45F);
            this.lblDenCreareAsoc.Location = new System.Drawing.Point(243, 74);
            this.lblDenCreareAsoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenCreareAsoc.Name = "lblDenCreareAsoc";
            this.lblDenCreareAsoc.Size = new System.Drawing.Size(512, 64);
            this.lblDenCreareAsoc.TabIndex = 1;
            this.lblDenCreareAsoc.Text = "Denumire Asociatie";
            // 
            // ButonSalvareAsocCreata
            // 
            this.ButonSalvareAsocCreata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButonSalvareAsocCreata.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButonSalvareAsocCreata.Location = new System.Drawing.Point(578, 312);
            this.ButonSalvareAsocCreata.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButonSalvareAsocCreata.Name = "ButonSalvareAsocCreata";
            this.ButonSalvareAsocCreata.Size = new System.Drawing.Size(268, 80);
            this.ButonSalvareAsocCreata.TabIndex = 3;
            this.ButonSalvareAsocCreata.Text = "SALVEAZA";
            this.ButonSalvareAsocCreata.UseVisualStyleBackColor = false;
            this.ButonSalvareAsocCreata.Click += new System.EventHandler(this.ButonSalvareAsocCreata_Click);
            // 
            // ButonAnulareCreareAsoc
            // 
            this.ButonAnulareCreareAsoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButonAnulareCreareAsoc.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButonAnulareCreareAsoc.Location = new System.Drawing.Point(38, 312);
            this.ButonAnulareCreareAsoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButonAnulareCreareAsoc.Name = "ButonAnulareCreareAsoc";
            this.ButonAnulareCreareAsoc.Size = new System.Drawing.Size(268, 80);
            this.ButonAnulareCreareAsoc.TabIndex = 4;
            this.ButonAnulareCreareAsoc.Text = "RENUNTA";
            this.ButonAnulareCreareAsoc.UseVisualStyleBackColor = false;
            this.ButonAnulareCreareAsoc.Click += new System.EventHandler(this.ButonAnulareCreareAsoc_Click);
            // 
            // CreareAsociatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.ControlBox = true;
            this.Controls.Add(this.ButonAnulareCreareAsoc);
            this.Controls.Add(this.ButonSalvareAsocCreata);
            this.Controls.Add(this.lblDenCreareAsoc);
            this.Controls.Add(this.DenumireCreareAsocBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "CreareAsociatie";
            this.Text = "CreareAsociatie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DenumireCreareAsocBox;
        private System.Windows.Forms.Label lblDenCreareAsoc;
        private System.Windows.Forms.Button ButonSalvareAsocCreata;
        private System.Windows.Forms.Button ButonAnulareCreareAsoc;
    }
}