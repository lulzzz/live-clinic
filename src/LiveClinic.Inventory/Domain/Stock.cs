using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public class Stock : Entity<Guid>
    {
        public string BatchNo { get; }
        public Action Transaction { get;  }
        public DateTime TransactionDate { get;  } = DateTime.Now;
        public double Quantity { get;  }
        public Guid DrugId { get;  }
        private Stock()
        {
        }
        public Stock(string batchNo, Action transaction, double quantity, Guid drugId)
        {
            BatchNo = batchNo;
            Transaction = transaction;
            Quantity = quantity;
            DrugId = drugId;
        }
    }
}
