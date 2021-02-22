using BlueSolAsoc.butoane_si_controale;

using DGVPrinterHelper;
using System;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;

using System.Windows.Forms;


namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class Calcul_intretinere : FormBluebit
    {
        ClassDataSet Calcul_intretinereDS = new ClassDataSet();

        private string denumireAsociatie;
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
            btnAnuleaza.Visible = false;
            btnImprima.Visible = true;
            btnModifica.Hide();
            SetDocActiv(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GenerareListaIntretinere();
            extrageTabelaTree();
            treeConsumuriApartament.ExpandAll();// afisarea treeului rezultat in format extins pana la nivel de scara
            PanelConsumAapartament.Hide();// ascunderea panelului ce contine gridul pentru adaugare consumuri pana este selectata o scar din tree                      

        }

        // aici genezez structura de coloane a unui tabel
        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = Calcul_intretinereDS.Tables[sTabelLucru].Columns;
            return coloane;
        }
        //GENERARE TABELA CU TOATE DENUMIRILE CHELTUIELILOR SI ADAUGAREA LOR IN TREE  in tabul Genereaza tabel intretinere//  Generea tabelul cu cheltuielile de intretinere
        public void GenerareListaIntretinere()
        {
            //creare tabel cu calculul intretinerii
            if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli1"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli1");
            }
            // Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli1");
            Calcul_intretinereDS.getSetFrom("exec mp_getCalculIntretinere " + idAsociatie, "denumiri_cheltuieli1");// aici vom adauga parametrul prin care verificam daca este sau nu validata lista intretinerii
            DataColumnCollection col = this.StructuraColoane("denumiri_cheltuieli1");
            for (int i = 0; i < col.Count; i++)
            {
                TreeNode node = new TreeNode(col[i].ToString());
                treeColoane.Nodes.Add(node);
            }
            //
            ClassConexiuneServer.ConectareDedicata();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            ClassConexiuneServer.DeschideConexiunea();
            SqlCommand sqlcommand = new SqlCommand("dbo.mp_CalculIntretinere", cnn);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@nIdAsociatie", idAsociatie);
            sqlcommand.Parameters.AddWithValue("@nValidare", 0);
            sqlcommand.Parameters.AddWithValue("@dDataAfisare", "1111.11.21");
            sqlcommand.Parameters.AddWithValue("@dDataScadenta", "2222.12.30");
            cnn.Close();
        }
        

        // METODA CARE GENEREAZA GRIDVIEW PE BAZA SELECTIEI DIN TREE in tabul Genereaza tabel intretinere
        public void GenereazaTabel_Click(object sender, EventArgs e)
        {
            DataColumnCollection col = this.StructuraColoane("denumiri_cheltuieli1");
            GridCalculIntretinere.DataSource = Calcul_intretinereDS.Tables["denumiri_cheltuieli1"];
            GridCalculIntretinere.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < Calcul_intretinereDS.Tables["denumiri_cheltuieli1"].Columns.Count; i++)
            {
                //GridCalculIntretinere.Columns[i].Width = 80;
                string NumeColoanaGrid = col[i].ColumnName;
                foreach (TreeNode node in treeColoane.Nodes)
                {
                    string numeColoana = node.Text.Trim();
                    string headerColoana = node.Text.Trim();
                    if (node.Checked && NumeColoanaGrid == numeColoana)
                    {
                        GridCalculIntretinere.Columns[i].Visible = false;
                    }
                    if (!(node.Checked) && NumeColoanaGrid == numeColoana)
                    {
                        GridCalculIntretinere.Columns[i].Visible = true;
                        GridCalculIntretinere.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            GridCalculIntretinere.Enabled = false;

        }

        // CREARE TABELA -  TREE PENTRU ADAUGARE INFORMATII PENTRU APARTAMENT in tabul adaugare consumuri apartament
        public void extrageTabelaTree()
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
        public void GetTreeItemsNou(int idOrg, string valoare, TreeNodeCollection parinteNod)
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

        public void treeConsumuriApartament_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect_treeAdaugareConsumuri(e.Node);
        }

        public void AfterSelect_treeAdaugareConsumuri(TreeNode Node)
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
                btnModifica.Show();
            }
            else
            {
                PanelConsumAapartament.Hide();
                GridAfisareConsumuri.Visible = false;
                lblMesajSelecteazScara.Show();
                btnModifica.Hide();
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


        public void btnModifica_Click(object sender, EventArgs e)
        {
            SetDocActiv(true);
            switch (TabCalculIntretinere.SelectedTab.Text)
            {
                case "Adaugare consumuri apartament":
                  
                    treeConsumuriApartament.Enabled = false;
                    btnModifica.Hide();
                    btnSalveaza.Visible = true;
                    btnAnuleaza.Visible = true;
                    GridAfisareConsumuri.Enabled = true;
                    break;
                case "Genereaza tabel intretinere":

                    break;
                default:

                    break;
            }
        }

        public void btnSalveaza_Click(object sender, EventArgs e)
        {
            treeConsumuriApartament.Enabled = true;
            btnModifica.Show();
            btnSalveaza.Hide();
            btnAnuleaza.Hide();
            Calcul_intretinereDS.TransmiteActualizari("mv_ConsumApartamente");
            SetDocActiv(false);
            // GridAfisareConsumuri.Enabled = false;
        }

        public void btnAnuleaza_Click_1(object sender, EventArgs e)
        {
            DataRow[] randuriModificate = Calcul_intretinereDS.Tables["mv_ConsumApartamente"].Select(null, null, DataViewRowState.ModifiedCurrent);
            if (randuriModificate.Length > 0)
            {

                DialogResult aaa = (MessageBox.Show("Campurile care au fost editate se vor pierde daca nu sunt salvate !", "Informare", MessageBoxButtons.OKCancel, MessageBoxIcon.Information));

                if (aaa == DialogResult.OK)
                {
                    treeConsumuriApartament.Enabled = false;
                    btnModifica.Visible = true;
                    btnSalveaza.Visible = false;
                    btnAnuleaza.Visible = false;
                    GridAfisareConsumuri.CancelEdit();
                    GridAfisareConsumuri.DataSource = Calcul_intretinereDS.Tables["mv_ConsumApartamente"];
                    treeConsumuriApartament.Enabled = true;
                    SetDocActiv(false);
                }
            }
            else
            {
                treeConsumuriApartament.Enabled = true;
                btnModifica.Show();
                btnSalveaza.Hide();
                btnAnuleaza.Hide();
                GridAfisareConsumuri.CancelEdit();
                SetDocActiv(false);
            }

        }

        public void PanelConsumAapartament_Click(object sender, PaintEventArgs e)
        {
            //if (GridAfisareConsumuri.Enabled == false)
            //{
            MessageBox.Show("Pentru a edita valorile din tabel apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        // verificarea introducere date in grid view
        public void GridAfisareConsumuri_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ClassGridView grid = (ClassGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "consum_apa_rece" || grid.Columns[e.ColumnIndex].Name == "numar_persoane" || grid.Columns[e.ColumnIndex].Name == "consum_apa_calda")
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

        public void GridAfisareConsumuri_Click(object sender, EventArgs e)
        {

            if (btnModifica.Visible == true)
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
                e.g.TranslateTransform(e.DrawingBounds.X + e.DrawingBounds.Width - 30, e.DrawingBounds.Y + e.DrawingBounds.Height);
                e.g.RotateTransform(-90);
                e.g.DrawString(printvalue, e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), 0, 0);
                e.g.ResetTransform();
                if (GridCalculIntretinere.CellBorderStyle != DataGridViewCellBorderStyle.None)
                    e.g.DrawRectangle(new Pen(GridCalculIntretinere.GridColor), e.DrawingBounds.X, e.DrawingBounds.Y,
                    e.DrawingBounds.Width, e.DrawingBounds.Height);
                e.Handled = true;
            }
        }

        void MetodaDGVPrinter(ClassGridView gridView, string sDataTip)
        {
            if (gridView.Columns.Count != 0 | gridView.Visible == false)
            {

                DGVPrinter printer = new DGVPrinter();
                //titlul documentului
                printer.TitleSpacing = 5;
                printer.SubTitleSpacing = 5;
                printer.Title = "Lista costurilor intretinerii, Asociatia de proprietari:" + denumireAsociatie; //header      
                //subtitlul compus din luna activa pentru calcul + elementele ce vin din caseta de dialog la imprimare
                printer.SubTitle = "Luna calculata:" + sLunaActiva + " | " + sDataTip;
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


        public void btnImprima_Click(object sender, EventArgs e)
        {
            
         
            string verificare = ShowDialogA("BluebitData", "Data Afisarii Listei", "Afisare de TIP", "Numar de zile pana la scadenta:");
           
                if (verificare.Contains("VALIDARE"))
                {
                    MetodaDGVPrinter(GridCalculIntretinere, verificare);

                }
                else if (verificare == "NU")
                {
                    MessageBox.Show("Imprimare anulata!", "Anulat de utilizator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
        }
       
      
        public void ValidareLunaActiva()
        {                       

                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    FormBluebit frmDeschis = (FormBluebit)Application.OpenForms[i];
                    if (frmDeschis.GetDocActiv())
                    {
                        MessageBox.Show(" Exista un document in editare, Termina editarea si apoi poti reveni la imprimare");
                        frmDeschis.BringToFront();
                        frmDeschis.Activate();
                        break;                        
                    }              
                 }      

        }
      
        public bool MST()
        {
            bool z = true;
           
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                FormBluebit frmDeschis = (FormBluebit)Application.OpenForms[i];
                if (z == frmDeschis.GetDocActiv())
                    return true;
               

            }
            return false;
           
          
            
        }

         public string ShowDialogA(string caption, string text, string selStr, string dataScadenta)
            {
                Form prompt = new Form();
                prompt.ControlBox = false;
                prompt.BackColor = Color.Aquamarine;
                prompt.ForeColor = Color.Black;
                prompt.FormBorderStyle = FormBorderStyle.Fixed3D;
                prompt.Width = 300;
                prompt.Height = 360;
                prompt.Text = caption;
                //eticheta + box pentru data afisarii
                Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = text };
                DateTimePicker dtbAfisare = new DateTimePicker() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
                dtbAfisare.Format = DateTimePickerFormat.Custom;
                dtbAfisare.CustomFormat = "d-MMM-yyyy";

            //TextBox textBox = new TextBox() { Left = 16, Top = 40, Width = 240, TabIndex = 0, TabStop = true };
            //eticheta + box pentru data scadenta

                 Label dataScad = new Label() { Left = 16, Top = 90, Width = 180, Text = dataScadenta };
                ComboBox dataScadTB = new ComboBox() { Left = 212, Top = 90, Width = 44, TabIndex = 1, TabStop = true };
            string[] nrZile = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            dataScadTB.Items.AddRange(nrZile);
            dataScadTB.SelectedItem = nrZile[14];
                // eticheta + combobox - tip afisare
                Label selLabel = new Label() { Left = 16, Top = 130, Width = 88, Text = selStr };
                ComboBox cmbx = new ComboBox() { Left = 112, Top = 130, Width = 144, TabIndex = 1, TabStop = true };
                // cele 2 butoane - validare /anulare
                Button confirmare = new Button() { Text = "Validez selectia!", Left = 150, Width = 100, Top = 200, TabIndex = 1, TabStop = true };
                Button anulare = new Button() { Text = "Anulez!", Left = 150, Width = 100, Top = 250, TabIndex = 1, TabStop = true };
                //itemurile din combobox
                cmbx.Items.Add("VERIFICARE");
                cmbx.Items.Add("VALIDARE");
                cmbx.SelectedItem = "VERIFICARE";
                // aici primesc parametrul care imi permite sa afisez in combobox de selectia doar valoarea VERIFICARE sau VALIDARE si VERIFICARE - pt true - doar verificare
                //  bool validat =true;
                bool validat = false;

                if (validat)
                {
                    cmbx.Items.Remove("VALIDARE");
                }
                // cmbx.Items.Add("TEST");
                confirmare.Click += (sender, e) => { prompt.Close(); };
                prompt.AcceptButton = confirmare;
                prompt.AcceptButton.DialogResult = DialogResult.Yes;
                prompt.CancelButton = anulare;
                prompt.CancelButton.DialogResult = DialogResult.No;
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(dtbAfisare);
            //prompt.Controls.Add(textBox);
            prompt.Controls.Add(dataScad);
            prompt.Controls.Add(dataScadTB);
            prompt.Controls.Add(selLabel);
                prompt.Controls.Add(cmbx);
                prompt.Controls.Add(confirmare);
                prompt.Controls.Add(anulare);
                prompt.StartPosition = FormStartPosition.CenterScreen;
                DialogResult res = prompt.ShowDialog();
                if (res == DialogResult.Yes)
                {
                    string tipAfisare = "";
                    string data = dtbAfisare.Value.ToString("d-MMM-yyyy");
                string dataSQL = dtbAfisare.Value.ToString("YYYY-MM-DD");
                    string sDataScadenta = dataScadTB.Text;
                    if (dtbAfisare.Text.Length == 0)
                    {
                        data = "12.12.2222";
                    }
                    if (cmbx.SelectedItem == null)
                    {
                        MessageBox.Show("Selecteaza Tip Afisare");
                        tipAfisare = "Afisare Neselectata";
                    }
                    switch (cmbx.SelectedItem)
                    {
                        case "VALIDARE":
                        if (MST())
                        {
                            ValidareLunaActiva();
                        }
                        else
                        {

                            tipAfisare = "VALIDARE";
                            DialogResult raspuns = MessageBox.Show("Blocheaza toate calculele pentru luna activa!", " Butonul VALIDARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (raspuns == DialogResult.Yes)
                            {
                                sDataScadenta = dtbAfisare.Value.AddDays(Convert.ToDouble(dataScadTB.SelectedItem)).ToString("YYYY-MM-DD");
                                ClassConexiuneServer.ConectareDedicata();
                                SqlConnection cnn = ClassConexiuneServer.GetConnection();
                                ClassConexiuneServer.DeschideConexiunea();
                                SqlCommand sqlcommand = new SqlCommand("dbo.mp_CalculIntretinere", cnn);
                                sqlcommand.CommandType = CommandType.StoredProcedure;
                                sqlcommand.Parameters.AddWithValue("@nIdAsociatie", idAsociatie);
                                sqlcommand.Parameters.AddWithValue("@nValidare", 1);
                                
                                sqlcommand.Parameters.AddWithValue("@dDataAfisare", dataSQL);
                                sqlcommand.Parameters.AddWithValue("@dDataScadenta", sDataScadenta);
                                cnn.Close();
                                MessageBox.Show("Luna curenta a fost VALIDATA si blocata!");

                            }
                            if (raspuns == DialogResult.No)
                            {
                                tipAfisare = "VERIFICARE";
                                MessageBox.Show("Schimb tipul imprimarii in VERIFICARE", "Schimbare tip afisare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }     
                        
                        break;
                       
                        case "VERIFICARE":
                            tipAfisare = "VERIFICARE";
                            break;
                        default:

                            break;
                    }

                    if ((dtbAfisare.Value.ToString()) != null)
                    {
                        sDataScadenta = dtbAfisare.Value.AddDays(Convert.ToDouble(dataScadTB.SelectedItem)).ToString("d-MMM-yyyy");
                    }

                    return string.Format("Data afisare:{0} | Data scadenta:{1} | Tip afisare:{2}", data, sDataScadenta, tipAfisare);
                }
                else
                { //return string.Format("Data afisarii:{0}|Data scadenta:{1}|Tip afisare:{2}", "fara data", "nu are scadenta", "nimic selectat");
                    return string.Format("{0}", "NU");
                }
            }
        

    }

}

