using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Order.Domain
{
    public class Prescription:Entity<Guid>
    {
        public string DrugCode { get; set; }
        public double Days { get; set; }
        public double Quantity { get; set; }
    }
}
