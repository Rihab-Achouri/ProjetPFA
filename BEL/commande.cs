using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Commande
    {
        public int Num_commande { get; set; }
        public int ID_cl { get; set; }
        public int Reference_produit { get; set; }
        public int Qt { get; set; }
        public int Prix { get; set; }
        public DateTime Date_commande { get; set; }
        public DateTime Date_livraison_réel { get; set; }
        public DateTime Date_livraison_souhaité { get; set; }
    }
}
