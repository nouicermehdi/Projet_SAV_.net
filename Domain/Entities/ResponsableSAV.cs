using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ResponsableSAV
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public ICollection<Reclamation> Reclamations { get; set; }
        public ICollection<Intervention> Interventions { get; set; }

    }
}
