using DAL.Domain;

namespace BL.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(EntityKey key);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(EntityKey key);
    }
}