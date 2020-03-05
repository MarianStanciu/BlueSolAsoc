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
            
            lblAsociatie_Selectata.Text = denumireAsociatieString + " "+id;
            
        }

        private void MeniuForm_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            PopulareMeniuPrincipal(meniuPrincipal);
        }
        // arrayuri pt butoane======================================================================
        string[] meniuPrincipal = { "Structura Asociatie", "Venituri/incasari", "Cheltuieli/plati", "Inchide Aplicatia" };
        string[] meniuSecundar = { "structura asociatie", "structura cheltuieli", "aaaaaaaa", "bbbbbbbbbbbb" };
        string[] meniuSecundar1 = { "alb", "negru" };
        string[] meniuSecundar2 = { "cheltuieli", "plati" };


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
                    case ("Structura Asociatie"):
                                if (Application.OpenForms.OfType<AsociatieForm>().Any())
                        {
                            Application.OpenForms.OfType<AsociatieForm>().First().BringToFront();
                        }else
                 //       AsociatieForm asociatie = new AsociatieForm();
                 //       asociatie.Show();
                       DeschidePanelMama(new  AsociatieForm());

                 //       PopulareMeniuSecundar( meniuSecundar);
                  //      MessageBox.Show("aaaaaaaaaaaaaaaa");
                        
                        break;
                    case ("Venituri/incasari"):
                   //     MessageBox.Show("ooooooooooo");
                        DeschidePanelMama(new venituri_incasari());
                   //     PopulareMeniuSecundar(meniuSecundar1);
                        break;
                    case ("Cheltuieli/plati"):
                 //       MessageBox.Show("ooooooooooo");
                        DeschidePanelMama(new cheltuieli_plati());
                    //    PopulareMeniuSecundar(meniuSecundar2);
                        break;
                    case ("Inchide Aplicatia"):
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
