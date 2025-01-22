using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistence;
using Domain.Entities;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurez le DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SavDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Configurez l'identité avec votre classe Client
            services.AddIdentityCore<Client>(options =>
            {
                // Configurez les options d'Identity si nécessaire
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<SavDbContext>();
        }
    }
}
