using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueSolAsoc.butoane_si_controale
{
    class ClassDataSet : DataSet
    {
        //primire instructiune sql  - si daca returneaza valoare - sa adauge o tabela cu denumirea pe care o folosim
        // trimiterea instructiunii
        public void getSetFrom(String sSQL, String sNumeTabel)
        {
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            ClassConexiuneServer.DeschideConexiunea();
            //connection.Open();

            SqlCommand command = new SqlCommand(sSQL, connection);
            DataTable tabelLucru = new DataTable(sNumeTabel);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(tabelLucru);
            this.Tables.Add(tabelLucru);


        }
       

        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = this.Tables[sTabelLucru].Columns;
            return coloane;
        }
        //metoda pentru inserare
        public int Inserare(string sTabelLucru)
        {

            DataRow[] adaugate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Added);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string inserare = "insert into " + sTabelLucru + " (";
            for (int i = 0; i < dc.Count; i++)
            {
                if (i == 0)
                {
                    inserare = inserare + dc[i].ColumnName;
                }
                else
                {
                    inserare = inserare + "," + dc[i].ColumnName;
                }
            }
            inserare = inserare + " ) values ";

            for (int k = 0; k < adaugate.Length; k++)
            {
                DataRow r = (DataRow)adaugate[k];
                string linie = "";
                foreach (DataColumn f in dc)
                {
                    string tip = f.DataType.ToString();
                    string valoare = "";
                    switch (f.DataType.ToString())

                    {
                        case "System.String":
                            valoare = "'" + r[f.ColumnName].ToString() + "'";
                            break;
                        case "System.Int32":
                            valoare = r[f.ColumnName].ToString();
                            break;
                        default:
                            break;
                    }
                    if (string.IsNullOrEmpty(linie))
                    {
                        linie = linie + valoare;
                    }
                    else
                    {
                        linie = linie + "," + valoare;
                    }
                }
                if (k == 0)
                {
                    inserare = inserare + " (" + linie + " )";
                }
                else
                {
                    inserare = inserare + " ,(" + linie + " )";
                }
            }
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(inserare, connection);
            connection.Open();
            command.ExecuteNonQuery();
            return adaugate.Length;
        }

        public int ExecutaComenzi (string sNumeProcedura)
        {
            ClassConexiuneServer.DeschideConexiunea();
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            SqlCommand command = new SqlCommand(sNumeProcedura, connection);      
            command.ExecuteNonQuery();
            return 0;
        }

        //metoda pentru actalizare 
        public int Actualizare(string sTabelLucru)
         {         
            DataRow[] modificate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.ModifiedCurrent);         
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string actualizare = "Update  " + sTabelLucru + " set ";
            for (int k = 0; k < modificate.Length; k++)
            {
                
                for (int i = 1; i < dc.Count; i++)
                {
                    actualizare = actualizare + dc[i].ColumnName + "=";
                  
                
                        DataRow r = (DataRow)modificate[k];
                        string linie = "";
                        //foreach (DataColumn f in dc)
                        //{
                        DataColumn f = dc[i];
                        string tip = f.DataType.ToString();
                        string valoare = "";
                        switch (f.DataType.ToString())

                        {
                            case "System.String":
                                valoare = "'" + r[f.ColumnName].ToString() + "'";
                                break;
                            case "System.Int32":
                                valoare = r[f.ColumnName].ToString();
                                break;
                            default:
                                break;
                        } 
                        if (string.IsNullOrEmpty(linie))
                        {
                            linie = linie + valoare;
                        }
                        else
                        {
                            linie = linie + "," + valoare;
                        }
                        if (i < dc.Count - 1)
                        {

                            actualizare = actualizare + linie + " ,";
                        }
                        if (i == dc.Count - 1)
                        {
                            actualizare = actualizare + linie;
                        }

                    }
                actualizare = actualizare + " where id=" + modificate[k][dc[0].ColumnName].ToString();
                if (k < modificate.Length-1)
                {
                    actualizare = actualizare + " Update  " + sTabelLucru + " set ";
                }

            }
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(actualizare, connection);
            connection.Open();
            command.ExecuteNonQuery();
            return actualizare.Length;
          
        }
        public int Stergere(string sTabelLucru)
        {
            DataRow[] sterse = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Deleted);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            string stergere = " delete  from " + sTabelLucru + " where ";

            for (int k = 0; k < sterse.Length; k++)
            {
                DataRow r = sterse[k];

                DataColumn f = dc[0];
                string valoare = r[0, DataRowVersion.Original].ToString();
                stergere = stergere + dc[0].ColumnName + "=" + valoare;
                if (k < sterse.Length - 1)
                {
                    stergere = stergere + " delete  from " + sTabelLucru + " where ";
                }
            }
            SqlConnection connection = ClassConexiuneServer.GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(stergere, connection);
            connection.Open();
            command.ExecuteNonQuery();
            return sterse.Length;
        }
    }
}
