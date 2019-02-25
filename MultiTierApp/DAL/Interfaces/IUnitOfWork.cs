namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
    }
}
