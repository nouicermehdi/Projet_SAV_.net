using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateAchat { get; set; }

        public double Prix { get; set; }


        public int GarantieEnMois { get; set; }

        public bool SousGarantie()
        {
            var dateActuelle = DateTime.Now;

            var dateLimiteGarantie = DateAchat.AddMonths(GarantieEnMois);

            return dateActuelle <= dateLimiteGarantie;

        }


    }
}