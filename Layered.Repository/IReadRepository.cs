using Layered.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Layered.Repository
{
    public interface IReadRepository<T> where T : class
    {
        IPaginate<T> GetList(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int index = 0, int size = 20);
        IPaginate<TResult> GetList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int index = 0, int size = 20) where TResult : class;
        IQueryable<T> Query(string sql, params object[] parameters);
        T Search(params object[] keyValues);
        T Single(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}