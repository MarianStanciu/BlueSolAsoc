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
        
        public AsociatieForm()
        {
            InitializeComponent();
        }

      


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {
            string[] blocuri = new string[3] { "Bloc marmota", " Bloc elefant", "Bloc foca" };

            foreach (string s in blocuri)
            {
                TreeNode Node = new TreeNode(s);
                treeView1.Nodes.Add(Node);
            }

        }
    }
}
