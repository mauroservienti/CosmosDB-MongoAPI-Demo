using NServiceBus;

namespace MongoCosmos
{
    public class SomethingHappened : IEvent
    {
        public string EventId { get; set; }
    }
}
