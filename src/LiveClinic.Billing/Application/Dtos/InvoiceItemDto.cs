using System;
using LiveClinic.Billing.Domain;

namespace LiveClinic.Billing.Application.Dtos
{
    public class InvoiceItemDto
    {
        public Guid PriceCatalogId { get; set; }
        public Guid DrugId { get; set; }
        public Money UnitPrice { get; set; }
        public double Quantity  { get; set; }
    }
}
