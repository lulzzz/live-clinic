using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public class Stock : AggregateRoot<Guid>
    {
        public string BatchNo { get; set; }
        public Action Transaction { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Quantity { get; set; }
        public Guid DrugId { get; set; }
    }
}
