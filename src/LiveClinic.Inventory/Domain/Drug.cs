using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public class Drug : AggregateRoot<Guid>
    {
        public string Code { get;  }
        public string Name { get;  }
        public ICollection<Stock> Stocks { get;} = new List<Stock>();
        private Drug()
        {
        }
        public Drug(string code, string name)
        {
            Code = code;
            Name = name;
        }
        public Stock AddStock(string batchNo,double quantity)
        {
            var tx = new Stock(batchNo, Action.In, quantity, Id);
            Stocks.Add(tx);
            return tx;
        }
        public Stock Dispense(string batchNo,double quantity)
        {
            var tx = new Stock(batchNo, Action.Out, quantity, Id);
            Stocks.Add(new Stock(batchNo,Action.Out,quantity,Id));
            return tx;
        }
    }
}
