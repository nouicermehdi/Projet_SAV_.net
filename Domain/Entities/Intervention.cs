using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Intervention
    {
        [Key]
        public int Id{ get; set; }
        public string Description { get; set; }
        public string des { get; set; }

        public DateTime? date { get; set; }
        public string? technicien { get; set; }
        public string? client { get; set; }

        public string statut { get; set; }
        public bool? EstSousGarantie { get; set; }

        public string? titre { get; set; }



    }
}
