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
            //mock repository and test service
            Mock<CustomerRepository> mock = new Mock<CustomerRepository>();
            //mock.Setup(m => m.GetAll()).Returns(user);
            Assert.Pass();
        }
    }
}