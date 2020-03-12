using BlueSolAsoc.butoane_si_controale;
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

namespace BlueSolAsoc
{
    public partial class AsociatieForm : FormBluebit
    {
        
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
                classLabel2.Text = denumireAsociatie;

               AdaugaRadacinaParinteTreeView();
               
            }
            catch (Exception)
            {

                MessageBox.Show("Eroare", "Nu sunt introduse entitati pentru selectie");
            }
           

        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {          
        }


        public void AdaugaRadacinaParinteTreeView()
        {
            
            //    TreeNode asociatie = new TreeNode(denumireAsociatie);
            //    treeView1.Nodes.Add(asociatie);
            //}
            //else
                AdRamura(treeView1.Nodes, 0);
        }

        
        
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            int nId = System.Convert.ToInt16(e.Node.Tag);
            
            AdRamura(e.Node.Nodes, nId);

        }
        // ADAUGA O RAMURA LA UN NOD
        private void AdRamura(TreeNodeCollection nodes, int nId)
        {
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            if (connection.State == ConnectionState.Open)
                connection.Close();
            try
            {
                

               // nodes.Clear();
                SqlDataReader dr = SqlQueryNoduri(nId);
                while (dr.Read())
                {
                   
                        TreeNode node = new TreeNode(dr["valoare"].ToString());
                        // SALVEZ VALOAREA ID-ULUI IN PROPRIETATEA TAG A NODULUI PENTRU A PUTEA APELA MAI DEPARTE QUERY PENTRU NODURILE ACESTEI RAMURI
                        node.Tag = dr["id"];
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
         
           SqlCommand cmd = new SqlCommand("select * from vOrganizatii where id_master=" + nIdMaster  , connection);
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
        private void AdaugareEntitati()
        {
            if (treeView1.Nodes.Count ==0)
            {
                TreeNode nodeBloc = new TreeNode(classTextBox1.Text);
                treeView1.Nodes.Add(nodeBloc);
            }
            else
            {
                TreeNode nodeNou = new TreeNode(classTextBox1.Text);
                treeView1.SelectedNode.Nodes.Add(nodeNou);

                if (classTextBox1.Text == null || classTextBox1.Text == "")
                    MessageBox.Show("Avertizare", "nu puteti insera campuri goale", MessageBoxButtons.OK);
                //else if (classTextBox1.Text != treeView1.SelectedNode.Text)
                //{ MessageBox.Show("nu puteti insera dubluri", "AVERTIZARE", MessageBoxButtons.OK); }
                //else
                //{
                //    treeView1.SelectedNode.Nodes.Add(nodeNou);
                //}



            }
        }








        private void classButonInteriorAdsauSalveaza2_Click(object sender, EventArgs e)
        {         
                     AdaugareEntitati();
        }

        private void classButonModifica1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Text = classTextBox1.Text;
        }
        //private void TreeView1_AfterSelect2(object sender, TreeViewEventArgs e)
        //{
        //    classTextBox1.Text = treeView1.SelectedNode.Text;
        //}

        private void classButonInteriorSterge1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }
    }       
}
