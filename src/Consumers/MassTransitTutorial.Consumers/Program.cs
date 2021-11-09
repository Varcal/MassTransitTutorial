using System;
using System.Threading.Tasks;
using MassTransit;

namespace MassTransitTutorial.Consumers
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando o Consumer");


            var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("localhost", cfg =>
                {
                    cfg.Username("admin");
                    cfg.Password("Admin@123");
                });

                config.ReceiveEndpoint("greet-new-customer", e =>
                {
                    e.Consumer<CustomerCreatedConsumer>();
                    e.PrefetchCount = 10;
                });

                config.ReceiveEndpoint("add-mail-list", e =>
                {
                    e.Consumer<AddMailListConsumer>();
                    e.PrefetchCount = 10;
                });
            });
            await busControl.StartAsync();

            Console.ReadKey();
        }
    }
}
