using DAL.DataBase;
using DAL.Domain;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<Customer, CustomerKey>, ICustomerRepository
    {
        public CustomerRepository(StoreContext context)
            : base(context)
        { }
    }
}
