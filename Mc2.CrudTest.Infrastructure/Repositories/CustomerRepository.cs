using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}
