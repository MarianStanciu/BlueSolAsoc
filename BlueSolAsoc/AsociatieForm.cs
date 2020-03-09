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
            //ClassConexiuneServer ConectareNoua = new ClassConexiuneServer();
            //ConectareNoua.ConectareDedicata();


        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {
          
            {
                TreeNode Node = new TreeNode(denumireAsociatie);
                treeView1.Nodes.Add(Node);
            }

        }

        //private void ButonAdauga()
        //{
        //    if ()
        //}
       
        public void AdaugaRadacinaTreeView()
        {
           // TreeNode node= new TreeNode()
           // treeView1.Nodes.Clear();
          // treeView1.Nodes.Add();
            // INCHIDEREA CONEXIUNII SE FACE LA INCHIDEREA FERESTREI 
            //            connection.Close();
        }
        // INPLEMENTEZ AFTERSELECT CARE SE APELEAZA DUPA CE SE DA CLICK PE UN NOD 
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // IN e SE PRIMESTE REFERINTA CATRE NODUL SELECTAT
            // EXTRAG VALOAREA DIN TAG PENTRU A PUTEA SELECTA NODURILE SUBORDONATE
            int nId = System.Convert.ToInt16(e.Node.Tag);
            // APELEZ ADAUGAREA RAMURII DEFINITA DE nId
            AdRamura(e.Node.Nodes, nId);

        }
        // ADAUGA O RAMURA LA UN NOD
        private void AdRamura(TreeNodeCollection nodes, int nId)
        {

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
            ClassConexiuneServer ConectareNoua = new ClassConexiuneServer();

            ConectareNoua.sqlDataReader
            SqlDataReader dr = null;
             
            SqlCommand cmd = new SqlCommand("select * from vOrganizatii where id_master=" + nIdMaster, ConectareNoua.ConectareDedicata());
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
    }
}
