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
            this.classLabel3 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.lblNumeFirma = new System.Windows.Forms.Label();
            this.lblCeas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMama = new System.Windows.Forms.Panel();
            this.gridTabelaLuni = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.classButon1 = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.comboBoxLUNA = new System.Windows.Forms.ComboBox();
            this.comboBoxAN = new System.Windows.Forms.ComboBox();
            this.classLabel2 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.classLabel1 = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.panelTabelLuni = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.panelSelectareLuni = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.panel1.SuspendLayout();
            this.pnlMama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabelaLuni)).BeginInit();
            this.panelTabelLuni.SuspendLayout();
            this.panelSelectareLuni.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.classLabel3);
            this.panel1.Controls.Add(this.lblNumeFirma);
            this.panel1.Controls.Add(this.lblCeas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 30);
            this.panel1.TabIndex = 2;
            // 
            // classLabel3
            // 
            this.classLabel3.AutoSize = true;
            this.classLabel3.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classLabel3.ForeColor = System.Drawing.Color.White;
            this.classLabel3.Location = new System.Drawing.Point(47, 2);
            this.classLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.classLabel3.Name = "classLabel3";
            this.classLabel3.Size = new System.Drawing.Size(126, 24);
            this.classLabel3.TabIndex = 2;
            this.classLabel3.Text = "classLabel3";
            // 
            // lblNumeFirma
            // 
            this.lblNumeFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumeFirma.AutoSize = true;
            this.lblNumeFirma.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeFirma.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblNumeFirma.Location = new System.Drawing.Point(1694, 4);
            this.lblNumeFirma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeFirma.Name = "lblNumeFirma";
            this.lblNumeFirma.Size = new System.Drawing.Size(189, 22);
            this.lblNumeFirma.TabIndex = 1;
            this.lblNumeFirma.Text = "BlueBit Data SRL";
            // 
            // lblCeas
            // 
            this.lblCeas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCeas.AutoSize = true;
            this.lblCeas.Font = new System.Drawing.Font("MS PGothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCeas.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblCeas.Location = new System.Drawing.Point(1711, 2);
            this.lblCeas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCeas.Name = "lblCeas";
            this.lblCeas.Size = new System.Drawing.Size(67, 24);
            this.lblCeas.TabIndex = 0;
            this.lblCeas.Text = "label1";
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
            this.pnlMama.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMama.Name = "pnlMama";
            this.pnlMama.Size = new System.Drawing.Size(1904, 929);
            this.pnlMama.TabIndex = 5;
            // 
            // gridTabelaLuni
            // 
            this.gridTabelaLuni.AllowUserToAddRows = false;
            this.gridTabelaLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTabelaLuni.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTabelaLuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTabelaLuni.EnableHeadersVisualStyles = false;
            this.gridTabelaLuni.Location = new System.Drawing.Point(-2, -2);
            this.gridTabelaLuni.MinimumSize = new System.Drawing.Size(228, 294);
            this.gridTabelaLuni.Name = "gridTabelaLuni";
            this.gridTabelaLuni.RowHeadersWidth = 51;
            this.gridTabelaLuni.Size = new System.Drawing.Size(483, 917);
            this.gridTabelaLuni.TabIndex = 5;
            // 
            // classButon1
            // 
            this.classButon1.BackColor = System.Drawing.Color.Aquamarine;
            this.classButon1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classButon1.Location = new System.Drawing.Point(47, 214);
            this.classButon1.Name = "classButon1";
            this.classButon1.Size = new System.Drawing.Size(109, 48);
            this.classButon1.TabIndex = 4;
            this.classButon1.Text = "Adauga luna noua";
            this.classButon1.UseVisualStyleBackColor = false;
            this.classButon1.Click += new System.EventHandler(this.classButon1_Click);
            // 
            // comboBoxLUNA
            // 
            this.comboBoxLUNA.FormattingEnabled = true;
            this.comboBoxLUNA.Location = new System.Drawing.Point(43, 148);
            this.comboBoxLUNA.Name = "comboBoxLUNA";
            this.comboBoxLUNA.Size = new System.Drawing.Size(108, 24);
            this.comboBoxLUNA.TabIndex = 3;
            // 
            // comboBoxAN
            // 
            this.comboBoxAN.FormattingEnabled = true;
            this.comboBoxAN.Location = new System.Drawing.Point(47, 63);
            this.comboBoxAN.Name = "comboBoxAN";
            this.comboBoxAN.Size = new System.Drawing.Size(85, 24);
            this.comboBoxAN.TabIndex = 2;
            // 
            // classLabel2
            // 
            this.classLabel2.AutoSize = true;
            this.classLabel2.Location = new System.Drawing.Point(44, 109);
            this.classLabel2.Name = "classLabel2";
            this.classLabel2.Size = new System.Drawing.Size(107, 16);
            this.classLabel2.TabIndex = 1;
            this.classLabel2.Text = "Selectie LUNA";
            // 
            // classLabel1
            // 
            this.classLabel1.AutoSize = true;
            this.classLabel1.Location = new System.Drawing.Point(47, 30);
            this.classLabel1.Name = "classLabel1";
            this.classLabel1.Size = new System.Drawing.Size(85, 16);
            this.classLabel1.TabIndex = 0;
            this.classLabel1.Text = "Selectie AN";
            // 
            // panelTabelLuni
            // 
            this.panelTabelLuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTabelLuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTabelLuni.Controls.Add(this.gridTabelaLuni);
            this.panelTabelLuni.Location = new System.Drawing.Point(1418, 4);
            this.panelTabelLuni.Name = "panelTabelLuni";
            this.panelTabelLuni.Size = new System.Drawing.Size(483, 922);
            this.panelTabelLuni.TabIndex = 6;
            // 
            // panelSelectareLuni
            // 
            this.panelSelectareLuni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelectareLuni.Controls.Add(this.classButon1);
            this.panelSelectareLuni.Controls.Add(this.comboBoxLUNA);
            this.panelSelectareLuni.Controls.Add(this.comboBoxAN);
            this.panelSelectareLuni.Controls.Add(this.classLabel2);
            this.panelSelectareLuni.Controls.Add(this.classLabel1);
            this.panelSelectareLuni.Location = new System.Drawing.Point(4, 4);
            this.panelSelectareLuni.Name = "panelSelectareLuni";
            this.panelSelectareLuni.Size = new System.Drawing.Size(480, 922);
            this.panelSelectareLuni.TabIndex = 7;
            // 
            // MeniuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridTabelaLuni)).EndInit();
            this.panelTabelLuni.ResumeLayout(false);
            this.panelSelectareLuni.ResumeLayout(false);
            this.panelSelectareLuni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMama;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCeas;
        private System.Windows.Forms.Label lblNumeFirma;
        private System.Windows.Forms.ComboBox comboBoxLUNA;
        private System.Windows.Forms.ComboBox comboBoxAN;
        private butoane_si_controale.ClassLabel classLabel2;
        private butoane_si_controale.ClassLabel classLabel1;
        private butoane_si_controale.ClassButon classButon1;
        private butoane_si_controale.ClassGridView gridTabelaLuni;
        private butoane_si_controale.ClassLabel classLabel3;
        private butoane_si_controale.ClassPanel panelTabelLuni;
        private butoane_si_controale.ClassPanel panelSelectareLuni;
    }
}