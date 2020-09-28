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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.classTabControl1 = new BlueSolAsoc.butoane_si_controale.ClassTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GenereazaTabel = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.GridCalculIntretinere = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.treeColoane = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlControale = new System.Windows.Forms.Panel();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.classButonInteriorSterge1 = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorSterge();
            this.classButonModifica1 = new BlueSolAsoc.butoane_si_controale.ClassButonModifica();
            this.PanelConsumAapartament = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.gridAfisareConsumuri = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.PanelTreeConsumAp = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.treeConsumuriApartament = new System.Windows.Forms.TreeView();
            this.calcul_intretinereDS1 = new BlueSolAsoc.Calcul_intretinereDS();
            this.mvConsumApartamenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mv_ConsumApartamenteTableAdapter = new BlueSolAsoc.Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter();
            this.lblMesajSelecteazScara = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlControale.SuspendLayout();
            this.PanelConsumAapartament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAfisareConsumuri)).BeginInit();
            this.PanelTreeConsumAp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // classTabControl1
            // 
            this.classTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.classTabControl1.Controls.Add(this.tabPage2);
            this.classTabControl1.Controls.Add(this.tabPage1);
            this.classTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTabControl1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classTabControl1.ItemSize = new System.Drawing.Size(309, 45);
            this.classTabControl1.Location = new System.Drawing.Point(0, 0);
            this.classTabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTabControl1.Name = "classTabControl1";
            this.classTabControl1.SelectedIndex = 0;
            this.classTabControl1.Size = new System.Drawing.Size(1194, 711);
            this.classTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GenereazaTabel);
            this.tabPage2.Controls.Add(this.GridCalculIntretinere);
            this.tabPage2.Controls.Add(this.treeColoane);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(1186, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Genereaza tabel intretinere";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GenereazaTabel
            // 
            this.GenereazaTabel.BackColor = System.Drawing.Color.Aquamarine;
            this.GenereazaTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenereazaTabel.Location = new System.Drawing.Point(9, 495);
            this.GenereazaTabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GenereazaTabel.Name = "GenereazaTabel";
            this.GenereazaTabel.Size = new System.Drawing.Size(244, 39);
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
            this.GridCalculIntretinere.Location = new System.Drawing.Point(275, 3);
            this.GridCalculIntretinere.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridCalculIntretinere.Name = "GridCalculIntretinere";
            this.GridCalculIntretinere.RowHeadersWidth = 51;
            this.GridCalculIntretinere.RowTemplate.Height = 24;
            this.GridCalculIntretinere.Size = new System.Drawing.Size(909, 652);
            this.GridCalculIntretinere.TabIndex = 2;
            // 
            // treeColoane
            // 
            this.treeColoane.CheckBoxes = true;
            this.treeColoane.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeColoane.Location = new System.Drawing.Point(2, 3);
            this.treeColoane.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeColoane.Name = "treeColoane";
            this.treeColoane.Size = new System.Drawing.Size(273, 652);
            this.treeColoane.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMesajSelecteazScara);
            this.tabPage1.Controls.Add(this.pnlControale);
            this.tabPage1.Controls.Add(this.PanelConsumAapartament);
            this.tabPage1.Controls.Add(this.PanelTreeConsumAp);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1186, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adaugare consumuri apartament";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlControale
            // 
            this.pnlControale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControale.Controls.Add(this.btnAnuleaza);
            this.pnlControale.Controls.Add(this.btnOK);
            this.pnlControale.Controls.Add(this.classButonInteriorSterge1);
            this.pnlControale.Controls.Add(this.classButonModifica1);
            this.pnlControale.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControale.Location = new System.Drawing.Point(1028, 3);
            this.pnlControale.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlControale.Name = "pnlControale";
            this.pnlControale.Size = new System.Drawing.Size(156, 652);
            this.pnlControale.TabIndex = 11;
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.BackColor = System.Drawing.Color.Red;
            this.btnAnuleaza.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnuleaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnuleaza.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnuleaza.Location = new System.Drawing.Point(0, 600);
            this.btnAnuleaza.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(152, 200);
            this.btnAnuleaza.TabIndex = 9;
            this.btnAnuleaza.Text = "ANULEAZA";
            this.btnAnuleaza.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(0, 400);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(152, 200);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "SALVEAZA";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // classButonInteriorSterge1
            // 
            this.classButonInteriorSterge1.BackColor = System.Drawing.Color.Red;
            this.classButonInteriorSterge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.classButonInteriorSterge1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonInteriorSterge1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classButonInteriorSterge1.Location = new System.Drawing.Point(0, 200);
            this.classButonInteriorSterge1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classButonInteriorSterge1.Name = "classButonInteriorSterge1";
            this.classButonInteriorSterge1.Size = new System.Drawing.Size(152, 200);
            this.classButonInteriorSterge1.TabIndex = 7;
            this.classButonInteriorSterge1.Text = "STERGE";
            this.classButonInteriorSterge1.UseVisualStyleBackColor = false;
            // 
            // classButonModifica1
            // 
            this.classButonModifica1.BackColor = System.Drawing.Color.Yellow;
            this.classButonModifica1.Dock = System.Windows.Forms.DockStyle.Top;
            this.classButonModifica1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonModifica1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classButonModifica1.Location = new System.Drawing.Point(0, 0);
            this.classButonModifica1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classButonModifica1.Name = "classButonModifica1";
            this.classButonModifica1.Size = new System.Drawing.Size(152, 200);
            this.classButonModifica1.TabIndex = 6;
            this.classButonModifica1.Text = "MODIFICA";
            this.classButonModifica1.UseVisualStyleBackColor = false;
            // 
            // PanelConsumAapartament
            // 
            this.PanelConsumAapartament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelConsumAapartament.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelConsumAapartament.Controls.Add(this.gridAfisareConsumuri);
            this.PanelConsumAapartament.Location = new System.Drawing.Point(310, 3);
            this.PanelConsumAapartament.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelConsumAapartament.Name = "PanelConsumAapartament";
            this.PanelConsumAapartament.Size = new System.Drawing.Size(709, 644);
            this.PanelConsumAapartament.TabIndex = 10;
            // 
            // gridAfisareConsumuri
            // 
            this.gridAfisareConsumuri.AllowUserToAddRows = false;
            this.gridAfisareConsumuri.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAfisareConsumuri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAfisareConsumuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAfisareConsumuri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAfisareConsumuri.EnableHeadersVisualStyles = false;
            this.gridAfisareConsumuri.Location = new System.Drawing.Point(0, 0);
            this.gridAfisareConsumuri.Margin = new System.Windows.Forms.Padding(4);
            this.gridAfisareConsumuri.Name = "gridAfisareConsumuri";
            this.gridAfisareConsumuri.RowHeadersWidth = 51;
            this.gridAfisareConsumuri.Size = new System.Drawing.Size(705, 640);
            this.gridAfisareConsumuri.TabIndex = 0;
            // 
            // PanelTreeConsumAp
            // 
            this.PanelTreeConsumAp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelTreeConsumAp.Controls.Add(this.treeConsumuriApartament);
            this.PanelTreeConsumAp.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTreeConsumAp.Location = new System.Drawing.Point(2, 3);
            this.PanelTreeConsumAp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelTreeConsumAp.Name = "PanelTreeConsumAp";
            this.PanelTreeConsumAp.Size = new System.Drawing.Size(307, 652);
            this.PanelTreeConsumAp.TabIndex = 9;
            // 
            // treeConsumuriApartament
            // 
            this.treeConsumuriApartament.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeConsumuriApartament.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConsumuriApartament.Location = new System.Drawing.Point(0, 0);
            this.treeConsumuriApartament.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeConsumuriApartament.Name = "treeConsumuriApartament";
            this.treeConsumuriApartament.Size = new System.Drawing.Size(303, 648);
            this.treeConsumuriApartament.TabIndex = 8;
            this.treeConsumuriApartament.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConsumuriApartament_AfterSelect);
            // 
            // calcul_intretinereDS1
            // 
            this.calcul_intretinereDS1.DataSetName = "Calcul_intretinereDS";
            this.calcul_intretinereDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mvConsumApartamenteBindingSource
            // 
            this.mvConsumApartamenteBindingSource.DataMember = "mv_ConsumApartamente";
            this.mvConsumApartamenteBindingSource.DataSource = this.calcul_intretinereDS1;
            // 
            // mv_ConsumApartamenteTableAdapter
            // 
            this.mv_ConsumApartamenteTableAdapter.ClearBeforeFill = true;
            // 
            // lblMesajSelecteazScara
            // 
            this.lblMesajSelecteazScara.AutoSize = true;
            this.lblMesajSelecteazScara.Location = new System.Drawing.Point(344, 306);
            this.lblMesajSelecteazScara.Name = "lblMesajSelecteazScara";
            this.lblMesajSelecteazScara.Size = new System.Drawing.Size(635, 30);
            this.lblMesajSelecteazScara.TabIndex = 2;
            this.lblMesajSelecteazScara.Text = "Pentru a introduce consumuri selecteaza o scara din tree";
            // 
            // Calcul_intretinere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 711);
            this.Controls.Add(this.classTabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Calcul_intretinere";
            this.Text = "Calcul_intretinere";
            this.Load += new System.EventHandler(this.Calcul_intretinere_Load);
            this.classTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlControale.ResumeLayout(false);
            this.PanelConsumAapartament.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAfisareConsumuri)).EndInit();
            this.PanelTreeConsumAp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).EndInit();
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
        private butoane_si_controale.ClassGridView gridAfisareConsumuri;
        private System.Windows.Forms.Panel pnlControale;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.Button btnOK;
        private butoane_si_controale.ClassButonInteriorSterge classButonInteriorSterge1;
        private butoane_si_controale.ClassButonModifica classButonModifica1;
        private Calcul_intretinereDS calcul_intretinereDS1;
        private System.Windows.Forms.BindingSource mvConsumApartamenteBindingSource;
        private Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter mv_ConsumApartamenteTableAdapter;
        private butoane_si_controale.ClassLabel lblMesajSelecteazScara;
    }
}