using System;

namespace LiveClinic.Billing.Domain.Events
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
