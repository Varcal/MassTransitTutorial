using System.Threading.Tasks;
using MassTransitTutorial.Domain.Common;
using MassTransitTutorial.Domain.Customer.Dtos;

namespace MassTransitTutorial.Domain.Customer
{
    public interface ICreateCustomerService
    {
        Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data);
    }
}