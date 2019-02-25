using DAL.Domain;

namespace BL.Interfaces
{
    public interface IAddressService
    {
        Address GetAddress(EntityKey key);
        void AddAddress(Address address);
    }
}