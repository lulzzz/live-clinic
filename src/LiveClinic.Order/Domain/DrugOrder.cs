using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Order.Domain
{
    public class DrugOrder:AggregateRoot<Guid>
    {
        public DateTime OrderDate { get; set; }
        public string Patient { get; set; }
        public string Provider { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }=new List<Prescription>();
    }
}
