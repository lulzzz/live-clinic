using System;
using LiveClinic.SharedKernel.Domain.Events;
using MediatR;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate.Events
{
    public class PaymentReceived : INotification, IDomainEvent
    {
        public Guid PaymentId { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public PaymentReceived(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
