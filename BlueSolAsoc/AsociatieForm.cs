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
        //pt meniul de adauga modifica sterge - cand este selecta unul se ascund celelalte
        private string denumireAsociatie;
        private int idAsociatie;
        public DataSet infoAsociatie;
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

            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeView1.Nodes.Add(asociatie);
           // treeView1.SelectedNode = treeView1.Nodes[0];
           
            //  AdRamura(treeView1.Nodes, 0);
        }

        
        
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            int nId = System.Convert.ToInt16(e.Node.Tag);
            
            AdRamura(e.Node.Nodes, nId);
            SelecteazaProprietatiNod(nId);
            int contor = 0; 
            foreach(var cl in splitContainer1.Panel1.Controls)
            {
                if(cl is ClassLabel)
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
          

            foreach (DataRow row in infoAsociatie.Tables[0].Rows)
            {
                foreach (var cl in splitContainer1.Panel1.Controls) 
                {
                    if (cl is ClassLabel)
                    {
                  
                        ClassLabel txtL = (ClassLabel)cl;
                        if(txtL.Tag.ToString()==contor.ToString())
                        
                        {
                            txtL.Visible = true;
                            txtL.Text = row["denumire"].ToString();
                        }
                    }
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                         if(txtB.Tag.ToString()==contor.ToString())
                        {
                            txtB.Visible = true;
                            txtB.Text = row["valoare"].ToString();
                        }

                    }
                }                         
                              
               
                contor=contor+1;
            }
            classLabel1.Visible = true;
            classLabel1.Text = treeView1.SelectedNode.Text;

        }
        // ADAUGA O RAMURA LA UN NOD
        private void AdRamura(TreeNodeCollection nodes, int nId)
        {
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            // de modificat aici cu conexiunea
            if (ClassConexiuneServer.DeschideConexiunea())
                connection.Close();
            ////   
            try
            {
                

                nodes.Clear();
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
            
            SqlCommand cmd = new SqlCommand("select * from vAsocTree where id_master=" + nIdMaster, connection);
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

        private DataSet SelecteazaProprietatiNod( int id)
        {
            string queryInformatii = "select * from vAfisareDetaliiEntitati where id_master=" + id + "and id_tip>1";
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            SqlCommand command = new SqlCommand(queryInformatii, connection);
           // SqlDataReader rdr = ClassConexiuneServer.sqlDataReader(queryInformatii);
            SqlDataAdapter da= new SqlDataAdapter();
            infoAsociatie = new DataSet();
            da.SelectCommand = command;
            da.Fill(infoAsociatie);
            return infoAsociatie;
        }






        private void classButonInteriorAdsauSalveaza2_Click(object sender, EventArgs e)
        {         
                    // AdaugareEntitati();
                    foreach(var a in splitContainer1.Panel1.Controls)
                    
            {
                if (a is TextBox)
                {
                    TextBox txt = (TextBox)a;
                    txt.Text = "qwqeq";
                }
            }
                   
            classLabel1.Text = treeView1.SelectedNode.Text;
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
