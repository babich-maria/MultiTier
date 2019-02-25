using DAL.DataBase;
using DAL.Domain;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AddressRepository : Repository<Address, object>, IAddressRepository
    {       
        public AddressRepository(StoreContext context)
            : base(context)
        {   }
    }
}
