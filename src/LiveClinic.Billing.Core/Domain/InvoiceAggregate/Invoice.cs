using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LiveClinic.Billing.Core.Application.Dtos;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.SharedKernel;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Core.Domain.InvoiceAggregate
{
    public class Invoice : AggregateRoot<Guid>
    {
        public string InvoiceNo { get; }
        public DateTime InvoiceDate { get; }
        public string Patient { get; }
        public Guid OrderId { get; }
        public string OrderNo { get; set; }
        public InvoiceStatus Status { get; private set; }
        public List<InvoiceItem> Items { get; } = new List<InvoiceItem>();
        public List<Payment> Payments { get; }=new List<Payment>();
        [NotMapped] public Money TotalAmount => GetTotalValue();
        [NotMapped] public Money TotalPaid => GetPaidValue();
        [NotMapped] public Money Balance => GetBalanceValue();
        private Invoice(string patient, Guid orderId, string orderNo)
        {
            Patient = patient;
            OrderId = orderId;
            OrderNo = orderNo;
            InvoiceNo = Utils.GenerateNo("I");
            InvoiceDate = DateTime.Now;
            Status = InvoiceStatus.NotPaid;
        }

        public static Invoice Generate(InvoiceDto invoiceDto)
        {
            var inv = new Invoice(invoiceDto.Patient, invoiceDto.OrderId, invoiceDto.OrderNo);

            inv.AddItems(invoiceDto.Items);

            return inv;
        }

        public void MakePayment(Payment payment)
        {
            Payments.Add(payment);

            Status = Balance.Amount == 0 ? InvoiceStatus.Paid : InvoiceStatus.NotPaid;
        }

        private void AddItems(List<InvoiceItemDto> itemDtos)
        {
            foreach (var dto in itemDtos)
            {
                Items.Add(new InvoiceItem(dto.PriceCatalogId, dto.Quantity, dto.UnitPrice, Id));
            }
        }

        private Money GetTotalValue()
        {
            var totalAmount = Items.Sum(x => x.LineTotal.Amount);
            return new Money(totalAmount, Items.First().QuotePrice.Currency);
        }
        private Money GetPaidValue()
        {
            var totalAmount = Payments.Sum(x => x.AmountPaid.Amount);
            return new Money(totalAmount, Payments.First().AmountPaid.Currency);
        }

        private Money GetBalanceValue()
        {
            var totalAmount = TotalAmount.Amount - TotalPaid.Amount;
            return new Money(totalAmount, Payments.First().AmountPaid.Currency);
        }
    }
}
