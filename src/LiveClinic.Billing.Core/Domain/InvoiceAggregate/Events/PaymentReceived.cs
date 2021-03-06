using System;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate.Events
{
    public class PaymentReceived
    {
        public Guid PaymentId { get; }
        public DateTime TimeStamp { get; }=new DateTime();

        public PaymentReceived(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}