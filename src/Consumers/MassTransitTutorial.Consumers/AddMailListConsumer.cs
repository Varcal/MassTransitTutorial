using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTutorial.Domain.Events;

namespace MassTransitTutorial.Consumers
{
    public class AddMailListConsumer: IConsumer<CustomerCreatedEvent>
    {
        public Task Consume(ConsumeContext<CustomerCreatedEvent> context)
        {
            var id = context.Message.CustomerId;
            var name = context.Message.Name;

            Console.WriteLine($"Novo cliente adicionado a lista de emails: [{id}] - [{name}]");

            return Task.CompletedTask;
        }
    }
}
