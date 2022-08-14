using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        /// <returns>The Entity's state</returns>
        EntityState Add(T entity);

        /// <returns>The Entity's state</returns>
        EntityState Update(T entity);
        /// <returns>The Entity's state</returns>
        /// <returns>Entity</returns>
        T Get<TKey>(TKey id);

        /// <returns>Task Entity</returns>
        Task<T> GetAsync<TKey>(TKey id);

        /// <returns>The requested Entity</returns>
        T Get(params object[] keyValues);

        /// <returns>Entity</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <returns>Queryable</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);

        /// <returns>List of entities</returns>
        IQueryable<T> GetAll();

        /// <returns>Queryable</returns>
        IQueryable<T> GetAll(int page, int pageCount);

        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
  
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll(string include, string include2);
        EntityState HardDeleteMultiple(IEnumerable<T> entities);
    }
}
