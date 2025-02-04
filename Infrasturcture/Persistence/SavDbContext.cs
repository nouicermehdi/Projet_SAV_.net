using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SavDbContext : IdentityDbContext
    {
        public SavDbContext(DbContextOptions<SavDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Technicien> Techniciens { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }


        public DbSet<ResponsableSAV> Responsables { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)





        {
            base.OnModelCreating(modelBuilder);
        

            modelBuilder.Entity<Reclamation>()
                .Property(a => a.date)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Article>()
    .Property(a => a.DateAchat)
    .HasDefaultValueSql("GETDATE()");
        }

        /*   // Configurer les relations One-to-Many
           modelBuilder.Entity<Client>()
               .HasMany(c => c.Articles)
               .WithOne(a => a.Client)
               .HasForeignKey(a => a.ClientId)
               .OnDelete(DeleteBehavior.SetNull);

           modelBuilder.Entity<Client>()
               .HasMany(c => c.Reclamations)
               .WithOne(r => r.Client)
               .HasForeignKey(r => r.ClientId);

           modelBuilder.Entity<Article>()
               .HasMany(a => a.Reclamations)
               .WithOne(r => r.Article)
               .HasForeignKey(r => r.ArticleId);

           modelBuilder.Entity<Intervention>()
               .HasOne(i => i.Reclamation)
               .WithMany(r => r.Interventions)
               .HasForeignKey(i => i.ReclamationId);
           ;
           // Technicien peut avoir plusieurs interventions (One-to-Many)
           modelBuilder.Entity<Technicien>()
               .HasMany(t => t.Interventions)
               .WithOne(i => i.Technicien)
               .HasForeignKey(i => i.TechnicienId);
           modelBuilder.Entity<ResponsableSAV>()
               .HasMany(r => r.Reclamations)
               .WithOne()
               .HasForeignKey(r => r.ClientId);

           modelBuilder.Entity<Intervention>()
     .HasOne(i => i.Technicien)
     .WithMany(t => t.Interventions)
     .HasForeignKey(i => i.TechnicienId);




                       // Configurer l'entité Intervention
                       builder.Entity<Intervention>()
                           .HasKey(i => i.IdIntervention);


                       // Configurer la relation entre Client et Article
                       builder.Entity<Client>()
                           .HasMany(c => c.Articles) // Un client peut avoir plusieurs articles
                           .WithMany() // L'article n'a pas besoin d'une collection Client, car l'article n'a pas besoin de connaître le client directement
                           .UsingEntity<Reclamation>(
                               j => j.HasOne(r => r.Article)
                                     .WithMany(a => a.Reclamations)  // Un article peut être lié à plusieurs réclamations
                                     .HasForeignKey(r => r.IdArticle),
                               j => j.HasOne(r => r.Client)
                                     .WithMany(c => c.Reclamations)  // Un client peut avoir plusieurs réclamations
                                     .HasForeignKey(r => r.IdClient)
                           );
                       builder.Entity<Article>()
               .HasOne(a => a.Client) // Un article peut être acheté par un client
               .WithMany(c => c.Articles) // Un client peut avoir plusieurs articles achetés
               .HasForeignKey(a => a.ClientId) // La clé étrangère qui relie un article à un client
               .OnDelete(DeleteBehavior.SetNull);

                       // Configurer l'entité Article
                       builder.Entity<Article>()
                           .HasKey(a => a.Id); // Clé primaire

                       builder.Entity<Article>()
                           .Property(a => a.Title)
                           .IsRequired() // Le Title est requis
                           .HasMaxLength(100); // Limiter la longueur du Title à 100 caractères

                       builder.Entity<Article>()
                           .HasIndex(a => a.Title); // Indexer la colonne Title pour des recherches plus rapides

                       // Configurer l'entité Technicien
                       builder.Entity<Technicien>()
                           .HasKey(t => t.id); // Clé primaire

                       builder.Entity<Technicien>()
                           .Property(t => t.name)
                           .IsRequired()
                           .HasMaxLength(150);

                       // Configurer l'entité Reclamation
                       builder.Entity<Reclamation>()
                           .HasKey(r => r.IdReclamation); // Clé primaire de Reclamation

                       builder.Entity<Reclamation>()
                           .HasOne(r => r.Client) // Chaque réclamation a un client
                           .WithMany(c => c.Reclamations) // Un client peut avoir plusieurs réclamations
                           .HasForeignKey(r => r.IdClient); // Clé étrangère dans Reclamation

                       builder.Entity<Reclamation>()
                           .HasOne(r => r.Technicien) // Chaque réclamation a un technicien
                           .WithMany(t => t.Reclamations) // Un technicien peut être associé à plusieurs réclamations
                           .HasForeignKey(r => r.IdTechnicien); // Clé étrangère dans Reclamation

                       // Ajouter la relation entre Reclamation et Article
                       builder.Entity<Reclamation>()
                           .HasOne(r => r.Article) // Une réclamation peut avoir un article
                           .WithMany() // Un article peut être lié à plusieurs réclamations si nécessaire
                           .HasForeignKey(r => r.IdArticle) // La clé étrangère pour l'Article dans Reclamation
                           .OnDelete(DeleteBehavior.Restrict); // Suppression restreinte de l'article (la réclamation ne peut pas être supprimée automatiquement avec l'article)
                   }

                   builder.Entity<Intervention>()
                        .HasOne(i => i.Article) // Relation 1-N entre Intervention et Article
                        .WithMany(a => a.Interventions) // Une intervention est associée à un article
                        .HasForeignKey(i => i.ArticleId); // La clé étrangère dans Intervention
                    builder.Entity<Intervention>()
                        .HasOne(i => i.Technicien) // Relation 1-N entre Intervention et Technicien
                        .WithMany(t => t.Interventions) // Un technicien peut avoir plusieurs interventions
                        .HasForeignKey(i => i.IdIntervention);*/ // La clé étrangère dans Intervention


    }
    }
