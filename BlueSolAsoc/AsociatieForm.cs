using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc
{
    public partial class AsociatieForm : FormBluebit
    {
        ClassDataSet asociatieFormDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;


        public AsociatieForm(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;

            try
            {
                ClassConexiuneServer.ConectareDedicata();
                AdaugaRadacinaParinteTreeView();
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
            catch (Exception e)
            {
                MessageBox.Show("Eroare", e.Message);
            }
            btnOK.Hide();
            btnAnuleaza.Hide();
        }

        public void AdaugaRadacinaParinteTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeView1.Nodes.Add(asociatie);
        }

        //implementare afterselect din tree view care preia id elementului si apelarea metodei care returneaza datasetul cu info despre id

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int nId = System.Convert.ToInt16(e.Node.Tag);
            asociatieFormDS.ExecutaComenzi("exec mp_VerificaAtribute " + nId);
            AdRamura(e.Node.Nodes, nId);
            //verificam daca exista tabelul in dataset
            if (!(asociatieFormDS.Tables["mv_detaliiOrganizatie"] is null))
            {
                asociatieFormDS.Tables.Remove("mv_detaliiOrganizatie");
            }
            asociatieFormDS.getSetFrom("select * from mv_detaliiOrganizatie  where  org_id_master =" + nId + " and aso_tip_afisare='edit'", "mv_detaliiOrganizatie");

         // ascundem toate controalele din splitpanel1  
            int contor = 0;
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassLabel)
                {
                    ClassLabel txtL = (ClassLabel)cl;
                    txtL.Visible = false;

                }
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                    txtB.Visible = false;
                }

            }
         // pentru fiecare rand din tabelul de lucru alocam un label si un text box cu acelasi nr pentru tag
            foreach (DataRow row in asociatieFormDS.Tables["mv_detaliiOrganizatie"].Rows)
            {
                foreach (var cl in splitContainer1.Panel1.Controls)
                {
                    // pentru label
                    if (cl is ClassLabel)
                    {
                        // labelul care are tagul titlu primeste denumirea nodtreeului selectat
                        ClassLabel txtL = (ClassLabel)cl;
                        if (txtL.Tag.ToString() == "titlu")
                        {
                            txtL.Visible = true;
                            txtL.Text = treeView1.SelectedNode.Text;
                        }
                        if (txtL.Tag.ToString() == contor.ToString())
                        {
                            txtL.Visible = true;
                            txtL.Text = row["aso_val_label"].ToString();
                        }
                    }
                    // pentru text box
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                        if (txtB.Tag.ToString() == contor.ToString())
                        {
                            txtB.Visible = true;
                            txtB.Enabled = false;
                            txtB.Text = row["org_valoare"].ToString();
                        }
                    }
                }

                contor = contor + 1;
            }
            
         // verificam daca treenodul selectat este "Scara "
            string a = treeView1.SelectedNode.Text;
            string b = "Scara ";
         //daca este selectata scara ascundem splitpannel1 si activam splitpannel2 cu gridview
                if (b == a)
                {
                    splitContainer1.Panel1.Hide();
                    splitContainer1.Panel2.Show();
                }
         // daca nu este selectata scara facem operatiunea inversa
                else
                {
                    splitContainer1.Panel2.Hide();
                    splitContainer1.Panel1.Show();
                }
                       
            dataGridViewAp.DataSource = asociatieFormDS.Tables["mv_detaliiOrganizatie"];

        }
        
        // ADAUGA O RAMURA LA UN NOD
        private void AdRamura(TreeNodeCollection nodes, int nId)
        {
            SqlConnection connection = ClassConexiuneServer.GetConnection();

            if (ClassConexiuneServer.DeschideConexiunea())
                connection.Close();
            try
            {
                nodes.Clear();
                SqlDataReader dr = SqlQueryNoduri(nId);
                while (dr.Read())
                {
                    TreeNode node = new TreeNode(dr["org_valoare"].ToString());
                    // SALVEZ VALOAREA ID-ULUI IN PROPRIETATEA TAG A NODULUI PENTRU A PUTEA APELA MAI DEPARTE QUERY PENTRU NODURILE ACESTEI RAMURI
                    node.Tag = dr["org_id_org"];
                    nodes.Add(node);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private SqlDataReader SqlQueryNoduri(int nIdMaster)
        {
            SqlDataReader dr = null;
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand("select * from mv_detaliiOrganizatie where org_id_master=" + nIdMaster + " and aso_tip_afisare='tree'", connection);
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return dr;

        }
        // actiune buton modifica
        private void classButonModifica1_Click(object sender, EventArgs e)
        {
            classButonInteriorSterge1.Hide();
            btnAnuleaza.Show();
            btnOK.Show();
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                    txtB.Enabled = true;
                    
                }
                if (cl is ClassLabel)
                {
                    ClassLabel txtL = (ClassLabel)cl;
                    txtL.Enabled = true;
                }
            }
        }
        //actiune buton anuleaza
        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            classButonInteriorSterge1.Show();
            btnAnuleaza.Hide();
            btnOK.Hide();
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                   //aici trebuie implementata refresh pentru textboxuri
              
                    txtB.Enabled = false;
          
                }
                
               
            }
        }
        //actiune buton ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable dataTable = asociatieFormDS.Tables["mv_detaliiOrganizatie"];
            string sr = "";
            for (int contor = 0;contor< dataTable.Rows.Count; contor++)
            {
               

                foreach (var cl in splitContainer1.Panel1.Controls)
                {
                    
                    if (cl is ClassTextBox)
                    {


                        ClassTextBox txtB = (ClassTextBox)cl;
                        if (txtB.Tag.ToString() == contor.ToString())
                        {
                            txtB.Visible = true;
                            string b = txtB.Text.ToString();
                            sr = b;

                        }
                       
                    }
                    
                }
                dataTable.Rows[contor]["org_valoare"] = sr;
                
            }
            classButonInteriorSterge1.Show();
            btnAnuleaza.Hide();
            btnOK.Hide();
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                    //aici trebuie implementata refresh pentru textboxuri

                    txtB.Enabled = false;

                }


            }
            asociatieFormDS.Actualizare("mv_detaliiOrganizatie");
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'asociatieFormDS1.mv_detaliiOrganizatie' table. You can move, or remove it, as needed.
            this.mv_detaliiOrganizatieTableAdapter.Fill(this.asociatieFormDS1.mv_detaliiOrganizatie);
            // TODO: This line of code loads data into the 'asociatieFormDS1.vAfisareDetaliiEntitati' table. You can move, or remove it, as needed.

            // this.vAfisareDetaliiEntitatiTableAdapter.Fill(this.asociatieFormDS1.vAfisareDetaliiEntitati);

        }
    }
}
