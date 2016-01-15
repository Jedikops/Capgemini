using Capgemini.Interfaces;
using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.Tests.FakeClasses
{
    public class FakeCustomerRepository : IRepository<Customer>
    {
        private IQueryable<Customer> _customers;
        public FakeCustomerRepository(IEnumerable<Customer> customers)
        {
            _customers = customers.AsQueryable();
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetAll()
        {
            return _customers.AsQueryable();
        }

        public Customer GetById(int? id)
        {
            if(id != null)
                return _customers.First(c => c.Id == id);
            return null;
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
