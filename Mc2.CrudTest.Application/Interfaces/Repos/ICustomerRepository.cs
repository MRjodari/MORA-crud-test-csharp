using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Interfaces.Repos
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
