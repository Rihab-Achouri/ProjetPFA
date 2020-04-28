using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using BEL;

namespace DAL
{
    public class MissionDAO
    {
        public static bool Insert_Mission(int Num, string Etat, string Département, DateTime Début_traitement, DateTime Date_cloture, string Description)
        {
            string requete = String.Format("insert into Mission (Num, Etat, Département, Début_traitement, Date_cloture, Description)" +
                " values ('{0}','{1}','{2}','{3}','{4}','{5}');", Num, Etat, Département, Début_traitement, Date_cloture, Description);
            return utils.miseajour(requete);
        }

        public static bool Update_Mission(int Num, string Etat, string Département, DateTime Début_traitement, DateTime Date_cloture, string Description)
        {
            string requete = String.Format("update Mission set Etat='{0}', Département='{1}'," +
                " Début_traitement='{2}', Date_cloture='{3}', Description='{4}' where Num={5};", Etat, Département, Début_traitement, Date_cloture, Description, Num);
            return utils.miseajour(requete);
        }

        public static bool Delete_Mission(int Num)
        {
            string requete = String.Format("delete from Mission where Num={0};", Num);
            return utils.miseajour(requete);
        }

        public static Mission Get_Mission_Num(int Num)
        {
            string requete = String.Format("select * from Mission where Num={0};", Num);
            OleDbDataReader rd = utils.lire(requete);
            Mission c = new Mission();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.Num = rd.GetInt32(0);
                    c.Etat = rd.GetString(1);
                    c.Département = rd.GetString(2);
                    c.Début_traitement = rd.GetDateTime(3);
                    c.Date_cloture = rd.GetDateTime(4);
                    c.Description = rd.GetString(5);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Mission> Get_Mission_Non_Traitée()
        {
            string requete = String.Format("select * from Mission  where Etat=='Non Traitée';");
            OleDbDataReader rd = utils.lire(requete);
            List<Mission> L = new List<Mission>();
            Mission c;
            while (rd.Read())
            {
                c = new Mission
                {
                    Num = rd.GetInt32(0),
                    Etat = rd.GetString(1),
                    Département = rd.GetString(2),      
                    Début_traitement = rd.GetDateTime(3),
                    Date_cloture = rd.GetDateTime(4),
                    Description = rd.GetString(5),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }

        public static List<Mission> Get_Mission_Cloturée()
        {
            string requete = String.Format("select * from Mission  where Etat=='Cloturée';");
            OleDbDataReader rd = utils.lire(requete);
            List<Mission> L = new List<Mission>();
            Mission c;
            while (rd.Read())
            {
                c = new Mission
                {
                    Num = rd.GetInt32(0),
                    Etat = rd.GetString(1),
                    Département = rd.GetString(2),
                    Début_traitement = rd.GetDateTime(3),
                    Date_cloture = rd.GetDateTime(4),
                    Description = rd.GetString(5),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }

        public static List<Mission> Get_Mission()
        {
            string requete = String.Format("select * from Mission;");
            OleDbDataReader rd = utils.lire(requete);
            List<Mission> L = new List<Mission>();
            Mission c;
            while (rd.Read())
            {
                c = new Mission
                {
                    Num = rd.GetInt32(0),
                    Etat = rd.GetString(1),
                    Département = rd.GetString(2),
                    Début_traitement = rd.GetDateTime(3),
                    Date_cloture = rd.GetDateTime(4),
                    Description = rd.GetString(5),

                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}
