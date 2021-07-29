using LiveClinic.SharedKernel.EventBus;
using LiveClinic.SharedKernel.Infrastructure.EventBus;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.SharedKernel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IEventBus, MassTransitEventBus>();
            return services;
        }
    }
}
