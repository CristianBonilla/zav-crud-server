using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Crud.Infrastructure
{
    public class ContextFactory<TContext> : IDisposable, IContextFactory<TContext> where TContext : DbContext
    {
        readonly TContext context;
        bool disposed = false;

        public ContextFactory(TContext context) => this.context = context;

        public EntityEntry<TEntity> EntityEntry<TEntity>(TEntity entity) where TEntity : class => context.Entry(entity);

        public DbSet<TEntity> EntitySet<TEntity>() where TEntity : class => context.Set<TEntity>();

        public int Save() => context.SaveChanges();

        public Task<int> SaveAsync() => context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
                context.Dispose();
            disposed = true;
        }
    }
}
