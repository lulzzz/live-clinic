using System;
using MediatR;

namespace LiveClinic.Ordering.Domain.Events
{
    public class DrugOrderGenerated:INotification
    {
        public Guid DrugOrderId { get; }
        public string OrderNo { get; }
        public DateTime TimeStamp { get; }=new DateTime();

        public DrugOrderGenerated(Guid drugOrderId, string orderNo)
        {
            DrugOrderId = drugOrderId;
            OrderNo = orderNo;
        }
    }
}
