using AutoMapper;
using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Application.CQRS.Queries;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
           

            CreateMap<Customer, SaveCustomerCommand>()
                .ReverseMap();
            CreateMap<Customer, GetCustomerQueryResponse>()
                .ReverseMap();
            CreateMap<Customer, EditCustomerCommand>()
               .ReverseMap();


        }
    }
}
