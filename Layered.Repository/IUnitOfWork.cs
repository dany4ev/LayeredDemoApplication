using System;
using System.Data.Entity;

namespace Layered.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
