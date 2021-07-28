using LiveClinic.SharedKernel.EventBus;
using MassTransit;

namespace LiveClinic.SharedKernel.Infrastructure.EventBus
{
    public class RabbitMQEventBus:IEventBus
    {
        private readonly   IPublishEndpoint _publishEndpoint;

        public RabbitMQEventBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public void Publish(object even)
        {
            _publishEndpoint.Publish(even);
        }

        public void Subscribe<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
