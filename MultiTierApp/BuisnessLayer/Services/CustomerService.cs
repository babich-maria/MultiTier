using System;
using BL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;

namespace BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new NullReferenceException("unitOfWork could not be bull");
            _unitOfWork = unitOfWork;
        }

        public Customer GetCustomer(CustomerKey key)
        {
            var customer = _unitOfWork.CustomerRepository.FindById(key.id, key.name);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            _unitOfWork.CustomerRepository.Add(customer);
            _unitOfWork.Commit();
          
        }
    }
}
