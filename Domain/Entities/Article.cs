namespace Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateAchat { get; set; }

        public float Prix { get; set; }

        public int GarantieEnMois { get; set; }

        public bool SousGarantie()
        {
            var dateActuelle = DateTime.Now;

            var dateLimiteGarantie = DateAchat.AddMonths(GarantieEnMois);

            return dateActuelle <= dateLimiteGarantie;

        }
        public ICollection<Intervention> Interventions { get; set; }


    }
}