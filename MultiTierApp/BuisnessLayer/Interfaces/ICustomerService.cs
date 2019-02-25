using DAL.Domain;

namespace BL.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(CustomerKey key);
        void AddCustomer(Customer customer);
    }
}