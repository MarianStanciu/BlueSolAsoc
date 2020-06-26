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

namespace BlueSolAsoc
{
    public partial class MeniuForm : FormBluebit
    {
        private string denumireAsociatie;
        private int idAsociatie;

        public MeniuForm(string denumireAsociatieString, int id)
        {
            InitializeComponent();
            timer1.Start();
            PopulareMeniuPrincipal(meniuPrincipal);
            denumireAsociatie = denumireAsociatieString;
            idAsociatie = id;
         //  lblAsociatie_Selectata.Text = denumireAsociatieString + " "+id;
            
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

        }
        // arrayuri pt butoane======================================================================
        string[] meniuPrincipal = { "STRUCTURA ASOCIATIE", "VENITURI / INCASARI", "CHELTUIELI / PLATI", "INCHIDE APLICATIA" };
       

        


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
            var b = (ClassButon)sender;
            if (b != null)
            {
                switch (b.Text)
                {
                    case ("STRUCTURA ASOCIATIE"):
                                if (Application.OpenForms.OfType<AsociatieForm>().Any())
                        {
                            Application.OpenForms.OfType<AsociatieForm>().First().BringToFront();
                        }else
                 //       AsociatieForm asociatie = new AsociatieForm();
                 //       asociatie.Show();
                       DeschidePanelMama(new  AsociatieForm(this.denumireAsociatie, this.idAsociatie));

                 //       PopulareMeniuSecundar( meniuSecundar);
                  //      MessageBox.Show("aaaaaaaaaaaaaaaa");
                        
                        break;
                    case ("VENITURI / INCASARI"):
                        if (Application.OpenForms.OfType<venituri_incasari>().Any())
                        {
                            Application.OpenForms.OfType<venituri_incasari>().First().BringToFront();
                        }
                        else
                            //     MessageBox.Show("ooooooooooo");
                            DeschidePanelMama(new venituri_incasari(this.denumireAsociatie, this.idAsociatie));
                   //     PopulareMeniuSecundar(meniuSecundar1);
                        break;
                    case ("CHELTUIELI / PLATI"):
                        if (Application.OpenForms.OfType<cheltuieli_plati>().Any())
                        {
                            Application.OpenForms.OfType<cheltuieli_plati>().First().BringToFront();
                        }
                        else
                            //       MessageBox.Show("ooooooooooo");
                            DeschidePanelMama(new cheltuieli_plati(this.denumireAsociatie, this.idAsociatie));
                    //    PopulareMeniuSecundar(meniuSecundar2);
                        break;
                    case ("INCHIDE APLICATIA"):
                        //       MessageBox.Show("ooooooooooo");
                        //DeschidePanelMama(new cheltuieli_plati());
                        //PopulareMeniuSecundar(meniuSecundar2);
                        this.Close();
                        break;
                    case ("structura asociatie"):
                        //       MessageBox.Show("ooooooooooo");
                        Form Structura_asociatie_definire  =new Structura_asociatie_definire();
                        Structura_asociatie_definire.Show();
                        //PopulareMeniuSecundar(meniuSecundar2);
                      
                        break;
                       
                        // ...
                        // ...
                }
            }

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
