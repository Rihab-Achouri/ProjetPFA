using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class commande
    {
        public int num_commande { get; set; }
        public int ID_cl { get; set; }
        public int reference_produit { get; set; }
        public int qt { get; set; }
        public int prix { get; set; }
        public DateTime date_commande { get; set; }
        public DateTime date_livraison_réel { get; set; }
        public DateTime date_livraison_souhaité { get; set; }
    }
}
