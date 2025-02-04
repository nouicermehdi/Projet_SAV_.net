using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Domain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


        public DateTime DateNaissance { get; set; }

    }
}
