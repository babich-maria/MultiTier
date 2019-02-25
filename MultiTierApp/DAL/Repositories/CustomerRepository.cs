using DAL.DataBase;
using DAL.Domain;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreContext context)
            : base(context)
        { }
    }
}
