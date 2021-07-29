using System.Threading.Tasks;
using LiveClinic.SharedKernel.EventBus;
using MassTransit;

namespace LiveClinic.SharedKernel.Infrastructure.EventBus
{
    public class MassTransitEventBus:IEventBus
    {
        private readonly IBusControl _bus;

        public MassTransitEventBus(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task Publish<T>(T @event)
        {
            await _bus.Publish(@event);
        }
    }
}
