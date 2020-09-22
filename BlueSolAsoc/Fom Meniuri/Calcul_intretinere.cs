﻿using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class Calcul_intretinere : FormBluebit
    {
        ClassDataSet Calcul_intretinereDS = new ClassDataSet();
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            adaugareColoane();
            extrageTabelaTree();
            treeConsumuriApartament.ExpandAll();// afisarea treeului rezultat in format extins pana la nivel de scara
            PanelConsumAapartament.Hide();// ascunderea panelului ce contine gridul pentru adaugare consumuri pana este selectata o scar din tree
        }
        //GENERARE TABELA CU TOATE DENUMIRILE CHELTUIELILOR in tabul Genereaza tabel intretinere
        public void adaugareColoane()
        {
            if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli");
            }
            Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");
            foreach (DataRow r in Calcul_intretinereDS.Tables["denumiri_cheltuieli"].Rows)
            {
                TreeNode node = new TreeNode(r["val_label"].ToString());
                treeColoane.Nodes.Add(node);

            }

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

            //adaugare tabela in dataset pentru apartamente  //TABELA DIN VIEW
            if (!(Calcul_intretinereDS.Tables["mv_tabelApartamente"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("mv_tabelApartamente");
            }
            Calcul_intretinereDS.getSetFrom("select * from mv_tabelApartamente  where  id_sc =" + nId, "mv_tabelApartamente");
            //CreareAsociatie tabelului pentru consumuri
            if (!(Calcul_intretinereDS.Tables["mv_tabelConsumuriApartamente"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("mv_tabelConsumuriApartamente");
            }
            Calcul_intretinereDS.getSetFrom("select * from mv_ConsumApartamente  where  id_sc =" + nId, "mv_tabelConsumuriApartamente");
            gridAfisareConsumuri.DataSource = Calcul_intretinereDS.Tables["mv_tabelConsumuriApartamente"];
            // verificam daca treenodul selectat este "Scara "
            if (val == 3)
            {
                PanelConsumAapartament.Show();
               
            }
            else
            {
                PanelConsumAapartament.Hide();
            }
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void classButonModifica1_Click(object sender, EventArgs e)
        {

        }

        private void Calcul_intretinere_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'calcul_intretinereDS1.mv_ConsumApartamente' table. You can move, or remove it, as needed.
            this.mv_ConsumApartamenteTableAdapter.Fill(this.calcul_intretinereDS1.mv_ConsumApartamente);

        }
    }
}
