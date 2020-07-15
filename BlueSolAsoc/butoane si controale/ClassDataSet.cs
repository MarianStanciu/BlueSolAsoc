using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

        public object ReturnareValoare(string query)
        {
            ClassConexiuneServer.DeschideConexiunea();
            SqlConnection cnn = ClassConexiuneServer.GetConnection();
            SqlCommand command;
            command = new SqlCommand(query, cnn);
            var scalar = command.ExecuteScalar();           
            return scalar;
        }
        public int TransmiteActualizari(string sTabelLucru)
        {
            return TransmiteActualizari(sTabelLucru, sTabelLucru);
        }
        public int TransmiteActualizari (string sTabelLucru, string sSursa)
        {
            Inserare(sTabelLucru,sSursa);
            Actualizare(sTabelLucru, sSursa);
            Stergere(sTabelLucru, sSursa);
            return 0;
        }
        public DataColumnCollection StructuraColoane(string sTabelLucru)
        {
            DataColumnCollection coloane = this.Tables[sTabelLucru].Columns;
            return coloane;
        }
        //metoda pentru inserare
        public int Inserare(string sTabelLucru,string sSursa)
        {          
            DataRow[] adaugate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Added);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            if (adaugate.Length > 0)
            {


                string inserare = "insert into " + sSursa + " (";
                for (int i = 0; i < dc.Count; i++)
                {
                    if (i == 0)
                    {
                        inserare = inserare + "["+dc[i].ColumnName+"]";
                    }
                    else
                    {
                        inserare = inserare + "," +"[" + dc[i].ColumnName + "]";
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
                                if (string.IsNullOrEmpty(valoare))
                                {
                                    valoare = "0";
                                }
                                break;
                            case "System.Guid":
                                valoare = "'"+r[f.ColumnName].ToString()+"'";
                                if (string.IsNullOrEmpty(valoare))
                                {
                                    valoare = "";
                                }
                                break;
                            case "System.DateTime":                              
                                valoare = "'" + ((DateTime)r[f.ColumnName]).ToString("yyyyMMdd") + "'";
                                if (string.IsNullOrEmpty(valoare))
                                {
                                    valoare = "01011900";
                                }
                                break;

                            case "System.Decimal":                       
                                valoare = ((System.Decimal)r[f.ColumnName]).ToString();
                                if (string.IsNullOrEmpty(valoare))
                                {
                                    valoare = "0";
                                }
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
                ClassConexiuneServer.DeschideConexiunea();
                SqlConnection connection = ClassConexiuneServer.GetConnection();

                SqlCommand command = new SqlCommand(inserare, connection);

                command.ExecuteNonQuery();
            }
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
        public int Actualizare(string sTabelLucru, string sSursa)
         {         
            DataRow[] modificate = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.ModifiedCurrent);         
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            if (modificate.Length > 0)
            {
                string actualizare = "Update  " + sSursa + " set ";
                for (int k = 0; k < modificate.Length; k++)
                {

                    for (int i = 1; i < dc.Count; i++)
                    {
                        actualizare = actualizare + "["+dc[i].ColumnName+"]" + "=";


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
                                valoare = "'" + r[f.ColumnName].ToString().Trim() + "'";
                                break;
                            case "System.Int32":
                                valoare = r[f.ColumnName].ToString().Trim();
                                break;
                            case "System.DateTime":
                                valoare = "'" + ((DateTime) r[f.ColumnName]).ToString("yyyyMMdd") + "'";
                                break;
                            case "System.Decimal":
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
                    actualizare = actualizare + " where "+"["+dc[0].ColumnName+"] ="+ modificate[k][dc[0].ColumnName].ToString();
                    if (k < modificate.Length - 1)
                    {
                        actualizare = actualizare + " Update  " + sSursa + " set ";
                    }

                }
                ClassConexiuneServer.DeschideConexiunea();
                SqlConnection connection = ClassConexiuneServer.GetConnection();
                SqlCommand command = new SqlCommand(actualizare, connection);
                command.ExecuteNonQuery();
            }
            return modificate.Length;
          
        }
        public int Stergere(string sTabelLucru, string sSursa)
        {
            DataRow[] sterse = this.Tables[sTabelLucru].Select(null, null, DataViewRowState.Deleted);
            DataColumnCollection dc = this.StructuraColoane(sTabelLucru);
            if (sterse.Length > 0)
            {
                string stergere = " delete  from " + sSursa + " where ";

                for (int k = 0; k < sterse.Length; k++)
                {
                    DataRow r = sterse[k];

                    DataColumn f = dc[0];
                    string valoare = r[0, DataRowVersion.Original].ToString();
                    stergere = stergere + dc[0].ColumnName + "=" + valoare;
                    if (k < sterse.Length - 1)
                    {
                        stergere = stergere + " delete  from " + sSursa + " where ";
                    }
                }
                ClassConexiuneServer.DeschideConexiunea();
                SqlConnection connection = ClassConexiuneServer.GetConnection();
                SqlCommand command = new SqlCommand(stergere, connection);
                //connection.Open();
                command.ExecuteNonQuery();
            }
            return sterse.Length;
        }
    }
}
