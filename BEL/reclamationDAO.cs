using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BEL
{
    class reclamationDAO
    {

        public static bool Insert_produit(int RF, int qt1, int qt2, DateTime date_de_vente)
        {
            string requete = String.Format("insert into reclamation (reference, qt_stock,qt_vendue,date_de_vente)" +
                " values ('{0}','{1}','{2}','{3}','{4}',{5}');", RF, qt1, qt2, date_de_vente);
            return utils.miseajour(requete);
        }

        public static bool Update_reclamation(int RF, int qt1, int qt2, DateTime date_de_vente)
        {
            string requete = String.Format("update reclamation set qt_stock='{0}', qt_vendue='{1}'," +
                " date_de_vente='{2}' where ID={5};", qt1, qt2, date_de_vente, RF);
            return utils.miseajour(requete);
        }

        public static bool Delete_reclamation(int RF)
        {
            string requete = String.Format("delete from produit where reference={0};", RF);
            return utils.miseajour(requete);
        }

        public static produit Get_produit_reference(int RF)
        {
            string requete = String.Format("select * from produit where reference={0};", RF);
            OleDbDataReader rd = utils.lire(requete);
            produit c = new produit();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.reference = rd.GetInt32(0);
                    c.qt_stock = rd.GetInt32(1);
                    c.qt_vendue = rd.GetInt32(2);
                    c.date_de_vente = rd.GetDateTime(3);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<produit> Get_produit()
        {
            string requete = String.Format("select * from produit;");
            OleDbDataReader rd = utils.lire(requete);
            List<produit> L = new List<produit>();
            produit c;
            while (rd.Read())
            {
                c = new produit
                {
                    reference = rd.GetInt32(0),
                    qt_stock = rd.GetInt32(1),
                    qt_vendue = rd.GetInt32(2),
                    date_de_vente = rd.GetDateTime(3),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}


