using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            
          
          
        }
            

        private void cheltuieli_plati_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cheltuieliDS1.mv_Documente' table. You can move, or remove it, as needed.
            this.mv_DocumenteTableAdapter.Fill(this.cheltuieliDS1.mv_Documente);
                       
            extrageTabelaTree();
           // InitializeazaGrupBox();
            //afisare desfasurata a treeului pt repartizarea cheltuielilor
            treeDistribuieCheltuiala.ExpandAll();
            



            AfisareGridFacturi(0);//istoric facturi
            AdaugareFacturi(0);//adaugare facturi
            ClassButon distribuieCheltuiala = new ClassButon();
            adaugareColoane();
        }
        private void InitializeazaGrupBox()
        {
            RadioButton indiviza = new RadioButton();
            indiviza.Text = "Pausal";
            indiviza.Location = new Point(5, 30);
            GroupBoxRepartitie.Controls.Add(indiviza);
            RadioButton asociatie = new RadioButton();
            asociatie.Text = "Indiviz";
            asociatie.Location = new Point(5, 50);
            GroupBoxRepartitie.Controls.Add(asociatie);

            RadioButton bloc = new RadioButton();
            bloc.Text = "Bloc";
            bloc.Location = new Point(5, 70);
            GroupBoxRepartitie.Controls.Add(bloc);
            GroupBoxRepartitie.Text = "Factura Repartizata:";
          
        }
     
        // metoda de AFISARE FACTURI EXISTENTE existente  si tabelul din dataset 
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
            comboBoxParteneri.ResetText();

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
        // metoda ADAUGARE ELEMENTE 
        public void AdaugareFacturi(int idAntet)
        {
            //creare tabel pentru afisare grid
            if (!(CheltuieliDS.Tables["TabelDocumente"] is null))
            {
                CheltuieliDS.Tables.Remove("TabelDocumente");
            }
            CheltuieliDS.getSetFrom("select * from mv_Documente where a_id_asociere=44 and a_id_antet=" + idAntet, "TabelDocumente");

            // creare tabel repartizare pentru transmiterea nodurilor selectate in tabela
            if (!(CheltuieliDS.Tables["TabelRepartizare"] is null))
            {
                CheltuieliDS.Tables.Remove("TabelRepartizare");
            }
            CheltuieliDS.getSetFrom("select * from mv_antet_repartizare where id_antet =" + idAntet, "TabelRepartizare");
            //data source pt grid pozitii factura
            GridPozitiiFactura.DataSource = CheltuieliDS.Tables["TabelDocumente"];
            NoduriDeBifat(treeDistribuieCheltuiala.Nodes);

            //valori predefinite de inserat in TabelDocumente
            CheltuieliDS.Tables["TabelDocumente"].Columns["a_id_org"].DefaultValue = idAsociatie;
            CheltuieliDS.Tables["TabelDocumente"].Columns["a_id_asociere"].DefaultValue = 44;
            CheltuieliDS.Tables["TabelDocumente"].Columns["p_pret"].DefaultValue = 0;
            CheltuieliDS.Tables["TabelDocumente"].Columns["p_cantitate"].DefaultValue = 0;

            CheltuieliDS.Tables["TabelDocumente"].Columns["p_valoare"].Expression = "p_cantitate * p_pret";
            CheltuieliDS.Tables["TabelDocumente"].Columns["p_valoare"].DefaultValue = 0.00;
            GridPozitiiFactura.AllowUserToAddRows = true;

            //creare dataTable in dataset pentru afisarea tipului de Repartizare 
            if (!(CheltuieliDS.Tables["Tip_Repartizare"] is null))
            {
                CheltuieliDS.Tables.Remove("Tip_Repartizare");
            }
            CheltuieliDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=20 ", "Tip_Repartizare");

            //creare datasource pt combotextbox din grid pozitii factura pentru tip_repartizare
            DataGridViewComboBoxColumn bbc = (DataGridViewComboBoxColumn)this.GridPozitiiFactura.Columns["p_id_tip_repartizare"];
            bbc.DataSource = CheltuieliDS.Tables["Tip_Repartizare"];
            bbc.ValueMember = "id_asociere";
            bbc.DisplayMember = "val_label";



            //creare dataTable in dataset pentru afisarea Denumirilor din lista de cheltuieli
            if (!(CheltuieliDS.Tables["denumiri_cheltuieli"] is null))
            {
                CheltuieliDS.Tables.Remove("denumiri_cheltuieli");
            }
            CheltuieliDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");

            //creare datasource pt combotextbox din grid pozitii factura
            DataGridViewComboBoxColumn abc = (DataGridViewComboBoxColumn)this.GridPozitiiFactura.Columns["p_id_asociere"];
            abc.DataSource = CheltuieliDS.Tables["denumiri_cheltuieli"];
            abc.ValueMember = "id_asociere";
            abc.DisplayMember = "val_label";
            
            //creare tabel antet repartizare care va prelua pozitiile din factura
            if (!(CheltuieliDS.Tables["mv_antet_repartizare"] is null))
            {
                CheltuieliDS.Tables.Remove("mv_antet_repartizare");
            }
            CheltuieliDS.getSetFrom("select * from mv_antet_repartizare ", "mv_antet_repartizare");
            


        }
        // CURATAREA CASETELOR
        public void CurataTextBox()
        {
           
            DataCurenta.Value = System.DateTime.Now; //valoarea pntru data               
            seriaFactura.Text = "";
            numarFactura.Text = "";
            sumaFactura.Text = "";
            treeDistribuieCheltuiala.ExpandAll();
            AfisareGridFacturi(0);
            AdaugareFacturi(0);
            //debifarea tuturor nodurilor
           treeDistribuieCheltuiala.Nodes[0].Checked = false;
        }
        

        // ADAUGAREA VALORILOR DIN TEXTBOXURI IN DATATABLE pentru tab adauga cheltuiala
        public void inserareValoriInGridFactura()
        {
            if (CheltuieliDS.Tables["mv_tabelParteneri"].Rows.Count > 0)
            {
                Guid id_temporar = Guid.NewGuid();
                foreach (DataRow row in CheltuieliDS.Tables["TabelDocumente"].Rows)
                {
                    string data = DataCurenta.Value.Date.ToString("yyyy/MM/dd");
                    int partener = (int)comboBoxParteneri.SelectedValue; ;
                    int id_antet = 0;
                    int id_pozitie = 0;

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

                // MessageBox.Show("uraa", "am inserat");

            }

        }
        // metoda care genereaza codul unic
        public Guid GenereazaCodulGuid()
        {
            Guid deTransmis = (Guid)CheltuieliDS.Tables["TabelDocumente"].Rows[0]["a_id_temporar"];
            return deTransmis; 
        }
        //metoda generare id_antet
        public int GenereazaIdAntet()
        {
            int idAntetDeTransmis = (int)CheltuieliDS.Tables["TabelDocumente"].Rows[0]["a_id_antet"];
            return idAntetDeTransmis;
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

        // CREAREA UNEI LISTE CE CONTINE IDORG PT FIECARE NOD SELECTAT
        List<TreeNode> listaDistribuieCheltuiala = new List<TreeNode>();// lista prin care verific daca exista elemente selectate in treeview

        //metoda  care RETURNEAZA NODURILE SELECTATE si le stocheaza in listaDistribuieCheltuiala
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
                }                
                else
                {
                    myNode.BackColor = Color.White;
                }
                noduriSelectate(myNode.Nodes);
            }

           
        }
        // verifica fiecare nod daca a fost selectat si exista in lista , apoi invers
        private void ToateNodurileSelectate(TreeNodeCollection nodes)
        {
            // sa parcurg tot treeul nod cu nod si in tabela de repartizare , pentru ficare nod extrag tagul si fac o cautare in tabela de reparttizare pe id-org
            //1 in tabela tag exista - adica am gasit o linie
            //1.1 nodul curent sa fie selectat - nu fac nimic
            //1.2 nodul curent nu este selectat in tree - linia aia trebuie stearsa din tabela de repartizare
            foreach (TreeNode nodbifat in nodes)
            {                
                    int idOrg = (int)nodbifat.Tag;
                DataRow[] abb = CheltuieliDS.Tables["TabelRepartizare"].Select(" id_org ="+idOrg);
                   if ( ((abb).Length>0) && !(nodbifat.Checked))  
                    {                 
                    CheltuieliDS.Tables["TabelRepartizare"].Rows.Remove(abb[0]);
                  
                  //sterg rand unde id-antet = var id antet si id_org
                    }
                //2 in tabela nu exista linie
                //2.1 nodul curent sa fie selectat - trebuie sa inserez o linie in tabela cu id_o rg pt ele
                //2.2 nodul curent nu este selectat in tree - nu fac nimic
                else if ((abb).Length == 0 && (nodbifat.Checked ))
                    {
                    CheltuieliDS.Tables["TabelRepartizare"].Rows.Add(0, GenereazaIdAntet(), idOrg, GenereazaCodulGuid());                   
                    }
                ToateNodurileSelectate(nodbifat.Nodes);
             }
         }         
        private void NoduriDeBifat(TreeNodeCollection nodes)
        {
            foreach (TreeNode deBifat in nodes)
            {
                int idOrg = (int)deBifat.Tag;
                if ((CheltuieliDS.Tables["TabelRepartizare"].Select(" id_org =" + idOrg).Length > 0) && !(deBifat.Checked))
                {
                    deBifat.Checked =true;
                }
                NoduriDeBifat(deBifat.Nodes);
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
           int idOrg= (int) CheltuieliDS.Tables["TabelAfisareTree"].Rows[0]["org_id_org"];
            string valoare = CheltuieliDS.Tables["TabelAfisareTree"].Rows[0]["org_valoare"].ToString();
            GetTreeItemsNou(idOrg, valoare, treeDistribuieCheltuiala.Nodes);
        }
        // metoda care returneaza toate elementele copil pentru nodul selectat
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
        //private void distribuieCheltuiala_MouseHover(object sender, EventArgs e)
        //{    
        //        distribuieCheltuiala.Text = "Bifeaza cel putin  o casuta !";         
 
        //}
        // afisarea textului de pe butonul distribuie cheltuiala la 
        //private void distribuieCheltuiala_MouseLeave(object sender, EventArgs e)
        //{
        //    distribuieCheltuiala.Text = "Distribuie Cheltuiala";
        //}

        private void btnModificaCheltuieli_Click(object sender, EventArgs e)
        {
            btnModificaCheltuieli.Visible = false;
            if (btnModificaCheltuieli.Visible == false)
            {
                
            }else
                MessageBox.Show("Pentru a modifica selecteaza un rand apoi apasa butonul MODIFICA");

        }

        //modificare factura existenta prin dublu click in grid de istoric facturi dupa apasarea butonului modifica
        private void GridFacturi_DoubleClick(object sender, EventArgs e)
        {
            if (btnModificaCheltuieli.Visible == false) {
                DataGridViewRow row =GridFacturi.CurrentRow;
                    int idAntet = Convert.ToInt32(row.Cells[0].Value);              
                DataRow [] randSelectat = CheltuieliDS.Tables["IstoricFacturi"].Select(idAntet+"=id_antet");
                numarFactura.Text = (randSelectat[0]["nr_doc"]).ToString();
                seriaFactura.Text = (randSelectat[0]["serie"]).ToString();
                DataCurenta.Value = Convert.ToDateTime(randSelectat[0]["data"].ToString());                               
                string partener = (randSelectat[0]["Denumire"].ToString());               
                    comboBoxParteneri.Text = partener;            
                    sumaFactura.Text = Convert.ToDouble(randSelectat[0]["Valoare"]).ToString();                   

                    AdaugareFacturi(idAntet);                 
            }
            else
                MessageBox.Show("Pentru a modifica apasa butonul MODIFICA");
        }

        //buton salvare
        private void btnSalveazaCheltuieli_Click_1(object sender, EventArgs e)
        {
            noduriSelectate(treeDistribuieCheltuiala.Nodes);
            if (comboBoxParteneri.Text=="" ||  seriaFactura.Text == "" || numarFactura.Text == "" || sumaFactura.Text == "")
            {
                MessageBox.Show("Nu poti salva Cheltuiala fara a trece:"+" \n\r"+ "Partener" + " \n\r"+"Serie"+ "\n\r"+ "Numar"+ " \n\r"+"Suma", "Notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (listaDistribuieCheltuiala.Count > 0)// verific daca a fost selectat cel putin un element in treeView
                {


                    if (!(VerificSumaTotala()))// verific daca valoarea din campul suma este - cu totalul cheltuielilor
                    {
                        MessageBox.Show("Valoarea casutei Suma nu este egala cu totalul elementelor din grid" + "\n\r" + "Verifica toate campurile", "Avartizare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        inserareValoriInGridFactura();
                        CheltuieliDS.TransmiteActualizari("TabelDocumente", "mv_Documente");
                        ToateNodurileSelectate(treeDistribuieCheltuiala.Nodes);
                        CheltuieliDS.TransmiteActualizari("TabelRepartizare", "mv_antet_repartizare");
                        listaDistribuieCheltuiala.Clear();
                        CurataTextBox();
                    }


                }
                else
                {
                    MessageBox.Show("Nu ai selectat nimic din TreeView Distribuie Cheltuiala" + "r\n" + "Trebuie sa alegi cel putin o entitate!", "Notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            btnModificaCheltuieli.Visible = true;
        }

        private void btnAnuleazaCheltuieli_Click(object sender, EventArgs e)
        {
            listaDistribuieCheltuiala.Clear();
            CurataTextBox();
            btnModificaCheltuieli.Show();
        }
        // CALCULARE SUMA IN COLOANA VALOARE
        private void CalculeazaSuma(object sender, DataGridViewCellEventArgs e)

        {
            //DataRow []row = CheltuieliDS.Tables["TabelDocumente"].Select(null, null, DataViewRowState.Added);

            foreach (DataRow row in CheltuieliDS.Tables["TabelDocumente"].Rows)
            {
                //row["p_valoare"] = (Decimal)(row["p_cantitate"]) * (Decimal)(row["p_pret"]);

                CheltuieliDS.Tables["TabelDocumente"].Columns["p_valoare"].Expression = "p_cantitate * p_pret";

            }


        }


        // VERIFICARE DACA EXISTA EGALITATE INTRE TEXTBOX SUMA SI SUMA PE COLOANA VALOARE
        private Boolean VerificSumaTotala()
        {
            double total=0;
            for(int i = 0; i < GridPozitiiFactura.Rows.Count - 1; i++)
            {
               total += Convert.ToDouble(GridPozitiiFactura.Rows[i].Cells["pvaloareDataGridViewTextBoxColumn"].Value);
            }
                if (Convert.ToDouble(sumaFactura.Text.ToString()) == total)
                {
                return true;
                }
                else
                {                         
                return false;
            
                }
        }

        // adaugare coloane in grid pentru calculul intretinerii- se selecteaza din tree elementele de afisat apoi se apasa pe butonul genereaza tabel
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


        // creare tree cu cu noduri din denumirile cheltuielilor
        public void adaugareColoane()
        {
            if (!(CheltuieliDS.Tables["denumiri_cheltuieli"] is null))
            {
                CheltuieliDS.Tables.Remove("denumiri_cheltuieli");
            }
            CheltuieliDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");
            foreach (DataRow r in CheltuieliDS.Tables["denumiri_cheltuieli"].Rows)
            {
                TreeNode node = new TreeNode(r["val_label"].ToString());
                treeColoane.Nodes.Add(node);

            }

        }
        // metoda de bifare parint + copii in tree
        private void treeColoane_AfterCheck(object sender, TreeViewEventArgs e)
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
    }
}
