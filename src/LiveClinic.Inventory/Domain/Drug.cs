using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public class Drug : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
