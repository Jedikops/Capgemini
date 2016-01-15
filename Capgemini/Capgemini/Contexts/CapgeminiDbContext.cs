using Capgemini.Helpers;
using Capgemini.Interfaces;
using Capgemini.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Capgemini.Contexts
{
    #region Migration Factory Class

    public class MigrationsContextFactory : IDbContextFactory<CapgeminiDbContext>
    {
        public CapgeminiDbContext Create()
        {
            //Edit app settings value in web.config to change connection string value.
            return new CapgeminiDbContext(AppSettingsHelper.GetConnectionStringName);
        }
    }

    #endregion

    public class CapgeminiDbContext : DbContext
    {
        #region DBSets

        public DbSet<Customer> Customers { get; set; }

        #endregion

        #region Constructors

        public CapgeminiDbContext(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region On DbSet Operations

        public void ApplyRules()
        {
            //Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.Created = DateTime.Now;
                }

                e.Modified = DateTime.Now;
            }
        }

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ApplyRules();
            return base.SaveChangesAsync();
        }

        #endregion

    }
}
