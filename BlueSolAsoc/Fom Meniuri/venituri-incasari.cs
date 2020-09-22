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
            //dataGridView2.Column
            DataSetVenituriIncasari.getSetFrom("select id_asociere,val_label from tabela_asocieri_tipuri where id_tip=14", "TipuriIncasari"); // selectare schelet tabela tipuri incasari
            
            ExtrageDocument(0); // Extragere Schelet
           
            //DataTable TabelaLabelValoare = dataSetVenituriIncasari1.Tables[0];
            
            //Pentru fiecare linie din tabela de incasari adaug o linie in view-ul documente cu id_asociere completat conform tipului de incasare
            DataSetVenituriIncasari.getSetFrom("select * from mv_IstoricDocumente where id_asociere=43","mv_IstoricDocumente");
            DataTable TabelaIstoricDocumente = DataSetVenituriIncasari.Tables["mv_IstoricDocumente"];
           
            dataGridView2.DataSource = TabelaIstoricDocumente;

            classButonInteriorSterge1.Hide();
            btnAnuleaza.Hide();


        }
        private void ExtrageDocument(int idAntet)
        { // Refresh de grid mv_Documente,refresh tabela de lucru
            dateTimePicker1.Value = System.DateTime.Now;
            int numarurmator = 1;
            TextBoxPret.Text = "";
            TextBoxSerieDoc.Text = "";
            

            if(!(DataSetVenituriIncasari.Tables["mv_Documente"] is null))
            {
                DataSetVenituriIncasari.Tables.Remove("mv_Documente");
            }
            DataSetVenituriIncasari.getSetFrom("select * from mv_Documente where a_id_antet="+idAntet, "mv_Documente");// Selectare schelet tabela

            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["mv_Documente"]; // Creare Tabel pe baza selectiei anterioare
            if (TabelaVenituriIncasari.Rows.Count==0) // Daca suntem la inserare se executa
            {
                if(!(DataSetVenituriIncasari.Tables["nrChitanta"] is null))
                {
                    DataSetVenituriIncasari.Tables.Remove("nrChitanta");
                }
                DataSetVenituriIncasari.getSetFrom("select top 1 nr_doc from tabela_antet where id_org=" + idAsociatie + " and id_asociere=43 order by id_antet desc", "nrChitanta");
                DataTable nrChitanta = DataSetVenituriIncasari.Tables["nrChitanta"];
                
                if (nrChitanta.Rows.Count != 0)
                {
                    numarurmator = Convert.ToInt32(nrChitanta.Rows[0]["nr_doc"])+1;
                }
            }else
            {
                numarurmator = Convert.ToInt32(TabelaVenituriIncasari.Rows[0]["a_nr_doc"]);
                dateTimePicker1.Value = (DateTime)TabelaVenituriIncasari.Rows[0]["a_data"];
            }
            DataTable TabelaTipuriIncasari   = DataSetVenituriIncasari.Tables["TipuriIncasari"];



            foreach (DataRow row in TabelaTipuriIncasari.Rows) // parcurgere Tabela Tipuri incasari si inserare tipuri in Venituri Incasari
            {
                //string valoareid = row["id_asociere"].ToString();
                int idAsociere = (int) row["id_asociere"];
                //idAsociere = Convert.ToInt32(TabelaVenituriIncasari.Rows[0]["a_id_asociere"]);
 
                
                DataRow[] randuri = TabelaVenituriIncasari.Select("p_id_asociere="+idAsociere);

                if (randuri.Length==0)
                {
                    DataRow randta = TabelaVenituriIncasari.Rows.Add();

                    randta["p_id_asociere"] = row["id_asociere"];
                    randta["tat_val_label"] = row["val_label"].ToString().Trim();
                    randta["a_data"] = dateTimePicker1.Value;
                    randta["a_nr_doc"] = numarurmator.ToString();
                    randta["a_id_partener"] = 0;
                }
               
            }
            dataGridView1.DataSource = TabelaVenituriIncasari;


                TextBoxNrDoc.Text = TabelaVenituriIncasari.Rows[0]["a_nr_doc"].ToString();
                TextBoxSerieDoc.Text = TabelaVenituriIncasari.Rows[0]["a_serie"].ToString();
                dateTimePicker1.Value = (DateTime)TabelaVenituriIncasari.Rows[0]["a_data"];
            int idPartener = Convert.ToInt32(TabelaVenituriIncasari.Rows[0]["a_id_partener"]);
            if (idPartener !=0)
            {
                string denumirepartener = (string)DataSetVenituriIncasari.ReturnareValoare("exec dbo.AutoCompletePersoaneFunctional "+idAsociatie+","+ idPartener);
                textBoxApartamente.Text = denumirepartener;
            }
                
                //TextBoxPret.Text = (row.Cells[7].Value).ToString();
            


        }

        private void venituri_incasari_Load(object sender, EventArgs e)
        {

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

            

            cnn.Close();

            
        }
      

        /*  private void textBoxApartamente_Leave(object sender, EventArgs e)
          {
              string[] StringInfo = textBoxApartamente.Text.Split('/');
              string idProprietar = StringInfo[4].ToString().TrimStart();


          }*/

        private void ButtonSalvareOK()
        {
            DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["mv_Documente"];
            
            Guid id_temporar = Guid.NewGuid();
            // Aducere tabela goala in DataSet / simulare false 1!=1 / Completare tabela goala -> upload in baza date

            string[] StringInfo = textBoxApartamente.Text.Split('/');

            if (dataGridView1.Rows[0].Cells["coloana_suma"].Value == "")
            {
                MetodaInserareSuma();
            }

            //dataGridView1.Rows[0].Cells["coloana_suma"].Value = TextBoxPret.Text;
            Decimal total = Convert.ToDecimal(TextBoxPret.Text);
            Decimal intretinere = Convert.ToDecimal(dataGridView1.Rows[0].Cells["coloana_suma"].Value);
            Decimal penalitati = Convert.ToDecimal(dataGridView1.Rows[1].Cells["coloana_suma"].Value);
            Decimal fond_rulment = Convert.ToDecimal(dataGridView1.Rows[2].Cells["coloana_suma"].Value);
            bool calcul = ((intretinere + penalitati + fond_rulment) == total) == true;
            if (!(textBoxApartamente.AutoCompleteCustomSource.Contains(textBoxApartamente.Text))^(TextBoxNrDoc.Text=="")^(TextBoxSerieDoc.Text=="")^calcul==false)
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

                if (calcul==false)
                {
                    MessageBox.Show("Suma nu corespunde,verifica datele");
                }

            }
            else
            {
                //alt foreach pentru
              //  int i;
                //for (i = 1; i < dataGridView1.RowCount; i++)
                //{
                    foreach (DataRow row in TabelaVenituriIncasari.Rows)
                    {
                    
                        string data = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd");
                        // string[] StringInfo = textBoxApartamente.Text.Split('/');
                        string idProprietar = StringInfo[4].ToString().TrimStart();
                        int id_antet = 0; // de preluat
                        int id_pozitie = 0; // de preluat

                        //int id_temporar = 0;
                        string NR_DOC = TextBoxNrDoc.Text;
                        string SERIE = TextBoxSerieDoc.Text;
                        //int id_asociere
                        //string pret = TextBoxPret.Text;

                    /*                    if (row["p_pret"].ToString() == "")
                                        {
                                            if (TabelaVenituriIncasari.Rows[0]["p_pret"].ToString() == "")
                                            {

                                                pret = (dataGridView1.Rows[0].Cells["coloana_suma"].Value).ToString();
                                                if (pret == "")
                                                {
                                                    pret = TextBoxPret.Text; // Caseta SUMA
                                                }
                                            }

                                            if (TabelaVenituriIncasari.Rows[0]["p_pret"].ToString() != "")
                                            {
                                                pret = (dataGridView1.Rows[1].Cells["coloana_suma"].Value).ToString();

                                            }
                                            if (TabelaVenituriIncasari.Rows[0]["p_pret"].ToString() != "" && TabelaVenituriIncasari.Rows[1]["p_pret"].ToString() != "")
                                            {
                                                pret = (dataGridView1.Rows[2].Cells["coloana_suma"].Value).ToString();
                                            }
                                            if (pret == "")
                                            {
                                                pret = "0";
                                            }
                                        }*/
/*                    if (row["p_pret"].ToString() == "")
                    {
                        int index = TabelaVenituriIncasari.Rows.IndexOf(row);
                        //int i = 0;
                        pret = dataGridView1.Rows[index].Cells["coloana_suma"].Value.ToString();
                        //i = i + 1;
                    }

                    if (row["p_pret"].ToString() != "")
                    {
                        int index = TabelaVenituriIncasari.Rows.IndexOf(row);
                        //int i = 0;
                        pret = dataGridView1.Rows[index].Cells["coloana_suma"].Value.ToString();
                            //i = i + 1;
                    }*/
                        int cantitate = 1;
                        int cota_tva = 1;
                        //Double suma = Convert.ToDouble(pret) * cantitate;


                        row["a_id_antet"] = id_antet;
                        row["a_nr_doc"] = NR_DOC;
                        row["a_serie"] = SERIE;
                        row["a_data"] = data;
                        row["p_id_pozitie"] = id_pozitie;
                        row["a_id_partener"] = idProprietar;
                        row["p_pret"] = row["p_valoare"].ToString();
                        row["p_cantitate"] = cantitate;
                        row["p_id_cota_tva"] = cota_tva;
                       // row["p_valoare"] = suma;
                        row["a_id_temporar"] = id_temporar;
                        row["a_id_org"] = idAsociatie;
                        row["a_id_asociere"] = 43;

                    }
                //}
             /*   int total = Convert.ToInt32(TextBoxPret.Text);
                int intretinere = Convert.ToInt32(dataGridView1.Rows[0].Cells["coloana_suma"].Value);
                int penalitati = Convert.ToInt32(dataGridView1.Rows[1].Cells["coloana_suma"].Value);
                int fond_rulment = Convert.ToInt32(dataGridView1.Rows[2].Cells["coloana_suma"].Value);*/

/*                if ((intretinere + penalitati + fond_rulment) != total)
                {
                    MessageBox.Show("Suma nu corespunde,verifica datele");
                }
                else
                {*/

                    DataSetVenituriIncasari.TransmiteActualizari("mv_Documente", "mv_Documente");
                    MetodaCuratare(); //metoda de curatare
                    MetodaRefreshGridView();
                //}
                


                //DataSetVenituriIncasari.Tables.Remove("mv_Documente");
                ExtrageDocument(0);

            }
        }
        private void MetodaInserareSuma()
        {
            dataGridView1.Focus();
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["coloana_suma"];
            dataGridView1.Rows[0].Cells["coloana_suma"].Value = TextBoxPret.Text;
            dataGridView1.Rows[1].Cells["coloana_suma"].Value = "0";
            dataGridView1.Rows[2].Cells["coloana_suma"].Value = "0";
        }

        private void MetodaApasareEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // intrare grid pe prima linie in "suma"
                MetodaInserareSuma();

                //ButtonChitanteOK_Click(sender, e);
            }
        }

        private void MetodaRefreshGridView()
        {
            if (!(DataSetVenituriIncasari.Tables["mv_IstoricDocumente"] is null))
            {
                DataSetVenituriIncasari.Tables.Remove("mv_IstoricDocumente");
            }
            DataSetVenituriIncasari.getSetFrom("select * from mv_IstoricDocumente where id_asociere=43", "mv_IstoricDocumente");
            DataTable TabelaIstoricDocumente = DataSetVenituriIncasari.Tables["mv_IstoricDocumente"];
            dataGridView2.DataSource = TabelaIstoricDocumente;
        }

        private void MetodaCuratare()
        {
            textBoxApartamente.Text = "";
            int numardocumentactual = Convert.ToInt32(TextBoxNrDoc.Text);
            TextBoxNrDoc.Text = (numardocumentactual + 1).ToString();
            TextBoxPret.Text = "";
            dataGridView1.Rows[0].Cells["coloana_suma"].Value = 0.0;
        }

          private void ButonStergere()
          {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                
                dataGridView2.Rows.RemoveAt(row.Index);
            }
          }


        private void TextBoxPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MetodaApasareEnter(sender, e);
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

            if (classButonModifica1.Visible == false)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    int id_antet = Convert.ToInt32(row.Cells[0].Value);
                    ExtrageDocument(id_antet);
                    TextBoxPret.Text = (row.Cells[7].Value).ToString();
                }
            }
            else
                MessageBox.Show("Pentru a modifica apasa butonul MODIFICA");
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
                // Cursor de la inceput dupa autocomplete
                textBoxApartamente.SelectionStart = 0;
                textBoxApartamente.SelectionLength = 0;
            };
        }

        private void classButonInteriorSterge1_Click(object sender, EventArgs e)
        {
            string message =
            "Esti sigur?";
            string caption = "Stergere";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
           

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.

            }
            else
            {
                ButonStergere();
                DataColumnCollection dataColumnCollection = DataSetVenituriIncasari.Tables["mv_IstoricDocumente"].Columns;
                dataColumnCollection[0].ColumnName = "a_id_antet";
                DataSetVenituriIncasari.TransmiteActualizari("mv_IstoricDocumente","mv_Documente");
                dataColumnCollection[0].ColumnName = "id_antet";
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (classButonModifica1.Visible == false) {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    int id_antet = Convert.ToInt32(row.Cells[0].Value);
                    ExtrageDocument(id_antet);
                    DataSetVenituriIncasari.TransmiteActualizari("mv_Documente");
                /*    TextBoxNrDoc.Text = (row.Cells[1].Value).ToString();
                    TextBoxSerieDoc.Text = (row.Cells[2].Value).ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells[3].Value);*/
                    TextBoxPret.Text = (row.Cells[7].Value).ToString();
                    //textBoxApartamente.Text = (row.Cells[4].Value).ToString();
                }               
            }else
            MessageBox.Show("Pentru a modifica apasa butonul MODIFICA");
        }

        private void TextBoxPret_Leave(object sender, EventArgs e)
        {
            if (TextBoxPret.Text != "")
            {
                MetodaInserareSuma();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bmp, 0, 0);
            Bitmap bm = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        Bitmap bmp;

        private void butonPrintTest_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp=new Bitmap(this.Size.Width,this.Size.Height,g);
            //bmp = new Bitmap(dataGridView2.Size.Width, dataGridView2.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //mg.CopyFromScreen()
            mg.CopyFromScreen(dataGridView2.Location.X, dataGridView2.Location.Y, 0, 0, dataGridView2.Size);
            printPreviewDialog1.ShowDialog();

            
        }
    }
}
