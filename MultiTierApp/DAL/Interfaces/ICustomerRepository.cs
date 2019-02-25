using DAL.Domain;

namespace DAL.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer, CustomerKey>
    {
    }
}
