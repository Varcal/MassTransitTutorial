using System;
using AutoMapper;
using MassTransitTutorial.Persistence;
using MassTransitTutorial.Domain;
using MassTransitTutorial.Domain.Customer;
using MassTransitTutorial.Domain.Customer.Dtos;
using Type = MassTransitTutorial.Domain.Customer.Type;

namespace MassTransitTutorial.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewCustomer, TbCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));

            CreateMap<Customer, TbCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ReverseMap()
                .ConstructUsing(
                    src => new Customer(
                        CustomerId.FromValue(src.Id),
                        src.Name,
                        src.BirthDate,
                        (Type)src.Type,
                        src.CreatedAt,
                        src.UpdatedAt));

            CreateMap<Customer, CustomerDto>();

            CreateMap<NewCustomerDto, NewCustomer>()
                .ConstructUsing(src => new NewCustomer(
                    src.Name,
                    src.BirthDate,
                    (Type)Enum.Parse(typeof(Type), src.Type)));
        }
    }
}
