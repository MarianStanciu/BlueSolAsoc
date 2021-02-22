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
            this.TabCalculIntretinere = new BlueSolAsoc.butoane_si_controale.ClassTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GenereazaTabel = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.GridCalculIntretinere = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.treeColoane = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMesajSelecteazScara = new BlueSolAsoc.butoane_si_controale.ClassLabel();
            this.pnlControale = new System.Windows.Forms.Panel();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnSterge = new BlueSolAsoc.butoane_si_controale.ClassButonInteriorSterge();
            this.btnModifica = new BlueSolAsoc.butoane_si_controale.ClassButonModifica();
            this.PanelConsumAapartament = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.GridAfisareConsumuri = new BlueSolAsoc.butoane_si_controale.ClassGridView();
            this.PanelTreeConsumAp = new BlueSolAsoc.butoane_si_controale.ClassPanel();
            this.treeConsumuriApartament = new System.Windows.Forms.TreeView();
            this.calcul_intretinereDS1 = new BlueSolAsoc.Calcul_intretinereDS();
            this.mvConsumApartamenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mv_ConsumApartamenteTableAdapter = new BlueSolAsoc.Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnImprima = new BlueSolAsoc.butoane_si_controale.ClassButon();
            this.TabCalculIntretinere.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnlControale.SuspendLayout();
            this.PanelConsumAapartament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAfisareConsumuri)).BeginInit();
            this.PanelTreeConsumAp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCalculIntretinere
            // 
            this.TabCalculIntretinere.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.TabCalculIntretinere.Controls.Add(this.tabPage2);
            this.TabCalculIntretinere.Controls.Add(this.tabPage1);
            this.TabCalculIntretinere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCalculIntretinere.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCalculIntretinere.ItemSize = new System.Drawing.Size(309, 45);
            this.TabCalculIntretinere.Location = new System.Drawing.Point(0, 0);
            this.TabCalculIntretinere.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TabCalculIntretinere.Name = "TabCalculIntretinere";
            this.TabCalculIntretinere.SelectedIndex = 0;
            this.TabCalculIntretinere.Size = new System.Drawing.Size(977, 542);
            this.TabCalculIntretinere.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnImprima);
            this.tabPage2.Controls.Add(this.GenereazaTabel);
            this.tabPage2.Controls.Add(this.GridCalculIntretinere);
            this.tabPage2.Controls.Add(this.treeColoane);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(969, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Genereaza tabel intretinere";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GenereazaTabel
            // 
            this.GenereazaTabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GenereazaTabel.BackColor = System.Drawing.Color.Aquamarine;
            this.GenereazaTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenereazaTabel.Location = new System.Drawing.Point(8, 321);
            this.GenereazaTabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GenereazaTabel.Name = "GenereazaTabel";
            this.GenereazaTabel.Size = new System.Drawing.Size(240, 70);
            this.GenereazaTabel.TabIndex = 3;
            this.GenereazaTabel.Text = "Genereaza Lista Intretinere";
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
            this.GridCalculIntretinere.Location = new System.Drawing.Point(253, 2);
            this.GridCalculIntretinere.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GridCalculIntretinere.Name = "GridCalculIntretinere";
            this.GridCalculIntretinere.RowHeadersWidth = 51;
            this.GridCalculIntretinere.RowTemplate.Height = 24;
            this.GridCalculIntretinere.Size = new System.Drawing.Size(714, 485);
            this.GridCalculIntretinere.TabIndex = 2;
            // 
            // treeColoane
            // 
            this.treeColoane.CheckBoxes = true;
            this.treeColoane.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeColoane.Location = new System.Drawing.Point(2, 2);
            this.treeColoane.Margin = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.treeColoane.Name = "treeColoane";
            this.treeColoane.Size = new System.Drawing.Size(251, 485);
            this.treeColoane.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMesajSelecteazScara);
            this.tabPage1.Controls.Add(this.pnlControale);
            this.tabPage1.Controls.Add(this.PanelConsumAapartament);
            this.tabPage1.Controls.Add(this.PanelTreeConsumAp);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(969, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adaugare consumuri apartament";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMesajSelecteazScara
            // 
            this.lblMesajSelecteazScara.AutoSize = true;
            this.lblMesajSelecteazScara.Location = new System.Drawing.Point(281, 233);
            this.lblMesajSelecteazScara.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMesajSelecteazScara.Name = "lblMesajSelecteazScara";
            this.lblMesajSelecteazScara.Size = new System.Drawing.Size(594, 24);
            this.lblMesajSelecteazScara.TabIndex = 2;
            this.lblMesajSelecteazScara.Text = "Pentru a introduce/modifica consumuri selecteaza o scara din tree";
            // 
            // pnlControale
            // 
            this.pnlControale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControale.Controls.Add(this.btnAnuleaza);
            this.pnlControale.Controls.Add(this.btnSalveaza);
            this.pnlControale.Controls.Add(this.btnSterge);
            this.pnlControale.Controls.Add(this.btnModifica);
            this.pnlControale.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControale.Location = new System.Drawing.Point(839, 2);
            this.pnlControale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.btnAnuleaza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(124, 152);
            this.btnAnuleaza.TabIndex = 9;
            this.btnAnuleaza.Text = "ANULEAZA";
            this.btnAnuleaza.UseVisualStyleBackColor = false;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click_1);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSalveaza.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalveaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalveaza.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalveaza.Location = new System.Drawing.Point(0, 304);
            this.btnSalveaza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(124, 152);
            this.btnSalveaza.TabIndex = 8;
            this.btnSalveaza.Text = "SALVEAZA";
            this.btnSalveaza.UseVisualStyleBackColor = false;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.Color.Red;
            this.btnSterge.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSterge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSterge.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSterge.Location = new System.Drawing.Point(0, 152);
            this.btnSterge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(124, 152);
            this.btnSterge.TabIndex = 7;
            this.btnSterge.Text = "STERGE";
            this.btnSterge.UseVisualStyleBackColor = false;
            // 
            // btnModifica
            // 
            this.btnModifica.BackColor = System.Drawing.Color.Yellow;
            this.btnModifica.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifica.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifica.Location = new System.Drawing.Point(0, 0);
            this.btnModifica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(124, 152);
            this.btnModifica.TabIndex = 6;
            this.btnModifica.Text = "MODIFICA";
            this.btnModifica.UseVisualStyleBackColor = false;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // PanelConsumAapartament
            // 
            this.PanelConsumAapartament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelConsumAapartament.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelConsumAapartament.Controls.Add(this.GridAfisareConsumuri);
            this.PanelConsumAapartament.Location = new System.Drawing.Point(254, 2);
            this.PanelConsumAapartament.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelConsumAapartament.Name = "PanelConsumAapartament";
            this.PanelConsumAapartament.Size = new System.Drawing.Size(581, 630);
            this.PanelConsumAapartament.TabIndex = 10;
            // 
            // GridAfisareConsumuri
            // 
            this.GridAfisareConsumuri.AllowUserToAddRows = false;
            this.GridAfisareConsumuri.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridAfisareConsumuri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridAfisareConsumuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAfisareConsumuri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridAfisareConsumuri.EnableHeadersVisualStyles = false;
            this.GridAfisareConsumuri.Location = new System.Drawing.Point(0, 0);
            this.GridAfisareConsumuri.Name = "GridAfisareConsumuri";
            this.GridAfisareConsumuri.RowHeadersWidth = 51;
            this.GridAfisareConsumuri.Size = new System.Drawing.Size(577, 626);
            this.GridAfisareConsumuri.TabIndex = 0;
            this.GridAfisareConsumuri.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.GridAfisareConsumuri_CellValidating);
            this.GridAfisareConsumuri.Click += new System.EventHandler(this.GridAfisareConsumuri_Click);
            // 
            // PanelTreeConsumAp
            // 
            this.PanelTreeConsumAp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelTreeConsumAp.Controls.Add(this.treeConsumuriApartament);
            this.PanelTreeConsumAp.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelTreeConsumAp.Location = new System.Drawing.Point(2, 2);
            this.PanelTreeConsumAp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PanelTreeConsumAp.Name = "PanelTreeConsumAp";
            this.PanelTreeConsumAp.Size = new System.Drawing.Size(252, 485);
            this.PanelTreeConsumAp.TabIndex = 9;
            // 
            // treeConsumuriApartament
            // 
            this.treeConsumuriApartament.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeConsumuriApartament.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConsumuriApartament.Location = new System.Drawing.Point(0, 0);
            this.treeConsumuriApartament.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeConsumuriApartament.Name = "treeConsumuriApartament";
            this.treeConsumuriApartament.Size = new System.Drawing.Size(249, 481);
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
            // btnImprima
            // 
            this.btnImprima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprima.BackColor = System.Drawing.Color.Aquamarine;
            this.btnImprima.BackgroundImage = global::BlueSolAsoc.Properties.Resources.icons8_print_80;
            this.btnImprima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprima.Location = new System.Drawing.Point(8, 396);
            this.btnImprima.Name = "btnImprima";
            this.btnImprima.Size = new System.Drawing.Size(240, 70);
            this.btnImprima.TabIndex = 4;
            this.btnImprima.UseVisualStyleBackColor = false;
            this.btnImprima.Click += new System.EventHandler(this.btnImprima_Click);
            // 
            // Calcul_intretinere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 542);
            this.Controls.Add(this.TabCalculIntretinere);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Calcul_intretinere";
            this.Text = "Calcul_intretinere";
            this.TabCalculIntretinere.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCalculIntretinere)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlControale.ResumeLayout(false);
            this.PanelConsumAapartament.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridAfisareConsumuri)).EndInit();
            this.PanelTreeConsumAp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calcul_intretinereDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvConsumApartamenteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private butoane_si_controale.ClassTabControl TabCalculIntretinere;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeColoane;
        private butoane_si_controale.ClassGridView GridCalculIntretinere;
        private butoane_si_controale.ClassButon GenereazaTabel;
        private System.Windows.Forms.TreeView treeConsumuriApartament;
        private butoane_si_controale.ClassPanel PanelTreeConsumAp;
        private butoane_si_controale.ClassPanel PanelConsumAapartament;
        private butoane_si_controale.ClassGridView GridAfisareConsumuri;
        private System.Windows.Forms.Panel pnlControale;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.Button btnSalveaza;
        private butoane_si_controale.ClassButonInteriorSterge btnSterge;
        private butoane_si_controale.ClassButonModifica btnModifica;
        private Calcul_intretinereDS calcul_intretinereDS1;
        private System.Windows.Forms.BindingSource mvConsumApartamenteBindingSource;
        private Calcul_intretinereDSTableAdapters.mv_ConsumApartamenteTableAdapter mv_ConsumApartamenteTableAdapter;
        private butoane_si_controale.ClassLabel lblMesajSelecteazScara;
        private butoane_si_controale.ClassButon btnImprima;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}