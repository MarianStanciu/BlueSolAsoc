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
            this.classButonInteriorAdsauSalveaza1 = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorAdsauSalveaza();
            this.SuspendLayout();
            // 
            // DenumireCreareAsocBox
            // 
            this.DenumireCreareAsocBox.Font = new System.Drawing.Font("Mongolian Baiti", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DenumireCreareAsocBox.Location = new System.Drawing.Point(293, 92);
            this.DenumireCreareAsocBox.Margin = new System.Windows.Forms.Padding(4);
            this.DenumireCreareAsocBox.Multiline = true;
            this.DenumireCreareAsocBox.Name = "DenumireCreareAsocBox";
            this.DenumireCreareAsocBox.Size = new System.Drawing.Size(636, 50);
            this.DenumireCreareAsocBox.TabIndex = 0;
            // 
            // lblDenCreareAsoc
            // 
            this.lblDenCreareAsoc.AutoSize = true;
            this.lblDenCreareAsoc.Location = new System.Drawing.Point(88, 104);
            this.lblDenCreareAsoc.Name = "lblDenCreareAsoc";
            this.lblDenCreareAsoc.Size = new System.Drawing.Size(173, 21);
            this.lblDenCreareAsoc.TabIndex = 1;
            this.lblDenCreareAsoc.Text = "Denumire Asociatie";
            // 
            // classButonInteriorAdsauSalveaza1
            // 
            this.classButonInteriorAdsauSalveaza1.BackColor = System.Drawing.Color.Green;
            this.classButonInteriorAdsauSalveaza1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonInteriorAdsauSalveaza1.Location = new System.Drawing.Point(811, 411);
            this.classButonInteriorAdsauSalveaza1.Name = "classButonInteriorAdsauSalveaza1";
            this.classButonInteriorAdsauSalveaza1.Size = new System.Drawing.Size(169, 97);
            this.classButonInteriorAdsauSalveaza1.TabIndex = 2;
            this.classButonInteriorAdsauSalveaza1.Text = "Salveaza";
            this.classButonInteriorAdsauSalveaza1.UseVisualStyleBackColor = false;
            this.classButonInteriorAdsauSalveaza1.Click += new System.EventHandler(this.classButonInteriorAdsauSalveaza1_Click);
            // 
            // CreareAsociatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.ControlBox = true;
            this.Controls.Add(this.classButonInteriorAdsauSalveaza1);
            this.Controls.Add(this.lblDenCreareAsoc);
            this.Controls.Add(this.DenumireCreareAsocBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "CreareAsociatie";
            this.Text = "CreareAsociatie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DenumireCreareAsocBox;
        private System.Windows.Forms.Label lblDenCreareAsoc;
        private butoane_si_controale.ClassButonInteriorAdsauSalveaza classButonInteriorAdsauSalveaza1;
    }
}