using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassConexiuneServer
    {
        public static SqlConnection con = null;

        public void ConectareDedicata()
        {
            string conexiune;
            SqlConnection con;

            conexiune = @"Data Source = 82.208.137.149\sqlexpress, 8833; Initial Catalog = proba_transare; Persist Security Info = True; User ID = sa; Password = pro";
            con = new SqlConnection(conexiune);
            con.Open();
        }
    }
}
