namespace BlueSolAsoc.butoane_si_controale
{
    partial class butonInchidere
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInchide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInchide
            // 
            this.btnInchide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnInchide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInchide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInchide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnInchide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInchide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchide.Location = new System.Drawing.Point(0, 0);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(65, 42);
            this.btnInchide.TabIndex = 0;
            this.btnInchide.Text = "Inchide";
            this.btnInchide.UseVisualStyleBackColor = false;
            // 
            // butonInchidere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInchide);
            this.Name = "butonInchidere";
            this.Size = new System.Drawing.Size(65, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInchide;
    }
}
