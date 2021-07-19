using System.Linq;
using LiveClinic.Ordering.Core.Domain.Repositories;
using LiveClinic.Ordering.Infrastructure.Tests.TestArtifacts;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.Ordering.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class DrugRepositoryTests
    {
        private IDrugOrderRepository _drugOrderRepository;

        [SetUp]
        public void SetUp()
        {
            TestInitializer.SeedData(TestData.CreateTestDrugOrders());
            _drugOrderRepository = TestInitializer.ServiceProvider.GetService<IDrugOrderRepository>();

        }

        [Test]
        public void should_Load_All_Orders()
        {
            var drugs = _drugOrderRepository.LoadAll().ToList();
            Assert.True(drugs.Count > 0);
            foreach (var drug in drugs)
                Log.Debug(drug.ToString());
        }
    }
}
