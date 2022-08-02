using Autofac;
using System;

namespace example.DIContainer
{
    public class FactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder
                    .RegisterAssemblyTypes(
                        typeof(example.library.Model.Address).Assembly)
                    .Where(t => t.Name.EndsWith("Factory"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
