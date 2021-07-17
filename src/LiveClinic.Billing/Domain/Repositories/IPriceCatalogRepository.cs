using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public interface IPriceCatalogRepository : IRepository<PriceCatalog, Guid>
    {

    }
}