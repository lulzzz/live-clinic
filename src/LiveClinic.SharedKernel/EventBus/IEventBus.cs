using System.Threading.Tasks;

namespace LiveClinic.SharedKernel.EventBus
{
    public interface IEventBus
    {
        Task Publish<T>(T @event);
    }
}
