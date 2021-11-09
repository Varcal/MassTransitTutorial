using System;

namespace MassTransitTutorial.Domain.Customer
{
    public class NewCustomer : CustomerBase
    {
        public NewCustomer(string name, DateTime birthDate, Type type)
            : base(name, birthDate, type)
        {
            CustomerId = CustomerId.New();
            CreatedAt = DateTime.Now;
        }
    }
}
