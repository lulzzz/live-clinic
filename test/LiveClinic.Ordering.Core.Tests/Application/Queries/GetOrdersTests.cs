using System.Collections.Generic;
using System.Linq;
using LiveClinic.Ordering.Core.Application.Dtos;
using LiveClinic.Ordering.Core.Application.Queries;
using LiveClinic.Ordering.Core.Domain;
using LiveClinic.Ordering.Core.Tests.TestArtifacts;
using MediatR;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


namespace LiveClinic.Ordering.Core.Tests.Application.Queries
{
    [TestFixture]
    public class GetOrdersTests
    {
        private List<DrugOrder> _orders = new List<DrugOrder>();
        private IMediator _mediator;

        [OneTimeSetUp]
        public void Init()
        {
            _orders = TestData.CreateTestDrugOrders();
            TestInitializer.SeedData(_orders);
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = TestInitializer.ServiceProvider.GetService<IMediator>();
        }

        [Test]
        public void should_Get_All()
        {
            var res = _mediator.Send(new GetOrders()).Result;
            Assert.True(res.IsSuccess);
            Assert.True(res.Value.Any());

            foreach (var order in res.Value)
            {
                Log.Debug($"{order}");
                foreach (var prescription in order.Prescriptions)
                    Log.Debug($"    {prescription}");
            }
        }

        [Test]
        public void should_Get_Patient()
        {
            var res = _mediator.Send(new GetOrders(null,_orders.First().Patient)).Result;
            Assert.True(res.IsSuccess);
            Assert.True(res.Value.Any());

            foreach (var order in res.Value)
            {
                Log.Debug($"{order}");
                foreach (var prescription in order.Prescriptions)
                    Log.Debug($"    {prescription}");
            }
        }

        [Test]
        public void should_Get_Order()
        {
            var res = _mediator.Send(new GetOrders(_orders.First().Id)).Result;
            Assert.True(res.IsSuccess);
            Assert.True(res.Value.Count == 1);

            foreach (var order in res.Value)
            {
                Log.Debug($"{order}");
                foreach (var prescription in order.Prescriptions)
                    Log.Debug($"    {prescription}");
            }
        }
    }
}
