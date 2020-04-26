using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using System.Data.OleDb;

namespace DAL
{
    public class CommandeDAO
    {
        public static bool passer_commande(int id, int reference_produit, int qt, int prix, DateTime date_1, DateTime date_2)
        {
            string req = String.Format("select max (num_commande) from commande");
            OleDbDataReader rd = utils.lire(req);
            int N = rd.GetInt32(0);
            utils.Disconnect();

            int num = N + 1;
            string requete = String.Format("insert into commande (num_commande, ID_cl, reference_produit, qt, prix, date_commande, date_livraison_souhaité)" +
                " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", num, id, reference_produit, qt, prix, date_1, date_2);
            return utils.miseajour(requete);
        }

        public static bool Update_commande(int num, int reference_produit, int qt, int prix, DateTime date_1, DateTime date_2)
        {
            string requete = String.Format("update commande set reference_produit='{0}', qt='{1}',prix ='{2}',date_commande ='{3}'," +
                " date_livraison_souhaité ='{4}' where num_commande = '{5}';", reference_produit, qt, prix, date_1, date_2, num);
            return utils.miseajour(requete);
        }

        public static bool Delete_commande(int rf)
        {
            string requete = String.Format("delete from commande where num_commande={0};", rf);
            return utils.miseajour(requete);
        }

        public static Commande Get_commande_ID(int rf)
        {
            string requete = String.Format("select * from commande where num_commande={0};", rf);
            OleDbDataReader rd = utils.lire(requete);
            Commande c = new Commande();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.Num_commande = rd.GetInt32(0);
                    c.ID_cl = rd.GetInt32(1);
                    c.Reference_produit = rd.GetInt32(2);
                    c.Qt = rd.GetInt32(3);
                    c.Prix = rd.GetInt32(4);
                    c.Date_commande = rd.GetDateTime(5);
                    c.Date_livraison_réel = rd.GetDateTime(6);
                    c.Date_livraison_souhaité = rd.GetDateTime(7);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Commande> Get_commande()
        {
            string requete = String.Format("select * from commande;");
            OleDbDataReader rd = utils.lire(requete);
            List<Commande> L = new List<Commande>();
            Commande c;
            while (rd.Read())
            {
                c = new Commande
                {
                    Num_commande= rd.GetInt32(0),
                    ID_cl = rd.GetInt32(1),
                    Reference_produit = rd.GetInt32(2),
                    Qt = rd.GetInt32(3),
                    Prix = rd.GetInt32(4),
                    Date_commande = rd.GetDateTime(5),
                    Date_livraison_réel = rd.GetDateTime(6),
                    Date_livraison_souhaité = rd.GetDateTime(7),

                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }
    }
}
