namespace Shared
{
    using System;
    using NServiceBus;

    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
