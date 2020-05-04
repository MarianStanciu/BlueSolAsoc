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
            
                AdRamura(e.Node.Nodes, nId);
            if (!(asociatieFormDS.Tables["vAfisareDetaliiEntitati"] is null))
            {
                asociatieFormDS.Tables.Remove("vAfisareDetaliiEntitati");
            }
            asociatieFormDS.getSetFrom("select * from vAfisareDetaliiEntitati  where  id_master =" + nId + " and tip_afisare='edit'", "vAfisareDetaliiEntitati");
        
           
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
            foreach (DataRow row in asociatieFormDS.Tables["vAfisareDetaliiEntitati"].Rows)
            {
                foreach (var cl in splitContainer1.Panel1.Controls) 
                {
                    if (cl is ClassLabel)
                    {                  
                        ClassLabel txtL = (ClassLabel)cl;
                        if(txtL.Tag.ToString()==contor.ToString())                        
                        {
                            txtL.Visible = true;
                            txtL.Text = row["val_label"].ToString();
                        }
                    }
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                         if(txtB.Tag.ToString()==contor.ToString())
                        {
                            txtB.Visible = true;
                            txtB.Enabled = false;
                            txtB.Text = row["valoare"].ToString();
                        }
                    }
                }                       
              
                contor=contor+1;
            }

           

        }
        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = this.asociatieFormDS.Tables[sTabelLucru].Columns;
            return coloane;
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
    
        
    }       
}
