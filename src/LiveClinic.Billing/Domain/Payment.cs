using System;
using LiveClinic.SharedKernel;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class Payment:Entity<Guid>
    {
        public DateTime ReceiptDate {get;}
        public string ReceiptNo { get; set; }
        public Money AmountPaid {get;}
        public Guid InvoiceId {get;}

        public Payment(Money amountPaid, Guid invoiceId)
        {
            ReceiptNo = Utils.GenerateNo("R");
            AmountPaid = amountPaid;
            InvoiceId = invoiceId;
        }
    }
}
