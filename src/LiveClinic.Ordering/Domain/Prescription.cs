using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Ordering.Domain
{
    public class Prescription:Entity<Guid>
    {
        public string DrugCode { get;  }
        public double Days { get;  }
        public double Quantity { get; }
        public Guid DrugOrderId { get; }
        public DateTime Generated { get; }

        public Prescription(string drugCode, double days, double quantity, Guid drugOrderId)
        {
            DrugCode = drugCode;
            Days = days;
            Quantity = quantity;
            DrugOrderId = drugOrderId;
            Generated = DateTime.Now;
        }
    }
}
