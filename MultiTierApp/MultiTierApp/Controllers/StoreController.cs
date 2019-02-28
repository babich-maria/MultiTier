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
        private IService<Customer, CustomerKey> _customerService;
        private IService<Address, AddressKey> _addressService;

        public StoreController(IService<Customer, CustomerKey> customerService, IService<Address, AddressKey> addressService)
        {
            _customerService = customerService ?? throw new NullReferenceException("CustomerService could not be bull");
            _addressService = addressService ?? throw new NullReferenceException("AddressService could not be bull");
        }
       
        [Route("GetCustomer")]
        public Customer GetCustomer([FromBody]CustomerKey key)
        {
            var customer = _customerService.Get(key);
            return customer;
        }

        [Route("GetAllCustomers")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _customerService.GetAll();
            return customers;
        }

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
        public void DeleteCustomer([FromBody]CustomerKey key)
        {
            _customerService.Delete(key);
        }

        [Route("GetAddress")]
        public Address GetAddress([FromBody]AddressKey key)
        {
            var address = _addressService.Get(key);
            return address;
        }
     
        [Route("GetAllAddresses")]
        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = _addressService.GetAll();
            return addresses;
        }
      
        [HttpPost]
        [Route("AddAddress")]
        public void AddAddress([FromBody]Address address)
        {
            _addressService.Add(address);
        }

        [HttpPost]
        [Route("UpdateAddress")]
        public void UpdateAddress([FromBody]Address address)
        {
            _addressService.Update(address);
        }

        [HttpPost]
        [Route("DeleteAddress")]
        public void DeleteAddress([FromBody]AddressKey key)
        {
            _addressService.Delete(key);
        }
    }
}
