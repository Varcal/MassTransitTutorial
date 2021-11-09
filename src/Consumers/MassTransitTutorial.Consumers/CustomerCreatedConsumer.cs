using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTutorial.Domain.Events;

namespace MassTransitTutorial.Consumers
{
    public class CustomerCreatedConsumer: IConsumer<CustomerCreatedEvent>
    {
        public async Task Consume(ConsumeContext<CustomerCreatedEvent> context)
        {

            var id = context.Message.CustomerId;
            var name = context.Message.Name;

            Console.WriteLine($"Novo cliente cadastro: [{id}] - [{name}]");

            await Task.CompletedTask;
        }
    }
}
