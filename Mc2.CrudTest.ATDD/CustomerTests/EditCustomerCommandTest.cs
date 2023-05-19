using AutoMapper;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Application.CQRS.Commands;
using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.ATDD.CustomerMock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.ATDD.CustomerTests
{
    public class EditCustomerCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepository;
        private readonly EditCustomerCommand command;
        private readonly EditCustomerCommandHandler _handler;

        public EditCustomerCommandTest()
        {
            _mockRepository = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new EditCustomerCommandHandler(_mockRepository.Object, _mapper);

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
        public async Task Update_SholdBeReturnNotFoundException_WhenNonExistCustomerPassedIt()
        {
            var customer = new EditCustomerCommand
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.UtcNow.AddYears(-30),
                PhoneNumber = "987654321",
                Email = "johndoe@example.com",
                BankAccountNumber = "123456789"
            };
            try
            {
                var result = await _handler.Handle(customer, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("customer  was not found", ex.Message);

            }

        }
    }
}
