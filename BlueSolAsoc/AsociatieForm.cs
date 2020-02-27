using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void AsociatieForm1_Load(object sender, EventArgs e)
        {
           /*  classTabControl1.TabPages.Clear();
            String[] denumiri = { "Structura asociatie", "Structura asociatie", "Structura asociatie" };
            int index = 0;
            foreach (string s in denumiri) 
            { 
            var tabPageName = new TabPage(denumiri[index]);
            classTabControl1.TabPages.Add(tabPageName);
            }*/
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
