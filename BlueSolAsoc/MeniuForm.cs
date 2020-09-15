using BlueSolAsoc.Fom_Meniuri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlueSolAsoc.Fom_Meniuri.structura_asociatie_formuri;
using BlueSolAsoc.butoane_si_controale;
using System.Configuration;

namespace BlueSolAsoc
{
    public partial class MeniuForm : FormBluebit
    {
        private string denumireAsociatie;
        private int idAsociatie;
        ClassDataSet DataSetComboBox = new ClassDataSet(); // Utilizare Clasa DataSet pentru creare tabele
        string sNumeMeniu = "";


        public MeniuForm(string denumireAsociatieString, int id)
        {
            InitializeComponent();
            timer1.Start();
            
            PopulareMeniuPrincipal(meniuPrincipal);
            denumireAsociatie = denumireAsociatieString;
            idAsociatie = id;
            //  lblAsociatie_Selectata.Text = denumireAsociatieString + " "+id;

            DataSetComboBox.getSetFrom("Select * from tabela_luni", "tabela_luni");//view pentru tabela + triggeri
            //AdaugareLunaCurenta();
           
            DataTable TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
            AtribuireDataSourceCombo();
                    
            gridTabelaLuni.DataSource = TabelaLuni;

            // Incarcare ultima Luna/AN
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if ((config.AppSettings.Settings.Count) != 0)
            {
                var ultimulan = config.AppSettings.Settings["an"].Value;
                var ultimaluna = config.AppSettings.Settings["luna"].Value;
                comboBoxAN.Text = ultimulan;
                comboBoxLUNA.Text = ultimaluna;
                TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
                TabelaLuni.Rows.Add(0, comboBoxLUNA.Text, comboBoxAN.Text, 1, idAsociatie, 0);
            }

        }
        public string GetDenumireAsociatie()
        {
            return this.denumireAsociatie;
        }
        public int GetIdAsociatie()
        {
            return this.idAsociatie;
        }

        private void MeniuForm_Load(object sender, EventArgs e)
        {
            var b = new ClassButon();
            classLabel3.Text = "Selecteaza un buton din meniu";


        }
        // arrayuri pt butoane======================================================================
        string[] meniuPrincipal = { "STRUCTURA ASOCIATIE", "VENITURI / INCASARI", "CHELTUIELI / PLATI","CALCUL INTRETINERE", "INCHIDE APLICATIA" };
       
        private void AdaugareLunaCurenta()
        {
            DataTable TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
            if (TabelaLuni.Rows.Count == 0)
            {
                string data = DateTime.Now.Month.ToString();
                string an = DateTime.Now.Year.ToString();               
                TabelaLuni.Rows.Add(0,data,an,1,idAsociatie,0);
                //DataSetComboBox.TransmiteActualizari("tabela_luni");
            }
        }
        

        private void AtribuireDataSourceCombo()
        {
            DataTable TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
            string[] lunicombobox = {"ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie" };
            int[] numarlunicombo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] ani= { 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031};
            DataTable TabelNumarareLuni = new DataTable();
            TabelNumarareLuni.Columns.Add("luna");
            TabelNumarareLuni.Columns.Add("numar_luna");
            for (int i = 0; i < lunicombobox.Length; i++)
            { 
                TabelNumarareLuni.Rows.Add(lunicombobox[i], numarlunicombo[i]);
            }
            comboBoxLUNA.DataSource = TabelNumarareLuni;
            comboBoxLUNA.ValueMember = "numar_luna";
            comboBoxLUNA.DisplayMember = "luna";

            comboBoxAN.DataSource = ani;
            //comboBoxAN.ValueMember = "an";
            //comboBoxAN.DisplayMember = "an";
            comboBoxAN.SelectedIndex = -1;
            comboBoxLUNA.SelectedIndex = -1;
            
        }

       
    // metoda de populare meniu principal========================================================
    public void PopulareMeniuPrincipal(string [] meniuPrincipal)
        {

            var rowCount = 1;
            var columnCount = meniuPrincipal.Length;
            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;


            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }
            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));

            }
            String[] denumiri = (meniuPrincipal);
            int index = 0;
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                var b = new ClassButon();
                //  var b = new ButonMeniuPrincipal();

                // for (int z = 0; z < denumiri.Length ; z++)
                if (index < denumiri.Length)
                {
                    b.Text = denumiri[index++];
                }

                b.Name = string.Format("b_{0}", i + 1);
                b.Click += ApasareButon;
                b.Dock = DockStyle.Fill;
             
                this.tableLayoutPanel1.Controls.Add(b);
            }
        }
        
        // metoda comuna pentru click pe butoane ---------------------------------------------------------------------
        public void ApasareButon(object sender, EventArgs e)
        {
           
            DataTable TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
            /*            if ((comboBoxLUNA.SelectedIndex == -1) || (comboBoxAN.SelectedIndex == -1))
                        {
                            MessageBox.Show("Alege luna si anul");
                        }else
                        { */

            
            var b = (ClassButon)sender;
                if (b != null)
                {
                    switch (b.Text)
                    {
                        case ("STRUCTURA ASOCIATIE"):
                        classLabel3.Text = "STRUCTURA ASOCIATIE";
                        if (Application.OpenForms.OfType<AsociatieForm>().Any())
                        {
                            Application.OpenForms.OfType<AsociatieForm>().First().BringToFront();
                        }
                        else
                        if (TabelaLuni.Rows.Count == 0)
                        {
                            MessageBox.Show("Alege luna si anul");
                        }
                        else
                        {
                            //       AsociatieForm asociatie = new AsociatieForm();
                            //       asociatie.Show();
                            DeschidePanelMama(new AsociatieForm(this.denumireAsociatie, this.idAsociatie));
                        }

                            //       PopulareMeniuSecundar( meniuSecundar);
                            //      MessageBox.Show("aaaaaaaaaaaaaaaa");

                            break;
                        case ("VENITURI / INCASARI"):
                        classLabel3.Text = "VENITURI / INCASARI";
                        if (Application.OpenForms.OfType<venituri_incasari>().Any())
                        {
                            Application.OpenForms.OfType<venituri_incasari>().First().BringToFront();
                        }
                        else
                         if (TabelaLuni.Rows.Count == 0)
                        {
                            MessageBox.Show("Alege luna si anul");
                        }
                        else
                        {
                            //     MessageBox.Show("ooooooooooo");
                            DeschidePanelMama(new venituri_incasari(this.denumireAsociatie, this.idAsociatie));
                        }
                            //     PopulareMeniuSecundar(meniuSecundar1);
                            break;

                        case ("CHELTUIELI / PLATI"):
                        classLabel3.Text = "CHELTUIELI / PLATI";
                        if (Application.OpenForms.OfType<cheltuieli_plati>().Any())
                        {
                            Application.OpenForms.OfType<cheltuieli_plati>().First().BringToFront();
                        }
                        else
                         if (TabelaLuni.Rows.Count == 0)
                        {
                            MessageBox.Show("Alege luna si anul");
                        }
                        else
                        {
                            //       MessageBox.Show("ooooooooooo");
                            DeschidePanelMama(new cheltuieli_plati(this.denumireAsociatie, this.idAsociatie));
                        }
                            
                            break;
                        case ("INCHIDE APLICATIA"):
                            //       MessageBox.Show("ooooooooooo");
                            //DeschidePanelMama(new cheltuieli_plati());
                            //PopulareMeniuSecundar(meniuSecundar2);
                            this.Close();
                            break;
                       
                        case ("CALCUL INTRETINERE"):
                        classLabel3.Text = "CALCUL INTRETINERE";
                        if (Application.OpenForms.OfType<Calcul_intretinere>().Any())
                        {
                            Application.OpenForms.OfType<Calcul_intretinere>().First().BringToFront();
                        }
                        if (TabelaLuni.Rows.Count == 0)
                        {
                            MessageBox.Show("Alege luna si anul");
                        }
                        else
                        {
                            DeschidePanelMama(new Calcul_intretinere(this.denumireAsociatie, this.idAsociatie));
                            //Form Calcul_intretinere = new Calcul_intretinere();
                            //Calcul_intretinere.Show();
                        }
                            break;

                            // ...
                            // ...
                    }
                }
            

        }

        public void AfisareNumeFereastraActiva()
        {

            classLabel3.Text = sNumeMeniu;
            //ActiveForm.Text;
            //Form.ActiveForm.ToString();
            //Application.OpenForms.ToString();
        }



        // metoda pentru a deschide toate formurile in panelul mama==============================================

        //  private new Form ActiveForm = null;
        private void DeschidePanelMama(Form MamaForm)
        {
            /*   if (ActiveForm != null)
               ActiveForm.Close();
               ActiveForm = MamaForm;*/
            MamaForm.TopLevel = false;
            MamaForm.FormBorderStyle = FormBorderStyle.None;
            MamaForm.Dock = DockStyle.Fill;           
            pnlMama.Controls.Add(MamaForm);
            pnlMama.Tag = MamaForm;
            MamaForm.BringToFront();
            MamaForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNumeFirma.Text = DateTime.Now.ToString("dd  MMM    HH:mm:ss");
        }

        private void classButon1_Click(object sender, EventArgs e)
        {
            if (comboBoxAN.SelectedIndex == -1 || comboBoxLUNA.SelectedIndex == -1)
            {
                MessageBox.Show("Alege luna si anul");
            }
            else
            {
                DataTable TabelaLuni = DataSetComboBox.Tables["tabela_luni"];
                TabelaLuni.Rows.Add(0, comboBoxLUNA.SelectedValue, comboBoxAN.Text, 1, idAsociatie, 0);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);               
                config.AppSettings.Settings.Add("an", comboBoxAN.SelectedValue.ToString());
                config.AppSettings.Settings.Add("luna",comboBoxLUNA.SelectedValue.ToString());
                //var asn = config.AppSettings.Settings["an"];
                //config.Save();
                config.Save(ConfigurationSaveMode.Full);
            }
        }


        // populare meniuri secundare =====================================================================
        /*       public void PopulareMeniuSecundar( String[]meniuSecundar)
               {

                   var rowCount = 1;
                   var columnCount =meniuSecundar.Length ;
                   this.tableLayoutPanel2.ColumnCount = columnCount;
                   this.tableLayoutPanel2.RowCount = rowCount;


                   this.tableLayoutPanel2.ColumnStyles.Clear();
                   this.tableLayoutPanel2.RowStyles.Clear();

                   for (int i = 0; i < rowCount; i++)
                   {
                       this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
                   }
                   for (int i = 0; i < columnCount; i++)
                   {
                       this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));

                   }

                   String[] denumiriSecundare =(meniuSecundar)  ;
                   int index = 0;
                   for (int i = 0; i < rowCount * columnCount; i++)
                   {
                       var b = new Button();
                       //  var b = new ButonMeniuPrincipal();

                       // for (int z = 0; z < denumiri.Length ; z++)
                       if (index < denumiriSecundare.Length)
                       {
                           b.Text = denumiriSecundare[index++];
                       }


                       b.Click += ApasareButon;
                       b.Dock = DockStyle.Fill;
                       this.tableLayoutPanel2.Controls.Add(b);
                   }
               }*/
    }
}
