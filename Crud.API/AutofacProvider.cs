using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Crud.Domain;
using Crud.Infrastructure;

namespace Crud.API
{
    class AutofacProvider
    {
        public static AutofacServiceProvider Provider(IServiceCollection services)
        {
            ContainerBuilder containerBuilder = Builder(services);
            IContainer container = containerBuilder.Build();
            AutofacServiceProvider serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;
        }

        private static ContainerBuilder Builder(IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterGeneric(typeof(ContextFactory<>))
                .As(typeof(IContextFactory<>));
            containerBuilder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepository<,>));
            containerBuilder.RegisterGeneric(typeof(RepositoryFactory<,>))
                .As(typeof(IRepositoryFactory<,>));
            containerBuilder.RegisterType<VisitaService>()
                .As<IVisitaService>()
                .UsingConstructor(
                    typeof(IRepositoryFactory<CrudContext, VisitaEntity>));

            return containerBuilder;
        }
    }
}
