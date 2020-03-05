using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.butoane_si_controale
{
    public static class ClassConexiuneServer
    {
        private static SqlConnection con = null;
        private static string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";

        public static void ConectareDedicata()
        {
            
        

            con = new SqlConnection(sirConectare );
            // con.Open();
        }
        public static Boolean setStringConectare (string sir)
        {
            sirConectare = sir;
            return true;
        }
        public static SqlConnection GetConnection()
        {
            return con;
        }

        public static SqlDataReader sqlDataReader(string QuerySql)
        {
            SqlDataReader dr = null;

            SqlCommand cmd = new SqlCommand(QuerySql,con );
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dr;

        }

    }
}
