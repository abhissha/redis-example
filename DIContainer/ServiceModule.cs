using Autofac;
using System;

namespace example.DIContainer
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder
                    .RegisterAssemblyTypes(
                        typeof(DiContaner).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
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
