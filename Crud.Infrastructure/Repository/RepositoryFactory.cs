using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure
{
    public class RepositoryFactory<TContext, TEntity> : IRepositoryFactory<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        public IContextFactory<TContext> Context { get; }
        public IRepository<TContext, TEntity> Repository { get; }

        public RepositoryFactory(IContextFactory<TContext> context, IRepository<TContext, TEntity> repository) =>
            (Context, Repository) = (context, repository);
    }
}
