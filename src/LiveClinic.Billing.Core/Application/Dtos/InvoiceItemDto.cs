using System;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.Billing.Core.Domain;

namespace LiveClinic.Billing.Core.Application.Dtos
{
    public class InvoiceItemDto
    {
        public Guid PriceCatalogId { get; set; }
        public Guid DrugId { get; set; }
        public Money UnitPrice { get; set; }
        public double Quantity  { get; set; }
    }
}
