using Mc2.CrudTest.Application.Interfaces.Repos;
using Mc2.CrudTest.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private ICustomerRepository _customerRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
