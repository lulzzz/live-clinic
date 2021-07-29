using System;

namespace LiveClinic.SharedKernel.Domain.Events
{
    public interface IIntegrationEvent
    {
        DateTime TimeStamp { get; }
    }
}