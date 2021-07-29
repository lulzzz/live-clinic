using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Serilog;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts
{
    public class TestEventMessage
    {
        public Guid Id { get; }
        public DateTime TimeStamp { get; }
        public string Message { get;}

        public TestEventMessage(string message)
        {
            Id=Guid.NewGuid();
            TimeStamp=DateTime.Now;
            Message = message;
        }
    }

    public class TestEventMessageConsumer :
        IConsumer<TestEventMessage>
    {
        public Task Consume(ConsumeContext<TestEventMessage> context)
        {
            Log.Debug("Received Text: {Text}", context.Message.Message);

            return Task.CompletedTask;
        }
    }
}
