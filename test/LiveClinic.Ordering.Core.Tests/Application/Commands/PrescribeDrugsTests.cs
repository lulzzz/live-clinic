using LiveClinic.Ordering.Core.Application.Commands;
using LiveClinic.Ordering.Core.Application.Dtos;
using LiveClinic.Ordering.Core.Tests.TestArtifacts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveClinic.Ordering.Core.Tests.Application.Commands
{
    [TestFixture]
    public class PrescribeDrugsTests
    {
        private IMediator _mediator;


        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }
        [Test]
        public void should_PrescribeDrugs()
        {
            var dto = TestData.CreateTestDrugOrderDto();
            var res = _mediator.Send( new  PrescribeDrugs(dto)).Result;
            Assert.True(res.IsSuccess);
        }
    }
}
