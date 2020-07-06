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
            btnSalveazaCheltuieli.Visible = false;
            btnAnuleazaCheltuieli.Visible = false;
            btnModificaCheltuieli.Visible = false;
            btnStergeCheltuieli.Visible = false;
           
            // de adaugat un array
        }

       
     

        private void cheltuieli_plati_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cheltuieliDS1.mv_Documente' table. You can move, or remove it, as needed.
            this.mv_DocumenteTableAdapter.Fill(this.cheltuieliDS1.mv_Documente);
            AfisareGridFacturi(0);            
            extrageTabelaTree();
            treeDistribuieCheltuiala.ExpandAll();
            noduriSelectate(treeDistribuieCheltuiala.Nodes);
        }
        public void AfisareGridFacturi(int id_antet)
        {

            //creare tabel cu istoric facturi
            if (!(CheltuieliDS.Tables["IstoricFacturi"] is null))
            {
                CheltuieliDS.Tables.Remove("IstoricFacturi");
            }
            CheltuieliDS.getSetFrom("select * from mv_IstoricDocumente where id_asociere=44 and id_org=" + idAsociatie , "IstoricFacturi");
          

            if (!(CheltuieliDS.Tables["mv_tabelParteneri"] is null))
            {
                CheltuieliDS.Tables.Remove("mv_tabelParteneri");
            }            
            CheltuieliDS.getSetFrom("select * from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            comboBoxParteneri.DataSource = CheltuieliDS.Tables["mv_tabelParteneri"];
            comboBoxParteneri.ValueMember = "id_org";
            comboBoxParteneri.DisplayMember = "Denumire";

            // verific daca au fost adaugati parteneri
            if(CheltuieliDS.Tables["mv_tabelParteneri"].Rows.Count==0)
            {
                DialogResult result = MessageBox.Show("Nu aveti parteneri definiti pentru asociatia curenta! " , "Notificare", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Trebuie sa mergeti la Structura Asociatie, tabul de Parteneri pentru a defini unul!", "notificare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           

            //creare tabel pentru afisare grid
            if (!(CheltuieliDS.Tables["TabelDocumente"] is null))
            {
                CheltuieliDS.Tables.Remove("TabelDocumente");
            }
            // variabila pentru a_id_antet
            CheltuieliDS.getSetFrom("select * from mv_Documente where a_id_asociere=44 and a_id_antet="+ id_antet, "TabelDocumente");
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
                    int id_temporar = 0;
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
                    row["a_id_asociere"] = 43;
                   
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

        private void btnSalveazaCheltuieli_Click(object sender, EventArgs e)
        {
            inserareValoriInGridFactura();          
            CheltuieliDS.TransmiteActualizari("TabelDocumente", "mv_Documente");           
        }

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

        private void distribuieCheltuiala_Click(object sender, EventArgs e)
        {
            treeDistribuieCheltuiala.Visible = true;
            btnSalveazaCheltuieli.Visible=true;
            btnAnuleazaCheltuieli.Visible = true;
           
          
           
        }

        public void noduriSelectate(TreeNodeCollection nodes)
        {
            //int countIndex = 0;
            
            string selectedNode = "Noduri selectate : ";
            foreach (TreeNode myNode in nodes)
            {
                // verific daca nodul este selectat
                if (myNode.Checked)
                {
                    // schimb culoarea nodului si il adaug in string
                    myNode.BackColor = Color.Aquamarine;
                    //adaugare in arrayul definit in 
                    selectedNode += myNode.Text + " " + "\r\n";
                  // countIndex++;
                }
                
                else
                {
                    myNode.BackColor = Color.White;
                }
                noduriSelectate(myNode.Nodes);
            }

           
        }

       

      
        private void GetTreeviewItems()
        {
            if (!(CheltuieliDS.Tables["TabelAfisareTree"] is null))
            {
                CheltuieliDS.Tables.Remove("TabelAfisareTree");
            }
            CheltuieliDS.getSetFrom("select * from mv_org_pt_repartizare where org_id_master<>0 and id_asociatie=" + idAsociatie, "TabelAfisareTree");
           CheltuieliDS.Relations.Add("ChildRows", CheltuieliDS.Tables["TabelAfisareTree"].Columns["org_id_org"], CheltuieliDS.Tables["TabelAfisareTree"].Columns["org_id_master"]);
           // CheltuieliDS.Relations.Add("testRelatie",)

            foreach (DataRow nivel1 in CheltuieliDS.Tables["TabelAfisareTree"].Rows)
            {
                if ((nivel1["org_id_master"].ToString())=="0")
                {
                    TreeNode nodeParinte = new TreeNode();
                    nodeParinte.Text = nivel1["org_valoare"].ToString();                    
                    treeDistribuieCheltuiala.Nodes.Add(nodeParinte);
                    GetChildRows(nivel1, nodeParinte);
                }
            }           
        }

        private void GetChildRows (DataRow datarow, TreeNode treenode)
        {
            DataRow[] childRows = datarow.GetChildRows("ChildRows");
            //string expresie = "select * from tabel tabelExtragere where org_id_org = org_id_master";
            // DataRow[] childRows = CheltuieliDS.Tables["TabelAfisareTree"].Select(expresie);
            foreach (DataRow childRow in childRows)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = childRow["org_valoare"].ToString();
                treenode.Nodes.Add(childTreeNode);
                if (childRow.GetChildRows("ChildRows").Length > 0)
                {
                    GetChildRows(childRow, childTreeNode);
                }
            }
        }
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
    }
}
