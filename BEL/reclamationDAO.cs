using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BEL
{
    public class reclamationDAO
    {

        public static bool Insert_reclamation_client(int num, string sujet, string departement, int id_client, int ref_prod, DateTime date_ouverture)
        {
            string requete = String.Format("insert into reclamation (num, sujet, departement, client, prod, decision, date_ouverture)" +
                " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", num, sujet, departement, id_client, ref_prod,"Non traitée", date_ouverture);
            return utils.miseajour(requete);
        }

        public static bool Update_reclamation_client(int num, string sujet, string departement, int id_client, int ref_prod,  DateTime date_ouverture)
        {
            string requete = String.Format("update reclamation set sujet='{0}', departemnt='{1}', date_ouverture='{2}'," +
                " where num={3};", sujet, departement, date_ouverture, num);
            return utils.miseajour(requete);
        }

        public static bool Delete_reclamation(int num)
        {
            string requete = String.Format("delete from reclamation where num={0};", num);
            return utils.miseajour(requete);
        }

        public static reclamation Get_reclamation_num(int num)
        {
            string requete = String.Format("select * from reclamation where num={0};", num);
            OleDbDataReader rd = utils.lire(requete);
            reclamation c = new reclamation();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.num = rd.GetInt32(0);
                    c.sujet = rd.GetString(1);
                    c.departement = rd.GetString(2);
                    c.id_client = rd.GetInt32(3);
                    c.ref_prod = rd.GetInt32(4);
                    c.decision = rd.GetString(5);
                    c.date_ouverture = rd.GetDateTime(6);
                    c.date_ouverture = rd.GetDateTime(7);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<reclamation> Get_reclamation()
        {
            string requete = String.Format("select * from reclamation;");
            OleDbDataReader rd = utils.lire(requete);
            List<reclamation> L = new List<reclamation>();
            reclamation c;
            while (rd.Read())
            {
                c = new reclamation
                {
                    num = rd.GetInt32(0),
                    sujet = rd.GetString(1),
                    departement = rd.GetString(2),
                    id_client = rd.GetInt32(3),
                    ref_prod = rd.GetInt32(4),
                    decision = rd.GetString(5),
                    date_ouverture = rd.GetDateTime(6),
                    date_cloture = rd.GetDateTime(7),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
        public static List<reclamation> Get_reclamation_non_traitée()
        {
            string requete = String.Format("select * from reclamation  where decision=='Non traitée';");
            OleDbDataReader rd = utils.lire(requete);
            List<reclamation> L = new List<reclamation>();
            reclamation c;
            while (rd.Read())
            {
                c = new reclamation
                {
                    num = rd.GetInt32(0),
                    sujet = rd.GetString(1),
                    departement = rd.GetString(2),
                    id_client = rd.GetInt32(3),
                    ref_prod = rd.GetInt32(4),
                    decision = rd.GetString(5),
                    date_ouverture = rd.GetDateTime(6),
                    date_cloture = rd.GetDateTime(7),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}


