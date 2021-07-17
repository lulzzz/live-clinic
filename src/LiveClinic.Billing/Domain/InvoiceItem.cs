using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class InvoiceItem:Entity<Guid>
    {
        public Guid PriceCatalogId { get;  }
        public double Quantity  { get;  }
        public Money QuotePrice  { get;}
        public Guid InvoiceId { get; }

        public InvoiceItem(Guid priceCatalogId, double quantity, Money quotePrice, Guid invoiceId)
        {
            PriceCatalogId = priceCatalogId;
            Quantity = quantity;
            QuotePrice = quotePrice;
            InvoiceId = invoiceId;
        }
    }
}
