using Capgemini.Interfaces;
using System;
using System.Linq;
using Capgemini.Models;
using Capgemini.Contexts;
using Capgemini.Repositories;

namespace Capgemini.Managers
{
    public class DataManager : IDataManager
    {
 
        #region Declarations

        private CapgeminiDbContext _context;
        private IRepository<Customer> _customers;

        #endregion

        #region Properties

        public IRepository<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);
                return _customers;
            }
        }

        #endregion

        #region Constructors
        public DataManager(CapgeminiDbContext context)
        {
            _context = context;
        }
        #endregion
       
        #region Public Methods

        public IQueryable<Customer> GetCustomers(int count, int page)
        {
            var customers = Customers as CustomerRepository;
            if(customers == null)
                throw new ArgumentNullException("Cannot retrieve CustomersRepository");

            return customers.GetCustomers(count, page);
        }

        #endregion
    }
}
