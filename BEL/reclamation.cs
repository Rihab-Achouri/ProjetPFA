using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class reclamation
    {
        public int num { get; set; }
        public string sujet { get; set; }
        public string departement { get; set; }
        public int id_client { get; set; }
        public int ref_prod { get; set; }
        public string decision { get; set; }
        public DateTime date_ouverture { get; set; }
        public DateTime date_cloture { get; set; }
    }
}
