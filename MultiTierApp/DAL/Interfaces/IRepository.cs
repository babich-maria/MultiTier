using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(params object[] keys);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
      
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity keys);
    }
}
