using AutoMapper;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Mc2.CrudTest.Domain.Entities;
using Moq;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class SaveCustomerCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepository;
        private readonly SaveCustomerCommand command;
        private readonly SaveCustomerCommandHandler _handler;

        public SaveCustomerCommandTest()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new SaveCustomerCommandHandler(_mockRepository.Object, _mapper);

            command = new SaveCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                PhoneNumber = "123456789",
                Email = "johndoe@example.com",
                BankAccountNumber = "123456789"
            };
        }
        [Fact]
        public async Task Handle_ShouldPersistCustomer()
        {
            // Arrange

            //var handler = new SaveCustomerCommandHandler(_mockRepository.Object, _mapper);

            // Act
            await _handler.Handle(command, default);

            // Assert
            _mockRepository.Verify(x => x.CustomerRepository.Add(It.Is<Customer>(c => c.FirstName == "John" && c.LastName == "Doe")), Times.Once);
        }
    }
}
