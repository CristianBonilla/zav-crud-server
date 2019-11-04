using Autofac;
using Crud.Domain;
using Crud.Infrastructure;

namespace Crud.API
{
    public class VisitaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ContextFactory<>))
                .As(typeof(IContextFactory<>));
            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>));
            builder.RegisterGeneric(typeof(RepositoryFactory<,>))
                .As(typeof(IRepositoryFactory<,>));
            builder.RegisterType<VisitaService>()
                .As<IVisitaService>()
                .UsingConstructor(
                    typeof(IRepositoryFactory<CrudContext, VisitaEntity>));
        }
    }
}
