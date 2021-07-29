using System;
using LiveClinic.SharedKernel.Domain.Events;
using MediatR;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate.Events
{
    public class InvoiceGenerated : INotification, IDomainEvent
    {
        public Guid InvoiceId { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public InvoiceGenerated(Guid invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
