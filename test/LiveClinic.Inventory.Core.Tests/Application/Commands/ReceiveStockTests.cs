using System.Collections.Generic;
using System.Linq;
using LiveClinic.Inventory.Core.Application.Commands;
using LiveClinic.Inventory.Core.Application.Queries;
using LiveClinic.Inventory.Core.Domain;
using LiveClinic.Inventory.Persistence.Tests.TestArtifacts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.Inventory.Persistence.Tests.Application.Commands
{
    [TestFixture]
    public class ReceiveStockTests
    {
        private IMediator _mediator;
        private Drug _drug;

        [OneTimeSetUp]
        public void Init()
        {
            _drug = TestData.CreateTestDrugWithStock("XYZ", 11);
            TestInitializer.SeedData(new[]{ _drug});
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }
        [Test]
        public void should_Receive_Stock()
        {
            var res = _mediator.Send( new  ReceiveStock(_drug.Id,"LEO",9)).Result;
            Assert.True(res.IsSuccess);

            var inventoryQuery = _mediator.Send(new GetInventory(_drug.Id)).Result;
            var inventoryDto = inventoryQuery.Value.First();
            Assert.AreEqual(20,inventoryDto.QuantityStock);
            Log.Debug(inventoryDto.ToString());
        }
    }
}
