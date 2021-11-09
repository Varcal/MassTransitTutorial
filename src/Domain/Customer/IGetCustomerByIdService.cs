using System;
using System.Threading.Tasks;
using MassTransitTutorial.Domain.Common;
using MassTransitTutorial.Domain.Customer.Dtos;

namespace MassTransitTutorial.Domain.Customer
{
    public interface IGetCustomerByIdService
    {
        Task<ServiceResult<CustomerDto>> GetCustomer(Guid customerId);
    }
}