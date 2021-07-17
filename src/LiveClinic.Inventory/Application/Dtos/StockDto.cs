using System;

namespace LiveClinic.Inventory.Application.Dtos
{
    public class StockDto
    {
        public Guid Id { get; set; }
        public string BatchNo { get;set; }
        public Action Transaction { get;set;  }
        public DateTime TransactionDate { get;set;  }
        public double Quantity { get; set; }
        public Guid DrugId { get;  set;}
    }
}