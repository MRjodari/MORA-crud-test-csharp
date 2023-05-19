using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; set; }

    }
}
