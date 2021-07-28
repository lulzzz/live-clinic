using System;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Billing.Core.Domain.PriceAggregate
{
    public interface IPriceCatalogRepository : IRepository<PriceCatalog, Guid>
    {

    }
}