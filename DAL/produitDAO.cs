using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using BEL;

namespace DAL
{
    public class ProduitDAO
    {

        public static bool Insert_produit(int RF, int qt, int prix)
        {
            string requete = String.Format("insert into produit (reference, qt_stock,prix_unitaire)" +
                " values ('{0}','{1}','{2}');",RF, qt , prix);
            return utils.miseajour(requete);
        }

        public static bool Update_produitl(int RF, int qt, int prix)
        {
            string requete = String.Format("update produit set qt_stock='{0}', prix_unitaire='{1}'," +
                " where reference={3};", qt, prix, RF);
            return utils.miseajour(requete);
        }

        public static bool Delete_produit(int RF)
        {
            string requete = String.Format("delete from produit where reference={0};", RF);
            return utils.miseajour(requete);
        }

        public static Produit Get_produit_reference(int RF)
        {
            string requete = String.Format("select * from produit where reference={0};", RF);
            OleDbDataReader rd = utils.lire(requete);
            Produit c = new Produit();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.Reference = rd.GetInt32(0);
                    c.Qt_stock = rd.GetInt32(1);
                    c.Prix_unitaire = rd.GetInt32(2);
                    
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Produit> Get_produit()
        {
            string requete = String.Format("select * from produit;");
            OleDbDataReader rd = utils.lire(requete);
            List<Produit> L = new List<Produit>();
            Produit c;
            while (rd.Read())
            {
                c = new Produit
                {
                    Reference= rd.GetInt32(0),
                    Qt_stock = rd.GetInt32(1),
                    Prix_unitaire = rd.GetInt32(2),
                    
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}

