using BlueSolAsoc.butoane_si_controale;
using Microsoft.Win32;
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
            button_sircon_ok.Visible = false;
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BlueBit");
            RegistryKey keyConectare = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\BlueBit", true);
            if (keyConectare.GetValue("String_Conectare") == null)
            {

                string SirConDinKey = "Data Source=ip\\sqlexpress,8833;Initial Catalog=baza_date;Persist Security Info=True;User ID=sa;Password=pro";
                keyConectare.SetValue("String_Conectare", SirConDinKey);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

            //Se deschide folderul de key-uri
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BlueBit");
            RegistryKey keyConectare = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\BlueBit", true);

            string connectionString = keyConectare.GetValue("String_Conectare").ToString();


            ClassConexiuneServer.setStringConectare(connectionString);
            ClassConexiuneServer.ConectareDedicata();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            if (!ClassConexiuneServer.DeschideConexiunea())
            {

                MessageBox.Show("Conexiunea nu poate fi realizata");
                sirconbox.Visible = true;
                button_sircon_ok.Visible = true;
                sirconbox.Text = ClassConexiuneServer.getStringConectare();
            }
            else
            {
                string sql = "Select utilizator,parola from Tabel_Utilizatori where utilizator = '" + utilizatorbox.Text + "' and parola ='" + parolabox.Text + "'";
                string StrResult = (String)ClassConexiuneServer.getScalar(sql);
                if (StrResult == null)
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
            }


            keyConectare.Close();

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
        //PENTRU TEST
        private void button_sircon_ok_Click(object sender, EventArgs e)
        {
            RegistryKey keyConectare = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BlueBit");
            keyConectare.SetValue("String_Conectare", sirconbox.Text);
            keyConectare.Close();
            Application.Restart();
        }
    }
}
