using LiveClinic.SharedKernel.EventBus;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.EventBus
{
    [TestFixture]
    public class MassTransitEventBusTests
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
            _eventBus.Publish<TestEventMessage>(new TestEventMessage("Hello World!"));
            Assert.Pass();
        }

    }
}
