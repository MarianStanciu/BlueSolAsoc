using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc
{
    public partial class LoginForm : FormBluebit
    {
        public LoginForm()
        {
            InitializeComponent();
            sirconbox.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            //Se verifica daca stringul de conectare exista in "app.config"
            if (ConfigurationManager.AppSettings["String_Conectare_Key"] != null)
            {
                try
                {
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    string connectionString;
                   /* if (sirconbox.Text == "")
                    {
                        MessageBox.Show("Completeaza stringul de conectare");
                    }
                    else
                    {*/
                        SqlConnection cnn;
                        connectionString = ConfigurationManager.AppSettings["String_Conectare_Key"];
                        //connectionString = @"Data Source=82.208.137.149\sqlexpress,8833;Initial Catalog=proba_transare;Persist Security Info=True;User ID=sa;Password=pro";
                        cnn = new SqlConnection(connectionString);

                        cnn.Open();

                        string sql = "Select utilizator,parola from Tabel_Utilizatori where utilizator = '" + utilizatorbox.Text + "' and parola ='" + parolabox.Text + "'";


                        command = new SqlCommand(sql, cnn);



                        String strResult = String.Empty;
                        // int length = strResult.Length;
                        strResult = (String)command.ExecuteScalar();

                        if (strResult == null)
                        {

                            MessageBox.Show("Date incorecte");

                        }
                        else
                        {
                            MessageBox.Show("Te-ai logat");
                        
                        this.Hide();
                            var SelectieAsociatie = new SelectieAsociatie();
                            SelectieAsociatie.Show();


                        }


                        command.Dispose();




                        cnn.Close();
                    /*}*/
                }
                catch (SqlException)
                {
                    MessageBox.Show("Nu ai conexiune la internet");
                }


            }
            else
            {
                MessageBox.Show("Stringul de conectare nu a fost gasit, completeaza-l acum");
                sirconbox.Visible = true;
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Add("String_Conectare_Key", sirconbox.Text);
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void butonsircon_Click(object sender, EventArgs e)
        {
            if (sirconbox.Visible == false)
            {
                sirconbox.Visible = true;
            }
            else
            {
                sirconbox.Visible = false;
            }
        }
    }
}
