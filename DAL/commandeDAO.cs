﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using System.Data.OleDb;

namespace DAL
{
    public class commandeDAO
    {
        public static bool passer_commande(int id, int reference_produit, int qt, int prix, DateTime date_1, DateTime date_2, DateTime date_3)
        {
            //num_commande=+1 et prix = qt* prix_unitaire
            string requete = String.Format("insert into commande (num_commande, ID_cl, reference_produit, qt, prix, date_commande, date_livraison_réel, date_livraison_souhaité)" +
                " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", id, reference_produit, qt, prix, date_1, date_2, date_3);
            return utils.miseajour(requete);
        }

        public static bool Update_commande(int id, int reference_produit, int qt, int prix, DateTime date_1, DateTime date_2, DateTime date_3)
        {
            string requete = String.Format("update commande set reference_produit='{0}', qt='{1}',prix ='{2}',date_commande ='{3}'," +
                " date_livraison_réel='{4}', date_livraison_souhaité ='{5}' where ID_cl={6};", reference_produit, qt, prix, date_1, date_2, date_3, id);
            return utils.miseajour(requete);
        }

        public static bool Delete_commande(int rf)
        {
            string requete = String.Format("delete from commande where num_commande={0};", rf);
            return utils.miseajour(requete);
        }

        public static commande Get_commande_ID(int rf)
        {
            string requete = String.Format("select * from commande where num_commande={0};", rf);
            OleDbDataReader rd = utils.lire(requete);
            commande c = new commande();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.num_commande = rd.GetInt32(0);
                    c.ID_cl = rd.GetInt32(1);
                    c.reference_produit = rd.GetInt32(2);
                    c.qt = rd.GetInt32(3);
                    c.prix = rd.GetInt32(4);
                    c.date_commande = rd.GetDateTime(5);
                    c.date_livraison_réel = rd.GetDateTime(6);
                    c.date_livraison_souhaité = rd.GetDateTime(7);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<commande> Get_commande()
        {
            string requete = String.Format("select * from commande;");
            OleDbDataReader rd = utils.lire(requete);
            List<commande> L = new List<commande>();
            commande c;
            while (rd.Read())
            {
                c = new commande
                {
                    num_commande= rd.GetInt32(0),
                    ID_cl = rd.GetInt32(1),
                    reference_produit = rd.GetInt32(2),
                    qt = rd.GetInt32(3),
                    prix = rd.GetInt32(4),
                    date_commande = rd.GetDateTime(5),
                    date_livraison_réel = rd.GetDateTime(6),
                    date_livraison_souhaité = rd.GetDateTime(7),

                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;
        }
    }
}
