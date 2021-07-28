using System;
using LiveClinic.Billing.Core.Domain.PriceAggregate;
using LiveClinic.SharedKernel.Infrastructure;

namespace LiveClinic.Billing.Infrastructure.Repositories
{
    public class PriceCatalogRepository:BaseRepository<PriceCatalog,Guid>, IPriceCatalogRepository
    {
        public PriceCatalogRepository(BillingDbContext context) : base(context)
        {
        }
    }
}
