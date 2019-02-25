using DAL.Domain;

namespace BL.Interfaces
{
    public interface IGenericService<TEntity, TKey> where TEntity : class
    {
        TEntity Get(TKey key);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
    }
}