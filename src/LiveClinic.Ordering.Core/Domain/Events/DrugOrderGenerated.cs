using System;
using LiveClinic.SharedKernel.Domain.Events;
using MediatR;

namespace LiveClinic.Ordering.Core.Domain.Events
{
    public class DrugOrderGenerated : INotification, IDomainEvent
    {
        public Guid DrugOrderId { get; }
        public string OrderNo { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public DrugOrderGenerated(Guid drugOrderId, string orderNo)
        {
            DrugOrderId = drugOrderId;
            OrderNo = orderNo;
        }
    }
}
