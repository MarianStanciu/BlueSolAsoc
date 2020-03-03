using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc
{
    public partial class SelectieAsociatie : FormBluebit
    {
        public SelectieAsociatie()
        {
            InitializeComponent();
        }

        private void SelectieAsociatie_Load(object sender, EventArgs e)
        {

            PopulareMeniuAsociatii(meniuAsociatii);
        }
        //SqlString SelectieUtilizatori = "Select * from dbo.Tabel_Utilizatori";
        //string[] meniuAsociatii = SelectieUtilizatori.ToString;
        //List<string> meniuAsociatii = new List<string>() { "Asociatie 1", "+", "Gol", "Setari" };
        List<String> meniuAsociatii = new List<String>();


        public void PopulareMeniuAsociatii(List<string> myCollection)
        {
           

            using (SqlConnection connection = new SqlConnection(@"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro"))
            {
                connection.Open();
                string query = "SELECT utilizator FROM dbo.Tabel_Utilizatori";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            meniuAsociatii.Add(reader.GetString(0));
                        }
                    }
                }
            }
            /*  var lungimescadere = 2;
              if (meniuAsociatii.Length == 4)
              {
                  lungimescadere = 2;
              }
              if (meniuAsociatii.Length >= 6)
              {
                  lungimescadere = 3;
              }*/

            var rowCount = 2;
            var columnCount = myCollection.Count/2;
            if (columnCount % 2 != 0)
            {
                columnCount = columnCount + 1;

            }

            this.TablePanelSelectAsoc.ColumnCount = columnCount;
            this.TablePanelSelectAsoc.RowCount = rowCount;


            this.TablePanelSelectAsoc.ColumnStyles.Clear();
            this.TablePanelSelectAsoc.RowStyles.Clear();

            for (int i = 0; i < rowCount; i++)
            {
                this.TablePanelSelectAsoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }
            for (int i = 0; i < columnCount; i++)
            {
                this.TablePanelSelectAsoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));

            }
            List<string> denumiri = (meniuAsociatii);
            int index = 0;
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                var b = new ClassButonSelectieAsoc();
                //  var b = new ButonMeniuPrincipal();

                // for (int z = 0; z < denumiri.Length ; z++)
                if (index < denumiri.Count)
                {
                    b.Text = denumiri[index++];
                }

                b.Name = string.Format("b_{0}", i + 1);
                b.Click += ApasareButon;
                b.Dock = DockStyle.Fill;
                this.TablePanelSelectAsoc.Controls.Add(b);
            }
        }
        // metoda comuna pentru click pe butoane ---------------------------------------------------------------------
        public void ApasareButon(object sender, EventArgs e)
        {
            var b = (ClassButonSelectieAsoc)sender;
            if (b != null)
            {
                switch (b.Text)
                {
                    case ("Asociatie 1"):

                        this.Hide();
                        string dataInFormNou = b.Text;

                        FormBluebit MeniuForm = new MeniuForm(dataInFormNou);
                        MeniuForm.Show();



                        break;


                    case ("+"):

                        meniuAsociatii.Add("Asociatie 2");
         

                        break;
                }
            }

        }


    }
}
    

