using System;
using System.Collections.Generic;
using System.Linq;
using LiveClinic.Inventory.Core.Domain;

namespace LiveClinic.Inventory.Core.Application.Dtos
{
    public class InventoryDto
    {
        public Guid Id { get;set;  }
        public string Code { get;set;  }
        public string Name { get; set; }
        public bool InStock => CheckStock();
        public double QuantityIn => CalcTxInStock();
        public double QuantityOut => CalcTxOutStock();
        public double QuantityStock => CalcStock();
        public List<StockTransactionDto> Transactions { get;set;} = new List<StockTransactionDto>();

        public override string ToString()
        {
            return $"{Name} Stock:{QuantityStock}";
        }

        private bool CheckStock()
        {
           return QuantityIn>QuantityOut;
        }

        private double CalcStock()
        {
            return QuantityIn-QuantityOut;
        }
        private double CalcTxInStock()
        {
            var inStock=Transactions
                .Where(x => x.Movement == Movement.Received)
                .Sum(x=>x.Quantity);
            return inStock;
        }
        private double CalcTxOutStock()
        {
            var outStock=Transactions.
                Where(x => x.Movement == Movement.Dispensed)
                .Sum(x=>x.Quantity);
            return outStock;
        }
    }
}
