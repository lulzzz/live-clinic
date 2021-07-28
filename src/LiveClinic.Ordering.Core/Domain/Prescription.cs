using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Ordering.Core.Domain
{
    public class Prescription:Entity<Guid>
    {
        public string DrugCode { get; private set; }
        public double Days { get;  private set;}
        public double Quantity { get; private set;}
        public Guid DrugOrderId { get; private set;}
        public DateTime Generated { get;private set; }

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
