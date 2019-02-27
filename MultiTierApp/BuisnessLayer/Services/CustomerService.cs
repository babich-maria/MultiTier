using System;
using System.Collections.Generic;
using BL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;

namespace BL.Services
{
    public class CustomerService : IService<Customer, CustomerKey> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException("UnitOfWork could not be bull");
        }

        public Customer Get(CustomerKey key)
        {
            var customer = _unitOfWork.Customers.FindById(key.Id, key.Name);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public void Add(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
        }

        public void Update(Customer customer)
        {
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
        }

        public void Delete(CustomerKey key)
        {
            var customer = _unitOfWork.Customers.FindById(key.Id, key.Name);
            if (customer != null)
            {
                _unitOfWork.Customers.Delete(customer);
                var addresses = _unitOfWork.Addresses.Find(a => a.CustomerId.Equals(customer.CustomerId));
                foreach (var address in addresses)
                {
                    _unitOfWork.Addresses.Delete(address);
                }
            }
            _unitOfWork.Commit();
        }
    }
}
