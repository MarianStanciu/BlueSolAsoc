using BlueSolAsoc.butoane_si_controale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueSolAsoc.Fom_Meniuri
{
    public partial class cheltuieli_plati : FormBluebit
    {
        //creare dataset pentru formul curent si aducerea variabilelor de nume si id asociatie selectate de utilizator
        ClassDataSet CheltuieliDS = new ClassDataSet();
        private string denumireAsociatie;
        private int idAsociatie;

        public cheltuieli_plati(string denumireAsociatie, int idAsociatie)
        {
            InitializeComponent();
            this.denumireAsociatie = denumireAsociatie;
            this.idAsociatie = idAsociatie;
            DataCurenta.Value = System.DateTime.Now;

        }

       
     

        private void cheltuieli_plati_Load(object sender, EventArgs e)
        {
           AfisareGridFacturi();

        }
        public void AfisareGridFacturi()
        {

            //creare tabel cu istoric facturi
            if (!(CheltuieliDS.Tables["IstoricFacturi"] is null))
            {
                CheltuieliDS.Tables.Remove("IstoricFacturi");
            }
            CheltuieliDS.getSetFrom("select * from mv_IstoricDocumente where id_asociere=44 and id_org=" + idAsociatie , "IstoricFacturi");
            GridFacturi.DataSource = CheltuieliDS.Tables["IstoricFacturi"];
            // GridFacturi.Enabled = false;

            if (!(CheltuieliDS.Tables["mv_tabelParteneri"] is null))
            {
                CheltuieliDS.Tables.Remove("mv_tabelParteneri");
            }
            CheltuieliDS.getSetFrom("select Denumire from mv_tabelParteneri  where  id_master =" + idAsociatie, "mv_tabelParteneri");
            List<string> parteneri = new List<string>(CheltuieliDS.Tables["mv_tabelParteneri"].Rows.Count);
            DataRow[] RowParteneri= CheltuieliDS.Tables["mv_tabelParteneri"].Select(null, null, DataViewRowState.CurrentRows);

            for (int k = 0; k < RowParteneri.Length; k++)
            {
                DataRow r = RowParteneri[k];
                string valoare = r[0, DataRowVersion.Original].ToString();
                parteneri.Add(valoare);
            }
            comboBoxParteneri.DataSource = parteneri;
        }

        

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {

        }
    }
}
