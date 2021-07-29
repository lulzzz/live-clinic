using System;

namespace LiveClinic.SharedKernel.Domain.Events
{
    public interface IDomainEvent
    {
         DateTime TimeStamp { get; }
    }
}
