using Movies.Data.Models;
using Movies.Repository.Interface;
using Movies.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private moviesEntities _context;

        private Dictionary<Type, object> repos;

        public UnitOfWork(moviesEntities context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(_context);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }

        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return _context.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
