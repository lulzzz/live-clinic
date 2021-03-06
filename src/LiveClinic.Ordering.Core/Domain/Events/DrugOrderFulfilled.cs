using System;
using MediatR;

namespace LiveClinic.Ordering.Core.Domain.Events
{
    public class DrugOrderFulfilled:INotification
    {
        public Guid DrugOrderId { get; }
        public DateTime TimeStamp { get; }=new DateTime();

        public DrugOrderFulfilled(Guid drugOrderId)
        {
            DrugOrderId = drugOrderId;
        }
    }
}