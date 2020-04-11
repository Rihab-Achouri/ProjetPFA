using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class produit
    {
        public int reference { get; set; }
        public int qt_stock { get; set; }
        public int qt_vendue { get; set; }
        public DateTime date_de_vente { get; set; }
    }
}
