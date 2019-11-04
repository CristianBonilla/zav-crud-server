using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure
{
    public interface IRepository<in TContext, TEntity>
        where TContext : DbContext
        where TEntity : class 
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> CreateAll(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> DeleteAll(IEnumerable<TEntity> entities);
        TEntity Find(params object[] keyValues);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        bool Exists(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
