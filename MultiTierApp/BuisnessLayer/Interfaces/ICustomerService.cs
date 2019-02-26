using System.Collections.Generic;
using DAL.Domain;

namespace BL.Interfaces
{
    public interface ICustomerService
    {
        Customer Get(EntityKey key);
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(EntityKey key);
    }
}