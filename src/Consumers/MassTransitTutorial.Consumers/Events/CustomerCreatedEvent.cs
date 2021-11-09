using System;


namespace MassTransitTutorial.Domain.Events
{
    public class CustomerCreatedEvent
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Type { get; }
        public DateTime CreatedAt { get; set; }
    }
}
