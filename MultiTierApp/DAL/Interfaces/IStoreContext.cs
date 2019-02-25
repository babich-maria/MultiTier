using DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IStoreContext
    {
         DbSet<Address> Adresses { get; }
         DbSet<Customer> Customers { get; }
    }
}