using System;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Core.Domain.PriceAggregate
{
    public class PriceCatalog:AggregateRoot<Guid>
    {
        public Guid DrugId { get; set; }
        public string DrugCode { get; set; }
        public string Name { get; set; }
        public Money UnitPrice { get; set; }
        public override string ToString()
        {
            return $"{Name} @ {UnitPrice}";
        }
    }
}
