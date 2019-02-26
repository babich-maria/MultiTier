using System.Collections.Generic;
using DAL.Domain;

namespace BL.Interfaces
{
    public interface IAddressService
    {
        Address Get(EntityKey key);
        IEnumerable<Address> GetAll();
        void Add(Address customer);
        void Update(Address customer);
        void Delete(EntityKey key);
    }
}