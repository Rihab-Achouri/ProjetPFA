using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BEL
{
    class personnelDAO
    {

        public static bool Insert_personnel(int id, string nom, string prenom, int tel, string adresse_mail, string post)
        {
            string requete = String.Format("insert into personnel (ID, nom,prenom,tel, adresse_mail, post)" +
                " values ('{0}','{1}','{2}','{3}','{4}',{5}');", id, nom, prenom, tel, adresse_mail, post);
            return utils.miseajour(requete);
        }

        public static bool Update_personnel(int id, string nom, string prenom, int tel, string adresse_mail, string post)
        {
            string requete = String.Format("update personnel set nom='{0}', prenom='{1}'," +
                " tel='{2}', adresse_mail='{3}', post='{4}' where ID={5};", nom, prenom, tel, adresse_mail, post, id);
            return utils.miseajour(requete);
        }

        public static bool Delete_personnel(int id)
        {
            string requete = String.Format("delete from personnel where ID={0};", id);
            return utils.miseajour(requete);
        }

        public static personnel Get_personnel_ID(int id)
        {
            string requete = String.Format("select * from personnel where ID={0};", id);
            OleDbDataReader rd = utils.lire(requete);
            personnel c = new personnel();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.ID = rd.GetInt32(0);
                    c.prenom = rd.GetString(1);
                    c.nom = rd.GetString(2);
                    c.tel = rd.GetInt32(3);
                    c.adresse_mail = rd.GetString(4);
                    c.post = rd.GetString(5);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<personnel> Get_personnel()
        {
            string requete = String.Format("select * from personnel;");
            OleDbDataReader rd = utils.lire(requete);
            List<personnel> L = new List<personnel>();
            personnel c;
            while (rd.Read())
            {
                c = new personnel
                {
                    ID = rd.GetInt32(0),
                    nom = rd.GetString(1),
                    prenom = rd.GetString(2),
                    tel = rd.GetInt32(3),
                    adresse_mail = rd.GetString(4),
                    post = rd.GetString(5),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}
