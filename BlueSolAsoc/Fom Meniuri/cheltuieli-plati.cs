using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class cheltuieli_plati : FormBluebit
    {
        //creare dataset pentru formul curent si aducerea variabilelor de nume si id asociatie selectate de utilizator
        ClassDataSet CheltuieliDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;
       

        public cheltuieli_plati(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            DataCurenta.Value = System.DateTime.Now;
            btnSalveazaCheltuieli.Visible = true;
            btnAnuleazaCheltuieli.Visible = true;
            btnModificaCheltuieli.Visible = true;
            btnStergeCheltuieli.Visible = true;
           
            // de adaugat un array
        }


       




        private void cheltuieli_plati_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cheltuieliDS1.mv_Documente' table. You can move, or remove it, as needed.
            this.mv_DocumenteTableAdapter.Fill(this.cheltuieliDS1.mv_Documente);
                       
            extrageTabelaTree();
            treeDistribuieCheltuiala.ExpandAll();
            AfisareGridFacturi(0);//istoric facturi
            AdaugareFacturi(0);//
            ClassButon distribuieCheltuiala = new ClassButon(); 
        }
     
        // metoda de afisare grid facturi existente  si tabelul din dataset 
        public void AfisareGridFacturi(int id_antet)
        {

            //creare tabel cu istoric facturi
            if (!(CheltuieliDS.Tables["IstoricFacturi"] is null))
            {
                CheltuieliDS.Tables.Remove("IstoricFacturi");
            }
            CheltuieliDS.getSetFrom("select * from mv_IstoricDocumente where id_asociere=44 and id_org=" + idAsociatie, "IstoricFacturi");
            GridFacturi.DataSource = CheltuieliDS.Tables["IstoricFacturi"];

            if (!(CheltuieliDS.Tables["mv_tabelParteneri"] is null))
            {
                CheltuieliDS.Tables.Remove("mv_tabelParteneri");
            }
            CheltuieliDS.getSetFrom("select * from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            comboBoxParteneri.DataSource = CheltuieliDS.Tables["mv_tabelParteneri"];
            comboBoxParteneri.ValueMember = "id_org";
            comboBoxParteneri.DisplayMember = "Denumire";

            // verific daca au fost adaugati parteneri pentru a notifica utilizatorul ca trebuie sa introduca mai intai unul
            if (CheltuieliDS.Tables["mv_tabelParteneri"].Rows.Count == 0)
            {
                DialogResult result = MessageBox.Show("Nu aveti parteneri definiti pentru asociatia curenta! ", "Notificare", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Trebuie sa mergeti la Structura Asociatie, tabul de Parteneri pentru a defini unul!", "notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
            // metoda afisare elemente din stanga treeview
            public void AdaugareFacturi(int idAntet)
            {

                //creare tabel pentru afisare grid
                if (!(CheltuieliDS.Tables["TabelDocumente"] is null))
                {
                    CheltuieliDS.Tables.Remove("TabelDocumente");
                }
                // variabila pentru a_id_antet
                CheltuieliDS.getSetFrom("select * from mv_Documente where a_id_asociere=44 and a_id_antet=" + idAntet, "TabelDocumente");
                if (!(CheltuieliDS.Tables["TabelRepartizare"] is null))
                {
                    CheltuieliDS.Tables.Remove("TabelRepartizare");
                }
                CheltuieliDS.getSetFrom("select * from mv_antet_repartizare where id_antet =" + idAntet, "TabelRepartizare");
            // trebuie eliminate orice urma de doc anterior atat din casete cat si din tree

            //dupa golire verific tabela preluata din repartizari
            // parcurgere tree din parinte catre ultimul copil si dau check la casetele respective

                GridPozitiiFactura.DataSource = CheltuieliDS.Tables["TabelDocumente"];
                CheltuieliDS.Tables["TabelDocumente"].Columns["a_id_org"].DefaultValue = idAsociatie;
                CheltuieliDS.Tables["TabelDocumente"].Columns["a_id_asociere"].DefaultValue = 44;
                GridPozitiiFactura.AllowUserToAddRows = true;
                //creare dataTable in dataset pentru afisarea din lista de cheltuieli
                if (!(CheltuieliDS.Tables["denumiri_cheltuieli"] is null))
                {
                    CheltuieliDS.Tables.Remove("denumiri_cheltuieli");
                }
                CheltuieliDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");
                DataGridViewComboBoxColumn abc = (DataGridViewComboBoxColumn)this.GridPozitiiFactura.Columns["p_id_asociere"];
                abc.DataSource = CheltuieliDS.Tables["denumiri_cheltuieli"];
                abc.ValueMember = "id_asociere";
                abc.DisplayMember = "val_label";


            }
        public void CurataTextBox()
        {
           
            DataCurenta.Value = System.DateTime.Now; //valoarea pntru data
            // 
            //if (!(CheltuieliDS.Tables["mv_tabelParteneri"] is null))
            //{
            //    CheltuieliDS.Tables.Remove("mv_tabelParteneri");
            //}
            //CheltuieliDS.getSetFrom("select * from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            //comboBoxParteneri.DataSource = CheltuieliDS.Tables["mv_tabelParteneri"];
            //comboBoxParteneri.ValueMember = "id_org";
            //comboBoxParteneri.DisplayMember = "Denumire";
          
            seriaFactura.Text = "";
            numarFactura.Text = "";
            sumaFactura.Text = "";
            treeDistribuieCheltuiala.ExpandAll();
            AfisareGridFacturi(0);
            AdaugareFacturi(0);
            treeDistribuieCheltuiala.Nodes[0].Checked = false;
        }
        
        

        public void inserareValoriInGridFactura()
        {
            if (CheltuieliDS.Tables["mv_tabelParteneri"].Rows.Count > 0)
            {
                foreach (DataRow row in CheltuieliDS.Tables["TabelDocumente"].Rows)
                {
                    string data = DataCurenta.Value.Date.ToString("yyyy/MM/dd");
                    int partener = (int)comboBoxParteneri.SelectedValue; ;
                    int id_antet = 0; 
                    int id_pozitie = 0; 
                    Guid id_temporar = Guid.NewGuid();
                    string numar = numarFactura.Text;
                    string serie = seriaFactura.Text;
                    string suma = sumaFactura.Text;
                    int cota_tva = 1;


                    row["a_id_antet"] = id_antet;
                    row["a_nr_doc"] = numar;
                    row["a_serie"] = serie;
                    row["a_data"] = data;
                    row["p_id_pozitie"] = id_pozitie;
                    row["a_id_partener"] = partener;                   
                    row["p_id_cota_tva"] = cota_tva;                   
                    row["a_id_temporar"] = id_temporar;
                    row["a_id_org"] = idAsociatie;
                    row["a_id_asociere"] = 44;
                   
                }
                MessageBox.Show("uraa", "am inserat");
            }

        }

       
        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {

        }
        //salvare doc sau update
        private void btnSalveazaCheltuieli_Click(object sender, EventArgs e)
        {
            
            

        }

        // metoda care verifica nodurile dupa bifarea casutei check
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.TreeView.BeginUpdate();
                if (e.Node.Nodes.Count > 0)
                {
                    var parentNode = e.Node;
                    var nodes = e.Node.Nodes;
                    CheckedOrUnCheckedNodes(parentNode, nodes);
                }
            }
            finally
            {
                e.Node.TreeView.EndUpdate();
            }
        }
        // fiecare copil care tine de un parinte checked este bifat sau debifat in bloc
        private void CheckedOrUnCheckedNodes(TreeNode parentNode, TreeNodeCollection nodes)
        {
            if (nodes.Count > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = parentNode.Checked;
                    CheckedOrUnCheckedNodes(parentNode, node.Nodes);
                }
            }
        }

        
        List<TreeNode> listaDistribuieCheltuiala = new List<TreeNode>();

        public void noduriSelectate(TreeNodeCollection nodes)
        {
            //int countIndex = 0;
            
           // string selectedNode = "Noduri selectate : ";
            foreach (TreeNode myNode in nodes)
            {
                // verific daca nodul este selectat
                if (myNode.Checked)
                {
                    listaDistribuieCheltuiala.Add(myNode);
                    // schimb culoarea nodului si il adaug in string
                   // myNode.BackColor = Color.Aquamarine;
                    
                   //verifica existenta bifarii in view si si asta trebuie sa se intoarca in tree
                   // selectedNode += myNode.Text + " " + "\r\n";
                  // countIndex++;
                }
                
                else
                {
                    myNode.BackColor = Color.White;
                }
                noduriSelectate(myNode.Nodes);
            }

           
        }

       
        // crearea tabelei pentru afisare in tree
        private void extrageTabelaTree()
        {
            if (!(CheltuieliDS.Tables["TabelAfisareTree"] is null))
            {
                CheltuieliDS.Tables.Remove("TabelAfisareTree");
            }
            CheltuieliDS.getSetFrom("select * from mv_org_pt_repartizare where  id_asociatie=" + idAsociatie + " order by org_id_master asc", "TabelAfisareTree");
           int id_org= (int) CheltuieliDS.Tables["TabelAfisareTree"].Rows[0]["org_id_org"];
            string valoare = CheltuieliDS.Tables["TabelAfisareTree"].Rows[0]["org_valoare"].ToString();
            GetTreeItemsNou(id_org, valoare, treeDistribuieCheltuiala.Nodes);
        }
        // metoda care returnea toate elementele copil pentru nodul selectat
        private void GetTreeItemsNou(int idOrg, string valoare , TreeNodeCollection parinteNod)
        {
           TreeNode copil =new TreeNode();
            copil.Tag = idOrg;
            copil.Text = valoare;
            parinteNod.Add(copil);
            DataRow[] datacopii = CheltuieliDS.Tables["TabelAfisareTree"].Select(" org_id_master = "+ idOrg);
            foreach (DataRow rand in datacopii)
            {
                int idOrgCopil = (int)rand ["org_id_org"];
                string valoare_copil = rand["org_valoare"].ToString();
                GetTreeItemsNou(idOrgCopil, valoare_copil, copil.Nodes);
            }



        }
        // schimbarea textului de pe butonul distribuie cheltuiala cand treci cu mouseul peste
        private void distribuieCheltuiala_MouseHover(object sender, EventArgs e)
        {    
                distribuieCheltuiala.Text = "Bifeaza cel putin  o casuta !";         
 
        }
        // afisarea textului de pe butonul distribuie cheltuiala la 
        private void distribuieCheltuiala_MouseLeave(object sender, EventArgs e)
        {
            distribuieCheltuiala.Text = "Distribuie Cheltuiala";
        }

        private void btnModificaCheltuieli_Click(object sender, EventArgs e)
        {
            btnModificaCheltuieli.Visible = false;
            if (btnModificaCheltuieli.Visible == false)
            {
                
            }else
                MessageBox.Show("Pentru a modifica selecteaza un rand apoi apasa butonul MODIFICA");

        }

        private void GridFacturi_DoubleClick(object sender, EventArgs e)
        {
            if (btnModificaCheltuieli.Visible == false) { 

                foreach (DataGridViewRow row in GridFacturi.SelectedRows)
                {
                    int id_antet = Convert.ToInt32(row.Cells[0].Value);
                    numarFactura.Text = (row.Cells[1].Value).ToString();
                    seriaFactura.Text = (row.Cells[2].Value).ToString();
                    DataCurenta.Value = Convert.ToDateTime(row.Cells[3].Value);
                    int idPartener = int.Parse((row.Cells[4].Value).ToString());

                    if (!(CheltuieliDS.Tables["DenumirePartenerSelectat"] is null))
                    {
                        CheltuieliDS.Tables.Remove("DenumirePartenerSelectat");
                    }
                    CheltuieliDS.getSetFrom("select id_org,Denumire from mv_tabelParteneri where id_org= " + idPartener, "DenumirePartenerSelectat");
                    comboBoxParteneri.DataSource = CheltuieliDS.Tables["DenumirePartenerSelectat"];
                    comboBoxParteneri.ValueMember = "id_org";
                    comboBoxParteneri.DisplayMember ="Denumire";
                    //comboBoxParteneri.SelectedItem = CheltuieliDS.Tables["DenumirePartenerSelectat"].Rows[0]["Denumire"];
                    // comboBoxParteneri.Text = "mARIAN";//CheltuieliDS.Tables["mv_tabelParteneri"].Rows[0]["id_org"].ToString();
                
                    sumaFactura.Text = (row.Cells[7].Value).ToString();                        
                
                    AdaugareFacturi(id_antet);                   
                }
            }
            else
                MessageBox.Show("Pentru a modifica apasa butonul MODIFICA");
        }

        private void btnSalveazaCheltuieli_Click_1(object sender, EventArgs e)
        {
            noduriSelectate(treeDistribuieCheltuiala.Nodes);
            if (seriaFactura.Text == "" || numarFactura.Text == "" || sumaFactura.Text == "")
            {
                MessageBox.Show("Nu nu poti salva Cheltuiala fara a trece serie, nr si suma", "Notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (listaDistribuieCheltuiala.Count > 0)// verific daca a fost selectat cel putin un element in treeView
                {
                    inserareValoriInGridFactura();
                    CheltuieliDS.TransmiteActualizari("TabelDocumente", "mv_Documente");
                    // creez var pt id-temporar din mv_documente si o inserez in mv_antet_repartizare
                    // sa parcurg tot treeul nod cu nod si in tabela de repartizare , pentru ficare nod extrag tagul si fac o cautare in tabela de reparttizare pe id-org
                    //1 in tabela tag exista - adica am gasit o linie
                    //1.1 nodul curent sa fie selectat - nu fac nimic
                    //1.2 nodul curent nu este selectat in tree - linia aia trebuie stearsa din tabela de repartizare

                    //2 in tabela nu exista linie
                    //2.1 nodul curent sa fie selectat - trebuie sa inserez o linie in tabela cu id_o rg pt ele
                    //2.2 nodul curent nu este selectat in tree - nu fac nimic
                    
                    CheltuieliDS.TransmiteActualizari("mv_antet_repartizare");
                    listaDistribuieCheltuiala.Clear();
                    CurataTextBox();
                }
                else
                {
                    MessageBox.Show("Nu ai selectat nimic din TreeView Distribuie Cheltuiala" + "r\n" + "Trebuie sa alegi cel putin o entitate!", "Notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            btnModificaCheltuieli.Visible = true;
        }
    }
}
