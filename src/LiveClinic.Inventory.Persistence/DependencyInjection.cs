using LiveClinic.Inventory.Core.Domain.Repositories;
using LiveClinic.Inventory.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.Inventory.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<InventoryDbContext>(o => o.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"),
                    x =>  x.MigrationsAssembly(typeof(InventoryDbContext).Assembly.FullName)
                    ));

            services.AddScoped<IDrugRepository, DrugRepository>();
            return services;
        }
    }
}
