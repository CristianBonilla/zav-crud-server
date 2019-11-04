using System.Linq;
using System.Collections.Generic;
using Crud.Infrastructure;
using System.Threading.Tasks;

namespace Crud.Domain
{
    public class VisitaService : IVisitaService
    {
        readonly IContextFactory<CrudContext> context;
        readonly IRepository<CrudContext, VisitaEntity> repository;

        public VisitaService(IRepositoryFactory<CrudContext, VisitaEntity> repositoryFactory)
        {
            context = repositoryFactory.Context;
            repository = repositoryFactory.Repository;
        }

        public async Task<VisitaEntity> Create(VisitaEntity visita)
        {
            VisitaEntity visitaCreate = repository.Create(visita);
            _ = await context.SaveAsync();

            return visitaCreate;
        }

        public IAsyncEnumerable<VisitaEntity> Read()
        {
            var visitas = repository.Get(orderBy: o => o.OrderBy(v => v.Id).ThenBy(v => v.Nombre))
                .ToAsyncEnumerable();

            return visitas;
        }

        public async Task<VisitaEntity> Update(VisitaEntity visita)
        {
            VisitaEntity visitaUpdate = repository.Update(visita);
            _ = await context.SaveAsync();

            return visitaUpdate;
        }

        public async Task<VisitaEntity> Delete(VisitaEntity visita)
        {
            VisitaEntity visitaDelete = repository.Delete(visita);
            _ = await context.SaveAsync();

            return visitaDelete;
        }

        public async Task<VisitaEntity> Find(int idVisita)
        {
            VisitaEntity visitaFind = repository.Find(idVisita);

            return await Task.FromResult(visitaFind);
        }
    }
}
