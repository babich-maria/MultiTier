using DAL.DataBase;
using DAL.Domain;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {       
        public AddressRepository(StoreContext context)
            : base(context)
        {   }
    }
}
