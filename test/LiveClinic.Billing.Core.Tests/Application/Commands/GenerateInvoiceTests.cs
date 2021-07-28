using System.Linq;
using LiveClinic.Billing.Core.Application.Commands;
using LiveClinic.Billing.Core.Application.Dtos;
using LiveClinic.Billing.Core.Tests.TestArtifacts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveClinic.Billing.Core.Tests.Application.Commands
{
    [TestFixture]
    public class GenerateInvoiceTests
    {
        private IMediator _mediator;
        private InvoiceDto _invoiceDto;

        [OneTimeSetUp]
        public void Init()
        {
            _invoiceDto = TestData.GenerateInvoiceDtos().First();
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }
        [Test]
        public void should_GenerateInvoice()
        {
            var res = _mediator.Send(new GenerateInvoice(_invoiceDto)).Result;
            Assert.True(res.IsSuccess);
        }
    }
}
