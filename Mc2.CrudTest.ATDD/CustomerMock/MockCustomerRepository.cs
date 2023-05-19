using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using Moq;

namespace Mc2.CrudTest.ATDD.CustomerMock
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName="Test First Name 1",
                    LastName="Test Last Name 1",
                    Email="TestEmail1@gmail.com",
                    InsertTime=DateTime.Now,
                    DateOfBirth=DateTime.Now.AddMonths(-360),
                    PhoneNumber="+90955874101",
                    BankAccountNumber="158141401",
                    ModifiedTime=DateTime.Now
                },
                new Customer
                {
                    Id = 2,
                    FirstName="Test First Name 2",
                    LastName="Test Last Name 2",
                    Email="TestEmail2@gmail.com",
                    InsertTime=DateTime.Now,
                    DateOfBirth=DateTime.Now.AddMonths(-480),
                    PhoneNumber="+90955874102",
                    BankAccountNumber="158141402",
                    ModifiedTime=DateTime.Now
                },
                new Customer
                {
                    Id = 3,
                    FirstName="Test First Name 3",
                    LastName="Test Last Name 3",
                    Email="TestEmail3@gmail.com",
                    InsertTime=DateTime.Now,
                    DateOfBirth= new DateTime(1976,8,8),
                    PhoneNumber="+90955874103",
                    BankAccountNumber="158141403",
                    ModifiedTime=DateTime.Now
                }
            };

            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(customers);
            mockRepo.Setup(r => r.GetById(customers[0].Id)).ReturnsAsync(customers[0]);
            mockRepo.Setup(r => r.Add(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });
            mockRepo.Setup(r => r.Delete(It.IsAny<Customer>())).Returns((Customer customer) =>
            {
                return Task.FromResult(customers.Remove(customer));

            });

            return mockRepo;

        }
    }
}
