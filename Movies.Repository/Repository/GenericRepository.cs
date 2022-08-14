using Microsoft.EntityFrameworkCore;
using Movies.Data.Models;
using Movies.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
            where T : class
    {
        private readonly moviesEntities _context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(moviesEntities context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual EntityState Add(T entity)
        {
            return dbSet.Add(entity).State;
        }
        public T Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public T Get(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return FindBy(predicate).Include(include);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = GetAll();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                            (current, include) => current.Include(include));
            }
            return query;
        }

        public IQueryable<T> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return dbSet.Skip(pageSize).Take(pageCount);
        }

        public IQueryable<T> GetAll(string include)
        {
            return dbSet.Include(include);
        }

        public IQueryable<T> GetAll(string include, string include2)
        {
            return dbSet.Include(include).Include(include2);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        public virtual EntityState HardDelete(T entity)
        {
            return dbSet.Remove(entity).State;
        }

        public virtual EntityState HardDeleteMultiple(IEnumerable<T> entities)
        {
            EntityState entityState = new();
            foreach (T entity in entities)
                entityState = HardDelete(entity);
            return entityState;
        }

        public virtual EntityState Update(T entity)
        {
            //return dbSet.Update(entity).State;
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.Entry(entity).State;
        }

    }
}
