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
        ClassDataSet DataSetVenituriIncasari = new ClassDataSet(); // Utilizare Clasa DataSet pentru creeare tabele
        private string denumireAsociatie; // preluare denumire asociatie 
        private int idAsociatie; // preluare id organizatie - respectiv id asociatie
        public venituri_incasari(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            dateTimePicker1.Value = System.DateTime.Now;
            DataSetVenituriIncasari.getSetFrom("select a_id_antet,a_nr_doc,a_serie,a_data,a_id_partener,p_id_pozitie,p_id_asociere,p_pret,p_cantitate,p_id_cota_tva,p_valoare,tat_val_label,a_id_temporar,a_id_org,a_id_asociere from mv_Documente where a_id_antet=0", "mv_Documente"); // Selectare schelet tabela
            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["mv_Documente"]; // Creare Tabel pe baza selectiei anterioare
            //DataTable TabelaLabelValoare = dataSetVenituriIncasari1.Tables[0];
            DataSetVenituriIncasari.getSetFrom("select id_asociere,val_label from tabela_asocieri_tipuri where id_tip=14", "TipuriIncasari"); // selectare schelet tabela tipuri incasari
            //Pentru fiecare linie din tabela de incasari adaug o linie in view-ul documente cu id_asociere completat conform tipului de incasare
            DataSetVenituriIncasari.getSetFrom("select * from mv_IstoricDocumente","mv_IstoricDocumente");
            DataTable TabelaIstoricDocumente = DataSetVenituriIncasari.Tables["mv_IstoricDocumente"];
            // count de coloane tipuriIncasari
            DataTable TabelaTipuriIncasari = DataSetVenituriIncasari.Tables["TipuriIncasari"];
            //TabelaTipuriIncasari.Columns.Add("Valoare");
            //vVenituriIncasari - denumire tabel initial
            //int id_asociere_tabela_tipuri = TabelaTipuriIncasari.Rows[0];
            //int numarcoloane = TabelaTipuriIncasari.Columns.Count;
            /* for (int i = 0; i < TabelaTipuriIncasari.Columns.Count; i++) {*/
            // Parcurgere tabela tipuri si stocare val in string valoareid
            //adaugare rand gol
            //parcurgere randuri goale
            foreach (DataRow row in TabelaTipuriIncasari.Rows) // parcurgere Tabela Tipuri incasari si inserare tipuri in Venituri Incasari
            {
                //string valoareid = row["id_asociere"].ToString();

                DataRow randta = TabelaVenituriIncasari.Rows.Add();

                randta["p_id_asociere"] = row["id_asociere"];
                randta["tat_val_label"] = row["val_label"].ToString().Trim();

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
            dataGridView2.DataSource = TabelaIstoricDocumente;

            classButonInteriorSterge1.Hide();
            btnAnuleaza.Hide();

            /* ComboBoxTipIncasare.DataSource = TabelaTipuriIncasari;
             ComboBoxTipIncasare.DisplayMember = "val_label";
             ComboBoxTipIncasare.AllowDrop = false;

            //Create the new combobox column and set it's DataSource to a DataTable
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = dal.GetMovieTypes(); ; 
            col.ValueMember = "MovieTypeID";
            col.DisplayMember = "MovieType";
            col.DataPropertyName = "MovieTypeID";

            //Add your new combobox column to the gridview
            gvMovies.Columns.Add(col);
            */
            //Insert into dbo.tabela_antet (nr_doc,serie,data,id_partener) values ('1024','GL','20200318','1029')
            // adaugare 2 linii in program id tip din asocieri cu denumirile respective 

        }


        private void venituri_incasari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetVenituriIncasari1.mv_Documente' table. You can move, or remove it, as needed.
            this.mv_DocumenteTableAdapter.Fill(this.dataSetVenituriIncasari1.mv_Documente);
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

            sdr.Close();

            SqlCommand comandatextbox = new SqlCommand("select top 1 nr_doc from tabela_antet order by id_antet desc", cnn);
            int numardocument = Convert.ToInt32(comandatextbox.ExecuteScalar())+1;
            TextBoxNrDoc.Text = numardocument.ToString();

            cnn.Close();

            
        }

       

        /*  private void textBoxApartamente_Leave(object sender, EventArgs e)
          {
              string[] StringInfo = textBoxApartamente.Text.Split('/');
              string idProprietar = StringInfo[4].ToString().TrimStart();


          }*/

        private void ButtonSalvareOK()
        {
          

            // Aducere tabela goala in DataSet / simulare false 1!=1 / Completare tabela goala -> upload in baza date

            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["mv_Documente"];

            /*     for (int i = 0; i <= TabelaVenituriIncasari.Rows.Count; i++)
                 {
                     id_asociere = Convert.ToInt32(TabelaVenituriIncasari.Rows[i]["id_asociere"].ToString());

                 }*/
            // int id_asociere = idasoc;
            string[] StringInfo = textBoxApartamente.Text.Split('/');
            
            if (!(textBoxApartamente.AutoCompleteCustomSource.Contains(textBoxApartamente.Text))^(TextBoxNrDoc.Text=="")^(TextBoxSerieDoc.Text==""))
            {
                //string eroare = "";
                if (!(textBoxApartamente.AutoCompleteCustomSource.Contains(textBoxApartamente.Text)))
                {
                    MessageBox.Show("Verifica proprietar");
                }
                if(TextBoxNrDoc.Text == "")
                {
                    MessageBox.Show("Numarul documentului nu a fost introdus");
                }
                if (TextBoxSerieDoc.Text == "")
                {
                    MessageBox.Show("Seria documentului nu a fost introdusa");
                }
            }
            else
            {
                foreach (DataRow row in TabelaVenituriIncasari.Rows)
                {
                    string data = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
                    // string[] StringInfo = textBoxApartamente.Text.Split('/');
                    string idProprietar = StringInfo[4].ToString().TrimStart();
                    int id_antet = 0; // de preluat
                    int id_pozitie = 0; // de preluat
                    int id_temporar = 0;
                    string NR_DOC = TextBoxNrDoc.Text;
                    string SERIE = TextBoxSerieDoc.Text;
                    //int id_asociere
                    string pret = TextBoxPret.Text;
                    if (TabelaVenituriIncasari.Rows[0]["p_pret"].ToString() == "")
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


                    row["a_id_antet"] = id_antet;
                    row["a_nr_doc"] = NR_DOC;
                    row["a_serie"] = SERIE;
                    row["a_data"] = data;
                    row["p_id_pozitie"] = id_pozitie;
                    row["a_id_partener"] = idProprietar;
                    row["p_pret"] = pret;
                    row["p_cantitate"] = cantitate;
                    row["p_id_cota_tva"] = cota_tva;
                    row["p_valoare"] = suma;
                    row["a_id_temporar"] = id_temporar;
                    row["a_id_org"] = idAsociatie;
                    row["a_id_asociere"] = 43;
                    //row["id_TipDocument"] = 0; 
                    //row["tipDocument"] = 0;
                }



                DataSetVenituriIncasari.TransmiteActualizari("mv_Documente");
            }
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
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["coloana_suma"];
                dataGridView1.Rows[0].Cells["coloana_suma"].Value = TextBoxPret.Text;
                
                //ButtonChitanteOK_Click(sender, e);
            }
            
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell == dataGridView1.Rows[1].Cells[9])
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ButtonSalvareOK();
                }
            }
        }

        private void classButonModifica1_Click(object sender, EventArgs e)
        {
            classButonInteriorSterge1.Show();
            classButonModifica1.Hide();
            btnAnuleaza.Show();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ButtonSalvareOK();
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            classButonInteriorSterge1.Hide();
            classButonModifica1.Show();
            btnAnuleaza.Hide();
        }

        private void textBoxApartamente_Leave(object sender, EventArgs e)
        {
            if (textBoxApartamente.AutoCompleteCustomSource.Contains(textBoxApartamente.Text))
            {
                // textBoxApartamente.DeselectAll();
                textBoxApartamente.SelectionStart = 0;
                textBoxApartamente.SelectionLength = 0;
            };
        }
    }
}
