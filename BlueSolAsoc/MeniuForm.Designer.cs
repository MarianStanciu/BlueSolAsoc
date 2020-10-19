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
            this.lblSelectieLuna = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.lblSelectieAn = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.panelTabelLuni = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.gridTabelaLuni = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.lunaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idorgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lunaincheiataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataafisareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mvtabelaluniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetComboBox1 = new BlueSolAsoc.DataSetComboBox();
            this.mv_tabela_luniTableAdapter = new BlueSolAsoc.DataSetComboBoxTableAdapters.mv_tabela_luniTableAdapter();
            this.panel1.SuspendLayout();
            this.pnlMama.SuspendLayout();
            this.panelSelectareLuni.SuspendLayout();
            this.panelTabelLuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabelaLuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvtabelaluniBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 108);
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
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 39);
            this.panel1.TabIndex = 2;
            // 
            // lblNumeFirma
            // 
            this.lblNumeFirma.AutoSize = true;
            this.lblNumeFirma.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeFirma.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeFirma.Location = new System.Drawing.Point(1621, 7);
            this.lblNumeFirma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeFirma.Name = "lblNumeFirma";
            this.lblNumeFirma.Size = new System.Drawing.Size(60, 30);
            this.lblNumeFirma.TabIndex = 8;
            this.lblNumeFirma.Text = "ceas";
            // 
            // lblLunaCurenta
            // 
            this.lblLunaCurenta.AutoSize = true;
            this.lblLunaCurenta.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunaCurenta.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblLunaCurenta.Location = new System.Drawing.Point(500, 7);
            this.lblLunaCurenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLunaCurenta.Name = "lblLunaCurenta";
            this.lblLunaCurenta.Size = new System.Drawing.Size(149, 30);
            this.lblLunaCurenta.TabIndex = 8;
            this.lblLunaCurenta.Text = "luna curenta";
            // 
            // classLabel3
            // 
            this.classLabel3.AutoSize = true;
            this.classLabel3.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLabel3.ForeColor = System.Drawing.Color.PaleGreen;
            this.classLabel3.Location = new System.Drawing.Point(841, 7);
            this.classLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classLabel3.Name = "classLabel3";
            this.classLabel3.Size = new System.Drawing.Size(223, 30);
            this.classLabel3.TabIndex = 2;
            this.classLabel3.Text = "nume buton meniu";
            this.classLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumeAsociatie
            // 
            this.lblNumeAsociatie.AutoSize = true;
            this.lblNumeAsociatie.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeAsociatie.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeAsociatie.Location = new System.Drawing.Point(23, 7);
            this.lblNumeAsociatie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeAsociatie.Name = "lblNumeAsociatie";
            this.lblNumeAsociatie.Size = new System.Drawing.Size(183, 30);
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
            this.pnlMama.Location = new System.Drawing.Point(0, 147);
            this.pnlMama.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlMama.Name = "pnlMama";
            this.pnlMama.Size = new System.Drawing.Size(1924, 908);
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
            this.panelSelectareLuni.Controls.Add(this.lblSelectieLuna);
            this.panelSelectareLuni.Controls.Add(this.lblSelectieAn);
            this.panelSelectareLuni.Location = new System.Drawing.Point(5, 5);
            this.panelSelectareLuni.Margin = new System.Windows.Forms.Padding(4);
            this.panelSelectareLuni.Name = "panelSelectareLuni";
            this.panelSelectareLuni.Size = new System.Drawing.Size(499, 891);
            this.panelSelectareLuni.TabIndex = 7;
            // 
            // classButon1
            // 
            this.classButon1.BackColor = System.Drawing.Color.Aquamarine;
            this.classButon1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButon1.Location = new System.Drawing.Point(141, 223);
            this.classButon1.Margin = new System.Windows.Forms.Padding(4);
            this.classButon1.Name = "classButon1";
            this.classButon1.Size = new System.Drawing.Size(178, 63);
            this.classButon1.TabIndex = 4;
            this.classButon1.Text = "Adauga luna noua";
            this.classButon1.UseVisualStyleBackColor = false;
            this.classButon1.Click += new System.EventHandler(this.classButon1_Click);
            // 
            // comboBoxLUNA
            // 
            this.comboBoxLUNA.FormattingEnabled = true;
            this.comboBoxLUNA.Location = new System.Drawing.Point(207, 144);
            this.comboBoxLUNA.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLUNA.Name = "comboBoxLUNA";
            this.comboBoxLUNA.Size = new System.Drawing.Size(131, 29);
            this.comboBoxLUNA.TabIndex = 3;
            // 
            // comboBoxAN
            // 
            this.comboBoxAN.FormattingEnabled = true;
            this.comboBoxAN.Location = new System.Drawing.Point(207, 87);
            this.comboBoxAN.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAN.Name = "comboBoxAN";
            this.comboBoxAN.Size = new System.Drawing.Size(131, 29);
            this.comboBoxAN.TabIndex = 2;
            // 
            // lblSelectieLuna
            // 
            this.lblSelectieLuna.AutoSize = true;
            this.lblSelectieLuna.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.lblSelectieLuna.Location = new System.Drawing.Point(5, 144);
            this.lblSelectieLuna.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectieLuna.Name = "lblSelectieLuna";
            this.lblSelectieLuna.Size = new System.Drawing.Size(185, 30);
            this.lblSelectieLuna.TabIndex = 1;
            this.lblSelectieLuna.Text = "Selectie LUNA";
            // 
            // lblSelectieAn
            // 
            this.lblSelectieAn.AutoSize = true;
            this.lblSelectieAn.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F);
            this.lblSelectieAn.Location = new System.Drawing.Point(40, 83);
            this.lblSelectieAn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectieAn.Name = "lblSelectieAn";
            this.lblSelectieAn.Size = new System.Drawing.Size(148, 30);
            this.lblSelectieAn.TabIndex = 0;
            this.lblSelectieAn.Text = "Selectie AN";
            // 
            // panelTabelLuni
            // 
            this.panelTabelLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabelLuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabelLuni.Controls.Add(this.gridTabelaLuni);
            this.panelTabelLuni.Location = new System.Drawing.Point(1330, 5);
            this.panelTabelLuni.Margin = new System.Windows.Forms.Padding(4);
            this.panelTabelLuni.Name = "panelTabelLuni";
            this.panelTabelLuni.Size = new System.Drawing.Size(589, 898);
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
            this.gridTabelaLuni.Location = new System.Drawing.Point(-2, -3);
            this.gridTabelaLuni.Margin = new System.Windows.Forms.Padding(4);
            this.gridTabelaLuni.MinimumSize = new System.Drawing.Size(279, 386);
            this.gridTabelaLuni.Name = "gridTabelaLuni";
            this.gridTabelaLuni.RowHeadersWidth = 51;
            this.gridTabelaLuni.Size = new System.Drawing.Size(590, 892);
            this.gridTabelaLuni.TabIndex = 5;
            // 
            // lunaDataGridViewTextBoxColumn
            // 
            this.lunaDataGridViewTextBoxColumn.DataPropertyName = "luna";
            this.lunaDataGridViewTextBoxColumn.HeaderText = "luna";
            this.lunaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lunaDataGridViewTextBoxColumn.Name = "lunaDataGridViewTextBoxColumn";
            this.lunaDataGridViewTextBoxColumn.Width = 125;
            // 
            // anDataGridViewTextBoxColumn
            // 
            this.anDataGridViewTextBoxColumn.DataPropertyName = "an";
            this.anDataGridViewTextBoxColumn.HeaderText = "an";
            this.anDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.anDataGridViewTextBoxColumn.Name = "anDataGridViewTextBoxColumn";
            this.anDataGridViewTextBoxColumn.Width = 125;
            // 
            // activDataGridViewTextBoxColumn
            // 
            this.activDataGridViewTextBoxColumn.DataPropertyName = "activ";
            this.activDataGridViewTextBoxColumn.FalseValue = "";
            this.activDataGridViewTextBoxColumn.HeaderText = "activ";
            this.activDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.activDataGridViewTextBoxColumn.Name = "activDataGridViewTextBoxColumn";
            this.activDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.activDataGridViewTextBoxColumn.TrueValue = "";
            this.activDataGridViewTextBoxColumn.Width = 125;
            // 
            // idorgDataGridViewTextBoxColumn
            // 
            this.idorgDataGridViewTextBoxColumn.DataPropertyName = "id_org";
            this.idorgDataGridViewTextBoxColumn.HeaderText = "id_org";
            this.idorgDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idorgDataGridViewTextBoxColumn.Name = "idorgDataGridViewTextBoxColumn";
            this.idorgDataGridViewTextBoxColumn.Width = 125;
            // 
            // lunaincheiataDataGridViewTextBoxColumn
            // 
            this.lunaincheiataDataGridViewTextBoxColumn.DataPropertyName = "luna_incheiata";
            this.lunaincheiataDataGridViewTextBoxColumn.HeaderText = "luna_incheiata";
            this.lunaincheiataDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lunaincheiataDataGridViewTextBoxColumn.Name = "lunaincheiataDataGridViewTextBoxColumn";
            this.lunaincheiataDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lunaincheiataDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lunaincheiataDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataafisareDataGridViewTextBoxColumn
            // 
            this.dataafisareDataGridViewTextBoxColumn.DataPropertyName = "data_afisare";
            this.dataafisareDataGridViewTextBoxColumn.HeaderText = "data_afisare";
            this.dataafisareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataafisareDataGridViewTextBoxColumn.Name = "dataafisareDataGridViewTextBoxColumn";
            this.dataafisareDataGridViewTextBoxColumn.Width = 125;
            // 
            // mvtabelaluniBindingSource
            // 
            this.mvtabelaluniBindingSource.DataMember = "mv_tabela_luni";
            this.mvtabelaluniBindingSource.DataSource = this.dataSetComboBox1;
            // 
            // dataSetComboBox1
            // 
            this.dataSetComboBox1.DataSetName = "DataSetComboBox";
            this.dataSetComboBox1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mv_tabela_luniTableAdapter
            // 
            this.mv_tabela_luniTableAdapter.ClearBeforeFill = true;
            // 
            // MeniuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnlMama);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
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
            ((System.ComponentModel.ISupportInitialize)(this.mvtabelaluniBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMama;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxLUNA;
        private System.Windows.Forms.ComboBox comboBoxAN;
        private butoane_si_controale.ClassLabel lblSelectieLuna;
        private butoane_si_controale.ClassLabel lblSelectieAn;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn activDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lunaincheiataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataafisareDataGridViewTextBoxColumn;
    }
}