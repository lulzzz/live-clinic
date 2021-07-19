using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Core.Domain
{
    public class StockTransaction : Entity<Guid>
    {
        public string BatchNo { get; private set; }
        public Movement Movement { get;private set; }
        public DateTime MovementDate { get; private set;}
        public double Quantity { get; private set;}
        public Guid DrugId { get;private set; }

        private StockTransaction()
        {
        }
        public StockTransaction(string batchNo, Movement movement, double quantity, Guid drugId)
        {
            BatchNo = batchNo;
            Movement = movement;
            Quantity = quantity;
            DrugId = drugId;
            MovementDate=DateTime.Now;
        }
    }
}
