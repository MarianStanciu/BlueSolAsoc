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
        public CreareAsociatie()
        {
            InitializeComponent();
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
    }
}
