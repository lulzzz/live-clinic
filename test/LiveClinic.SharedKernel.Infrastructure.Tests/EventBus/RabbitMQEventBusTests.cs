using LiveClinic.SharedKernel.EventBus;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.EventBus
{
    [TestFixture]
    public class RabbitMQEventBusTests
    {
        private IEventBus _eventBus;

        [SetUp]
        public void Setup()
        {
            _eventBus = TestInitializer.ServiceProvider.GetService<IEventBus>();
        }
        [Test]
        public void should_Publish()
        {

        }
        [Test]
        public void should_Subscribe()
        {

        }
    }
}
