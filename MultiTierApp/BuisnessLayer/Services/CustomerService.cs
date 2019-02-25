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

        public Customer GetCustomer(EntityKey key)
        {
            var customer = _unitOfWork.Customers.FindById(key.Id, key.Name);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
        }

        public void DeleteCustomer(EntityKey key)
        {
            var customer = _unitOfWork.Customers.FindById(key.Id, key.Name);
            if (customer != null)
            {
                _unitOfWork.Customers.Delete(customer);
            }
            _unitOfWork.Commit();
        }

        //public void UpdateDeliveryAddress(EntityKey key, Address address)
        //{
        //    var customer = _unitOfWork.CustomerRepository.FindById(key.Id, key.Name);
        //    if (customer == null)
        //        return;

        //    _unitOfWork.AddressRepository.Update(address);
        //    _unitOfWork.Commit();
        //}
    }
}
