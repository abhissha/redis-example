using Autofac;

namespace example.DIContainer
{
    public class DiContaner : IDiContainer
    {
        static IContainer container;
        public T Get<T>()
        {
            return container.Resolve<T>();
        }

        public T Get<T>(object key)
        {
            return container.ResolveKeyed<T>(key);
        }

        public void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new LoggerModule());
            builder.RegisterType<DiContaner>().As<IDiContainer>().SingleInstance();
            builder.RegisterType<Application>();
            container = builder.Build();
        }
    }
}
