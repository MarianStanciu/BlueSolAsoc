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
    public partial class CreareAsociatie : FormBluebit
    {
        ClassDataSet DataSetCreareAsoc = new ClassDataSet();
        public CreareAsociatie()
        {
            InitializeComponent();
            DataSetCreareAsoc.getSetFrom("select id_master,id_asociere,valoare from tabela_organizatii where 1<>1", "tabela_organizatii");
        }

        private void classButonInteriorAdsauSalveaza1_Click(object sender, EventArgs e)
        {
           
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string sql = "Insert into Tabela_Organizatii (id_master,id_tip,valoare) values" + " ('" + "0" + "','" + "1'"+",'" + DenumireCreareAsocBox.Text + "')";
            
           //"Insert into Tabela_Organizatii (id_master,id_tip,valoare) values ('0','1'','dsa')"
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();



            command.Dispose();
            cnn.Close();
            var SelectieAsoc = new SelectieAsociatie();         
            SelectieAsoc.Show();
            this.Close();

        }

        private void ButonSalvareAsocCreata_Click(object sender, EventArgs e)
        {
            /* SqlCommand command;
             SqlDataAdapter adapter = new SqlDataAdapter();

             string connetionString;
             SqlConnection cnn;
             connetionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
             cnn = new SqlConnection(connetionString);
             cnn.Open();
             string sql = "Insert into Tabela_Organizatii (id_master,id_tip,valoare) values" + " ('" + "0" + "','" + "1'" + ",'" + DenumireCreareAsocBox.Text + "')";
             //"Insert into Tabela_Organizatii (id_master,id_tip,valoare) values ('0','1'','dsa')"
             command = new SqlCommand(sql, cnn);
             adapter.InsertCommand = new SqlCommand(sql, cnn);
             adapter.InsertCommand.ExecuteNonQuery();





             command.Dispose();
             cnn.Close();
             var SelectieAsoc = new SelectieAsociatie();
             SelectieAsoc.Show();
             this.Close();*/
            ClassConexiuneServer.DeschideConexiunea();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            DataTable tabela_organizatii = DataSetCreareAsoc.Tables["tabela_organizatii"];
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

           /* string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
            cnn = new SqlConnection(connetionString);
            cnn.Open();*/
            //dc[i].ColumnName

            
            tabela_organizatii.Rows.Add(0,1, DenumireCreareAsocBox.Text);

            DataSetCreareAsoc.Inserare("tabela_organizatii");
            int id = ReturnareId();
            tabela_organizatii.Rows.Add(id, 2, DenumireCreareAsocBox.Text);
            //DataSetCreareAsoc.Tables["tabela_organizatii"].Rows[0].Delete();
            tabela_organizatii.Rows[0].Delete();
            DataSetCreareAsoc.Inserare("tabela_organizatii");
           


            var SelectieAsoc = new SelectieAsociatie();
            SelectieAsoc.Show();
            this.Close();

        }
        public int ReturnareId()
        {
            ClassConexiuneServer.DeschideConexiunea();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            SqlCommand command;
            string query = "select id_org from dbo.tabela_organizatii where valoare='" + DenumireCreareAsocBox.Text + "'";
            command = new SqlCommand(query, cnn);
            var scalar = command.ExecuteScalar();
            int id = (int)scalar;
            return id;
        }

        private void ButonAnulareCreareAsoc_Click(object sender, EventArgs e)
        {
            var SelectieAsoc = new SelectieAsociatie();
            SelectieAsoc.Show();
            this.Close();

        }
    }
}
