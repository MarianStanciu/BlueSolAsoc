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

      
    }
}
