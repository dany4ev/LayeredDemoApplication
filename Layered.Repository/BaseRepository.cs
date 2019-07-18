using Layered.EF;
using Layered.Extensions;
using Layered.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Layered.Repository
{
    [Injectable]
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected PeopleDBEntities _dbContext;
        protected readonly DbSet<T> _dbSet;
        protected readonly IDbFactory _dbFactory;

        public BaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbContext = _dbFactory.Init();
            _dbSet = _dbContext.Set<T>();
        }

        public virtual IQueryable<T> Query(string sql, params object[] parameters)
        {
            return _dbSet.SqlQuery(sql, parameters).AsQueryable();
        }

        public T Search(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public T Single(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();

            return query.FirstOrDefault();
        }

        public IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int index = 0,
            int size = 20)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null ? orderBy(query).ToPaginate(index, size) : query.ToPaginate(index, size);
        }


        public IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int index = 0, int size = 20) where TResult : class
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query).Select(selector).ToPaginate(index, size)
                : query.Select(selector).ToPaginate(index, size);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(params T[] entities)
        {
            Add(entities);
        }

        public void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            var existing = _dbSet.Find(entity);

            if (existing != null)
                _dbSet.Remove(existing);
        }

        public void Delete(params T[] entities)
        {
            Delete(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Attach(entity);
        }

        public void Update(params T[] entities)
        {
            Update(entities);
        }

        public void Update(IEnumerable<T> entities)
        {
            _dbContext.Entry(entities).State = EntityState.Modified;

            foreach (var entity in entities)
                _dbSet.Attach(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _dbContext?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
