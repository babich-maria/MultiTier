namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
