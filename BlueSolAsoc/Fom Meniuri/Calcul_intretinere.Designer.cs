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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.mvConsumApartamenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calcul_intretinereDS1 = new BlueSolAsoc.Calcul_intretinereDS();
            this.PanelTreeConsumAp = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.treeConsumuriApartament = new System.Windows.Forms.TreeView();
            this.calculintretinereDS1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mv_ConsumApartamenteTableAdapter = new BlueSolAsoc.Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter();
            this.idscDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idconsumuriapartamenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denumireApartamentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumapareceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumapacaldaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numarpersoaneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proprietarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlControale.SuspendLayout();
            this.PanelConsumAapartament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAfisareConsumuri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).BeginInit();
            this.PanelTreeConsumAp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calculintretinereDS1BindingSource)).BeginInit();
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
            this.classTabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.classTabControl1.Name = "classTabControl1";
            this.classTabControl1.SelectedIndex = 0;
            this.classTabControl1.Size = new System.Drawing.Size(977, 542);
            this.classTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GenereazaTabel);
            this.tabPage2.Controls.Add(this.GridCalculIntretinere);
            this.tabPage2.Controls.Add(this.treeColoane);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(969, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Genereaza tabel intretinere";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GenereazaTabel
            // 
            this.GenereazaTabel.BackColor = System.Drawing.Color.Aquamarine;
            this.GenereazaTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenereazaTabel.Location = new System.Drawing.Point(7, 377);
            this.GenereazaTabel.Margin = new System.Windows.Forms.Padding(2);
            this.GenereazaTabel.Name = "GenereazaTabel";
            this.GenereazaTabel.Size = new System.Drawing.Size(200, 30);
            this.GenereazaTabel.TabIndex = 3;
            this.GenereazaTabel.Text = "Genereaza Tabel";
            this.GenereazaTabel.UseVisualStyleBackColor = false;
            this.GenereazaTabel.Click += new System.EventHandler(this.GenereazaTabel_Click);
            // 
            // GridCalculIntretinere
            // 
            this.GridCalculIntretinere.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCalculIntretinere.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridCalculIntretinere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCalculIntretinere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCalculIntretinere.EnableHeadersVisualStyles = false;
            this.GridCalculIntretinere.Location = new System.Drawing.Point(226, 2);
            this.GridCalculIntretinere.Margin = new System.Windows.Forms.Padding(2);
            this.GridCalculIntretinere.Name = "GridCalculIntretinere";
            this.GridCalculIntretinere.RowHeadersWidth = 51;
            this.GridCalculIntretinere.RowTemplate.Height = 24;
            this.GridCalculIntretinere.Size = new System.Drawing.Size(741, 485);
            this.GridCalculIntretinere.TabIndex = 2;
            // 
            // treeColoane
            // 
            this.treeColoane.CheckBoxes = true;
            this.treeColoane.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeColoane.Location = new System.Drawing.Point(2, 2);
            this.treeColoane.Margin = new System.Windows.Forms.Padding(2);
            this.treeColoane.Name = "treeColoane";
            this.treeColoane.Size = new System.Drawing.Size(224, 485);
            this.treeColoane.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlControale);
            this.tabPage1.Controls.Add(this.PanelConsumAapartament);
            this.tabPage1.Controls.Add(this.PanelTreeConsumAp);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(969, 489);
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
            this.pnlControale.Location = new System.Drawing.Point(839, 2);
            this.pnlControale.Margin = new System.Windows.Forms.Padding(2);
            this.pnlControale.Name = "pnlControale";
            this.pnlControale.Size = new System.Drawing.Size(128, 485);
            this.pnlControale.TabIndex = 11;
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.BackColor = System.Drawing.Color.Red;
            this.btnAnuleaza.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnuleaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnuleaza.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnuleaza.Location = new System.Drawing.Point(0, 456);
            this.btnAnuleaza.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(124, 152);
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
            this.btnOK.Location = new System.Drawing.Point(0, 304);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 152);
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
            this.classButonInteriorSterge1.Location = new System.Drawing.Point(0, 152);
            this.classButonInteriorSterge1.Margin = new System.Windows.Forms.Padding(2);
            this.classButonInteriorSterge1.Name = "classButonInteriorSterge1";
            this.classButonInteriorSterge1.Size = new System.Drawing.Size(124, 152);
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
            this.classButonModifica1.Margin = new System.Windows.Forms.Padding(2);
            this.classButonModifica1.Name = "classButonModifica1";
            this.classButonModifica1.Size = new System.Drawing.Size(124, 152);
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
            this.PanelConsumAapartament.Location = new System.Drawing.Point(254, 2);
            this.PanelConsumAapartament.Margin = new System.Windows.Forms.Padding(2);
            this.PanelConsumAapartament.Name = "PanelConsumAapartament";
            this.PanelConsumAapartament.Size = new System.Drawing.Size(581, 485);
            this.PanelConsumAapartament.TabIndex = 10;
            // 
            // gridAfisareConsumuri
            // 
            this.gridAfisareConsumuri.AllowUserToAddRows = false;
            this.gridAfisareConsumuri.AutoGenerateColumns = false;
            this.gridAfisareConsumuri.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAfisareConsumuri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridAfisareConsumuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAfisareConsumuri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idscDataGridViewTextBoxColumn,
            this.idconsumuriapartamenteDataGridViewTextBoxColumn,
            this.denumireApartamentDataGridViewTextBoxColumn,
            this.consumapareceDataGridViewTextBoxColumn,
            this.consumapacaldaDataGridViewTextBoxColumn,
            this.numarpersoaneDataGridViewTextBoxColumn,
            this.proprietarDataGridViewTextBoxColumn});
            this.gridAfisareConsumuri.DataSource = this.mvConsumApartamenteBindingSource;
            this.gridAfisareConsumuri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAfisareConsumuri.EnableHeadersVisualStyles = false;
            this.gridAfisareConsumuri.Location = new System.Drawing.Point(0, 0);
            this.gridAfisareConsumuri.Name = "gridAfisareConsumuri";
            this.gridAfisareConsumuri.Size = new System.Drawing.Size(577, 481);
            this.gridAfisareConsumuri.TabIndex = 0;
            // 
            // mvConsumApartamenteBindingSource
            // 
            this.mvConsumApartamenteBindingSource.DataMember = "mv_ConsumApartamente";
            this.mvConsumApartamenteBindingSource.DataSource = this.calcul_intretinereDS1;
            // 
            // calcul_intretinereDS1
            // 
            this.calcul_intretinereDS1.DataSetName = "Calcul_intretinereDS";
            this.calcul_intretinereDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PanelTreeConsumAp
            // 
            this.PanelTreeConsumAp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelTreeConsumAp.Controls.Add(this.treeConsumuriApartament);
            this.PanelTreeConsumAp.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTreeConsumAp.Location = new System.Drawing.Point(2, 2);
            this.PanelTreeConsumAp.Margin = new System.Windows.Forms.Padding(2);
            this.PanelTreeConsumAp.Name = "PanelTreeConsumAp";
            this.PanelTreeConsumAp.Size = new System.Drawing.Size(252, 485);
            this.PanelTreeConsumAp.TabIndex = 9;
            // 
            // treeConsumuriApartament
            // 
            this.treeConsumuriApartament.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeConsumuriApartament.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConsumuriApartament.Location = new System.Drawing.Point(0, 0);
            this.treeConsumuriApartament.Margin = new System.Windows.Forms.Padding(2);
            this.treeConsumuriApartament.Name = "treeConsumuriApartament";
            this.treeConsumuriApartament.Size = new System.Drawing.Size(249, 481);
            this.treeConsumuriApartament.TabIndex = 8;
            this.treeConsumuriApartament.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConsumuriApartament_AfterSelect);
            // 
            // calculintretinereDS1BindingSource
            // 
            this.calculintretinereDS1BindingSource.DataSource = this.calcul_intretinereDS1;
            this.calculintretinereDS1BindingSource.Position = 0;
            // 
            // mv_ConsumApartamenteTableAdapter
            // 
            this.mv_ConsumApartamenteTableAdapter.ClearBeforeFill = true;
            // 
            // idscDataGridViewTextBoxColumn
            // 
            this.idscDataGridViewTextBoxColumn.DataPropertyName = "id_sc";
            this.idscDataGridViewTextBoxColumn.HeaderText = "id_sc";
            this.idscDataGridViewTextBoxColumn.Name = "idscDataGridViewTextBoxColumn";
            this.idscDataGridViewTextBoxColumn.Visible = false;
            // 
            // idconsumuriapartamenteDataGridViewTextBoxColumn
            // 
            this.idconsumuriapartamenteDataGridViewTextBoxColumn.DataPropertyName = "id_consumuri_apartamente";
            this.idconsumuriapartamenteDataGridViewTextBoxColumn.HeaderText = "id_consumuri_apartamente";
            this.idconsumuriapartamenteDataGridViewTextBoxColumn.Name = "idconsumuriapartamenteDataGridViewTextBoxColumn";
            this.idconsumuriapartamenteDataGridViewTextBoxColumn.Visible = false;
            // 
            // denumireApartamentDataGridViewTextBoxColumn
            // 
            this.denumireApartamentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.denumireApartamentDataGridViewTextBoxColumn.DataPropertyName = "Denumire Apartament";
            this.denumireApartamentDataGridViewTextBoxColumn.HeaderText = "Denumire Apartament";
            this.denumireApartamentDataGridViewTextBoxColumn.Name = "denumireApartamentDataGridViewTextBoxColumn";
            // 
            // consumapareceDataGridViewTextBoxColumn
            // 
            this.consumapareceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.consumapareceDataGridViewTextBoxColumn.DataPropertyName = "consum_apa_rece";
            this.consumapareceDataGridViewTextBoxColumn.HeaderText = "consum_apa_rece";
            this.consumapareceDataGridViewTextBoxColumn.Name = "consumapareceDataGridViewTextBoxColumn";
            // 
            // consumapacaldaDataGridViewTextBoxColumn
            // 
            this.consumapacaldaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.consumapacaldaDataGridViewTextBoxColumn.DataPropertyName = "consum_apa_calda";
            this.consumapacaldaDataGridViewTextBoxColumn.HeaderText = "consum_apa_calda";
            this.consumapacaldaDataGridViewTextBoxColumn.Name = "consumapacaldaDataGridViewTextBoxColumn";
            // 
            // numarpersoaneDataGridViewTextBoxColumn
            // 
            this.numarpersoaneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numarpersoaneDataGridViewTextBoxColumn.DataPropertyName = "numar_persoane";
            this.numarpersoaneDataGridViewTextBoxColumn.HeaderText = "numar_persoane";
            this.numarpersoaneDataGridViewTextBoxColumn.Name = "numarpersoaneDataGridViewTextBoxColumn";
            this.numarpersoaneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proprietarDataGridViewTextBoxColumn
            // 
            this.proprietarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proprietarDataGridViewTextBoxColumn.DataPropertyName = "Proprietar";
            this.proprietarDataGridViewTextBoxColumn.HeaderText = "Proprietar";
            this.proprietarDataGridViewTextBoxColumn.Name = "proprietarDataGridViewTextBoxColumn";
            // 
            // Calcul_intretinere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 542);
            this.Controls.Add(this.classTabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Calcul_intretinere";
            this.Text = "Calcul_intretinere";
            this.Load += new System.EventHandler(this.Calcul_intretinere_Load);
            this.classTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnlControale.ResumeLayout(false);
            this.PanelConsumAapartament.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAfisareConsumuri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).EndInit();
            this.PanelTreeConsumAp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calculintretinereDS1BindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource calculintretinereDS1BindingSource;
        private System.Windows.Forms.BindingSource mvConsumApartamenteBindingSource;
        private Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter mv_ConsumApartamenteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idscDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idconsumuriapartamenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denumireApartamentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumapareceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumapacaldaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarpersoaneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proprietarDataGridViewTextBoxColumn;
    }
}