using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SavDbContext : IdentityDbContext<IdentityUser>
    {
        public SavDbContext(DbContextOptions<SavDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Technicien> Techniciens { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<ResponsableSAV> ResponsablesSAV { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurer l'entité Article
            builder.Entity<Article>()
                .HasKey(a => a.Id); // Clé primaire
            builder.Entity<Article>()
                .Property(a => a.Title)
                .IsRequired() // Le Title est requis
                .HasMaxLength(100); // Limiter la longueur du Title à 100 caractères
            builder.Entity<Article>()
                .HasIndex(a => a.Title); // Indexer la colonne Name pour des recherches plus rapides

            // Configurer l'entité Technicien
            builder.Entity<Technicien>()
                .HasKey(t => t.id); // Clé primaire
            builder.Entity<Technicien>()
                .Property(t => t.name)
                .IsRequired() // Le nom est requis
                .HasMaxLength(150); // Limiter la longueur du nom à 150 caractères

            // Configurer l'entité Intervention
            builder.Entity<Intervention>()
                .HasKey(i => i.IdIntervention); // Clé primaire
            builder.Entity<Intervention>()
                .HasOne(i => i.Article) // Relation 1-N entre Intervention et Article
                .WithMany(a => a.Interventions) // Une intervention est associée à un article
                .HasForeignKey(i => i.ArticleId); // La clé étrangère dans Intervention
            builder.Entity<Intervention>()
                .HasOne(i => i.Technicien) // Relation 1-N entre Intervention et Technicien
                .WithMany(t => t.Interventions) // Un technicien peut avoir plusieurs interventions
                .HasForeignKey(i => i.IdIntervention); // La clé étrangère dans Intervention


            // Configurer l'entité ResponsableSAV
            builder.Entity<ResponsableSAV>()
                .HasKey(r => r.id); // Clé primaire
            builder.Entity<ResponsableSAV>()
                .Property(r => r.name)
                .IsRequired() // Le nom est requis
                .HasMaxLength(100); // Limiter la longueur du nom à 100 caractères

            // Configurer l'entité Reclamation
            builder.Entity<Reclamation>()
                .HasKey(r => r.IdReclamation); // Clé primaire
            builder.Entity<Reclamation>()
                .HasOne(r => r.Client) // Relation 1-N entre Reclamation et Client
                .WithMany(c => c.Reclamations) // Un client peut avoir plusieurs réclamations
                .HasForeignKey(r => r.IdClient); // La clé étrangère dans Reclamation
            builder.Entity<Reclamation>()
                .HasOne(r => r.Technicien) // Relation 1-N entre Reclamation et Technicien
                .WithMany(t => t.Reclamations) // Un technicien peut avoir plusieurs réclamations
                .HasForeignKey(r => r.IdTechnicien); // La clé étrangère dans Reclamation
        }
    }
}
