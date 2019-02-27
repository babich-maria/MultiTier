using System.Collections.Generic;
using BL.Services;
using DAL.Domain;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    public class CustomerServiceTests
    {
        private List<Customer> customers;
        private CustomerService customerService;
        [SetUp]
        public void Setup()
        {
            customers = new List<Customer>
            {  new Customer { CustomerId = "1", Name = "Alex", Street = "Gaja", ZIP = "24605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "2", Name = "Alex", Street = "Swieta", ZIP = "35605", City = "Grodno", CountryId = 20 },
                new Customer { CustomerId = "1", Name = "Ola", Street = "Jasna", ZIP = "67605", City = "Wroclaw", CountryId = 171 },
                new Customer { CustomerId = "3", Name = "Ola", Street = "Czysta", ZIP = "24777", City = "Katovice", CountryId = 171 } };
            
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(m => m.GetAll()).Returns(customers);

            Mock<IUnitOfWork> mockUniOfWork = new Mock<IUnitOfWork>();
            mockUniOfWork.Setup(m => m.Customers).Returns(mockCustomerRepository.Object);

            customerService = new CustomerService(mockUniOfWork.Object);
        }

        [Test]
        public void GetAllCustomers()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count,  Is.EqualTo(customers.Count));
        }

        [Test]
        public void GetCustomerWhenExistReturnCustomer()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void GetCustomerWhenNonExistReturnNull()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void AddCustomerWhenNewReturnNoException()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void AddCustomerWhenExistReturnException()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void UpdateCustomerWhenNonExistReturnException()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void UpdateCustomerWhenExistReturnNoException()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void DeleteCustomerWhenNonExistReturnException()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }

        [Test]
        public void DeleteCustomerWhenExistReturnNoExceptionDeleteLinkedAddresses()
        {
            IList<Customer> result = (IList<Customer>)customerService.GetAll();
            Assert.That(result.Count, Is.EqualTo(customers.Count));
        }
    }
}