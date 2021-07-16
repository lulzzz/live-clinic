using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class PriceCatalog:AggregateRoot<Guid>
    {
        public Guid DrugId { get; set; }
        public double UnitPrice { get; set; }
    }
}
