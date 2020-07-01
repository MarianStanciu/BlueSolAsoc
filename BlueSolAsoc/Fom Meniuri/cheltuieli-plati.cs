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
            AfisareGridFacturi();
            AdaugaRadacinaParinteTreeView();
        

        }
        public void AfisareGridFacturi()
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
            CheltuieliDS.getSetFrom("select * from mv_Documente where a_id_asociere=44 and a_id_org=0", "TabelDocumente");
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
                   // row["p_pret"] = pret;
                    //row["p_cantitate"] = cantitate;
                    row["p_id_cota_tva"] = cota_tva;
                    //row["p_valoare"] = suma;
                    row["a_id_temporar"] = id_temporar;
                    row["a_id_org"] = idAsociatie;
                    row["a_id_asociere"] = 43;
                    //row["id_TipDocument"] = 0; 
                    //row["tipDocument"] = 0;
                }
                MessageBox.Show("uraa", "am inserat");
            }

        }

        public void AdaugaRadacinaParinteTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeDistribuieCheltuiala.Nodes.Add(asociatie);
            treeDistribuieCheltuiala.Visible = false;


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
            noduriSelectate(treeDistribuieCheltuiala.Nodes);
            // ApeleazaRecursive(treeDistribuieCheltuiala);
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

            //if (countIndex > 0)
            //    MessageBox.Show(selectedNode);
            //else
            //    MessageBox.Show("Nu sunt noduri selectate!");
        }

        private void AfiseazaRecursive(TreeNode treeNode)
        {
            // afisez nodul  
          //  System.Diagnostics.Debug.WriteLine(treeNode.Text);
            MessageBox.Show(treeNode.Text);
            // afisez fiecare nod recursiv  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                AfiseazaRecursive(tn);
            }
        }

        // apelez procedura folosind TreeView.  
        private void ApeleazaRecursive(TreeView treeView)
        {
            // Print each node recursively.  
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                AfiseazaRecursive(n);
            }
        }



    }
}
