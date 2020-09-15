namespace BlueSolAsoc.Fom_Meniuri
{
    partial class Calcul_intretinere
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.classTabControl1 = new BlueSolAsoc.butoane_si_controale.ClassTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GenereazaTabel = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.GridCalculIntretinere = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.treeColoane = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PanelConsumAapartament = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.PanelTreeConsumAp = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.treeConsumuriApartament = new System.Windows.Forms.TreeView();
            this.classTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.PanelTreeConsumAp.SuspendLayout();
            this.SuspendLayout();
            // 
            // classTabControl1
            // 
            this.classTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.classTabControl1.Controls.Add(this.tabPage2);
            this.classTabControl1.Controls.Add(this.tabPage1);
            this.classTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTabControl1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTabControl1.Location = new System.Drawing.Point(0, 0);
            this.classTabControl1.Name = "classTabControl1";
            this.classTabControl1.SelectedIndex = 0;
            this.classTabControl1.Size = new System.Drawing.Size(1194, 712);
            this.classTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GenereazaTabel);
            this.tabPage2.Controls.Add(this.GridCalculIntretinere);
            this.tabPage2.Controls.Add(this.treeColoane);
            this.tabPage2.Location = new System.Drawing.Point(4, 41);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1186, 667);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Genereaza tabel intretinere";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GenereazaTabel
            // 
            this.GenereazaTabel.BackColor = System.Drawing.Color.Aquamarine;
            this.GenereazaTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenereazaTabel.Location = new System.Drawing.Point(8, 495);
            this.GenereazaTabel.Name = "GenereazaTabel";
            this.GenereazaTabel.Size = new System.Drawing.Size(244, 40);
            this.GenereazaTabel.TabIndex = 3;
            this.GenereazaTabel.Text = "Genereaza Tabel";
            this.GenereazaTabel.UseVisualStyleBackColor = false;
            this.GenereazaTabel.Click += new System.EventHandler(this.GenereazaTabel_Click);
            // 
            // GridCalculIntretinere
            // 
            this.GridCalculIntretinere.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCalculIntretinere.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridCalculIntretinere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCalculIntretinere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCalculIntretinere.EnableHeadersVisualStyles = false;
            this.GridCalculIntretinere.Location = new System.Drawing.Point(276, 3);
            this.GridCalculIntretinere.Name = "GridCalculIntretinere";
            this.GridCalculIntretinere.RowHeadersWidth = 51;
            this.GridCalculIntretinere.RowTemplate.Height = 24;
            this.GridCalculIntretinere.Size = new System.Drawing.Size(907, 661);
            this.GridCalculIntretinere.TabIndex = 2;
            // 
            // treeColoane
            // 
            this.treeColoane.CheckBoxes = true;
            this.treeColoane.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeColoane.Location = new System.Drawing.Point(3, 3);
            this.treeColoane.Name = "treeColoane";
            this.treeColoane.Size = new System.Drawing.Size(273, 661);
            this.treeColoane.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PanelConsumAapartament);
            this.tabPage1.Controls.Add(this.PanelTreeConsumAp);
            this.tabPage1.Location = new System.Drawing.Point(4, 41);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1186, 667);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adaugare consumuri apartament";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PanelConsumAapartament
            // 
            this.PanelConsumAapartament.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelConsumAapartament.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelConsumAapartament.Location = new System.Drawing.Point(310, 3);
            this.PanelConsumAapartament.Name = "PanelConsumAapartament";
            this.PanelConsumAapartament.Size = new System.Drawing.Size(873, 661);
            this.PanelConsumAapartament.TabIndex = 10;
            // 
            // PanelTreeConsumAp
            // 
            this.PanelTreeConsumAp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelTreeConsumAp.Controls.Add(this.treeConsumuriApartament);
            this.PanelTreeConsumAp.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTreeConsumAp.Location = new System.Drawing.Point(3, 3);
            this.PanelTreeConsumAp.Name = "PanelTreeConsumAp";
            this.PanelTreeConsumAp.Size = new System.Drawing.Size(307, 661);
            this.PanelTreeConsumAp.TabIndex = 9;
            // 
            // treeConsumuriApartament
            // 
            this.treeConsumuriApartament.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeConsumuriApartament.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConsumuriApartament.Location = new System.Drawing.Point(0, 0);
            this.treeConsumuriApartament.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeConsumuriApartament.Name = "treeConsumuriApartament";
            this.treeConsumuriApartament.Size = new System.Drawing.Size(303, 657);
            this.treeConsumuriApartament.TabIndex = 8;
            // 
            // Calcul_intretinere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 712);
            this.Controls.Add(this.classTabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Calcul_intretinere";
            this.Text = "Calcul_intretinere";
            this.classTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.PanelTreeConsumAp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private butoane_si_controale.ClassTabControl classTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeColoane;
        private butoane_si_controale.ClassGridView GridCalculIntretinere;
        private butoane_si_controale.ClassButon GenereazaTabel;
        private System.Windows.Forms.TreeView treeConsumuriApartament;
        private butoane_si_controale.ClassPanel PanelTreeConsumAp;
        private butoane_si_controale.ClassPanel PanelConsumAapartament;
    }
}