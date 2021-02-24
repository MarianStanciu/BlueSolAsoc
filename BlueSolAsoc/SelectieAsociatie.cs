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
            ClassConexiuneServer.ConectareDedicata();
            
        }

        private void SelectieAsociatie_Load(object sender, EventArgs e)
        {

            PopulareMeniuAsociatii();
        }
        // List<String> meniuAsociatii = new List<String>();
        
       //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BlueBit");

        public void PopulareMeniuAsociatii()
        {


            //SqlConnection connection = new SqlConnection(@"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = colectie_asoc; Persist Security Info = True; User ID = sa; Password = pro");
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            
            string query = "select id_asociere,valoare from dbo.tabela_organizatii where id_asociere=1";
            SqlCommand command = new SqlCommand(query, connection);
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int nRows = ds.Tables[0].Rows.Count+1;
           
            var rowCount = 2;
            var columnCount = nRows / rowCount;
            if (nRows % 2 != 0)
            {
                columnCount = columnCount + 1; // 1 - butonul de plus

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

            {
                var b = new ClassButonSelectieAsoc();
                b.Name = string.Format("bplus");
                b.Image = Properties.Resources.iconfinder_Artboard_26_3741736;
                b.Click += ApasareButon;
                b.Dock = DockStyle.Fill;
                TablePanelSelectAsoc.Controls.Add(b);
            }

            foreach (DataRow row in  ds.Tables[0].Rows)
            {
                var b = new ClassButonSelectieAsoc();
                b.Click += ApasareButon;
                b.Dock = DockStyle.Fill;
                b.Text = row["valoare"].ToString();
                b.Tag = row["id_asociere"];
               // b.Tag = reader.GetInt16(reader.GetOrdinal("id"));
                this.TablePanelSelectAsoc.Controls.Add(b);

            }
/*            if (nRows >= 8)
            {
                columnCount = columnCount + 1;
            }*/
            
            
            this.TablePanelSelectAsoc.Refresh();
            
            connection.Close();
            command.Dispose();
          
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
                    using (SqlConnection connection = new SqlConnection(@"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = colectie_asoc; Persist Security Info = True; User ID = sa; Password = pro"))
                    {
                        connection.Open();
                        string query = "select id_org from dbo.tabela_organizatii where valoare='" + b.Text + "'";
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

    

