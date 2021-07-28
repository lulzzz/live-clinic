using System.Linq;
using LiveClinic.Billing.Core.Application.Commands;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.Billing.Core.Domain.InvoiceAggregate;
using LiveClinic.Billing.Core.Tests.TestArtifacts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveClinic.Billing.Core.Tests.Application.Commands
{
    [TestFixture]
    public class ReceivePaymentTests
    {
        private IMediator _mediator;
        private Invoice _invoice;

        [OneTimeSetUp]
        public void Init()
        {
            _invoice = TestData.GenerateInvoices().First();
            TestInitializer.SeedData(new []{_invoice});
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }
        [Test]
        public void should_GenerateInvoice()
        {
            var res = _mediator.Send(new ReceivePayment(_invoice.Id,new Money(200,"KES"))).Result;
            Assert.True(res.IsSuccess);
        }
    }
}
