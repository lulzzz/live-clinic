using System;
using LiveClinic.SharedKernel.Domain.Events;
using MediatR;

namespace LiveClinic.Inventory.Core.Domain.Events
{
    public class StockReceived : INotification,IDomainEvent
    {
        public Guid StockId { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public StockReceived(Guid stockId)
        {
            StockId = stockId;
        }
    }
}
