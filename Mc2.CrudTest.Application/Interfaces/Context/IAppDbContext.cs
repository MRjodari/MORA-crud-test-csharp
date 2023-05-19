using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; set; }

    }
}
