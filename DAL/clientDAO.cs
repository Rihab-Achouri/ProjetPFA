using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using BEL;

namespace DAL
{
    public class ClientDAO
    {

        public static bool Insert_client(int id, string nom, string prenom, int tel, string adresse_mail)
        {
            string requete = String.Format("insert into client (ID_cl, nom_cl,prenom_cl,tel, adresse_mail_cl)" +
                " values ('{0}','{1}','{2}','{3}','{4}');", id, nom, prenom, tel, adresse_mail);
            return utils.miseajour(requete);
        }

        public static bool Update_client(int id, string nom, string prenom, int tel, string adresse_mail)
        {
            string requete = String.Format("update client set nom_cl='{0}', prenom_cl='{1}'," +
                " tel_cl='{2}', adresse_mail_cl='{3}' where ID_cl={4};", nom, prenom, tel, adresse_mail, id);
            return utils.miseajour(requete);
        }

        public static bool Delete_client(int id)
        {
            string requete = String.Format("delete from client where ID_cl={0};", id);
            return utils.miseajour(requete);
        }

        public static Client Get_client_ID(int id)
        {
            string requete = String.Format("select * from client where ID_cl={0};", id);
            OleDbDataReader rd = utils.lire(requete);
            Client c = new Client();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.ID_cl = rd.GetInt32(0);
                    c.Prenom_cl = rd.GetString(1);
                    c.Nom_cl = rd.GetString(2);
                    c.Tel_cl = rd.GetInt32(3);
                    c.Adresse_mail_cl = rd.GetString(4);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Client> Get_client()
        {
            string requete = String.Format("select * from client;");
            OleDbDataReader rd = utils.lire(requete);
            List<Client> L = new List<Client>();
            Client c;
            while (rd.Read())
            {
                c = new Client
                {
                    ID_cl = rd.GetInt32(0),
                    Nom_cl = rd.GetString(1),
                    Prenom_cl = rd.GetString(2),
                    Tel_cl = rd.GetInt32(3),
                    Adresse_mail_cl = rd.GetString(4),
                    
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}
