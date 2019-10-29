using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Crud.Infrastructure;

namespace Crud.Domain
{
    public class VisitaService : IVisitaService
    {
        readonly IContextFactory<CrudContext> context;
        readonly IRepository<CrudContext, VisitaEntity> repository;

        public VisitaService(IRepositoryFactory<CrudContext, VisitaEntity> repositoryBase)
        {
            context = repositoryBase.Context;
            repository = repositoryBase.Repository;
        }

        public async Task<VisitaEntity> Create(VisitaEntity visita)
        {
            VisitaEntity visitaCreate = repository.Create(visita);
            _ = await context.SaveAsync();

            return visitaCreate;
        }

        public IEnumerable<VisitaEntity> Read()
        {
            var visitasReaded = repository.Get(orderBy: o => o.OrderBy(v => v.Id).ThenBy(v => v.Nombre));

            return visitasReaded;
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

        public VisitaEntity Find(int idVisita)
        {
            VisitaEntity visitaFind = repository.Find(idVisita);

            return visitaFind;
        }
    }
}
