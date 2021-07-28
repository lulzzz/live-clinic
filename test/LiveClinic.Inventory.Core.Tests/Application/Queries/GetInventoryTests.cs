using System.Collections.Generic;
using System.Linq;
using LiveClinic.Inventory.Core.Application.Queries;
using LiveClinic.Inventory.Core.Domain;
using LiveClinic.Inventory.Core.Tests.TestArtifacts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.Inventory.Core.Tests.Application.Queries
{
    [TestFixture]
    public class GetInventoryTests
    {
        private IMediator _mediator;
        private List<Drug> _drugs;

        [OneTimeSetUp]
        public void Init()
        {
            _drugs = TestData.CreateTestDrugs();
           TestInitializer.SeedData(_drugs);
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }
        [Test]
        public void should_Get_All()
        {
            var res = _mediator.Send( new  GetInventory()).Result;
            Assert.True(res.IsSuccess);
            foreach (var inventoryDto in res.Value)
            {
                Log.Debug(inventoryDto.ToString());
            }
        }

        [Test]
        public void should_Get_By_Drug()
        {
            var res = _mediator.Send( new  GetInventory(_drugs.First().Id)).Result;
            Assert.True(res.IsSuccess);
            foreach (var inventoryDto in res.Value)
            {
                Log.Debug(inventoryDto.ToString());
            }
        }
    }
}
