using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Contexts.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(p => p.FirstName).IsRequired();
            Property(p => p.SurName).IsRequired();
            Property(p => p.PhoneNumber).IsOptional().HasMaxLength(14);
            Property(p => p.Address).IsOptional().HasMaxLength(128);
            Property(p => p.Created).IsRequired().HasColumnType("datetime");
            Property(p=> p.Modified).IsRequired().HasColumnType("datetime");
        }
    }
}
