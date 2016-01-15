using Capgemini.Contexts;
using Capgemini.Models;
using System.Linq;

namespace Capgemini.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        #region Constructors

        public CustomerRepository(CapgeminiDbContext context) : base(context)
        {

        }

        #endregion

        #region Public Methods

        public IQueryable<Customer> GetCustomers(int count, int page)
        {
            var result =  DBSet.OrderByDescending(p => p.Modified);
            var skippedstarts = result.Skip(count * (page - 1));
            return skippedstarts.Take(count);
        }

        #endregion
    }
}
