using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Intervention
    {
        public int IdIntervention { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }


        public string technicien { get; set; }
        public Technicien Technicien { get; set; }


        public bool EstSousGarantie { get; set; }



    }
}
