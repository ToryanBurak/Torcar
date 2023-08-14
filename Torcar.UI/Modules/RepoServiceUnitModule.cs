using Autofac;
using System.Reflection;
using Torcar.CORE.Entity;
using Torcar.CORE.Repositories;
using Torcar.CORE.Service;
using Torcar.CORE.UnitOfWork;
using Torcar.REPOSITORY;
using Torcar.REPOSITORY.Repository;
using Torcar.REPOSITORY.UnitOfWork;
using Torcar.SERVICE.Mapping;
using Torcar.SERVICE.Service;

namespace Torcar.UI.Modules
{
    public class RepoServiceUnitModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            var CoreAssembly = Assembly.GetAssembly(typeof(User));
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            builder.RegisterAssemblyTypes(CoreAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(CoreAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
