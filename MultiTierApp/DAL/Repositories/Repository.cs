using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected DbSet<TEntity> _entities;
        protected DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity FindById(params object[] keys)
        {
            return _entities.Find(keys);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}
