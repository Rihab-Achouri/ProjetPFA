using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace DAL
{
    public static class utils
    {

            public static OleDbConnection cn;
            public static OleDbCommand cmd;
            public static OleDbDataReader rd;
            public static OleDbDataAdapter oledbAdapter;


            public static void Connect()
            {
                string cnstr = "provider = Microsoft.JET.OLEDB.4.0;" +
                    "Data Source =C:\\Users\\p\\Downloads\\Reclamation_Client.accdb;";
                cn = new OleDbConnection(cnstr);
                cn.Open();
            }
            public static string Connect1()
            {
                string cnstr = "provider = Microsoft.JET.OLEDB.4.0;" +
                    "Data Source =C:\\Users\\p\\Downloads\\Reclamation_Client.accdb;";
                return cnstr;
            }




            public static OleDbDataReader lire(string req)
            {
                Connect();
                cmd = new OleDbCommand(req, cn);
                rd = cmd.ExecuteReader();
                return rd;
            }

            public static bool miseajour(string req)
            {
                Connect();
                cmd = new OleDbCommand(req, cn);
                int nbaffected = cmd.ExecuteNonQuery();
                Disconnect();
                if (nbaffected != 0)
                    return true;
                else
                    return false;
            }

            public static void Disconnect()
            {
                cn.Close();
                cn.Dispose();
            }
        
    }

}

