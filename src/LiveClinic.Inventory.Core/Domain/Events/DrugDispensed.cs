using System;
using MediatR;

namespace LiveClinic.Inventory.Core.Domain.Events
{
    public class DrugDispensed : INotification
    {
        public Guid StockId { get; }
        public DateTime TimeStamp { get; } = new DateTime();

        public DrugDispensed(Guid stockId)
        {
            StockId = stockId;
        }
    }
}
