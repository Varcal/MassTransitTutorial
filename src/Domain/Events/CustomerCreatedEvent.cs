using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransitTutorial.Domain.Customer;
using Type = System.Type;

namespace MassTransitTutorial.Domain.Events
{
    public interface CustomerCreatedEvent
    {
         string CustomerId { get; }
         string Name { get; }
         DateTime BirthDate { get; }
         string Type { get; }
         DateTime CreatedAt { get; }
    }
}
