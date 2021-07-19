using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Core.Domain
{
    public class Drug : AggregateRoot<Guid>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ICollection<StockTransaction> Transactions { get; private set; } = new List<StockTransaction>();

        private Drug()
        {
        }
        public Drug(string code, string name)
        {
            Code = code;
            Name = name;
        }
        public StockTransaction ReceiveStock(string batchNo,double quantity)
        {
            var tx = new StockTransaction(batchNo, Movement.Received, quantity, Id);
            Transactions.Add(tx);
            return tx;
        }
        public StockTransaction Dispense(string batchNo,double quantity)
        {
            var tx = new StockTransaction(batchNo, Movement.Dispensed, quantity, Id);
            Transactions.Add(tx);
            return tx;
        }

        public override string ToString()
        {
            return $"{Code}-{Name}";
        }
    }
}
