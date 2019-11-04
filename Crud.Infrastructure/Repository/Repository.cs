using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Crud.Infrastructure
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        readonly DbSet<TEntity> entitySet;
        readonly Func<TEntity, EntityEntry<TEntity>> entityEntry;

        public Repository(IContextFactory<TContext> context)
        {
            entitySet = context.EntitySet<TEntity>();
            entityEntry = e => context.EntityEntry(e);
        }

        public TEntity Create(TEntity entity)
        {
            var setEntity = entitySet.Add(entity);
            TEntity createEntity = setEntity.Entity;

            return createEntity;
        }

        public IEnumerable<TEntity> CreateAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Create(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var entry = entityEntry(entity);
            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            entry.State = EntityState.Modified;
            TEntity updateEntity = entry.Entity;

            return updateEntity;
        }

        public IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Update(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            var entry = entityEntry(entity);
            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            entry.State = EntityState.Deleted;
            TEntity deleteEntity = entry.Entity;

            return deleteEntity;
        }

        public IEnumerable<TEntity> DeleteAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Delete(entity);
        }

        public TEntity Find(params object[] keyValues) => entitySet.Find(keyValues);

        public TEntity Find(Expression<Func<TEntity, bool>> expression) => entitySet.FirstOrDefault(expression);

        public bool Exists(Expression<Func<TEntity, bool>> expression) => entitySet.Any(expression);

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var setQuery = entitySet.AsQueryable();
            if (filter != null)
                setQuery = setQuery.Where(filter);
            foreach (var expression in includes)
                setQuery = setQuery.Include(expression);
            var queryableEntity = orderBy != null ? orderBy(setQuery) : setQuery;

            return queryableEntity;
        }
    }
}
