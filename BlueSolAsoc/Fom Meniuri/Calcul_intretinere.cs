using BlueSolAsoc.butoane_si_controale;
using CasetaDialogTag;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class Calcul_intretinere : FormBluebit
    {
        ClassDataSet Calcul_intretinereDS = new ClassDataSet();
        ClassDataSet Calcul_intretinere_finalDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;

        public Calcul_intretinere()        
        {
            InitializeComponent();
        }
       
            public Calcul_intretinere(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            GridAfisareConsumuri.CellEndEdit += gridAfisareConsumuri_CellEndEdit;
            PanelConsumAapartament.Show();
            lblMesajSelecteazScara.Show();
            lblMesajSelecteazScara.BringToFront();
            btnSalveaza.Hide();
            btnSterge.Hide();
            btnAnuleaza.Hide();
            btnImprima.Visible = false;
           // GridAfisareConsumuri.Enabled = false;
         //   GridAfisareConsumuri.CellValidating += GridAfisareConsumuri_CellValidating;
           
        }

       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            adaugareColoane();
            extrageTabelaTree();
            treeConsumuriApartament.ExpandAll();// afisarea treeului rezultat in format extins pana la nivel de scara
            PanelConsumAapartament.Hide();// ascunderea panelului ce contine gridul pentru adaugare consumuri pana este selectata o scar din tree
                       
           CasetaDialog.AfiseazaMesaj("afisare test", "Bluebitdata te saluta",
                CasetaDialog.ButonMesaj.Ok,
                CasetaDialog.ButonMesaj.Nimic,
                CasetaDialog.ButonMesaj.Nu,
                CasetaDialog.IconitaMesaj.Informare);
            //if (a == DialogResult.OK)
            //{
            //    MessageBox.Show("te salut si eu");
            //}
        }
        //GENERARE TABELA CU TOATE DENUMIRILE CHELTUIELILOR in tabul Genereaza tabel intretinere
        public void adaugareColoane()
        {
            if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli1"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli1");
            }
            // Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli1");
            Calcul_intretinereDS.getSetFrom("exec mp_getCalculIntretinere " + idAsociatie, "denumiri_cheltuieli1");
            foreach (DataRow r in Calcul_intretinereDS.Tables["denumiri_cheltuieli1"].Rows)
            {
                TreeNode node = new TreeNode(r["Canalizare"].ToString());
                treeColoane.Nodes.Add(node);

            }
            /*
              if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli1"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli1");
            }
            // Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli1");
            Calcul_intretinereDS.getSetFrom("exec mp_getCalculIntretinere " + idAsociatie, "denumiri_cheltuieli1");
            foreach (DataRow r in Calcul_intretinereDS.Tables["denumiri_cheltuieli1"].Rows)
            {
                TreeNode node = new TreeNode(r["val_label"].ToString());
                treeColoane.Nodes.Add(node);

            }
            */
        }




        // BUTONUL CARE GENEREAZA GRIDVIEW PE BAZA SELECTIEI DIN TREE in tabul Genereaza tabel intretinere
        private void GenereazaTabel_Click(object sender, EventArgs e)
        {
            GridCalculIntretinere.Columns.Clear();

            foreach (TreeNode node in treeColoane.Nodes)
            {
                string numeColoana = node.Text.Trim();
                string headerColoana = node.Text.Trim();

                if (node.Checked)
                {
                    if (GridCalculIntretinere.Columns[numeColoana] == null)
                    {
                        GridCalculIntretinere.Columns.Add(numeColoana, headerColoana);
                    }
                }

            }
            if (GridCalculIntretinere.Columns.Count > 0)
            {
                GridCalculIntretinere.Rows.Add();
            }

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

        // metoda care selecteaza apartamentele asociate unei scari din tree

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
                btnImprima.Visible = true;
            }
            else
            {
                PanelConsumAapartament.Hide();
                GridAfisareConsumuri.Visible=false;
                lblMesajSelecteazScara.Show();
                btnImprima.Visible = false;
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
                   // GridAfisareConsumuri.Enabled = false;
                 
                }
            }
            else
            {
                treeConsumuriApartament.Enabled = true;
                btnModifica.Show();
                btnSalveaza.Hide();
               
                btnAnuleaza.Hide();
               
                GridAfisareConsumuri.CancelEdit();
               // GridAfisareConsumuri.Enabled = false;
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
                 //   GridAfisareConsumuri.CurrentCell.Value = null;
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
            //else
            //{
            //    MessageBox.Show("Pentru a edita valorile din tabel apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void MetodaDGVPrinter(ClassGridView gridView, string sDataTip)
        {
            if (gridView.Columns.Count != 0 | gridView.Visible==false)
            {
                DGVPrinter printer = new DGVPrinter();
                printer.TitleSpacing = 5;
                printer.SubTitleSpacing = 5;
                printer.Title = "LISTA INTRETINERE, ASOCIATIA:" + denumireAsociatie; //header
                printer.SubTitle = "LUNA AFISATA:     /"+"DATA AFISARII:" +sDataTip;
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = false;
                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.ColumnWidths.Add(gridView.Columns[0].Name, 10); // formatare latime colaoana 9 [denumire]
                printer.Footer = "BlueBitData" + "\n" + "Companie de software";// Footer   
                printer.HeaderCellFormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
                printer.FooterFormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.FooterColor = Color.Red;
                printer.printDocument.DefaultPageSettings.Landscape = true;

                printer.PrintPreviewDataGridView(gridView);// print preview           
                                                           //printer.PrintDataGridView(gridView);// print direct
            }
            else
                MessageBox.Show("NIMIC DE IMPRIMAT");


        }

        private void btnImprima_Click(object sender, EventArgs e)
        {
           string verificare = PromptForTextAndSelection.ShowDialog("BluebitData", "Data Afisare", "Tip Afisare");

            if (verificare== "fara data;nimic selectat")
            {
                MessageBox.Show("Imprimare anulata!");
            }
            else
            {
                MetodaDGVPrinter(GridAfisareConsumuri, verificare);
                
            }
        }

        public static class PromptForTextAndSelection
        {
            public static string ShowDialog(string caption, string text, string selStr)
            {
                Form prompt = new Form();
                prompt.ControlBox = false;
                prompt.Width = 400;
                prompt.Height = 360;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = text };
                TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
                Label selLabel = new Label() { Left = 16, Top = 66, Width = 88, Text = selStr };
                ComboBox cmbx = new ComboBox() { Left = 112, Top = 64, Width = 144 };
                cmbx.Items.Add("Verificare");
                cmbx.Items.Add("Afisare Definitiva");
                cmbx.Items.Add("Imprimare Test");
                Button confirmare = new Button() { Text = "Validez selectia!", Left = 16, Width = 80, Top = 150, TabIndex = 1, TabStop = true };
                Button anulare= new Button() { Text = "Anulez!", Left = 16, Width = 80, Top = 98, TabIndex = 1, TabStop = true };
                confirmare.Click += (sender, e) => { prompt.Close(); };
                prompt.AcceptButton = confirmare;
                prompt.AcceptButton.DialogResult = DialogResult.Yes;
                
                prompt.CancelButton = anulare;
                prompt.CancelButton.DialogResult = DialogResult.No;
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(selLabel);
                prompt.Controls.Add(cmbx);
                prompt.Controls.Add(confirmare);
                prompt.Controls.Add(anulare);
             
                
            
               
                prompt.StartPosition = FormStartPosition.CenterScreen;
                
                DialogResult res= prompt.ShowDialog();
                
                if (res==DialogResult.Yes )
                {
                    string tipAfisare;
                    string data = textBox.Text;
                    if (textBox.Text.Length == 0)
                    {
                        data = "19.09.1900";
                    }
                    
                    if (cmbx.SelectedItem == null)
                    {
                        tipAfisare = "Verificare fara data";
                    }
                    else  tipAfisare = cmbx.SelectedItem.ToString();


                    return string.Format("{0};{1}", data, tipAfisare);

                    
            


                }
                else
                {
                    return string.Format("{0};{1}", "fara data", "nimic selectat");

                }
                

            }
          
        }
    }
}

