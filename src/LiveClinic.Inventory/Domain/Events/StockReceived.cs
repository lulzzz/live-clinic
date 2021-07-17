using System;
using MediatR;

namespace LiveClinic.Inventory.Domain.Events
{
    public class StockReceived:INotification
    {
        public Guid  TransactionId { get; }
        public Guid  DrugId { get; }
        public double  Quantity { get; }
        public DateTime TimeStamp { get; }=new DateTime();

        public StockReceived(Guid transactionId, Guid drugId, double quantity)
        {
            TransactionId = transactionId;
            DrugId = drugId;
            Quantity = quantity;
        }
    }
}