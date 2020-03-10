namespace BlueSolAsoc
{
    partial class AsociatieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsociatieForm));
            this.button1 = new System.Windows.Forms.Button();
            this.classTabControl1 = new BlueSolAsoc.butoane_si_controale.ClassTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.classLabel1 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTextBox1 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classGroupBox1 = new BlueSolAsoc.butoane_si_controale.ClassGroupBox();
            this.classButonModifica1 = new BlueSolAsoc.butoane_si_controale.ClassButonModifica();
            this.classButonInteriorAdsauSalveaza2 = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorAdsauSalveaza();
            this.classButonInteriorSterge1 = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorSterge();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.classTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.classGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(85, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 57);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // classTabControl1
            // 
            this.classTabControl1.Controls.Add(this.tabPage1);
            this.classTabControl1.Controls.Add(this.tabPage2);
            this.classTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTabControl1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTabControl1.ItemSize = new System.Drawing.Size(150, 50);
            this.classTabControl1.Location = new System.Drawing.Point(0, 0);
            this.classTabControl1.Name = "classTabControl1";
            this.classTabControl1.SelectedIndex = 0;
            this.classTabControl1.Size = new System.Drawing.Size(1100, 591);
            this.classTabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.classLabel1);
            this.tabPage1.Controls.Add(this.classTextBox1);
            this.tabPage1.Controls.Add(this.classGroupBox1);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1092, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Structura Asociatie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // classLabel1
            // 
            this.classLabel1.AutoSize = true;
            this.classLabel1.Location = new System.Drawing.Point(246, 44);
            this.classLabel1.Name = "classLabel1";
            this.classLabel1.Size = new System.Drawing.Size(124, 30);
            this.classLabel1.TabIndex = 4;
            this.classLabel1.Text = "Denumire";
            // 
            // classTextBox1
            // 
            this.classTextBox1.Location = new System.Drawing.Point(221, 90);
            this.classTextBox1.Name = "classTextBox1";
            this.classTextBox1.Size = new System.Drawing.Size(464, 39);
            this.classTextBox1.TabIndex = 3;
            // 
            // classGroupBox1
            // 
            this.classGroupBox1.Controls.Add(this.classButonModifica1);
            this.classGroupBox1.Controls.Add(this.button1);
            this.classGroupBox1.Controls.Add(this.classButonInteriorAdsauSalveaza2);
            this.classGroupBox1.Controls.Add(this.classButonInteriorSterge1);
            this.classGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.classGroupBox1.Location = new System.Drawing.Point(908, 3);
            this.classGroupBox1.Name = "classGroupBox1";
            this.classGroupBox1.Size = new System.Drawing.Size(181, 527);
            this.classGroupBox1.TabIndex = 2;
            this.classGroupBox1.TabStop = false;
            this.classGroupBox1.Text = "Controale";
            // 
            // classButonModifica1
            // 
            this.classButonModifica1.BackColor = System.Drawing.Color.Yellow;
            this.classButonModifica1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonModifica1.Location = new System.Drawing.Point(19, 187);
            this.classButonModifica1.Name = "classButonModifica1";
            this.classButonModifica1.Size = new System.Drawing.Size(153, 45);
            this.classButonModifica1.TabIndex = 3;
            this.classButonModifica1.Text = "Modifica";
            this.classButonModifica1.UseVisualStyleBackColor = false;
            // 
            // classButonInteriorAdsauSalveaza2
            // 
            this.classButonInteriorAdsauSalveaza2.BackColor = System.Drawing.Color.Green;
            this.classButonInteriorAdsauSalveaza2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonInteriorAdsauSalveaza2.Location = new System.Drawing.Point(19, 28);
            this.classButonInteriorAdsauSalveaza2.Name = "classButonInteriorAdsauSalveaza2";
            this.classButonInteriorAdsauSalveaza2.Size = new System.Drawing.Size(153, 45);
            this.classButonInteriorAdsauSalveaza2.TabIndex = 2;
            this.classButonInteriorAdsauSalveaza2.Text = "Adauga";
            this.classButonInteriorAdsauSalveaza2.UseVisualStyleBackColor = false;
            this.classButonInteriorAdsauSalveaza2.Click += new System.EventHandler(this.classButonInteriorAdsauSalveaza2_Click);
            // 
            // classButonInteriorSterge1
            // 
            this.classButonInteriorSterge1.BackColor = System.Drawing.Color.Red;
            this.classButonInteriorSterge1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonInteriorSterge1.Location = new System.Drawing.Point(22, 367);
            this.classButonInteriorSterge1.Name = "classButonInteriorSterge1";
            this.classButonInteriorSterge1.Size = new System.Drawing.Size(153, 45);
            this.classButonInteriorSterge1.TabIndex = 1;
            this.classButonInteriorSterge1.Text = "Sterge";
            this.classButonInteriorSterge1.UseVisualStyleBackColor = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 527);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1092, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Structura Cheltuieli";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AsociatieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.Controls.Add(this.classTabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "AsociatieForm";
            this.Text = "AsociatieForm1";
            this.Load += new System.EventHandler(this.AsociatieForm_Load);
            this.classTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.classGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button button1;
        private butoane_si_controale.ClassTabControl classTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private butoane_si_controale.ClassGroupBox classGroupBox1;
        private butoane_si_controale.ClassButonInteriorAdsauSalveaza classButonInteriorAdsauSalveaza2;
        private butoane_si_controale.ClassButonInteriorSterge classButonInteriorSterge1;
        private butoane_si_controale.ClassButonModifica classButonModifica1;
        private butoane_si_controale.ClassTextBox classTextBox1;
        private butoane_si_controale.ClassLabel classLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}