using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure
{
    public interface IRepositoryFactory<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        IContextFactory<TContext> Context { get; }
        IRepository<TContext, TEntity> Repository { get; }
    }
}
