using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public class StockTransaction : Entity<Guid>
    {
        public string BatchNo { get; }
        public Movement Movement { get; }
        public DateTime MovementDate { get; }
        public double Quantity { get; }
        public Guid DrugId { get; }

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
