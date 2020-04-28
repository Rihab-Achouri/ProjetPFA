using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Mission
    {
        public int Num { get; set; }
        public string Etat { get; set; }
        public string Département { get; set; }
        public DateTime Début_traitement { get; set; }
        public DateTime Date_cloture { get; set; }
        public string Description { get; set; }
    }
}
