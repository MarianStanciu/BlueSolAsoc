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
            this.TabSA = new BlueSolAsoc.butoane_si_controale.ClassTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.classTextBox7 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classLabel8 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel5 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTextBox6 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classLabel7 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel4 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel6 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTextBox4 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classTextBox3 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classTextBox5 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classLabel3 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTextBox2 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.classLabel2 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel1 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classTextBox1 = new BlueSolAsoc.butoane_si_controale.ClassTextBox();
            this.dataGridViewAp = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mvdetaliiOrganizatieApartamentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.asociatieFormDS1 = new BlueSolAsoc.asociatieFormDS();
            this.mvdetaliiOrganizatieBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mvdetaliiOrganizatieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classGroupBox1 = new BlueSolAsoc.butoane_si_controale.ClassGroupBox();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.classButonInteriorSterge1 = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorSterge();
            this.classButonModifica1 = new BlueSolAsoc.butoane_si_controale.ClassButonModifica();
            this.mv_detaliiOrganizatieTableAdapter = new BlueSolAsoc.asociatieFormDSTableAdapters.mv_detaliiOrganizatieTableAdapter();
            this.mvdetaliiOrganizatieApartamentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabSA.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieApartamentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asociatieFormDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieBindingSource)).BeginInit();
            this.classGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieApartamentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabSA
            // 
            this.TabSA.Controls.Add(this.tabPage1);
            this.TabSA.Controls.Add(this.tabPage2);
            this.TabSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabSA.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabSA.ItemSize = new System.Drawing.Size(150, 50);
            this.TabSA.Location = new System.Drawing.Point(0, 0);
            this.TabSA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TabSA.Name = "TabSA";
            this.TabSA.SelectedIndex = 0;
            this.TabSA.Size = new System.Drawing.Size(1212, 759);
            this.TabSA.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1204, 701);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Structura Asociatie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(214, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox7);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel8);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel5);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox6);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel7);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox4);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox3);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox5);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.classLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.classTextBox1);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.splitContainer1_Panel1_Click);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Maroon;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewAp);
            this.splitContainer1.Panel2.Click += new System.EventHandler(this.splitContainer1_Panel2_Click);
            this.splitContainer1.Size = new System.Drawing.Size(988, 695);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // classTextBox7
            // 
            this.classTextBox7.Location = new System.Drawing.Point(4, 74);
            this.classTextBox7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox7.Name = "classTextBox7";
            this.classTextBox7.Size = new System.Drawing.Size(204, 39);
            this.classTextBox7.TabIndex = 14;
            this.classTextBox7.Tag = "5";
            // 
            // classLabel8
            // 
            this.classLabel8.AutoSize = true;
            this.classLabel8.Location = new System.Drawing.Point(-1, 41);
            this.classLabel8.Name = "classLabel8";
            this.classLabel8.Size = new System.Drawing.Size(144, 30);
            this.classLabel8.TabIndex = 13;
            this.classLabel8.Tag = "5";
            this.classLabel8.Text = "classLabel8";
            // 
            // classLabel5
            // 
            this.classLabel5.AutoSize = true;
            this.classLabel5.Location = new System.Drawing.Point(-1, 374);
            this.classLabel5.Name = "classLabel5";
            this.classLabel5.Size = new System.Drawing.Size(144, 30);
            this.classLabel5.TabIndex = 4;
            this.classLabel5.Tag = "3";
            this.classLabel5.Text = "classLabel5";
            // 
            // classTextBox6
            // 
            this.classTextBox6.Location = new System.Drawing.Point(4, 586);
            this.classTextBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox6.Name = "classTextBox6";
            this.classTextBox6.Size = new System.Drawing.Size(204, 39);
            this.classTextBox6.TabIndex = 12;
            this.classTextBox6.Tag = "6";
            // 
            // classLabel7
            // 
            this.classLabel7.AutoSize = true;
            this.classLabel7.Location = new System.Drawing.Point(-1, 553);
            this.classLabel7.Name = "classLabel7";
            this.classLabel7.Size = new System.Drawing.Size(144, 30);
            this.classLabel7.TabIndex = 6;
            this.classLabel7.Tag = "6";
            this.classLabel7.Text = "classLabel7";
            // 
            // classLabel4
            // 
            this.classLabel4.AutoSize = true;
            this.classLabel4.Location = new System.Drawing.Point(-1, 286);
            this.classLabel4.Name = "classLabel4";
            this.classLabel4.Size = new System.Drawing.Size(144, 30);
            this.classLabel4.TabIndex = 3;
            this.classLabel4.Tag = "2";
            this.classLabel4.Text = "classLabel4";
            // 
            // classLabel6
            // 
            this.classLabel6.AutoSize = true;
            this.classLabel6.Location = new System.Drawing.Point(-1, 463);
            this.classLabel6.Name = "classLabel6";
            this.classLabel6.Size = new System.Drawing.Size(144, 30);
            this.classLabel6.TabIndex = 5;
            this.classLabel6.Tag = "4";
            this.classLabel6.Text = "classLabel6";
            // 
            // classTextBox4
            // 
            this.classTextBox4.Location = new System.Drawing.Point(4, 407);
            this.classTextBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox4.Name = "classTextBox4";
            this.classTextBox4.Size = new System.Drawing.Size(204, 39);
            this.classTextBox4.TabIndex = 10;
            this.classTextBox4.Tag = "3";
            // 
            // classTextBox3
            // 
            this.classTextBox3.Location = new System.Drawing.Point(4, 319);
            this.classTextBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox3.Name = "classTextBox3";
            this.classTextBox3.Size = new System.Drawing.Size(204, 39);
            this.classTextBox3.TabIndex = 9;
            this.classTextBox3.Tag = "2";
            // 
            // classTextBox5
            // 
            this.classTextBox5.Location = new System.Drawing.Point(4, 496);
            this.classTextBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox5.Name = "classTextBox5";
            this.classTextBox5.Size = new System.Drawing.Size(204, 39);
            this.classTextBox5.TabIndex = 11;
            this.classTextBox5.Tag = "4";
            // 
            // classLabel3
            // 
            this.classLabel3.AutoSize = true;
            this.classLabel3.Location = new System.Drawing.Point(-1, 202);
            this.classLabel3.Name = "classLabel3";
            this.classLabel3.Size = new System.Drawing.Size(144, 30);
            this.classLabel3.TabIndex = 2;
            this.classLabel3.Tag = "1";
            this.classLabel3.Text = "classLabel3";
            // 
            // classTextBox2
            // 
            this.classTextBox2.Location = new System.Drawing.Point(4, 235);
            this.classTextBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox2.Name = "classTextBox2";
            this.classTextBox2.Size = new System.Drawing.Size(204, 39);
            this.classTextBox2.TabIndex = 8;
            this.classTextBox2.Tag = "1";
            // 
            // classLabel2
            // 
            this.classLabel2.AutoSize = true;
            this.classLabel2.Location = new System.Drawing.Point(-1, 115);
            this.classLabel2.Name = "classLabel2";
            this.classLabel2.Size = new System.Drawing.Size(144, 30);
            this.classLabel2.TabIndex = 1;
            this.classLabel2.Tag = "0";
            this.classLabel2.Text = "classLabel2";
            // 
            // classLabel1
            // 
            this.classLabel1.AutoSize = true;
            this.classLabel1.Location = new System.Drawing.Point(22, 0);
            this.classLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classLabel1.Name = "classLabel1";
            this.classLabel1.Size = new System.Drawing.Size(144, 30);
            this.classLabel1.TabIndex = 0;
            this.classLabel1.Tag = "titlu";
            this.classLabel1.Text = "classLabel1";
            // 
            // classTextBox1
            // 
            this.classTextBox1.Location = new System.Drawing.Point(4, 148);
            this.classTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classTextBox1.Name = "classTextBox1";
            this.classTextBox1.Size = new System.Drawing.Size(204, 39);
            this.classTextBox1.TabIndex = 7;
            this.classTextBox1.Tag = "0";
            // 
            // dataGridViewAp
            // 
            this.dataGridViewAp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAp.Name = "dataGridViewAp";
            this.dataGridViewAp.RowHeadersWidth = 51;
            this.dataGridViewAp.RowTemplate.Height = 24;
            this.dataGridViewAp.Size = new System.Drawing.Size(761, 695);
            this.dataGridViewAp.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(2, 3);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 695);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(1204, 701);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Structura Cheltuieli";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mvdetaliiOrganizatieApartamentBindingSource1
            // 
            this.mvdetaliiOrganizatieApartamentBindingSource1.DataMember = "mv_detaliiOrganizatieApartament";
            this.mvdetaliiOrganizatieApartamentBindingSource1.DataSource = this.asociatieFormDS1;
            // 
            // asociatieFormDS1
            // 
            this.asociatieFormDS1.DataSetName = "asociatieFormDS";
            this.asociatieFormDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mvdetaliiOrganizatieBindingSource1
            // 
            this.mvdetaliiOrganizatieBindingSource1.DataMember = "mv_detaliiOrganizatie";
            this.mvdetaliiOrganizatieBindingSource1.DataSource = this.asociatieFormDS1;
            // 
            // mvdetaliiOrganizatieBindingSource
            // 
            this.mvdetaliiOrganizatieBindingSource.DataMember = "mv_detaliiOrganizatie";
            this.mvdetaliiOrganizatieBindingSource.DataSource = this.asociatieFormDS1;
            // 
            // classGroupBox1
            // 
            this.classGroupBox1.Controls.Add(this.btnAnuleaza);
            this.classGroupBox1.Controls.Add(this.btnOK);
            this.classGroupBox1.Controls.Add(this.classButonInteriorSterge1);
            this.classGroupBox1.Controls.Add(this.classButonModifica1);
            this.classGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.classGroupBox1.Location = new System.Drawing.Point(1054, 0);
            this.classGroupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classGroupBox1.Name = "classGroupBox1";
            this.classGroupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classGroupBox1.Size = new System.Drawing.Size(158, 759);
            this.classGroupBox1.TabIndex = 4;
            this.classGroupBox1.TabStop = false;
            this.classGroupBox1.Text = "Controale";
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnuleaza.BackColor = System.Drawing.Color.Red;
            this.btnAnuleaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnuleaza.Location = new System.Drawing.Point(0, 569);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(158, 180);
            this.btnAnuleaza.TabIndex = 6;
            this.btnAnuleaza.Text = "ANULEAZA";
            this.btnAnuleaza.UseVisualStyleBackColor = false;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(0, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(158, 163);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // classButonInteriorSterge1
            // 
            this.classButonInteriorSterge1.BackColor = System.Drawing.Color.Red;
            this.classButonInteriorSterge1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonInteriorSterge1.Location = new System.Drawing.Point(0, 238);
            this.classButonInteriorSterge1.Name = "classButonInteriorSterge1";
            this.classButonInteriorSterge1.Size = new System.Drawing.Size(158, 177);
            this.classButonInteriorSterge1.TabIndex = 4;
            this.classButonInteriorSterge1.Text = "STERGE";
            this.classButonInteriorSterge1.UseVisualStyleBackColor = false;
            // 
            // classButonModifica1
            // 
            this.classButonModifica1.BackColor = System.Drawing.Color.Yellow;
            this.classButonModifica1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButonModifica1.Location = new System.Drawing.Point(0, 60);
            this.classButonModifica1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.classButonModifica1.Name = "classButonModifica1";
            this.classButonModifica1.Size = new System.Drawing.Size(158, 181);
            this.classButonModifica1.TabIndex = 3;
            this.classButonModifica1.Text = "MODIFICA";
            this.classButonModifica1.UseVisualStyleBackColor = false;
            this.classButonModifica1.Click += new System.EventHandler(this.classButonModifica1_Click);
            // 
            // mv_detaliiOrganizatieTableAdapter
            // 
            this.mv_detaliiOrganizatieTableAdapter.ClearBeforeFill = true;
            // 
            // mvdetaliiOrganizatieApartamentBindingSource
            // 
            this.mvdetaliiOrganizatieApartamentBindingSource.DataMember = "mv_detaliiOrganizatieApartament";
            this.mvdetaliiOrganizatieApartamentBindingSource.DataSource = this.asociatieFormDS1;
            // 
            // AsociatieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 759);
            this.Controls.Add(this.classGroupBox1);
            this.Controls.Add(this.TabSA);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "AsociatieForm";
            this.Text = "AsociatieForm1";
            this.Load += new System.EventHandler(this.AsociatieForm_Load);
            this.TabSA.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieApartamentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asociatieFormDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieBindingSource)).EndInit();
            this.classGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mvdetaliiOrganizatieApartamentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private butoane_si_controale.ClassTabControl TabSA;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        
        private butoane_si_controale.ClassLabel classLabel4;
        private butoane_si_controale.ClassTextBox classTextBox3;
        private butoane_si_controale.ClassLabel classLabel1;
        private butoane_si_controale.ClassTextBox classTextBox2;
        private butoane_si_controale.ClassLabel classLabel3;
        private butoane_si_controale.ClassLabel classLabel2;
        private butoane_si_controale.ClassTextBox classTextBox1;
        
        private butoane_si_controale.ClassGroupBox classGroupBox1;
        private butoane_si_controale.ClassButonModifica classButonModifica1;
        private butoane_si_controale.ClassLabel classLabel5;
        private butoane_si_controale.ClassTextBox classTextBox6;
        private butoane_si_controale.ClassLabel classLabel7;
        private butoane_si_controale.ClassLabel classLabel6;
        private butoane_si_controale.ClassTextBox classTextBox4;
        private butoane_si_controale.ClassTextBox classTextBox5;
        private butoane_si_controale.ClassTextBox classTextBox7;
        private butoane_si_controale.ClassLabel classLabel8;
        private butoane_si_controale.ClassButonInteriorSterge classButonInteriorSterge1;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.Button btnOK;
        private asociatieFormDS asociatieFormDS1;
   

        private System.Windows.Forms.BindingSource mvdetaliiOrganizatieBindingSource;
        private asociatieFormDSTableAdapters.mv_detaliiOrganizatieTableAdapter mv_detaliiOrganizatieTableAdapter;
        private System.Windows.Forms.BindingSource mvdetaliiOrganizatieBindingSource1;
        private System.Windows.Forms.BindingSource mvdetaliiOrganizatieApartamentBindingSource1;
        private System.Windows.Forms.BindingSource mvdetaliiOrganizatieApartamentBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewAp;
    }
}