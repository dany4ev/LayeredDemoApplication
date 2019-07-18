using Layered.Extensions.Attributes;

namespace Layered.Repository
{
    [Injectable]
    public class UnitOfWork : IUnitOfWork
    {
        //private Dictionary<Type, object> _repositories;

        //public UnitOfWork(TContext context)
        //{
        //    Context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        //public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        //{
        //    if (_repositories == null)
        //        _repositories = new Dictionary<Type, object>();

        //    var type = typeof(TEntity);

        //    if (!_repositories.ContainsKey(type))
        //        _repositories[type] = new BaseRepository<TEntity>(Context);

        //    return (IRepository<TEntity>)_repositories[type];
        //}

        //public TContext Context { get; }

        public int SaveChanges()
        {
            return 0;
            //return Context.SaveChanges();
        }

        public void Dispose()
        {
            //Context?.Dispose();
        }
    }
}