using AutoMapper;
using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
           

            CreateMap<Customer, SaveCustomerCommand>()
                .ReverseMap();
            //CreateMap<Customer, GetCustomerQueryResponse>()
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
            //    .ReverseMap();
            //CreateMap<Customer, EditCustomerCommand>()
            //   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
            //   .ReverseMap();


        }
    }
}
