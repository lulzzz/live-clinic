using System;
using System.Collections.Generic;
using LiveClinic.Order.Domain;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class Invoice:AggregateRoot<Guid>
    {
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string Patient { get; set; }
        public Guid OrderId { get; set; }
        public InvoiceStatus Status { get; set; }
        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }
}
