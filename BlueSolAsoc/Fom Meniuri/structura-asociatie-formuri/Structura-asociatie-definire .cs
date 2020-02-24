using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.Fom_Meniuri.structura_asociatie_formuri
{
    public partial class Structura_asociatie_definire : FormBluebit
    {
        public Structura_asociatie_definire()
        {
            InitializeComponent();
        }

        private void Structura_asociatie_definire_Load(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string nume = "Asociatia";
            lblDenumireAsociatie.Text = nume;
            
        }

        private void butonInchidere1_Load(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
