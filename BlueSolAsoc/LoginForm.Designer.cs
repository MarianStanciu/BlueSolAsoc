namespace BlueSolAsoc
{
    partial class LoginForm
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
            this.utilizatorbox = new System.Windows.Forms.TextBox();
            this.parolabox = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butonsircon = new System.Windows.Forms.Button();
            this.sirconbox = new System.Windows.Forms.TextBox();
            this.button_sircon_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // utilizatorbox
            // 
            this.utilizatorbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.utilizatorbox.Font = new System.Drawing.Font("Mongolian Baiti", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilizatorbox.Location = new System.Drawing.Point(228, 166);
            this.utilizatorbox.Multiline = true;
            this.utilizatorbox.Name = "utilizatorbox";
            this.utilizatorbox.Size = new System.Drawing.Size(693, 65);
            this.utilizatorbox.TabIndex = 0;
            // 
            // parolabox
            // 
            this.parolabox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.parolabox.Font = new System.Drawing.Font("Mongolian Baiti", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parolabox.Location = new System.Drawing.Point(228, 285);
            this.parolabox.Multiline = true;
            this.parolabox.Name = "parolabox";
            this.parolabox.PasswordChar = '*';
            this.parolabox.Size = new System.Drawing.Size(693, 65);
            this.parolabox.TabIndex = 1;
            // 
            // Login
            // 
            this.Login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Login.Location = new System.Drawing.Point(442, 418);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(223, 64);
            this.Login.TabIndex = 2;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Location = new System.Drawing.Point(442, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 64);
            this.button2.TabIndex = 3;
            this.button2.Text = "Register";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // butonsircon
            // 
            this.butonsircon.Location = new System.Drawing.Point(10, 27);
            this.butonsircon.Name = "butonsircon";
            this.butonsircon.Size = new System.Drawing.Size(45, 26);
            this.butonsircon.TabIndex = 4;
            this.butonsircon.Text = "...";
            this.butonsircon.UseVisualStyleBackColor = true;
            this.butonsircon.Click += new System.EventHandler(this.butonsircon_Click);
            // 
            // sirconbox
            // 
            this.sirconbox.Location = new System.Drawing.Point(72, 27);
            this.sirconbox.Name = "sirconbox";
            this.sirconbox.Size = new System.Drawing.Size(616, 31);
            this.sirconbox.TabIndex = 5;
            // 
            // button_sircon_ok
            // 
            this.button_sircon_ok.Location = new System.Drawing.Point(714, 27);
            this.button_sircon_ok.Name = "button_sircon_ok";
            this.button_sircon_ok.Size = new System.Drawing.Size(61, 35);
            this.button_sircon_ok.TabIndex = 6;
            this.button_sircon_ok.Text = "OK";
            this.button_sircon_ok.UseVisualStyleBackColor = true;
            this.button_sircon_ok.Click += new System.EventHandler(this.button_sircon_ok_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.ControlBox = true;
            this.Controls.Add(this.button_sircon_ok);
            this.Controls.Add(this.sirconbox);
            this.Controls.Add(this.butonsircon);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.parolabox);
            this.Controls.Add(this.utilizatorbox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox utilizatorbox;
        private System.Windows.Forms.TextBox parolabox;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butonsircon;
        private System.Windows.Forms.TextBox sirconbox;
        private System.Windows.Forms.Button button_sircon_ok;
    }
}