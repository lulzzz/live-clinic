using System;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Billing.Domain.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
    }
}
