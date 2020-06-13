using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class venituri_incasari : FormBluebit

    {
        ClassDataSet DataSetVenituriIncasari = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;
        public venituri_incasari(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            dateTimePicker1.Value = System.DateTime.Now;
            DataSetVenituriIncasari.getSetFrom("select * from vVenituriIncasari where id_antet=0", "vVenituriIncasari");
            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["vVenituriIncasari"];
            //DataTable TabelaLabelValoare = dataSetVenituriIncasari1.Tables[0];
            DataSetVenituriIncasari.getSetFrom("select id_asociere,val_label from tabela_asocieri_tipuri where id_master=24", "TipuriIncasari");
            //Pentru fiecare linie din tabela de incasari adaug o linie in view-ul documente cu id_asociere completat conform tipului de incasare
            // inserare pozitii in documente

            // count de coloane tipuriIncasari
            DataTable TabelaTipuriIncasari = DataSetVenituriIncasari.Tables["TipuriIncasari"];
            //TabelaTipuriIncasari.Columns.Add("Valoare");

            //int id_asociere_tabela_tipuri = TabelaTipuriIncasari.Rows[0];
            //int numarcoloane = TabelaTipuriIncasari.Columns.Count;
            /* for (int i = 0; i < TabelaTipuriIncasari.Columns.Count; i++) {*/
            // Parcurgere tabela tipuri si stocare val in string valoareid
            //adaugare rand gol
            //parcurgere randuri goale
            foreach (DataRow row in TabelaTipuriIncasari.Rows)
            {
                //string valoareid = row["id_asociere"].ToString();

                DataRow randta = TabelaVenituriIncasari.Rows.Add();

                randta["id_asociere"] = row["id_asociere"];
                randta["val_label"] = row["val_label"].ToString().Trim();

            }

            //TabelaLabelValoare.Rows.RemoveAt(TabelaLabelValoare.Rows.Count+1);


            // if randvenituri idasoc = gol
            //}

            /*    foreach (DataRow row in TabelaTipuriIncasari.Rows)
                {
                   // string valoareid = row["id_asociere"].ToString();
                    TabelaVenituriIncasari.Rows.Add();

                }
                foreach (DataRow randvenituri in TabelaVenituriIncasari.Rows)
                {
                string valoareid = row["id_asociere"].ToString();
                randvenituri["id_asociere"] = valoareid;
                }*/




            dataGridView1.DataSource = TabelaVenituriIncasari;

            /* ComboBoxTipIncasare.DataSource = TabelaTipuriIncasari;
             ComboBoxTipIncasare.DisplayMember = "val_label";
             ComboBoxTipIncasare.AllowDrop = false;
 */
            //Insert into dbo.tabela_antet (nr_doc,serie,data,id_partener) values ('1024','GL','20200318','1029')
            // adaugare 2 linii in program id tip din asocieri cu denumirile respective 

        }


        private void venituri_incasari_Load(object sender, EventArgs e)
        {
            /*  // TODO: This line of code loads data into the 'dataSetVenituriIncasari1.vVenituriIncasari' table. You can move, or remove it, as needed.
              this.vVenituriIncasariTableAdapter.Fill(this.dataSetVenituriIncasari1.vVenituriIncasari);
              // TODO: This line of code loads data into the 'proba_transareDataSet1.tabela_pozitii' table. You can move, or remove it, as needed.
              this.tabela_pozitiiTableAdapter.Fill(this.proba_transareDataSet1.tabela_pozitii);
              // TODO: This line of code loads data into the 'proba_transareDataSet1.tabela_antet' table. You can move, or remove it, as needed.
              this.tabela_antetTableAdapter.Fill(this.proba_transareDataSet1.tabela_antet);
              // TODO: This line of code loads data into the 'proba_transareDataSet.tabela_intretinere' table. You can move, or remove it, as needed.
              this.tabela_intretinereTableAdapter.Fill(this.proba_transareDataSet.tabela_intretinere);*/
            ClassConexiuneServer.ConectareDedicata();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            ClassConexiuneServer.DeschideConexiunea();

            //string sql = "Select * from dbo.tabela_organizatii";
            // AUTOCOMPLETE DE REFACUT!!!!
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


            // Aducere tabela goala in DataSet / simulare false 1!=1 / Completare tabela goala -> upload in baza date

            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["vVenituriIncasari"];

            /*     for (int i = 0; i <= TabelaVenituriIncasari.Rows.Count; i++)
                 {
                     id_asociere = Convert.ToInt32(TabelaVenituriIncasari.Rows[i]["id_asociere"].ToString());

                 }*/
            // int id_asociere = idasoc;
            foreach (DataRow row in TabelaVenituriIncasari.Rows)
            {
                string data = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
                string[] StringInfo = textBoxApartamente.Text.Split('/');
                string idProprietar = StringInfo[4].ToString().TrimStart();
                int id_antet = 0; // de preluat
                int id_pozitie = 0; // de preluat
                int id_temporar = 0;
                string NR_DOC = TextBoxNrDoc.Text;
                string SERIE = TextBoxSerieDoc.Text;
                //int id_asociere
                string pret = TextBoxPret.Text;
                if (TabelaVenituriIncasari.Rows[0]["pret"].ToString() == "")
                {
                    pret = TextBoxPret.Text; // Caseta SUMA
                }
                else
                {
                    pret = "0";

                }
                int cantitate = 1;
                int cota_tva = 1;
                int suma = Convert.ToInt16(pret) * cantitate;

                row["id_antet"] = id_antet;
                row["nr_doc"] = NR_DOC;
                row["serie"] = SERIE;
                row["data"] = data;
                row["id_pozitie"] = id_pozitie;
                row["id_partener"] = idProprietar;
                row["pret"] = pret;
                row["cantitate"] = cantitate;
                row["id_cota_tva"] = cota_tva;
                row["valoare"] = suma;
                row["id_temporar"] = id_temporar;
            }


            DataSetVenituriIncasari.TransmiteActualizari("vVenituriIncasari");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // in tabela antet la col nr_doc se insereaza valoarea din text box-ul din ecran
            //string nr_doc=TextBoxNrDoc.Text
            //tabel adauga.rand = ...param anterior
            //string serie = TextBoxSerie.Text
            // 

            // DataSetVenituriIncasari.Inserare("vVenituriIncasari");
        }

        private void TextBoxPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // intrare grid pe prima linie in "suma"
                dataGridView1.Focus();
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[9];
                dataGridView1.Rows[0].Cells[9].Value = TextBoxPret.Text;
                //ButtonChitanteOK_Click(sender, e);
            }
            
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell == dataGridView1.Rows[1].Cells[9])
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ButtonChitanteOK_Click(sender, e);
                }
            }
        }
    }
}
