using System;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate.Events
{
    public class InvoiceGenerated
    {
        public Guid InvoiceId { get; }
        public DateTime TimeStamp { get; }=new DateTime();

        public InvoiceGenerated(Guid invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
