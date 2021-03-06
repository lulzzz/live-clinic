using System.Collections.Generic;
using LiveClinic.Billing.Core.Domain.PriceAggregate;

namespace LiveClinic.Billing.Infrastructure.Seed
{
    public static class PriceCatalogSeed
    {
        public static List<PriceCatalog> GetCatalogs()
        {
            return new()
            {
                new(){DrugCode = "PN",Name ="Panadol 500mg" },
                new(){DrugCode = "BF",Name ="Brufen 500mg" }
            };
        }
    }
}
