using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Reclamation
    {
        public int Num { get; set; }
        public string Sujet { get; set; }
        public string Departement { get; set; }
        public int Id_client { get; set; }
        public int Ref_prod { get; set; }
        public string Decision { get; set; }
        public DateTime Date_ouverture { get; set; }
        public DateTime Date_cloture { get; set; }
        public string Etat_reclamation { get; set; }
    }
}
