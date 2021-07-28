using System;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
    }
}
