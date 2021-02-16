using BlueSolAsoc.butoane_si_controale;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
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

        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();

        // Declare a string to hold the entire document contents.
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;

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

            ////load datagrid paint
            dataGridView2.ColumnHeadersHeight = dataGridView2.ColumnHeadersHeight * 2;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView2_CellPainting);
            dataGridView2.Paint += new PaintEventHandler(dataGridView2_Paint);
            dataGridView2.Scroll += new ScrollEventHandler(dataGridView2_Scroll);
            dataGridView2.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView2_ColumnWidthChanged);

            //folosim subtitluri drept header peste header
        }
        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            //Rectangle r1 = dataGridView2.GetCellDisplayRectangle(1, -1, true);
            //int w2 = dataGridView2.GetCellDisplayRectangle(-2, -1, true).Width;
            //r1.X += 1;
            //r1.Y += 1;
            //r1.Width = r1.Width + w2 - 2;
            //r1.Height = r1.Height / 2 - 2;
            //e.Graphics.FillRectangle(new SolidBrush(dataGridView2.ColumnHeadersDefaultCellStyle.BackColor), r1);

            //StringFormat format = new StringFormat();
            //format.Alignment = StringAlignment.Center;
            //format.LineAlignment = StringAlignment.Center;
            //e.Graphics.DrawString("Header principal",dataGridView2.ColumnHeadersDefaultCellStyle.Font,new SolidBrush(dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor),r1,format);

        }

        private void dataGridView2_ColumnWidthChanged(object sender,DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataGridView2.DisplayRectangle;
            rtHeader.Height = dataGridView2.ColumnHeadersHeight / 2;
            dataGridView2.Invalidate(rtHeader);
        }
        private void dataGridView2_Scroll(object sender,ScrollEventArgs e)
        {
            Rectangle rtHeader = dataGridView2.DisplayRectangle;
            rtHeader.Height = dataGridView2.ColumnHeadersHeight / 2;
            dataGridView2.Invalidate(rtHeader);
        }
        private void dataGridView2_CellPainting(object sender,DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height/2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
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
                string[] StringInfo = textBoxApartamente.Text.Split('/');
                string idProprietar = StringInfo[4].ToString().TrimStart();
                dataGridViewIstoricProprietar.Rows.Add("Ianuarie","30","100","50","180");
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

        private void ReadDocument()
        {
            string docName = "testPage.txt";
            string docPath = @"D:\";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bmp, 0, 0);
            /* DataTable TabelaVenituriIncasari = DataSetVenituriIncasari.Tables["mv_Documente"];*/
            /*Bitmap bm = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bm, 0, 0);*/

            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;

            printPreviewDialog1.Document = printDocument1;

        }
        private void copyAlltoClipboard()
        {
            dataGridView2.SelectAll();
            DataObject dataObj = dataGridView2.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        //Bitmap bmp;
        public void OwnerDraw(object sender, DGVCellDrawingEventArgs e)
        {
            if (e.row == -1)
            {
                DataGridViewHeaderCell cell = dataGridView2.Columns[e.column].HeaderCell;
                String printvalue = dataGridView2.Columns[e.column].HeaderText;
                // allow the user to do whatever
                // draw background
               // e.g.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.DrawingBounds);
                // Draw column header text upside down and backwards
                e.g.TranslateTransform(e.DrawingBounds.X - 125 + e.DrawingBounds.Width,
                e.DrawingBounds.Y + e.DrawingBounds.Height);
                // e.g.TranslateTransform(e.DrawingBounds.X - ((1/2)*e.DrawingBounds.Width),
                //e.DrawingBounds.Y + e.DrawingBounds.Height + e.DrawingBounds.Width);
                e.g.RotateTransform(270);
                e.g.DrawString(printvalue, e.CellStyle.Font,
                new SolidBrush(e.CellStyle.ForeColor), e.CellStyle.Padding.Left, -
               cell.InheritedStyle.Padding.Bottom);
                // undo the backwards upside down transform
                e.g.ResetTransform();
                // draw grid
                if (dataGridView2.CellBorderStyle != DataGridViewCellBorderStyle.None)
                    e.g.DrawRectangle(new Pen(dataGridView2.GridColor), e.DrawingBounds.X,
                   e.DrawingBounds.Y,
                    e.DrawingBounds.Width, e.DrawingBounds.Height);
                e.Handled = true;
            }
        }
        private void butonPrintTest_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns[1].HeaderText = "NUMAR" + "\n" + "DOCUMENT";
            //dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
            //dataGridView2.Columns[1].HeaderCell.
            /*            //printPreviewDialog1.ShowDialog();
                        ReadDocument();
                        printPreviewDialog1.Document = printDocument1;
                        printPreviewDialog1.ShowDialog();*/
            DGVPrinter printer = new DGVPrinter();
           printer.OwnerDraw += new CellOwnerDrawEventHandler(OwnerDraw);
           //printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;



           // dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView2_CellPainting);

            
            printer.Title = "Titlu de test"; //header
            printer.SubTitle = "Subtitlu"; // footer
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.ColumnWidths.Add(dataGridView2.Columns[9].Name, 130); // formatare latime colaoana 9 [denumire]
            printer.Footer = "BlueBitData" + "\n" + "altceva";// Footer
            //printer.GetRowHeaderCellFormat
            printer.HeaderCellFormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
            //printer.HeaderCellFormatFlags =  RotateFlipType.Rotate180FlipXY;
            //printer.HideColumns.Add(dataGridView2.Columns[9].Name); // Ascundere coloana
            printer.FooterFormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.FooterFormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.DirectionVertical | StringFormatFlags.NoClip;
            printer.FooterColor = Color.Red;
            printer.printDocument.DefaultPageSettings.Landscape = true;            
            printer.PrintDataGridView(dataGridView2);
            
        }


        private void exportBtn_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

       /* private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Vertical text from column 0, or adjust below, if first column(s) to be skipped
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5);
                e.Graphics.ResetTransform();
                e.Handled = true;
            }
            }*/
        // Draw column headers upside down and backwards

    }
    }
