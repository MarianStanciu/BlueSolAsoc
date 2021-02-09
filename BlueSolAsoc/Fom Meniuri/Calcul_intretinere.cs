﻿using BlueSolAsoc.butoane_si_controale;
using CasetaDialogTag;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class Calcul_intretinere : FormBluebit
    {
        ClassDataSet Calcul_intretinereDS = new ClassDataSet();
       
        private string denumireAsociatie ;
        private int idAsociatie;
        public string sLunaActiva;

    
        public Calcul_intretinere()        
        {
            InitializeComponent();
        }
       
            public Calcul_intretinere(string denumireAsociatie, int idAsociatie, string lunaActiva)
        {
            InitializeComponent();
            this.sLunaActiva = lunaActiva;
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            GridAfisareConsumuri.CellEndEdit += gridAfisareConsumuri_CellEndEdit;
            PanelConsumAapartament.Show();
            lblMesajSelecteazScara.Show();
            lblMesajSelecteazScara.BringToFront();
            btnSalveaza.Hide();
            btnSterge.Hide();
            btnAnuleaza.Hide();
            btnImprima.Visible = true;
            //GridCalculIntretinere.CellPainting += DataGridView1_CellPainting;
           // GridCalculIntretinere.CellPainting += DataGridView11_CellPainting;
        }      

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            adaugareColoane();
            extrageTabelaTree();
            treeConsumuriApartament.ExpandAll();// afisarea treeului rezultat in format extins pana la nivel de scara
            PanelConsumAapartament.Hide();// ascunderea panelului ce contine gridul pentru adaugare consumuri pana este selectata o scar din tree
                       
          // CasetaDialog.AfiseazaMesaj("afisare test", "Bluebitdata te saluta",
                //CasetaDialog.ButonMesaj.Ok,
                //CasetaDialog.ButonMesaj.Nimic,
                //CasetaDialog.ButonMesaj.Nu,
                //CasetaDialog.IconitaMesaj.Informare);
        }
      
        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Vertical text from column 0, or adjust below, if first column(s) to be skipped
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
        }

       




        // aici genezez structura de coloane a unui tabel
        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = Calcul_intretinereDS.Tables[sTabelLucru].Columns;
            return coloane;
        }
        //GENERARE TABELA CU TOATE DENUMIRILE CHELTUIELILOR SI ADAUGAREA LOR IN TREE  in tabul Genereaza tabel intretinere
        public void adaugareColoane()
        {

            if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli1"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli1");
            }
            // Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli1");
            Calcul_intretinereDS.getSetFrom("exec mp_getCalculIntretinere " + idAsociatie, "denumiri_cheltuieli1");
            DataColumnCollection col = this.StructuraColoane("denumiri_cheltuieli1");
            for (int i = 0; i < col.Count; i++)
            {
                TreeNode node = new TreeNode(col[i].ToString());
                treeColoane.Nodes.Add(node);
            }           
        }

        // METODA CARE GENEREAZA GRIDVIEW PE BAZA SELECTIEI DIN TREE in tabul Genereaza tabel intretinere
        private void GenereazaTabel_Click(object sender, EventArgs e)
        {
            DataColumnCollection col = this.StructuraColoane("denumiri_cheltuieli1");
            GridCalculIntretinere.DataSource=Calcul_intretinereDS.Tables["denumiri_cheltuieli1"];
            GridCalculIntretinere.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         
            for (int i=0; i< Calcul_intretinereDS.Tables["denumiri_cheltuieli1"].Columns.Count; i++)
            {
                //GridCalculIntretinere.Columns[i].Width = 80;
                string NumeColoanaGrid = col[i].ColumnName;
                foreach (TreeNode node in treeColoane.Nodes)
                {               
                    string numeColoana = node.Text.Trim();
                    string headerColoana = node.Text.Trim();
                    if (node.Checked && NumeColoanaGrid==numeColoana)
                    {
                        GridCalculIntretinere.Columns[i].Visible=false;
                        
                    }
                    if (!(node.Checked) && NumeColoanaGrid==numeColoana)
                    {
                        GridCalculIntretinere.Columns[i].Visible = true;
                        GridCalculIntretinere.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                       
                    }
                }
            }
            GridCalculIntretinere.Enabled = false;
           
        }

        // CREARE TABELA -  TREE PENTRU ADAUGARE INFORMATII PENTRU APARTAMENT in tabul adaugare consumuri apartament
        private void extrageTabelaTree()
        {
            if (!(Calcul_intretinereDS.Tables["TabelAfisareTreeCalculIntretinere"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("TabelAfisareTreeCalculIntretinere");
            }
            Calcul_intretinereDS.getSetFrom("select * from mv_orgAfisareTreeCalculIntretinere where  id_asociatie=" + idAsociatie + " order by org_id_master asc", "TabelAfisareTreeCalculIntretinere");
            int idOrg = (int)Calcul_intretinereDS.Tables["TabelAfisareTreeCalculIntretinere"].Rows[0]["org_id_org"];
            string valoare = Calcul_intretinereDS.Tables["TabelAfisareTreeCalculIntretinere"].Rows[0]["org_valoare"].ToString();
            GetTreeItemsNou(idOrg, valoare, treeConsumuriApartament.Nodes);
        }
        // metoda care returneaza toate elementele copil pentru nodul selectat in tree din tabul adaugare consumuri apartament
        private void GetTreeItemsNou(int idOrg, string valoare, TreeNodeCollection parinteNod)
        {
            TreeNode copil = new TreeNode();
            copil.Tag = idOrg;
            copil.Text = valoare;
            parinteNod.Add(copil);
            DataRow[] datacopii = Calcul_intretinereDS.Tables["TabelAfisareTreeCalculIntretinere"].Select(" org_id_master = " + idOrg);
            foreach (DataRow rand in datacopii)
            {
                int idOrgCopil = (int)rand["org_id_org"];
                string valoare_copil = rand["org_valoare"].ToString();
                GetTreeItemsNou(idOrgCopil, valoare_copil, copil.Nodes);
            }                   
        }

        private void treeConsumuriApartament_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect_treeAdaugareConsumuri(e.Node);
        }
        public object ReturnareValoare(string query)
        {
            ClassConexiuneServer.DeschideConexiunea();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            SqlCommand command;
            command = new SqlCommand(query, cnn);
            var scalar = command.ExecuteScalar();
            return scalar;
        }
        private void AfterSelect_treeAdaugareConsumuri(TreeNode Node)
        {
            int nId = System.Convert.ToInt16(Node.Tag);
            int val = (Int32)Calcul_intretinereDS.ReturnareValoare("select aso_id_tip from mv_detaliiOrganizatie where org_id_org=" + nId);

            
            if (val == 3)
            {  //adaugare tabela in dataset pentru apartamente  //TABELA DIN VIEW
                if (!(Calcul_intretinereDS.Tables["mv_ConsumApartamente"] is null))
                {
                    Calcul_intretinereDS.Tables.Remove("mv_ConsumApartamente");
                }
                Calcul_intretinereDS.getSetFrom("select * from mv_ConsumApartamente  where  id_sc =" + nId, "mv_ConsumApartamente");

                GridAfisareConsumuri.DataSource = Calcul_intretinereDS.Tables["mv_ConsumApartamente"];
                GridAfisareConsumuri.Columns["id_sc"].Visible = false;
                GridAfisareConsumuri.Columns["id_consumuri_apartamente"].Visible = false;
                GridAfisareConsumuri.Columns["id_apartament"].Visible = false;
                GridAfisareConsumuri.Columns["id_tabela_luni"].Visible = false;
                GridAfisareConsumuri.Columns["id_asociatie"].Visible = false;
                GridAfisareConsumuri.Columns["Denumire Apartament"].HeaderText = "Apartament";
                GridAfisareConsumuri.Columns["consum_apa_rece"].HeaderText = "MC Apa Rece";
                //    gridAfisareConsumuri.Sort(gridAfisareConsumuri.Columns["Denumire Apartament"], ListSortDirection.Descending);
                GridAfisareConsumuri.Columns["consum_apa_calda"].HeaderText = "MC Apa Calda";
                GridAfisareConsumuri.Columns["numar_persoane"].HeaderText = "Numar Persoane";
                GridAfisareConsumuri.Columns["Proprietar"].HeaderText = "Nume proprietar";
                GridAfisareConsumuri.Columns["Proprietar"].ReadOnly = true;
                GridAfisareConsumuri.Columns["Denumire Apartament"].ReadOnly = true;
                GridAfisareConsumuri.Columns["Denumire Apartament"].DisplayIndex = 1;
                GridAfisareConsumuri.Columns["numar_persoane"].DisplayIndex = 2;
                GridAfisareConsumuri.Columns["consum_apa_rece"].DisplayIndex = 3;
                GridAfisareConsumuri.Columns["consum_apa_calda"].DisplayIndex = 4;
                GridAfisareConsumuri.Columns["Proprietar"].DisplayIndex = 5;
                GridAfisareConsumuri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                PanelConsumAapartament.Show();
                GridAfisareConsumuri.Visible = true;
                GridAfisareConsumuri.Show();
                lblMesajSelecteazScara.Hide();
                //btnImprima.Visible = true;
            }
            else
            {
                PanelConsumAapartament.Hide();
                GridAfisareConsumuri.Visible=false;
                lblMesajSelecteazScara.Show();
               // btnImprima.Visible = false;
            }
        }
        public void reimprospateazaGridConsumuri()
        {
            GridAfisareConsumuri.DataSource = Calcul_intretinereDS.Tables["mv_ConsumApartamente"];
            GridAfisareConsumuri.Refresh();
        }

       
        //colorare celula editata pe baza valorii initiale comparata cu cea finala
        void gridAfisareConsumuri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            object initial = this.Calcul_intretinereDS.Tables["mv_ConsumApartamente"].Rows[e.RowIndex][this.Calcul_intretinereDS.Tables["mv_ConsumApartamente"].Columns[e.ColumnIndex].ColumnName, DataRowVersion.Current];
            object final = this.Calcul_intretinereDS.Tables["mv_ConsumApartamente"].Rows[e.RowIndex][e.ColumnIndex];
            object tipObiect = final.GetType();

            switch (Type.GetTypeCode(final.GetType()))
            {
                case TypeCode.Decimal:
                    decimal a = decimal.Parse(final.ToString());
                    if (a < 0)
                    {
                        MessageBox.Show("Introduceti un numar pozitiv", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        final = decimal.Parse((initial.ToString()));
                        GridAfisareConsumuri.CancelEdit();
                    }

                    break;

                case TypeCode.Int32:
                    int b = int.Parse(final.ToString());
                    if (b < 0)
                    {
                        MessageBox.Show("Introduceti un numar pozitiv", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        final = int.Parse((initial.ToString()));
                        GridAfisareConsumuri.CancelEdit();
                    }
                    break;
                default:
                    break;
            }

            if (initial != final)
            {
                GridAfisareConsumuri[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Cyan;
            }

        }

        private void Calcul_intretinere_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calcul_intretinereDS1.mv_ConsumApartamente' table. You can move, or remove it, as needed.
            this.mv_ConsumApartamenteTableAdapter.Fill(this.calcul_intretinereDS1.mv_ConsumApartamente);        
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            switch (TabCalculIntretinere.SelectedTab.Text)
            {
                case "Adaugare consumuri apartament":
                    treeConsumuriApartament.Enabled = false;
                    btnModifica.Hide();
                    btnSalveaza.Show();
                    btnAnuleaza.Show();                  
                    GridAfisareConsumuri.Enabled = true;
                        break;
                case "Genereaza tabel intretinere":

                    break;
                default:

                    break;
            }
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            treeConsumuriApartament.Enabled = true;
            btnModifica.Show();
            btnSalveaza.Hide();
            btnAnuleaza.Show();
            Calcul_intretinereDS.TransmiteActualizari("mv_ConsumApartamente");
           // GridAfisareConsumuri.Enabled = false;
        }

        private void btnAnuleaza_Click_1(object sender, EventArgs e)
        {
            DataRow[] randuriModificate = Calcul_intretinereDS.Tables["mv_ConsumApartamente"].Select(null, null, DataViewRowState.ModifiedCurrent);
            if (randuriModificate.Length > 0)
            {
              
                MessageBox.Show("Campurile care au fost editate se vor pierde daca nu sunt salvate !", "Informare", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
                if (DialogResult == DialogResult.OK)
                {
                    treeConsumuriApartament.Enabled = true;
                    btnModifica.Show();
                    btnSalveaza.Hide();
                    btnAnuleaza.Show();              
                    GridAfisareConsumuri.CancelEdit();                                  
                }
            }
            else
            {
                treeConsumuriApartament.Enabled = true;
                btnModifica.Show();
                btnSalveaza.Hide();               
                btnAnuleaza.Hide();               
                GridAfisareConsumuri.CancelEdit();
            }

        }       

        private void PanelConsumAapartament_Click(object sender, PaintEventArgs e)
        {
            //if (GridAfisareConsumuri.Enabled == false)
            //{
                MessageBox.Show("Pentru a edita valorile din tabel apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

       // verificarea introducere date in grid view
        private void GridAfisareConsumuri_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //e.FormattedValue  will return current cell value and 
            //e.ColumnIndex & e.RowIndex will rerurn current cell position

            // If you want to validate particular cell data must be numeric then check e.FormattedValue is all numeric 
            // if not then just set  e.Cancel = true and show some message 
            //Like this 
            ClassGridView grid = (ClassGridView)sender;

            if (grid.Columns[e.ColumnIndex].Name== "consum_apa_rece" || grid.Columns[e.ColumnIndex].Name == "numar_persoane"|| grid.Columns[e.ColumnIndex].Name == "consum_apa_calda")
            {
                if (!IsNumeric(e.FormattedValue.ToString()))  // IsNumeric will be your method where you will check for numebrs 
                {
                    MessageBox.Show("Pot fi introduse doar numere!");
                    GridAfisareConsumuri.CancelEdit();
                }
            }
        }
       
        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;
            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }

        private void GridAfisareConsumuri_Click(object sender, EventArgs e)
        {
            
            if (btnModifica.Visible==true)
            {
                MessageBox.Show("Pentru a edita valorile din tabel apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        public void OwnerDraw(object sender, DGVCellDrawingEventArgs e)
        {
            if (e.row == -1)
            {
                DataGridViewHeaderCell cell = GridCalculIntretinere.Columns[e.column].HeaderCell;
                String printvalue = GridCalculIntretinere.Columns[e.column].HeaderText;


                //e.g.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.DrawingBounds);
               
                // Draw column header text upside down and backwards
              //  e.g.TranslateTransform(e.DrawingBounds.X+ e.DrawingBounds.Height, e.DrawingBounds.Y+ e.DrawingBounds.Width);
             //   e.g.TranslateTransform(e.DrawingBounds.X + e.DrawingBounds.Width, e.DrawingBounds.Y + e.DrawingBounds.Height);
                e.g.TranslateTransform(e.DrawingBounds.X + e.DrawingBounds.Width-30, e.DrawingBounds.Y + e.DrawingBounds.Height);
                e.g.RotateTransform(-90);
               // e.g.DrawString(printvalue, e.CellStyle.Font,new SolidBrush(e.CellStyle.ForeColor), e.CellStyle.Padding.Left, -cell.InheritedStyle.Padding.Bottom);
               // e.g.DrawString(printvalue, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), e.CellStyle.Padding.Left, -e.CellStyle.Padding.Bottom);
                e.g.DrawString(printvalue, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), 0, 0);
                // undo the backwards upside down transform
                e.g.ResetTransform();
                // draw grid
                if (GridCalculIntretinere.CellBorderStyle != DataGridViewCellBorderStyle.None)
                    e.g.DrawRectangle(new Pen(GridCalculIntretinere.GridColor), e.DrawingBounds.X, e.DrawingBounds.Y,
                    e.DrawingBounds.Width, e.DrawingBounds.Height);
                e.Handled = true;
            }
        }

        private void MetodaDGVPrinter(ClassGridView gridView, string sDataTip)
        {
            if (gridView.Columns.Count != 0 | gridView.Visible==false)
            {
               
                DGVPrinter printer = new DGVPrinter();                   
                //titlul documentului
                printer.TitleSpacing = 5;
                printer.SubTitleSpacing = 5;
                printer.Title = "Lista costurilor intretinerii, Asociatia de proprietari:" + denumireAsociatie; //header      
                //subtitlul compus din luna activa pentru calcul + elementele ce vin din caseta de dialog la imprimare
                printer.SubTitle = "Luna calculata:" + sLunaActiva+" | " + sDataTip;                    
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                //setari privind afisari pe pagina - nr pagini ...
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = false;

                printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;// setatrea latimii coloanelor la continut
                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //orientarea pe verticala a numelor de coloana
                printer.HeaderCellFormatFlags = StringFormatFlags.DirectionVertical;
                //rotirea numelor de coloana pe verticala de jos in sus si de la stanga la dreapta
                printer.OwnerDraw += new CellOwnerDrawEventHandler(OwnerDraw);
             
                printer.Footer = "BlueBitData" + "\n" + "Companie de software";// Footer             
                printer.FooterFormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.FooterColor = Color.Red;
                printer.printDocument.DefaultPageSettings.Landscape = true;
                //initializarea print preview
                printer.PrintPreviewDataGridView(gridView);// print preview   

            }
            else
                MessageBox.Show("NIMIC DE IMPRIMAT");


        }

        private void btnImprima_Click(object sender, EventArgs e)
        {
           string verificare = PromptForTextAndSelection.ShowDialog("BluebitData", "Data Afisare", "Tip Afisare","Data Scadentei");

            if (verificare== "fara data;nimic selectat;nu are scadenta")
            {
                MessageBox.Show("Imprimare anulata!");
            }
            else
            {
                MetodaDGVPrinter(GridCalculIntretinere, verificare);
                
            }
        }

        public static class PromptForTextAndSelection
        {
         
         
             public static string ShowDialog(string caption, string text, string selStr, string dataScadenta)
            {
               
                Form prompt = new Form();
                prompt.ControlBox = false;
                prompt.BackColor = Color.Aquamarine;
                prompt.ForeColor = Color.Black;
                
                prompt.Width = 300;
                prompt.Height = 360;
                prompt.Text = caption;
                //eticheta + box pentru data afisarii
                Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = text };
                TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
                //eticheta + box pentru data scadenta
                Label dataScad = new Label() { Left = 16, Top = 65, Width = 240, Text = dataScadenta };
                TextBox dataScadTB = new TextBox() { Left = 16, Top = 90, Width = 240, TabIndex = 1, TabStop = true };
                // eticheta + combobox - tip afisare
                Label selLabel = new Label() { Left = 16, Top = 130, Width = 88, Text = selStr };
                ComboBox cmbx = new ComboBox() { Left = 112, Top = 130, Width = 144, TabStop = true };

                Button confirmare = new Button() { Text = "Validez selectia!", Left = 150, Width = 100, Top = 200, TabIndex = 1, TabStop = true };
                Button anulare = new Button() { Text = "Anulez!", Left = 150, Width = 100, Top = 250, TabIndex = 1, TabStop = true };

                cmbx.Items.Add("VERIFICARE");
                cmbx.Items.Add("VALIDATA");
                cmbx.Items.Add("TEST");
                
                confirmare.Click += (sender, e) => { prompt.Close(); };
                prompt.AcceptButton = confirmare;
                prompt.AcceptButton.DialogResult = DialogResult.Yes;
                
                prompt.CancelButton = anulare;
                prompt.CancelButton.DialogResult = DialogResult.No;
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(dataScad);
                prompt.Controls.Add(dataScadTB);
                prompt.Controls.Add(selLabel);
                prompt.Controls.Add(cmbx);
                prompt.Controls.Add(confirmare);
                prompt.Controls.Add(anulare);                        
                prompt.StartPosition = FormStartPosition.CenterScreen;                
                DialogResult res= prompt.ShowDialog();                
                if (res==DialogResult.Yes )
                {
                    string tipAfisare=""  ;
                  
                    string data = textBox.Text;
                    string sDataScadenta = dataScadTB.Text;
                    if (textBox.Text.Length == 0)
                    {
                        data = "12.12.2222";
                    }
                    if (cmbx.SelectedItem == null)
                    {
                        tipAfisare = "Verificare fara data";
                    }
                    else tipAfisare = cmbx.SelectedItem.ToString();

                    if (dataScadTB.Text.Length == 0)
                    {
                        sDataScadenta = "15.15.5555";
                    }
                   
                    

                    return string.Format("Data afisarii:{0}|Data scadenta:{1}|Tip afisare:{2}", data,  sDataScadenta, tipAfisare) ;
                 
                }
                else
                {
                    return string.Format("Data afisarii:{0}|Data scadenta:{1}|Tip afisare:{2}", "fara data", "nu are scadenta", "nimic selectat");
                }


            }

        }


    }
}

