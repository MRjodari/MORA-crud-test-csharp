using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(13)").IsRequired();
            builder.Property(x => x.BankAccountNumber).HasMaxLength(34).HasColumnType("varchar");
            builder.Property(x => x.DateOfBirth).IsRequired().HasColumnType("date");
            builder.HasIndex(e => new { e.FirstName, e.LastName, e.DateOfBirth }, "Customer_firstname_lastname_dob_unique")
                    .IsUnique();
            builder.HasIndex(e => new { e.Email }, "Email_unique").IsUnique();
            builder.HasQueryFilter(p => !p.IsRemoved);
        }
    }
}
