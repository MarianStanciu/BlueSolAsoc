﻿using BlueSolAsoc.butoane_si_controale;
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

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class venituri_incasari : FormBluebit

    {
        
        private string denumireAsociatie;
        private int idAsociatie;
        public venituri_incasari(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            string data = dateTimePicker1.Value.Date.ToString("yyyymmdd");
            
            //Insert into dbo.tabela_antet (nr_doc,serie,data,id_partener) values ('1024','GL','20200318','1029')


        }

        private void venituri_incasari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proba_transareDataSet1.tabela_pozitii' table. You can move, or remove it, as needed.
            this.tabela_pozitiiTableAdapter.Fill(this.proba_transareDataSet1.tabela_pozitii);
            // TODO: This line of code loads data into the 'proba_transareDataSet1.tabela_antet' table. You can move, or remove it, as needed.
            this.tabela_antetTableAdapter.Fill(this.proba_transareDataSet1.tabela_antet);
            // TODO: This line of code loads data into the 'proba_transareDataSet.tabela_intretinere' table. You can move, or remove it, as needed.
            this.tabela_intretinereTableAdapter.Fill(this.proba_transareDataSet.tabela_intretinere);
            ClassConexiuneServer.ConectareDedicata();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            ClassConexiuneServer.DeschideConexiunea();

            //string sql = "Select * from dbo.tabela_organizatii";
            SqlCommand sqlcommand = new SqlCommand("dbo.AutoCompletePersoaneFunctional", cnn);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.AddWithValue("@id_asoc", idAsociatie);
             //SqlCommand sqlcommand = new SqlCommand(sql, cnn);

            SqlDataReader sdr = sqlcommand.ExecuteReader();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autoComplete.Add(sdr.GetString(0));
                
            }
            textBoxApartamente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxApartamente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxApartamente.AutoCompleteCustomSource = autoComplete;
            
            cnn.Close();
        }


        
      /*  private void textBoxApartamente_Leave(object sender, EventArgs e)
        {
            string[] StringInfo = textBoxApartamente.Text.Split('/');
            string idProprietar = StringInfo[4].ToString().TrimStart();


        }*/

        private void ButtonChitanteOK_Click(object sender, EventArgs e)
        {
            /* string[] StringInfo = textBoxApartamente.Text.Split('/');
             string idProprietar = StringInfo[4].ToString().TrimStart(); 
             ClassConexiuneServer.ConectareDedicata();
             SqlConnection cnn = ClassConexiuneServer.GetConnection();
             ClassConexiuneServer.DeschideConexiunea();

             // Aducere tabela goala in DataSet / simulare false 1!=1 / Completare tabela goala -> upload in baza date


             string data = dateTimePicker1.Value.Date.ToString("yyyyMMdd");
             string sqlInsertTab_Antet = "Insert into dbo.tabela_antet (nr_doc,serie,data,id_partener) values" + " ('" + TextBoxNrDoc.Text + "','" + TextBoxSerieDoc.Text + "','" + data + "','" + idProprietar + "')"+
                 Convert.ToChar(13)+Convert.ToChar(10) + "Select @@identity as id_antet";
             //SqlCommand command = new SqlCommand(sqlInsertTab_Antet, cnn);
             int id_antet = Convert.ToInt32(ClassConexiuneServer.getScalar(sqlInsertTab_Antet));
             string sqlInsertTab_Pozitii = "Insert into dbo.tabela_pozitii (id_antet,id_tip,pret,cantitate,id_cota_tva,valoare) values" + " ('" + id_antet + "','" + ComboBoxTipIncasare.SelectedIndex + "','" + 1 + "','" + 1 + "','" + 5 + "','" + TextBoxSuma.Text + "')"; 

             //command.ExecuteNonQuery();
             SqlCommand command2 = new SqlCommand(sqlInsertTab_Pozitii, cnn);
             command2.ExecuteNonQuery();
             MessageBox.Show("Ai inserat");
             cnn.Close();*/
            tabelaantetBindingSource.EndEdit();
            tabela_antetTableAdapter.Update(this.proba_transareDataSet1.tabela_antet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
