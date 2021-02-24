using Microsoft.Win32;
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
       // private static string sirConectare;
        private static string sirConectare = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = colectie_asoc; Persist Security Info = True; User ID = sa; Password = pro";

        public static void ConectareDedicata()
        {
            
        

            con = new SqlConnection(sirConectare);
            // con.Open();
        }

        public static Boolean DeschideConexiunea()
        {
            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {


                    con.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean setStringConectare (string sir)
        {
            sirConectare = sir;
            return true;
        }
        public static string getStringConectare()
        {
            return sirConectare;
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
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dr;

        }
        public static object getScalar(string QuerySql)
        {
            SqlCommand cmd = new SqlCommand(QuerySql, con);
            object Scalar;
            Scalar = cmd.ExecuteScalar();
            cmd.Dispose();
            return Scalar;
        }

    }
}
