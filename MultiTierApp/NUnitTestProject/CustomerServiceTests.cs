using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BL.Services;
using DAL.Domain;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    class Box
    {
        static Box()
        {
            Debug.WriteLine("static ctor was called");
        }

        public Box()
        {
            Debug.WriteLine("default ctor was calleds");
        }

        public static string Data { get { return "You are trying to get data"; } }

        public const int Foo = 7;
    }
    public class CustomerServiceTests
    {
        private List<Customer> customers;
        private CustomerService customerService;
        private Mock<IUnitOfWork> mockUniOfWork;
        private Mock<ICustomerRepository> mockCustomerRepository;

        [SetUp]
        public void Setup()
        {
            var data = Box.Data;
            var box = new Box();

            customers = new List<Customer>
            {  new Customer { CustomerId = "1", Name = "Alex", Street = "Gaja", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "2", Name = "Alex", Street = "Swieta", ZIP = "35605", City = "Grodno", CountryId = 20 },
                new Customer { CustomerId = "1", Name = "Ola", Street = "Jasna", ZIP = "67605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "3", Name = "Ola", Street = "Czysta", ZIP = "24777", City = "Katovice", CountryId = 171 } };
            
            mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(m => m.GetAll()).Returns(customers);
           
            //mockCustomerRepository.Setup(m => m.Find()).Returns(customers);
            //mockCustomerRepository.Setup(m => m.Delete()).Returns(customers);

            mockUniOfWork = new Mock<IUnitOfWork>();
            mockUniOfWork.Setup(m => m.Customers).Returns(mockCustomerRepository.Object);

            customerService = new CustomerService(mockUniOfWork.Object);
        }

        [Test]
        public void GetAllCustomers()
        {
            var result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count,  Is.EqualTo(customers.Count));
        }

        [Test]
        public void GetCustomerWhenExistReturnCustomer()
        {
            Customer customer = customers[0];
            CustomerKey key = new CustomerKey() { Id = customer.CustomerId, Name = customer.Name };
            mockCustomerRepository.Setup(m => m.FindById(key.Id, key.Name)).Returns(customer);

            Customer result = customerService.Get(key);

            Assert.That(result, Is.EqualTo(customer));
        }

        [Test]
        public void GetCustomerWhenNonExistReturnNull()
        {
        }

        [Test]
        public void AddCustomerWhenNewReturnNoException()
        {
        }

        [Test]
        public void AddCustomerWhenExistReturnException()
        {
        }

        [Test]
        public void UpdateCustomerWhenNonExistReturnException()
        {
        }

        [Test]
        public void UpdateCustomerWhenExistReturnNoException()
        {
        }

        [Test]
        public void DeleteCustomerWhenNonExistReturnException()
        {
        }

        [Test]
        public void DeleteCustomerWhenExistReturnNoExceptionDeleteLinkedAddresses()
        {
            //SETUP
            var addresses = new List<Address>
            {  new Address { CustomerId = "1", AddressTypeId = 1, Name = "Alex", Street = "Zielona", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "1", AddressTypeId = 2, Name = "Alex", Street = "Czerwona", ZIP = "24601", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "3", AddressTypeId = 3, Name = "Ola", Street = "Pomaranczowa", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Address { CustomerId = "2", AddressTypeId = 2, Name = "Alex", Street = "Szara", ZIP = "24601", City = "Wroclaw", CountryId = 171 } };

            Mock<IAddressRepository> mockAddressRepository = new Mock<IAddressRepository>();
            mockAddressRepository.Setup(m => m.GetAll()).Returns(addresses);

            //IQueryable myFilteredFoos = null;
            //Address addressKeyForDelete = new Ad
            //mockAddressRepository.Setup(r => r.Delete(It.IsAny<Address>()))
            //     .Callback((Address address) =>        myFilteredFoos = addresses.Where())
            //        .Returns(() => myFilteredFoos.Cast<IFooBar>());

            mockUniOfWork.Setup(m => m.Addresses).Returns(mockAddressRepository.Object);

            customerService = new CustomerService(mockUniOfWork.Object);
            var addressService = new AddressService(mockUniOfWork.Object);

            var customerKey = new CustomerKey() { Id = "1", Name = "Alex" };

            //ACT
            customerService.Delete(customerKey);

            //ASSERT
            var resultCustomer = customerService.Get(customerKey);
            var resultAddress = addressService.GetAll().Where(a => a.CustomerId == customerKey.Id);

           Assert.That(resultCustomer, Is.EqualTo(null));
           // mockAddressRepository.Verify(r => r.Delete(It.IsAny<Address>()));
        }
    }
}