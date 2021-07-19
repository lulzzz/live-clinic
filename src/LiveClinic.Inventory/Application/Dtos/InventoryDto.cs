using System;
using System.Collections.Generic;

namespace LiveClinic.Inventory.Application.Dtos
{
    public class InventoryDto
    {
        public Guid Id { get;set;  }
        public string Code { get;set;  }
        public string Name { get; set; }
        public List<StockTransactionDto> Transactions { get;set;} = new List<StockTransactionDto>();
    }
}
