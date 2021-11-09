using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MassTransitTutorial.Domain.Common;
using MassTransitTutorial.Domain.Customer;
using MassTransitTutorial.Domain.Customer.Dtos;
using MassTransitTutorial.Domain.Events;

namespace MassTransitTutorial.Application
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateCustomerService(ICustomerRepository repo, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repo = repo;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data)
        {
            try
            {
                var newCustomer = _mapper.Map<NewCustomer>(data);
                var createdCustomer = await _repo.CreateCustomer(newCustomer);

                await _publishEndpoint.Publish<CustomerCreatedEvent>(new
                {
                    CustomerId = createdCustomer.CustomerId.Id,
                    Name = createdCustomer.Name,
                    BirthDate = createdCustomer.BirthDate,
                    Type = createdCustomer.Type.ToString(),
                    CreatedAt = createdCustomer.CreatedAt
                });

                return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(createdCustomer));
            }
            catch (ArgumentException e)
            {
                return ServiceResult<CustomerDto>.Error("ERR_VALIDATION", e.Message);
            }
        }
    }
}