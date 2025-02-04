using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistence;
using Domain.Entities;
using Application.Interfaces.Repository;
using Domain.Repository;
using Application.Interfaces.IServices;
using Application.Services;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurez DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SavDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddIdentity<Admin, IdentityRole>()
    .AddEntityFrameworkStores<SavDbContext>()
    .AddDefaultTokenProviders();


            // Enregistrement des services supplémentaires
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryImp<>));
            services.AddScoped<IService<Article>, ServiceArticle>();
            services.AddScoped<IService<Client>, ServiceClient>();
            services.AddScoped<IService<Reclamation>, ServiceReclamation>();
            services.AddScoped<IService<Intervention>, ServiceIntervention>();

            // Ajoutez une politique CORS si nécessaire
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}

