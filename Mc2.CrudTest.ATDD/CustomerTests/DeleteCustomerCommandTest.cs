using AutoMapper;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Moq;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class DeleteCustomerCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepository;
        private readonly EditCustomerCommand command;
        private readonly DeleteCustomerCommandHandler _handler;

        public DeleteCustomerCommandTest()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new DeleteCustomerCommandHandler(_mockRepository.Object, _mapper);

            command = new EditCustomerCommand
            {
                Id=1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                PhoneNumber = "123456789",
                Email = "johndoe@example.com",
                BankAccountNumber = "123456789"
            };
        }

        [Fact]
        public async Task Exist_CustomerId_SholdBeDeleteed()
        {
            var result = await _handler.Handle(new DeleteCustomerCommand() { Id = 1 }, CancellationToken.None);

        }
    }
}
