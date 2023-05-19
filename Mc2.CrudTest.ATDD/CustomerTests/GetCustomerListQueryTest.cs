using AutoMapper;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.CQRS.Queries;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Mc2.CrudTest.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mc2.CrudTest.Application.CQRS.Queries.GetCustomerListQuery;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class GetCustomerListQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepository;
        private readonly GetCustomerListQuery command;
        private readonly GetCustomerListQueryHandler _handler;

        public GetCustomerListQueryTest()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCustomerListQueryHandler(_mockRepository.Object, _mapper);


        }

        [Fact]
        public async Task<IEnumerable<Customer>> Get_ShouldReturnCustomerList()
        {
            var handler = new GetCustomerListQueryHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new GetCustomerListQuery(),CancellationToken.None);
            return result.ShouldBeOfType<List<Customer>>();
        }
    }
}
