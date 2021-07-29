using System;
using LiveClinic.SharedKernel.Domain.Events;
using MediatR;

namespace LiveClinic.Inventory.Core.Domain.Events
{
    public class DrugDispensed : INotification,IDomainEvent
    {
        public Guid StockId { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public DrugDispensed(Guid stockId)
        {
            StockId = stockId;
        }
    }
}
