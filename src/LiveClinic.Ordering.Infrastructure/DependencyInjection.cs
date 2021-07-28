using LiveClinic.Ordering.Core.Domain.Repositories;
using LiveClinic.Ordering.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration, bool initDb = true)
        {
            if (initDb)
                services.AddDbContext<OrderingDbContext>(o => o.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"),
                    x =>  x.MigrationsAssembly(typeof(OrderingDbContext).Assembly.FullName)
                    ));

            services.AddScoped<IDrugOrderRepository, DrugOrderRepository>();
            return services;
        }
    }
}
