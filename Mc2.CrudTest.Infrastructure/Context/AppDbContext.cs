using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            base.OnModelCreating(modelBuilder);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.InsertTime = DateTime.Now;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
    }
}
