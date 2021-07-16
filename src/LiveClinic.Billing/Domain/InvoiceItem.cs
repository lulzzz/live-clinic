using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class InvoiceItem:Entity<Guid>
    {
        public Guid DrugId { get; set; }
        public double Quantity  { get; set; }
        public double UnitPrice  { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
