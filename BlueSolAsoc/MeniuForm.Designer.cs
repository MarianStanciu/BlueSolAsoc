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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumeFirma = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.lblLunaCurenta = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel3 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.lblNumeAsociatie = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMama = new System.Windows.Forms.Panel();
            this.panelSelectareLuni = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.classButon1 = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.comboBoxLUNA = new System.Windows.Forms.ComboBox();
            this.comboBoxAN = new System.Windows.Forms.ComboBox();
            this.classLabel2 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel1 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.panelTabelLuni = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.gridTabelaLuni = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.dataSetComboBox1 = new BlueSolAsoc.DataSetComboBox();
            this.mvtabelaluniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mv_tabela_luniTableAdapter = new BlueSolAsoc.DataSetComboBoxTableAdapters.mv_tabela_luniTableAdapter();
            this.lunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idorgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lunaincheiataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataafisareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlMama.SuspendLayout();
            this.panelSelectareLuni.SuspendLayout();
            this.panelTabelLuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabelaLuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvtabelaluniBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.lblNumeFirma);
            this.panel1.Controls.Add(this.lblLunaCurenta);
            this.panel1.Controls.Add(this.classLabel3);
            this.panel1.Controls.Add(this.lblNumeAsociatie);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1574, 30);
            this.panel1.TabIndex = 2;
            // 
            // lblNumeFirma
            // 
            this.lblNumeFirma.AutoSize = true;
            this.lblNumeFirma.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeFirma.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeFirma.Location = new System.Drawing.Point(1326, 5);
            this.lblNumeFirma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeFirma.Name = "lblNumeFirma";
            this.lblNumeFirma.Size = new System.Drawing.Size(49, 24);
            this.lblNumeFirma.TabIndex = 8;
            this.lblNumeFirma.Text = "ceas";
            // 
            // lblLunaCurenta
            // 
            this.lblLunaCurenta.AutoSize = true;
            this.lblLunaCurenta.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunaCurenta.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblLunaCurenta.Location = new System.Drawing.Point(409, 5);
            this.lblLunaCurenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLunaCurenta.Name = "lblLunaCurenta";
            this.lblLunaCurenta.Size = new System.Drawing.Size(119, 24);
            this.lblLunaCurenta.TabIndex = 8;
            this.lblLunaCurenta.Text = "luna curenta";
            // 
            // classLabel3
            // 
            this.classLabel3.AutoSize = true;
            this.classLabel3.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLabel3.ForeColor = System.Drawing.Color.PaleGreen;
            this.classLabel3.Location = new System.Drawing.Point(688, 5);
            this.classLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classLabel3.Name = "classLabel3";
            this.classLabel3.Size = new System.Drawing.Size(176, 24);
            this.classLabel3.TabIndex = 2;
            this.classLabel3.Text = "nume buton meniu";
            this.classLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumeAsociatie
            // 
            this.lblNumeAsociatie.AutoSize = true;
            this.lblNumeAsociatie.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeAsociatie.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeAsociatie.Location = new System.Drawing.Point(19, 5);
            this.lblNumeAsociatie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeAsociatie.Name = "lblNumeAsociatie";
            this.lblNumeAsociatie.Size = new System.Drawing.Size(147, 24);
            this.lblNumeAsociatie.TabIndex = 8;
            this.lblNumeAsociatie.Text = "asociatia activa";
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
            this.pnlMama.Controls.Add(this.panelSelectareLuni);
            this.pnlMama.Controls.Add(this.panelTabelLuni);
            this.pnlMama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMama.Location = new System.Drawing.Point(0, 112);
            this.pnlMama.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMama.Name = "pnlMama";
            this.pnlMama.Size = new System.Drawing.Size(1574, 692);
            this.pnlMama.TabIndex = 5;
            // 
            // panelSelectareLuni
            // 
            this.panelSelectareLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSelectareLuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelectareLuni.Controls.Add(this.classButon1);
            this.panelSelectareLuni.Controls.Add(this.comboBoxLUNA);
            this.panelSelectareLuni.Controls.Add(this.comboBoxAN);
            this.panelSelectareLuni.Controls.Add(this.classLabel2);
            this.panelSelectareLuni.Controls.Add(this.classLabel1);
            this.panelSelectareLuni.Location = new System.Drawing.Point(4, 4);
            this.panelSelectareLuni.Name = "panelSelectareLuni";
            this.panelSelectareLuni.Size = new System.Drawing.Size(453, 680);
            this.panelSelectareLuni.TabIndex = 7;
            // 
            // classButon1
            // 
            this.classButon1.BackColor = System.Drawing.Color.Aquamarine;
            this.classButon1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButon1.Location = new System.Drawing.Point(115, 170);
            this.classButon1.Name = "classButon1";
            this.classButon1.Size = new System.Drawing.Size(146, 48);
            this.classButon1.TabIndex = 4;
            this.classButon1.Text = "Adauga luna noua";
            this.classButon1.UseVisualStyleBackColor = false;
            this.classButon1.Click += new System.EventHandler(this.classButon1_Click);
            // 
            // comboBoxLUNA
            // 
            this.comboBoxLUNA.FormattingEnabled = true;
            this.comboBoxLUNA.Location = new System.Drawing.Point(169, 110);
            this.comboBoxLUNA.Name = "comboBoxLUNA";
            this.comboBoxLUNA.Size = new System.Drawing.Size(108, 24);
            this.comboBoxLUNA.TabIndex = 3;
            // 
            // comboBoxAN
            // 
            this.comboBoxAN.FormattingEnabled = true;
            this.comboBoxAN.Location = new System.Drawing.Point(169, 66);
            this.comboBoxAN.Name = "comboBoxAN";
            this.comboBoxAN.Size = new System.Drawing.Size(108, 24);
            this.comboBoxAN.TabIndex = 2;
            // 
            // classLabel2
            // 
            this.classLabel2.AutoSize = true;
            this.classLabel2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.classLabel2.Location = new System.Drawing.Point(4, 110);
            this.classLabel2.Name = "classLabel2";
            this.classLabel2.Size = new System.Drawing.Size(147, 24);
            this.classLabel2.TabIndex = 1;
            this.classLabel2.Text = "Selectie LUNA";
            // 
            // classLabel1
            // 
            this.classLabel1.AutoSize = true;
            this.classLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.classLabel1.Location = new System.Drawing.Point(33, 63);
            this.classLabel1.Name = "classLabel1";
            this.classLabel1.Size = new System.Drawing.Size(118, 24);
            this.classLabel1.TabIndex = 0;
            this.classLabel1.Text = "Selectie AN";
            // 
            // panelTabelLuni
            // 
            this.panelTabelLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabelLuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabelLuni.Controls.Add(this.gridTabelaLuni);
            this.panelTabelLuni.Location = new System.Drawing.Point(1088, 4);
            this.panelTabelLuni.Name = "panelTabelLuni";
            this.panelTabelLuni.Size = new System.Drawing.Size(483, 685);
            this.panelTabelLuni.TabIndex = 6;
            // 
            // gridTabelaLuni
            // 
            this.gridTabelaLuni.AllowUserToAddRows = false;
            this.gridTabelaLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTabelaLuni.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTabelaLuni.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTabelaLuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTabelaLuni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lunaDataGridViewTextBoxColumn,
            this.anDataGridViewTextBoxColumn,
            this.activDataGridViewTextBoxColumn,
            this.idorgDataGridViewTextBoxColumn,
            this.lunaincheiataDataGridViewTextBoxColumn,
            this.dataafisareDataGridViewTextBoxColumn});
            this.gridTabelaLuni.DataSource = this.mvtabelaluniBindingSource;
            this.gridTabelaLuni.EnableHeadersVisualStyles = false;
            this.gridTabelaLuni.Location = new System.Drawing.Point(-2, -2);
            this.gridTabelaLuni.MinimumSize = new System.Drawing.Size(228, 294);
            this.gridTabelaLuni.Name = "gridTabelaLuni";
            this.gridTabelaLuni.RowHeadersWidth = 51;
            this.gridTabelaLuni.Size = new System.Drawing.Size(483, 680);
            this.gridTabelaLuni.TabIndex = 5;
            // 
            // dataSetComboBox1
            // 
            this.dataSetComboBox1.DataSetName = "DataSetComboBox";
            this.dataSetComboBox1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mvtabelaluniBindingSource
            // 
            this.mvtabelaluniBindingSource.DataMember = "mv_tabela_luni";
            this.mvtabelaluniBindingSource.DataSource = this.dataSetComboBox1;
            // 
            // mv_tabela_luniTableAdapter
            // 
            this.mv_tabela_luniTableAdapter.ClearBeforeFill = true;
            // 
            // lunaDataGridViewTextBoxColumn
            // 
            this.lunaDataGridViewTextBoxColumn.DataPropertyName = "luna";
            this.lunaDataGridViewTextBoxColumn.HeaderText = "luna";
            this.lunaDataGridViewTextBoxColumn.Name = "lunaDataGridViewTextBoxColumn";
            // 
            // anDataGridViewTextBoxColumn
            // 
            this.anDataGridViewTextBoxColumn.DataPropertyName = "an";
            this.anDataGridViewTextBoxColumn.HeaderText = "an";
            this.anDataGridViewTextBoxColumn.Name = "anDataGridViewTextBoxColumn";
            // 
            // activDataGridViewTextBoxColumn
            // 
            this.activDataGridViewTextBoxColumn.DataPropertyName = "activ";
            this.activDataGridViewTextBoxColumn.HeaderText = "activ";
            this.activDataGridViewTextBoxColumn.Name = "activDataGridViewTextBoxColumn";
            // 
            // idorgDataGridViewTextBoxColumn
            // 
            this.idorgDataGridViewTextBoxColumn.DataPropertyName = "id_org";
            this.idorgDataGridViewTextBoxColumn.HeaderText = "id_org";
            this.idorgDataGridViewTextBoxColumn.Name = "idorgDataGridViewTextBoxColumn";
            // 
            // lunaincheiataDataGridViewTextBoxColumn
            // 
            this.lunaincheiataDataGridViewTextBoxColumn.DataPropertyName = "luna_incheiata";
            this.lunaincheiataDataGridViewTextBoxColumn.HeaderText = "luna_incheiata";
            this.lunaincheiataDataGridViewTextBoxColumn.Name = "lunaincheiataDataGridViewTextBoxColumn";
            // 
            // dataafisareDataGridViewTextBoxColumn
            // 
            this.dataafisareDataGridViewTextBoxColumn.DataPropertyName = "data_afisare";
            this.dataafisareDataGridViewTextBoxColumn.HeaderText = "data_afisare";
            this.dataafisareDataGridViewTextBoxColumn.Name = "dataafisareDataGridViewTextBoxColumn";
            // 
            // MeniuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 804);
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
            this.pnlMama.ResumeLayout(false);
            this.panelSelectareLuni.ResumeLayout(false);
            this.panelSelectareLuni.PerformLayout();
            this.panelTabelLuni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTabelaLuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvtabelaluniBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMama;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxLUNA;
        private System.Windows.Forms.ComboBox comboBoxAN;
        private butoane_si_controale.ClassLabel classLabel2;
        private butoane_si_controale.ClassLabel classLabel1;
        private butoane_si_controale.ClassButon classButon1;
        private butoane_si_controale.ClassGridView gridTabelaLuni;
        private butoane_si_controale.ClassLabel classLabel3;
        private butoane_si_controale.ClassPanel panelTabelLuni;
        private butoane_si_controale.ClassPanel panelSelectareLuni;
        private butoane_si_controale.ClassLabel lblNumeAsociatie;
        private butoane_si_controale.ClassLabel lblNumeFirma;
        private butoane_si_controale.ClassLabel lblLunaCurenta;
        private DataSetComboBox dataSetComboBox1;
        private System.Windows.Forms.BindingSource mvtabelaluniBindingSource;
        private DataSetComboBoxTableAdapters.mv_tabela_luniTableAdapter mv_tabela_luniTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunaincheiataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataafisareDataGridViewTextBoxColumn;
    }
}