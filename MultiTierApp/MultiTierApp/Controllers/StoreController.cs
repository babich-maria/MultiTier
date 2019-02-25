using System;
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
            var customer = _customerService.GetCustomer(key);
            
            return customer;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("AddCustomer")]
        public void AddCustomer([FromBody]Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public void UpdateCustomer([FromBody]Customer customer)
        {
            _customerService.UpdateCustomer(customer);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public void DeleteCustomer([FromBody]EntityKey key)
        {
            _customerService.DeleteCustomer(key);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
