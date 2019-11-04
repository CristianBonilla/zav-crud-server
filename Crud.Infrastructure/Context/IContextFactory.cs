using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Crud.Infrastructure
{
    public interface IContextFactory<in TContext> : IDisposable where TContext : DbContext
    {
        DbSet<TEntity> EntitySet<TEntity>() where TEntity : class;
        EntityEntry<TEntity> EntityEntry<TEntity>(TEntity entity) where TEntity : class;
        int Save();
        Task<int> SaveAsync();
    }
}
