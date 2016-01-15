using Capgemini.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Models;
using Capgemini.Tests.FakeObjects;

namespace Capgemini.Tests.FakeClasses
{
    public class FakeDataManager : IDataManager
    {
        private IRepository<Customer> _customers;
        public IRepository<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new FakeCustomerRepository(CustomerObjects.CustomersList);
                return _customers;
            }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
