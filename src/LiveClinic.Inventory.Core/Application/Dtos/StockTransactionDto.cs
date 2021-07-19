using System;
using LiveClinic.Inventory.Core.Domain;

namespace LiveClinic.Inventory.Core.Application.Dtos
{
    public class StockTransactionDto
    {
        public Guid Id { get; set; }
        public string BatchNo { get;set; }
        public Movement Movement { get;set;  }
        public DateTime MovementDate { get;set;  }
        public double Quantity { get; set; }
        public Guid DrugId { get;  set;}
    }
}
