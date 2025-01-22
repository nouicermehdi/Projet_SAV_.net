using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Client : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateNaissance { get; set; }
        public ICollection<Reclamation> Reclamations { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
