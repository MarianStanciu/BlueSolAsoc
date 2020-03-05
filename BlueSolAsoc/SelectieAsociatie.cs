using BlueSolAsoc.butoane_si_controale;
using Microsoft.Win32;
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
        List<String> meniuAsociatii = new List<String>() { "+" };
        
       //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BlueBit");

        public void PopulareMeniuAsociatii(List<String> meniuAsociatii)
        {
           

            using (SqlConnection connection = new SqlConnection(@"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro"))
            {
                connection.Open();
                string query = "select valoare from dbo.tabela_organizatii where id_tip=1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                            meniuAsociatii.Add(reader.GetString(0));
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }
                connection.Close();
               
            }
           
            var rowCount = 2;
            var columnCount = meniuAsociatii.Count/2;
            if (meniuAsociatii.Count%2 != 0)
            {
                columnCount = columnCount+1;

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
           // List<string> denumiri = (meniuAsociatii);
            int index = 0;
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                var b = new ClassButonSelectieAsoc();
                //  var b = new ButonMeniuPrincipal();

                // for (int z = 0; z < denumiri.Length ; z++)
                if (index < meniuAsociatii.Count)
                {
                    b.Text = meniuAsociatii[index++];
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
            if (b.TabIndex == 0)
            {
                var CreareAsoc = new CreareAsociatie();
                CreareAsoc.Show();
                this.Hide();
            }
            else
            {
                if (!string.IsNullOrEmpty(b.Text))
                {
                    string denumireAsociatieString = b.Text;
                    int id;
                    using (SqlConnection connection = new SqlConnection(@"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro"))
                    {
                        connection.Open();
                        string query = "select id from dbo.tabela_organizatii where valoare='" + b.Text + "'";
                        //"select id from dbo.tabela_organizatii where valoare='asociatia marmota'"
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                reader.Read();

                                id = reader.GetInt32(0);


                                reader.Close();
                            }
                            connection.Close();
                            command.Dispose();
                        }
                    }


                    FormBluebit MeniuForm = new MeniuForm(denumireAsociatieString, id);
                    MeniuForm.Show();


                }
            }

          
        }

        }


    }

    

