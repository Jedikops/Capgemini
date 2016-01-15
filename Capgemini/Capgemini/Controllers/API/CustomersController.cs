using Capgemini.Interfaces;
using Capgemini.Models;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using System.Web.Http;
using Capgemini.ViewModels;
using Capgemini.Managers;
using System.Linq;

namespace Capgemini.Controllers.API
{
    public class CustomersController : ApiController
    {
        IDataManager _dataManager;

        public CustomersController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        // GET: api/Customers
        public IEnumerable<CustomerViewModel> Get()
        {
            var customers = _dataManager.Customers.GetAll().ToList();
            return from s in customers
                   select new CustomerViewModel
                   {
                       Id = s.Id,
                       FirstName = s.FirstName,
                       SurName = s.SurName                    
                   };
        }

        // GET: api/Customers/5
        public CustomerDetailsModel Get(int id)
        {
            var customer = _dataManager.Customers.GetById(id);
            return mapToCustomerDetailsModel(customer);

        }


        // POST: api/Customers
        public CustomerDetailsModel Post([FromBody]CustomerDetailsModel value)
        {
            var customer = new Customer()
            {
                Id = value.Id,
                FirstName = value.FirstName,
                SurName = value.SurName,
                Address = value.Address,
                PhoneNumber = value.PhoneNumber
            };

            _dataManager.Customers.Add(customer);
            return mapToCustomerDetailsModel(customer);
        }

        // PUT: api/Customers/5
        public CustomerViewModel Put([FromBody]CustomerDetailsModel value)
        {
            Customer customer = _dataManager.Customers.GetById(value.Id);
            customer.FirstName = value.FirstName;
            customer.SurName = value.SurName;
            customer.Address = value.Address;
            customer.PhoneNumber = value.PhoneNumber;

            _dataManager.Customers.Update(customer);

            return new CustomerViewModel() { Id = customer.Id, FirstName = customer.FirstName, SurName = customer.SurName };
        }

        // DELETE: api/Customers/5
        public int Delete(int id)
        {
            _dataManager.Customers.Delete(_dataManager.Customers.GetById(id));
            return id;
        }


        private static CustomerDetailsModel mapToCustomerDetailsModel(Customer customer)
        {
            return new CustomerDetailsModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                SurName = customer.SurName,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }
}
