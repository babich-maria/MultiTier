using System.Collections.Generic;
using DAL.Domain;

namespace BL.Interfaces
{
    public interface IService<TEntity, TKey>
    {
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity customer);
        void Update(TEntity customer);
        void Delete(TKey key);
    }
}