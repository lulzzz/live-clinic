namespace LiveClinic.SharedKernel.EventBus
{
    public interface IEventBus
    {
        void Publish(object even);
        void Subscribe<T>() where T : class;
    }
}
