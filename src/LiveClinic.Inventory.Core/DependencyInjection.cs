using System.Collections.Generic;
using System.Reflection;
using LiveClinic.Inventory.Core.Application.Commands;
using LiveClinic.Inventory.Core.Application.Dtos;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.Inventory.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, List<Assembly> mediatrAssemblies = null)
        {
            services.AddAutoMapper(typeof(InventoryProfile));

            if (null != mediatrAssemblies)
            {
                mediatrAssemblies.Add(typeof(DispenseDrugHandler).Assembly);
                services.AddMediatR(mediatrAssemblies.ToArray());
            }
            else
            {
                services.AddMediatR(typeof(DispenseDrugHandler).Assembly);
            }

            return services;
        }
    }
}
