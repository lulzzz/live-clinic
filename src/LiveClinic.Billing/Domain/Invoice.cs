using System;
using System.Collections.Generic;
using LiveClinic.Billing.Application.Dtos;
using LiveClinic.SharedKernel;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Billing.Domain
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

        public void MakePayment(Money amount)
        {
            Payments.Add(new Payment(amount, Id));
            Status = InvoiceStatus.Paid;
        }

        private void AddItems(List<InvoiceItemDto> itemDtos)
        {
            foreach (var dto in itemDtos)
            {
                Items.Add(new InvoiceItem(dto.PriceCatalogId, dto.Quantity, dto.UnitPrice, Id));
            }
        }
    }
}
