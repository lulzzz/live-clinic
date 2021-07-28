using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using LiveClinic.Billing.Core.Application.Dtos;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.Billing.Core.Domain.InvoiceAggregate;
using LiveClinic.Billing.Core.Domain.PriceAggregate;

namespace LiveClinic.Billing.Infrastructure.Tests.TestArtifacts
{
    public class TestData
    {
        public static List<Invoice> GenerateInvoices(int count=2,int itemCount=2,double price=10,double qty=10)
        {
            List<Invoice> invoices = new List<Invoice>();
            var invoiceDtos = Builder<InvoiceDto>.CreateListOfSize(count).All()
                .With(x=>x.Patient="Mr. Maun")
                .Build().ToList();
            foreach (var testCar in invoiceDtos)
            {
                var models = Builder<InvoiceItemDto>.CreateListOfSize(itemCount).All()
                    .With(x=>x.Quantity=qty)
                    .With(x=>x.UnitPrice=new Money(price,"KES"))
                    .Build().ToList();
                testCar.Items = models;
            }

            foreach (var invoiceDto in invoiceDtos)
            {
                invoices.Add(Invoice.Generate(invoiceDto));
            }
            return invoices;
        }
    }
}
