using Mc2.CrudTest.Application.Interfaces.Repos;
using Moq;

namespace Mc2.CrudTest.ATDD.CustomerMock
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockCustomerRepo = MockCustomerRepository.GetCustomerRepository();

            mockUow.Setup(r => r.CustomerRepository).Returns(mockCustomerRepo.Object);

            return mockUow;
        }
    }
}
