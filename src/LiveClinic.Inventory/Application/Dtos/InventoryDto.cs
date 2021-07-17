using System.Collections.Generic;

namespace LiveClinic.Inventory.Application.Dtos
{
    public class InventoryDto
    {
        public string Code { get;set;  }
        public string Name { get; set; }
        public List<StockDto> Stocks { get;set;} = new List<StockDto>();
    }
}
