using System;
using System.ComponentModel.DataAnnotations.Schema;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate
{
    public class InvoiceItem:Entity<Guid>
    {
        public Guid PriceCatalogId { get;  }
        public double Quantity  { get;  }
        public Money QuotePrice  { get;}
        public Guid InvoiceId { get; }
        [NotMapped]
        public Money LineTotal => CalcTotal();

        public InvoiceItem(Guid priceCatalogId, double quantity, Money quotePrice, Guid invoiceId)
        {
            PriceCatalogId = priceCatalogId;
            Quantity = quantity;
            QuotePrice = quotePrice;
            InvoiceId = invoiceId;
        }

        private Money CalcTotal()
        {
            var total = Quantity * QuotePrice.Amount;
            return new Money(total, QuotePrice.Currency);
        }
    }
}
