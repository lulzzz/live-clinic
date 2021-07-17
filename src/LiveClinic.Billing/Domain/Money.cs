using System.Collections.Generic;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
{
    public class Money:ValueObject<Money>
    {
        public double Amount { get; }
        public string Currency { get; }

        protected Money()
        {
        }

        public Money(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
