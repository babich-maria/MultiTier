using System.Collections.Generic;
using BL.Services;
using DAL.Domain;
using DAL.Interfaces;
using DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var customers = new List<Customer>
            {  new Customer { CustomerId = "1", Name = "Alex", Street = "Gaja", ZIP = "24605", City = "Wroclaw", CountryId = 20 },
                new Customer { CustomerId = "2", Name = "Alex", Street = "Gaja", ZIP = "24605", City = "Wroclaw", CountryId = 20 }};
            //mock repository and test service
            Mock<CustomerRepository> mockCustomerRepository = new Mock<CustomerRepository>();
            mockCustomerRepository.Setup(m => m.GetAll()).Returns(customers);

            Mock<IUnitOfWork> mockUniOfWork = new Mock<IUnitOfWork>();
            mockUniOfWork.Setup(m => m.Customers).Returns(mockCustomerRepository.Object);

            var customerService = new CustomerService(mockUniOfWork.Object);

            var result = customerService.GetAll();
            Assert.Pass();
        }
    }
}