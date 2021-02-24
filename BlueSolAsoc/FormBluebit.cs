using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc
{
    public partial class FormBluebit : Form
    {
        public bool documentActiv;
        public bool lunaValidata = false;
        public bool GetDocActiv()
        {
            return documentActiv;
        }
        public bool SetDocActiv(bool a)
        {
            return documentActiv = a;
        }

        public FormBluebit()
        {
            InitializeComponent();           

        }

        public bool LunaValidata(int idAsociatie)
        {
            //ClassConexiuneServer.ConectareDedicata();
            //SqlConnection cnn = ClassConexiuneServer.GetConnection();
            //ClassConexiuneServer.DeschideConexiunea();
            string sqlCerere = " ";
           object Scalar= ClassConexiuneServer.getScalar(sqlCerere);
            if (Scalar!=null)
            {
                return true;
            }
            else return false;
        }




}
}
