using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using BEL;

namespace DAL
{
    public class PersonnelDAO
    {

        public static bool Insert_personnel(int id, string nom, string prenom, int tel, string adresse_mail, string poste)
        {
            string requete = String.Format("insert into personnel (ID, nom,prenom,tel, adresse_mail, post)" +
                " values ('{0}','{1}','{2}','{3}','{4}',{5}');", id, nom, prenom, tel, adresse_mail, poste);
            return utils.miseajour(requete);
        }

        public static bool Update_personnel(int id, string nom, string prenom, int tel, string adresse_mail, string poste)
        {
            string requete = String.Format("update personnel set nom='{0}', prenom='{1}'," +
                " tel='{2}', adresse_mail='{3}', post='{4}' where ID={5};", nom, prenom, tel, adresse_mail, poste, id);
            return utils.miseajour(requete);
        }

        public static bool Delete_personnel(int id)
        {
            string requete = String.Format("delete from personnel where ID={0};", id);
            return utils.miseajour(requete);
        }

        public static Personnel Get_personnel_ID(int id)
        {
            string requete = String.Format("select * from personnel where ID={0};", id);
            OleDbDataReader rd = utils.lire(requete);
            Personnel c = new Personnel();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    c.ID = rd.GetInt32(0);
                    c.Prenom = rd.GetString(1);
                    c.Nom = rd.GetString(2);
                    c.Tel = rd.GetInt32(3);
                    c.Adresse_mail = rd.GetString(4);
                    c.Poste = rd.GetString(5);
                }

            }
            utils.Disconnect();
            return c;
        }

        public static List<Personnel> Get_personnel()
        {
            string requete = String.Format("select * from personnel;");
            OleDbDataReader rd = utils.lire(requete);
            List<Personnel> L = new List<Personnel>();
            Personnel c;
            while (rd.Read())
            {
                c = new Personnel
                {
                    ID = rd.GetInt32(0),
                    Nom = rd.GetString(1),
                    Prenom = rd.GetString(2),
                    Tel = rd.GetInt32(3),
                    Adresse_mail = rd.GetString(4),
                    Poste = rd.GetString(5),
                };
                L.Add(c);
            }
            utils.Disconnect();
            return L;

        }
    }
}
