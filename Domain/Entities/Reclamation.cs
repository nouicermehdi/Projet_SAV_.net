using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reclamation
    {
        public int IdReclamation { get; set; }

        public string Titre { get; set; }
        public string Description { get; set; }

        public string Statut { get; set; }

        public DateTime DateCreation { get; set; }

        public int IdTechnicien { get; set; }
        public Technicien Technicien { get; }
        public string IdClient { get; set; }
        public Client Client { get; }





    }
}
