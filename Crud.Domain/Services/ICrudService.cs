using System.Threading.Tasks;
using System.Collections.Generic;

namespace Crud.Domain
{
    public interface ICrudService<TKey, TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        IEnumerable<TEntity> Read();
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        TEntity Find(TKey id);
    }
}
