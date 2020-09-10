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

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class Calcul_intretinere : FormBluebit
    {
        ClassDataSet Calcul_intretinereDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;

        public Calcul_intretinere()        
        {
            InitializeComponent();
        }
       
            public Calcul_intretinere(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;         
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            adaugareColoane();
        }
        public void adaugareColoane()
        {
            if (!(Calcul_intretinereDS.Tables["denumiri_cheltuieli"] is null))
            {
                Calcul_intretinereDS.Tables.Remove("denumiri_cheltuieli");
            }
            Calcul_intretinereDS.getSetFrom("select * from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");
            foreach (DataRow r in Calcul_intretinereDS.Tables["denumiri_cheltuieli"].Rows)
            {
                TreeNode node = new TreeNode(r["val_label"].ToString());
                treeColoane.Nodes.Add(node);

            }

        }
        private void GenereazaTabel_Click(object sender, EventArgs e)
        {
            GridCalculIntretinere.Columns.Clear();

            foreach (TreeNode node in treeColoane.Nodes)
            {
                string numeColoana = node.Text.Trim();
                string headerColoana = node.Text.Trim();

                if (node.Checked)
                {
                    if (GridCalculIntretinere.Columns[numeColoana] == null)
                    {
                        GridCalculIntretinere.Columns.Add(numeColoana, headerColoana);
                    }
                }

            }
            if (GridCalculIntretinere.Columns.Count > 0)
            {
                GridCalculIntretinere.Rows.Add();
            }

        }

        //private void treeColoane_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {
        //        e.Node.TreeView.BeginUpdate();
        //        if (e.Node.Nodes.Count > 0)
        //        {
        //            var parentNode = e.Node;
        //            var nodes = e.Node.Nodes;
        //            CheckedOrUnCheckedNodes(parentNode, nodes);
        //        }
        //    }
        //    finally
        //    {
        //        e.Node.TreeView.EndUpdate();
        //    }

        //}
        //private void CheckedOrUnCheckedNodes(TreeNode parentNode, TreeNodeCollection nodes)
        //{
        //    if (nodes.Count > 0)
        //    {
        //        foreach (TreeNode node in nodes)
        //        {
        //            node.Checked = parentNode.Checked;
        //            CheckedOrUnCheckedNodes(parentNode, node.Nodes);
        //        }
        //    }
        //}
    }
}
