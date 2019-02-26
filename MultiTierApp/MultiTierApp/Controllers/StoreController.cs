using System;
using System.Collections.Generic;
using BL.Interfaces;
using DAL.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MultiTierApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private ICustomerService _customerService;
        public StoreController(ICustomerService customerService)
        {
            if (customerService == null)
                throw new NullReferenceException("customerService could not be bull");

            _customerService = customerService;
        }

        // GET: api/<controller>/GetCustomer
        [Route("GetCustomer")]
        public Customer GetCustomer([FromBody]EntityKey key)
        {
            var customer = _customerService.Get(key);
            return customer;
        }

        // GET: api/<controller>/GetCustomer
        [Route("GetAllCustomers")]
        public IEnumerable<Customer> GetAllCustomer()
        {
            var customers = _customerService.GetAll();
            return customers;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("AddCustomer")]
        public void AddCustomer([FromBody]Customer customer)
        {
            _customerService.Add(customer);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public void UpdateCustomer([FromBody]Customer customer)
        {
            _customerService.Update(customer);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public void DeleteCustomer([FromBody]EntityKey key)
        {
            _customerService.Delete(key);
        }

    }
}
