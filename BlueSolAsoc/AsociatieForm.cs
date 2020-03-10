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
                AdaugaRadacinaTreeView();
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

        public void AdaugaRadacinaTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            treeView1.Nodes.Add(asociatie);
            AdRamura(treeView1.Nodes, 0);

        }
        // INPLEMENTEZ AFTERSELECT CARE SE APELEAZA DUPA CE SE DA CLICK PE UN NOD 
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            int nId = System.Convert.ToInt16(e.Node.Tag);
            
            AdRamura(e.Node.Nodes, nId);

        }
        // ADAUGA O RAMURA LA UN NOD
        private void AdRamura(TreeNodeCollection nodes, int nId)
        {

            try
            {
              //  nodes.Clear();
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
          //  nIdMaster = idAsociatie;
            SqlDataReader dr = null;
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            connection.Open();
 
            SqlCommand cmd = new SqlCommand("select * from vOrganizatii where id_master=" + nIdMaster, connection);
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
        private void SelectNode(TreeNode node)
        {
            if (node.IsSelected)
               
                node.TreeView.Focus();
        }
    }
}
