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
        string eroareCaseta = "";
           
       

        public AsociatieForm(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;           
            dataGridViewAp.CellEndEdit += dataGridViewAp_CellEndEdit;
           // GridParteneri.CellEndEdit += GridParteneri_CellEndEdit;

            

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

            // adaugare tabela in dataset pt afisarea elementelor tab parteneri si setare datasource pentri gridParteneri// TABELA DIN VIEW
            if (!(asociatieFormDS.Tables["mv_tabelParteneri"] is null))
            {
                asociatieFormDS.Tables.Remove("mv_tabelParteneri");
            }
            asociatieFormDS.getSetFrom("select * from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            GridParteneri.DataSource = asociatieFormDS.Tables["mv_tabelParteneri"];
            this.GridParteneri.AllowUserToAddRows = true;
            //GridParteneri.Columns["id_master"].Visible = false;
            //GridParteneri.Columns["id_org"].Visible = false;
            //GridParteneri.Columns["Principal"].Visible = false;
            asociatieFormDS.Tables["mv_tabelParteneri"].Columns["id_master"].DefaultValue = idAsociatie;
            //asociatieFormDS.Tables["mv_tabelParteneri"].Columns["Denumire"].DefaultValue = "nume";
            //asociatieFormDS.Tables["mv_tabelParteneri"].Columns["CodFiscal"].DefaultValue = "";
            //asociatieFormDS.Tables["mv_tabelParteneri"].Columns["AtributFiscal"].DefaultValue = "Nu";
            //asociatieFormDS.Tables["mv_tabelParteneri"].Columns["Adresa"].DefaultValue = "";
            //asociatieFormDS.Tables["mv_tabelParteneri"].Columns["NrRegCom"].DefaultValue = "";
            GridParteneri.Enabled = false;


        }

        public void AdaugaRadacinaParinteTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeView1.Nodes.Add(asociatie);


            //creare dataTable in dataset pentru afisarea din lista de cheltuieli
            //TABELUL DENUMIRI CHELTUIELI ESTE CREAT DIN TABELA ASOCIERI PRIN DATASET SI NU DIN VIEW // TABEL DIN TABEL
            asociatieFormDS.getSetFrom("select val_label from tabela_asocieri_tipuri where id_tip=15 ", "denumiri_cheltuieli");
            List<string> scheltuieli = new List<string>(asociatieFormDS.Tables["denumiri_cheltuieli"].Rows.Count);
            DataRow[] cheltuieli = asociatieFormDS.Tables["denumiri_cheltuieli"].Select(null, null, DataViewRowState.OriginalRows);
            for (int k = 0; k < cheltuieli.Length; k++)
            {
                DataRow r = cheltuieli[k];
                string valoare = r[0, DataRowVersion.Original].ToString();
                scheltuieli.Add(valoare);
            }
            //atribuirea listei de valori creata ca sursa de date pentru lista de afisare
            listaCheltuieli.DataSource = scheltuieli;
        }

        //redesenare GridParteneri dupa apasare ok
        private void DupaApasareOk (ClassGridView nume)
        {
            if (!(asociatieFormDS.Tables["mv_tabelParteneri"] is null))
            {
                asociatieFormDS.Tables.Remove("mv_tabelParteneri");
            }

            // adaugare tabela in dataset pt afisarea elementelor tab parteneri / TABELA DIN VIEW
            asociatieFormDS.getSetFrom("select * from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            GridParteneri.DataSource = asociatieFormDS.Tables["mv_tabelParteneri"];
            GridParteneri.Enabled = false;
            MessageBox.Show("a fost folosita metoda de refresh", "notificare");
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

            // adaugare tabela in dataset pt afisarea elementelor din panel1 // TABELA DIN VIEW
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

            //adaugare tabela in dataset pentru apartamente  //TABELA DIN VIEW
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
            switch (TabSA.SelectedTab.Text)
            {
                case "Structura Asociatie":
                    
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
                    break;

                case "Parteneri":
                    
                    GridParteneri.Enabled = true;
                    break;
                default:
                    break;
            }       
                     
           
        }
       
        //actiune buton anuleaza
        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vei pierde toate campurile modificate care nu au fost salvate", "Avertizare", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            { 
                switch (TabSA.SelectedTab.Text)
                {
                    case "Structura Asociatie":
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
                                txtB.Enabled = false;
                            }
                        }
                        classButonModifica1.Show();
                        break;

                    case "Parteneri":
                        GridParteneri.Enabled = false;
                        classButonModifica1.Show();
                        classButonInteriorSterge1.Show();
                        btnAnuleaza.Hide();
                        btnOK.Hide();
                        DupaApasareOk(GridParteneri);
                        break;
                    default:
                        break;
                }           
                
            }           

        }


        // metoda pentru colorarea celulor din datagridview   pentru apartamente  
        //colorare celula editata pe baza valorii initiale comparata cu cea finala

        void dataGridViewAp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            object initial = this.asociatieFormDS.Tables["mv_tabelApartamente"].Rows[e.RowIndex][this.asociatieFormDS.Tables["mv_tabelApartamente"].Columns[e.ColumnIndex].ColumnName, DataRowVersion.Original];
            object final = this.asociatieFormDS.Tables["mv_tabelApartamente"].Rows[e.RowIndex][e.ColumnIndex];
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

          
        }

        //colorare celula editata pe baza valorii initiale comparata cu cea finala
        void GridParteneri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
                object initial = this.asociatieFormDS.Tables["mv_tabelParteneri"].Rows[e.RowIndex][this.asociatieFormDS.Tables["mv_tabelParteneri"].Columns[e.ColumnIndex].ColumnName, DataRowVersion.Current];
                object final = this.asociatieFormDS.Tables["mv_tabelParteneri"].Rows[e.RowIndex][e.ColumnIndex];
                //object tipObiect=final.GetType();

                switch (Type.GetTypeCode(final.GetType()))
                {
                    case TypeCode.Decimal:
                        decimal a = decimal.Parse(final.ToString());
                        if (a < 0)
                        {
                            MessageBox.Show("Introduceti un numar pozitiv", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            final = decimal.Parse((initial.ToString()));
                            GridParteneri.CancelEdit();
                        }

                        break;

                    case TypeCode.Int32:
                        int b = int.Parse(final.ToString());
                        if (b < 0)
                        {
                            MessageBox.Show("Introduceti un numar pozitiv", "Avertizare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            final = int.Parse((initial.ToString()));
                            GridParteneri.CancelEdit();
                        }
                        break;
                    default:
                        break;
                }

                if (initial != final)
                {
                    GridParteneri[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Cyan;
                }
          
        }

        //structura de coloane pentru tabel selectat

        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = asociatieFormDS.Tables[sTabelLucru].Columns;
            return coloane;
        }




        //actiune buton ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (TabSA.SelectedTab.Text)
            {
                case "Structura Asociatie":
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

                        string utilizatComparatie;
                        switch (sl)
                        {
                            case "Numar Bloc(uri)":
                                utilizatComparatie = "Numar Bloc(uri)";
                                if (sl == utilizatComparatie && sr == "0")
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
                            txtB.Enabled = false;
                        }
                    }
                    asociatieFormDS.TransmiteActualizari("mv_detaliiOrganizatie");
                    asociatieFormDS.TransmiteActualizari("mv_tabelApartamente");

                    asociatieFormDS.ExecutaComenzi("exec mp_AdaugaElemente " + id_master);

                    PentruTreeview1AfterSelect(this.treeView1.SelectedNode);

                    break;

/// aici este codul salvare din tabul parteneri
                
                case "Parteneri":
                    DataColumnCollection dc = asociatieFormDS.StructuraColoane("mv_tabelParteneri");
                    string eroare = "";
                    DataRow[] curente= asociatieFormDS.Tables["mv_tabelParteneri"].Select(null, null, DataViewRowState.CurrentRows);// acesta contine statusurile addaugate si modificate
                    for (int k = 0; k < curente.Length; k++)
                    {
                        
                        DataRow r = (DataRow)curente[k];
                        foreach (DataColumn f in dc)
                        {
                            string valoare = r[f.ColumnName].ToString();
                            if (f.ColumnName == "Denumire" && string.IsNullOrEmpty(valoare))
                            {
                                eroare = eroare + f.ColumnName.ToString() + "\r\n";
                            }

                            if (f.ColumnName == "AtributFiscal" && string.IsNullOrEmpty(valoare))
                            {
                                eroare = eroare + f.ColumnName.ToString() + "\r\n";
                            }
                            if (f.ColumnName == "CodFiscal" && string.IsNullOrEmpty(valoare))
                            {
                                eroare = eroare + f.ColumnName.ToString() + "\r\n";
                            }

                        }
                    }

                    if (eroare != "")
                    {
                        MessageBox.Show("Nu poti adauga sau modifica un partener  nou fara Campurile: " + "\r\n" + eroare, "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        asociatieFormDS.TransmiteActualizari("mv_tabelParteneri");
                        classButonModifica1.Show();
                        classButonInteriorSterge1.Show();
                        btnAnuleaza.Hide();
                        btnOK.Hide();
                        GridParteneri.Enabled = false;
                        DupaApasareOk(GridParteneri);
                    }

                    

                    break;
                default:
                    break;
            }
        }

        private void AsociatieForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'asociatieFormDS1.mv_tabelApartamente' table. You can move, or remove it, as needed.
            this.mv_tabelApartamenteTableAdapter.Fill(this.asociatieFormDS1.mv_tabelApartamente);

        }

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !","Informare",MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }
        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !","Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void GridParteneri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a edita valorile din casete apasa butonul MODIFICA !", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       

    }
}
