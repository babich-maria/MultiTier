using System;
using System.Collections.Generic;
using BL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;

namespace BL.Services
{
    public class AddressService : IService<Address, AddressKey> 
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new NullReferenceException("UnitOfWork could not be bull");
        }

        public Address Get(AddressKey key)
        {
            var address = _unitOfWork.Addresses.FindById(key.Id, key.Type);
            return address;
        }

        public IEnumerable<Address> GetAll()
        {
            return _unitOfWork.Addresses.GetAll();
        }

        public void Add(Address address)
        {
            _unitOfWork.Addresses.Add(address);
            _unitOfWork.Commit();
        }

        public void Update(Address address)
        {
            _unitOfWork.Addresses.Update(address);
            _unitOfWork.Commit();
        }

        public void Delete(AddressKey key)
        {
            //var customer = _unitOfWork.Customers.FindById(key.Id, key.Name);
            //if (customer != null)
            //{
            //    _unitOfWork.Customers.Delete(customer);
            //    var addresses = _unitOfWork.Addresses.Find(a => a.CustomerId.Equals(customer.CustomerId));
            //    foreach (var address in addresses)
            //    {
            //        _unitOfWork.Addresses.Delete(address);
            //    }
            //}
            _unitOfWork.Commit();
        }
    }
}
