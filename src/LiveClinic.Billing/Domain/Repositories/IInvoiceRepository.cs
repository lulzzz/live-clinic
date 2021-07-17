using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
    }
}
