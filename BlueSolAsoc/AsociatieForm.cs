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
        //public DataSet infoAsociatie;
        //private DataSet infoBazaAsociatie;
        //private DataSet valoriPredefiniteAsociatie;

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

        private void AsociatieForm_Load(object sender, EventArgs e)
        {          
        }

        // adaugare elemente in treeview incapand cu radacina

        public void AdaugaRadacinaParinteTreeView()
        {
            TreeNode asociatie = new TreeNode(denumireAsociatie);
            asociatie.Tag = idAsociatie;
            treeView1.Nodes.Add(asociatie);
            // aici trenuie pusa metoda care face verificarea si inserarea de valori default 
            // atat pt val edit cat si pentru tree
            //SelectieValoriEntitati(idAsociatie); acesta este inlocuit de 
            asociatieFormDS.getSetFrom("select * from vAfisareDetaliiEntitati where legaturaEntitati = 1 and tip_afisare = 'edit' and id_master =" + idAsociatie, "vAfisareDetaliiEntati");
            ElementePredefinite();
            if (asociatieFormDS.Tables[0].Rows.Count == 0)

            {
                SqlConnection connection = ClassConexiuneServer.GetConnection();
                connection.Open();
                foreach ( DataRow r  in valoriPredefiniteAsociatie.Tables[0].Rows )
                {
                    
                    string sqlInsert ="insert into Tabela_Organizatii (id_master, id_tip, valoare)  values("+idAsociatie+", @id_tip, @valoare)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, connection);
                   
                    foreach (DataColumn column in valoriPredefiniteAsociatie.Tables[0].Columns)
                    {

                        cmd.Parameters.AddWithValue("@id_tip", r["id_tip"]);
                        cmd.Parameters.AddWithValue("@valoare", r["val_default"]);
                        //cmd.Parameters.AddWithValue("@id_tip",SqlDbType.Int).Value= r["id_tip"];
                        //cmd.Parameters.Add("@valoare", SqlDbType.VarChar,50).Value = r["val_default"];
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                    }
                }
                //string sqlInsert = " insert into Tabela_Organizatii (id_master, id_tip, valoare)  values";
                //for (int i=0; i<valoriPredefiniteAsociatie.Tables[0].Rows.Count; i++)
                //{
                //    values(idAsociatie + ", " + valoriPredefiniteAsociatie.Tables[0].Columns["id_tip"] + ", " + valoriPredefiniteAsociatie.Tables[0].Columns["val_default"])
                //}
                // MessageBox.Show("Eroare", "Nu sunt introduse entitati pentru selectie");
            }
             
           
        }

        //implementare afterselect din tree view care preia id elementului si apelarea metodei care returneaza datasetul cu info despre id
        
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            int nId = System.Convert.ToInt16(e.Node.Tag);
            
                AdRamura(e.Node.Nodes, nId);
            SelecteazaProprietatiNod(nId);
           
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
            foreach (DataRow row in infoAsociatie.Tables[0].Rows)
            {
                foreach (var cl in splitContainer1.Panel1.Controls) 
                {
                    if (cl is ClassLabel)
                    {                  
                        ClassLabel txtL = (ClassLabel)cl;
                        if(txtL.Tag.ToString()==contor.ToString())                        
                        {
                            txtL.Visible = true;
                            txtL.Text = row["denumire"].ToString();
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
            //label pt afisarea nr de entitati selectate pentru nod
            classLabel8.Visible = true;
            if (treeView1.SelectedNode == treeView1.Nodes[0])
            {
                splitContainer1.Panel2.Controls.Clear();
                classLabel8.Text = "Numar de blocuri";
            }
            else if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0])
            {
                splitContainer1.Panel2.Controls.Clear();
                classLabel8.Text = "Numar de scari";
            }
            else if (treeView1.SelectedNode == treeView1.Nodes[0].Nodes[0].Nodes[0])
            {

                classLabel8.Text = "Numar de apartamente";

                DataSet infoScara = SelecteazaProprietatiNod(nId);
                DataTable dt = infoScara.Tables[0];
                //SqlDataAdapter da = new SqlDataAdapter();
                //DataTableReader dtr = new DataTableReader(dt);


                dataGridViewAp.DataSource = dt;
                splitContainer1.Panel2.Controls.Add(dataGridViewAp);

            }
            //TextBox pt afisarea nr de entitati selectate pentru nod
            classTextBox7.Visible = true;
           // classTextBox7.Text = NumarEntitati(nId).ToString();
            //label pt afisarea denumirii nodului
            classLabel1.Visible = true;
            classLabel1.Text = treeView1.SelectedNode.Text;

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
        //metoda care returneaza numarul de elemente pt id selectat - daca rez=0 iseamna ca nu sunt elemete cu id-MASTER =ID ASOCIATIE
        //private int NumarEntitati(int id)
        //{
        //    string queryNrEntitati = " select count (id_master) from vAfisareDetaliiEntitati where id_master=" + id  ;
        //    SqlConnection connection = ClassConexiuneServer.GetConnection();
        //    SqlCommand command = new SqlCommand(queryNrEntitati, connection);
        //    if (ClassConexiuneServer.DeschideConexiunea() == false)
        //    {
        //        connection.Open();
        //    }
        //    SqlDataReader reader = command.ExecuteReader();
        //           reader.Read();

        //        int    nr_returnat = reader.GetInt32(0);
        //            reader.Close();
        //    connection.Close();
        //        return nr_returnat ;
        //}
        // crearea datasetului pentru id selectat in treeview
        //private DataSet SelecteazaProprietatiNod( int id)
        //{
        //    string queryInformatii = "select * from vAfisareDetaliiEntitati where  id_master=" + id+ " and tip_afisare='edit' ";
            
        //    SqlConnection connection = ClassConexiuneServer.GetConnection();
        //    SqlCommand command = new SqlCommand(queryInformatii, connection);
        //   // SqlDataReader rdr = ClassConexiuneServer.sqlDataReader(queryInformatii);
        //    SqlDataAdapter da= new SqlDataAdapter();
        //    infoAsociatie = new DataSet();
        //    da.SelectCommand = command;
        //    da.Fill(infoAsociatie);
        //    return infoAsociatie;
        //}   
        // metoda care selecteaza elementele din viewul afisare elemente pe baza legaturaEntitate
       // private DataSet SelectieValoriEntitati(int id)
       // {
       //     string SQLselectie = "select * from vAfisareDetaliiEntitati where legaturaEntitati = 1 and tip_afisare = 'edit' and id_master =" + id;
       //     SqlConnection connection = ClassConexiuneServer.GetConnection();
       //     SqlCommand command = new SqlCommand(SQLselectie, connection);
       //     SqlDataAdapter da = new SqlDataAdapter();
       //     infoBazaAsociatie = new DataSet();
       //     da.SelectCommand = command;
       //     da.Fill(infoBazaAsociatie);
          
       //     //infoBazaAsociatie.Tables.Add()
       //     return infoBazaAsociatie;
       // }
        
       //private void InserareEntitatiValPredefinite(int a)
       // {
       //     string sqlInsert = " insert into Tabela_Organizatii (id_master, id_tip, valoare)  values(" + idAsociatie+","+ valoriPredefiniteAsociatie.Tables[0].Columns["id_tip"]+","+ valoriPredefiniteAsociatie.Tables[0].Columns["val_default"];
       //     SqlConnection connection = ClassConexiuneServer.GetConnection();
       //     if (ClassConexiuneServer.DeschideConexiunea() == false)
       //     {
       //         connection.Open();
       //     }
            
       //    // SqlCommand command = new SqlCommand(sqlInsert, connection);
       //     SqlDataAdapter da = new SqlDataAdapter();
       //     da.InsertCommand = new SqlCommand(sqlInsert, connection);
       //     da.InsertCommand.ExecuteNonQuery();
       //     connection.Close();
       // }
       // private DataSet ElementePredefinite()
       // {
       // string selectie = "select id_tip, val_default from tabela_tipuri where id_master=1";
       // SqlConnection connection = ClassConexiuneServer.GetConnection();
       // SqlCommand command = new SqlCommand(selectie, connection);
       // SqlDataAdapter da = new SqlDataAdapter();
       // valoriPredefiniteAsociatie = new DataSet();
       // da.SelectCommand = command;
       //     da.Fill(valoriPredefiniteAsociatie);
       //     return valoriPredefiniteAsociatie;

       // }
        
    }       
}
