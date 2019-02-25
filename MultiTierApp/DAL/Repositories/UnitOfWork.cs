﻿using System;
using DAL.DataBase;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly StoreContext _dbContext;
       
       public IAddressRepository _addressRepository;
       public ICustomerRepository _customerRepository;
       
       
        public UnitOfWork(StoreContext dbContext, IAddressRepository addressRepository, 
            ICustomerRepository customerRepository)
        {
            if (dbContext == null)
                throw new NullReferenceException("dbContext could not be bull");
            if (addressRepository == null)
                throw new NullReferenceException("addressRepository could not be bull");
            if (customerRepository == null)
                throw new NullReferenceException("customerRepository could not be bull");

            _dbContext = dbContext;
            _addressRepository = addressRepository;
            _customerRepository = customerRepository;
        }

        IAddressRepository IUnitOfWork.AddressRepository => _addressRepository;
        ICustomerRepository IUnitOfWork.CustomerRepository => _customerRepository;

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
       
    }
}