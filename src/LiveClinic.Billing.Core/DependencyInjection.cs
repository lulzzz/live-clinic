using System.Collections.Generic;
using System.Reflection;
using LiveClinic.Billing.Core.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LiveClinic.Billing.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, List<Assembly> mediatrAssemblies = null)
        {
            // services.AddAutoMapper(typeof(InventoryProfile));

            if (null != mediatrAssemblies)
            {
                mediatrAssemblies.Add(typeof(GenerateInvoiceHandler).Assembly);
                services.AddMediatR(mediatrAssemblies.ToArray());
            }
            else
            {
                services.AddMediatR(typeof(GenerateInvoiceHandler).Assembly);
            }

            return services;
        }
    }
}
