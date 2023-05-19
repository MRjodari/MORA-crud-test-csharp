using AutoMapper;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.CQRS.Queries;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Moq;
using Shouldly;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class GetCustomerQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepository;
        private readonly GetCustomerQuery command;
        private readonly GetCustomerQueryHandler _handler;

        public GetCustomerQueryTest()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCustomerQueryHandler(_mockRepository.Object, _mapper);

            
        }

        [Fact]
        public async void Get_ShouldReturnCustomer_WhenCustomerExist()
        {
            var handler = new GetCustomerQueryHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(new GetCustomerQuery() { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType<GetCustomerQueryResponse>();
        }
    }
}
