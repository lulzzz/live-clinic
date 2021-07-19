using System;
using MediatR;

namespace LiveClinic.Inventory.Domain.Events
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
