using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reclamation
    {
        [Key]
        public int Id {get; set; }

        public string Titre { get; set; }
        public string Description { get; set; }
        public string client { get; set; }
        public string produit { get; set; }
        public string Statut { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime date { get; set; }





    }
}
