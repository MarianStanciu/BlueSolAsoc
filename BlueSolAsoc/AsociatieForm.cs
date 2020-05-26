using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BlueSolAsoc
{
    public partial class AsociatieForm : FormBluebit
    {
        ClassDataSet asociatieFormDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;
        object previousValue;
        string eroareCaseta = "";
        string eroareGridView = "";


        public AsociatieForm(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            


         //   dataGridViewAp.CellBeginEdit += dataGridViewAp_CellBeginEdit;
            dataGridViewAp.CellEndEdit += dataGridViewAp_CellEndEdit;

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
            btnOK.Hide();
            btnAnuleaza.Hide();
            if (splitContainer1.Panel1.Focused)
            {
                MessageBox.Show("eeeee !");
            }
            
        }

        public void AdaugaRadacinaParinteTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeView1.Nodes.Add(asociatie);
        }

        //implementare afterselect din tree view care preia id elementului si apelarea metodei care returneaza datasetul cu info despre id
        private void PentruTreeview1AfterSelect(TreeNode Node)
        {
            int nId = System.Convert.ToInt16(Node.Tag);
            asociatieFormDS.ExecutaComenzi("exec mp_VerificaAtribute " + nId);
            asociatieFormDS.ExecutaComenzi("exec mp_VerificaAtributeSubordonate " + nId);
            AdRamura(Node.Nodes, nId);


            //verificam daca exista tabelul in dataset
            if (!(asociatieFormDS.Tables["mv_detaliiOrganizatie"] is null))
            {
                asociatieFormDS.Tables.Remove("mv_detaliiOrganizatie");
            }

            // adaugare tabela in dataset pt afisarea elementelor din panel1
            asociatieFormDS.getSetFrom("select * from mv_detaliiOrganizatie  where  org_id_master =" + nId + " and aso_tip_afisare='edit'", "mv_detaliiOrganizatie");

            


            // ascundem toate controalele din splitpanel1  
            int contor = 0;
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassLabel)
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
            // pentru fiecare rand din tabelul de lucru alocam un label si un text box cu acelasi nr pentru tag
            foreach (DataRow row in asociatieFormDS.Tables["mv_detaliiOrganizatie"].Rows)
            {
                foreach (var cl in splitContainer1.Panel1.Controls)
                {
                    // pentru label
                    if (cl is ClassLabel)
                    {
                        // labelul care are tagul titlu primeste denumirea nodtreeului selectat
                        ClassLabel txtL = (ClassLabel)cl;
                        if (txtL.Tag.ToString() == "titlu")
                        {
                            txtL.Visible = true;
                            txtL.Text = treeView1.SelectedNode.Text;
                        }
                        if (txtL.Tag.ToString() == contor.ToString())
                        {
                            txtL.Visible = true;
                            txtL.Text = row["aso_val_label"].ToString();
                        }
                    }
                    // pentru text box
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                        if (txtB.Tag.ToString() == contor.ToString())
                        {
                            txtB.Visible = true;
                            txtB.Enabled = false;
                            txtB.Text = row["org_valoare"].ToString();
                        }
                    }
                }

                contor = contor + 1;
            }

            int val = (Int32)asociatieFormDS.ReturnareValoare("select aso_id_tip from mv_detaliiOrganizatie where org_id_org=" + nId);

            //adaugare tabela in dataset pentru apartamente
            if (!(asociatieFormDS.Tables["mv_tabelApartamente"] is null))
            {
                asociatieFormDS.Tables.Remove("mv_tabelApartamente");
            }
            asociatieFormDS.getSetFrom("select * from mv_tabelApartamente  where  id_sc =" + nId, "mv_tabelApartamente");

            // verificam daca treenodul selectat este "Scara "
            if (val == 3)
            {
                splitContainer1.Panel1.Show();
                splitContainer1.Panel2.Show();
            }
            // daca nu este selectata scara facem operatiunea inversa
            else
            {
                splitContainer1.Panel2.Hide();
                splitContainer1.Panel1.Show();
            }

            dataGridViewAp.DataSource = asociatieFormDS.Tables["mv_tabelApartamente"];
            dataGridViewAp.Enabled = false;

        }


        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PentruTreeview1AfterSelect(e.Node);
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
                    TreeNode node = new TreeNode(dr["org_valoare"].ToString());
                    // SALVEZ VALOAREA ID-ULUI IN PROPRIETATEA TAG A NODULUI PENTRU A PUTEA APELA MAI DEPARTE QUERY PENTRU NODURILE ACESTEI RAMURI
                    node.Tag = dr["org_id_org"];
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

            SqlCommand cmd = new SqlCommand("select * from mv_detaliiOrganizatie where org_id_master=" + nIdMaster + " and aso_tip_afisare='tree'", connection);
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
        // actiune buton modifica
        private void classButonModifica1_Click(object sender, EventArgs e)
        {
            classButonModifica1.Hide();
            classButonInteriorSterge1.Hide();
            btnAnuleaza.Show();
            btnOK.Show();
            dataGridViewAp.Enabled = true;


            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                    txtB.Enabled = true;
                    
                }
                if (cl is ClassLabel)
                {
                    ClassLabel txtL = (ClassLabel)cl;
                    txtL.Enabled = true;
                }
            }
           
        }
       
        //actiune buton anuleaza
        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vei pierde toate campurile modificate care nu au fost salvate", "Avertizare", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                PentruTreeview1AfterSelect(this.treeView1.SelectedNode);
                dataGridViewAp.Enabled = false;
                classButonInteriorSterge1.Show();
                btnAnuleaza.Hide();
                btnOK.Hide();

                foreach (var cl in splitContainer1.Panel1.Controls)
                {
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                        //aici trebuie implementata refresh pentru textboxuri

                        txtB.Enabled = false;

                    }


                }
                classButonModifica1.Show();
            }
            

        }
        // metoda pentru colorarea celulor din datagridview
        
        

        void dataGridViewAp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            object initial = this.asociatieFormDS.Tables[1].Rows[e.RowIndex][this.asociatieFormDS.Tables[1].Columns[e.ColumnIndex].ColumnName, DataRowVersion.Original];
            object final = this.asociatieFormDS.Tables[1].Rows[e.RowIndex][e.ColumnIndex];
            //object tipObiect=final.GetType();
            
                switch (Type.GetTypeCode(final.GetType()))
            {
                case TypeCode.Decimal:
                    decimal a = decimal.Parse(final.ToString());
                    if (a < 0)
                    {
                        MessageBox.Show("Introduceti un numar pozitiv","Avertizare", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        final = decimal.Parse((initial.ToString()));
                        dataGridViewAp.CancelEdit();
                    }
                   
                    break;

                case TypeCode.Int32:
                    int b =int.Parse(final.ToString());
                    if (b < 0)
                    {
                        MessageBox.Show("Introduceti un numar pozitiv", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        final = int.Parse((initial.ToString()));
                        dataGridViewAp.CancelEdit();
                    }
                    break;
                default:
                    break;
            }

            if ( initial != final)
            {
                dataGridViewAp[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Cyan;
            }  

            //    if (dataGridViewAp[e.ColumnIndex, e.RowIndex].Value != previousValue)
            //        dataGridViewAp[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Cyan;
        }

        //void dataGridViewAp_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    previousValue = dataGridViewAp[e.ColumnIndex, e.RowIndex].Value;
        //}



        //actiune buton ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            //creare DATATABLE
            string id_master = this.treeView1.SelectedNode.Tag.ToString();
            DataTable dataTable = asociatieFormDS.Tables["mv_detaliiOrganizatie"];   
            string sr = "";
            string sl = "";
            for (int contor = 0; contor < dataTable.Rows.Count; contor++)
            {
                foreach (var cl in splitContainer1.Panel1.Controls)
                {
                    if (cl is ClassTextBox)
                    {
                        ClassTextBox txtB = (ClassTextBox)cl;
                        if (txtB.Tag.ToString() == contor.ToString())
                        {
                            txtB.Visible = true;
                            sr = txtB.Text.ToString().Trim();
                        }
                    }
                    if (cl is ClassLabel)
                    {
                        ClassLabel txtL = (ClassLabel)cl;
                        if (txtL.Tag.ToString() == contor.ToString())
                        {
                            txtL.Visible = true;
                            sl = txtL.Text.ToString().Trim();
                        }
                    }

                }
                        int numar;                
                        bool result = int.TryParse(sr, out numar);                
                        if (result)
                        {
                            if (numar < 0) 
                            { 
                            eroareCaseta = "valoare negativa";
                            }
                        }
                        else
                        {
                            eroareCaseta = "";
                        }


                //if ( sl==(dataTable.Rows[contor]["aso_val_label"]).ToString()  )
                //{
                //    MessageBox.Show("Pentru a opera in Asociatie aveti nevoie de cel putin 1 entitate in caseta cu Numar ... " , "Informatie", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //}
                
                string utilizatComparatie;
                switch (sl)
                {
                    case "Numar Bloc(uri)":
                        utilizatComparatie = "Numar Bloc(uri)";
                        if ( sl==utilizatComparatie && sr=="0"  )
                        {
                            MessageBox.Show("Pentru a opera in Asociatie aveti nevoie de cel putin 1 entitate in caseta cu Numar Blocuri ", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        }
                        break;

                    case "Numar Scari":
                        utilizatComparatie = "Numar Scari";
                        if (sl == utilizatComparatie && sr == "0")
                        {
                            MessageBox.Show("Pentru a opera in Asociatie aveti nevoie de cel putin 1 entitate in caseta cu Numar Scari ", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;


                    case "Numar Apartamente":
                        utilizatComparatie = "Numar Apartamente";
                        if (sl == utilizatComparatie && sr == "0")
                        {
                            MessageBox.Show("Pentru a opera in Asociatie aveti nevoie de cel putin 1 entitate in caseta cu Numar Apartamente ", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    default:
                        break;
                }

                if (!(eroareCaseta == ""))
                {
                    MessageBox.Show("NU POTI INTRODUCE VALORI NEGATIVE", "AVERTIZARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //verific daca datele din casetete sunt aceleasi cu cele din tabela
                    if (!(dataTable.Rows[contor]["org_valoare"] == sr))
                    {
                        
                        dataTable.Rows[contor]["org_valoare"] = sr;
                    }
                }
                // daca e diferit de sr atunci = sr
                }
                classButonModifica1.Show();

            
            classButonInteriorSterge1.Show();
            btnAnuleaza.Hide();
            btnOK.Hide();
            foreach (var cl in splitContainer1.Panel1.Controls)
            {
                if (cl is ClassTextBox)
                {
                    ClassTextBox txtB = (ClassTextBox)cl;
                    //aici trebuie implementata refresh pentru textboxuri

                    txtB.Enabled = false;

                }
            }


            asociatieFormDS.TransmiteActualizari("mv_detaliiOrganizatie");
            asociatieFormDS.TransmiteActualizari( "mv_tabelApartamente");
            asociatieFormDS.ExecutaComenzi("exec mp_AdaugaElemente " + id_master);

            PentruTreeview1AfterSelect(this.treeView1.SelectedNode);
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'asociatieFormDS1.mv_detaliiOrganizatie' table. You can move, or remove it, as needed.
            this.mv_detaliiOrganizatieTableAdapter.Fill(this.asociatieFormDS1.mv_detaliiOrganizatie);
            // TODO: This line of code loads data into the 'asociatieFormDS1.vAfisareDetaliiEntitati' table. You can move, or remove it, as needed.

            // this.vAfisareDetaliiEntitatiTableAdapter.Fill(this.asociatieFormDS1.vAfisareDetaliiEntitati);

        }
        private void ProceseazaUpdate(DataTable tabel, OleDbDataAdapter adapter)
        {

        }
        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !","Informare",MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }
        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !","Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
