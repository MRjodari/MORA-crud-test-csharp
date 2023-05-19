using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Context;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}
