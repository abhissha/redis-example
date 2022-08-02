using Autofac;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using System;

namespace example.DIContainer
{
    public static class DiContaner
    {
        private static ContainerBuilder builder = new ContainerBuilder();

        public static void AddRegistration<T>()
        {
            builder.RegisterType<T>();
        }

        public static IContainer Register()
        {
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new FactoryModule());
            builder.RegisterModule(new LoggerModule());
            //builder.RegisterType<Application>();
            //builder.RegisterType<MediaTrApplication>();

            //builder.RegisterMediatR(typeof(Program).Assembly);
            builder.Register<IDataGeneratorService>((c, p) =>
            {
                var type = p.TypedAs<DataGeneratorTypeEnum>();
                switch (type)
                {
                    case DataGeneratorTypeEnum.List:
                        return new FakeDataListGeneratorService();
                    case DataGeneratorTypeEnum.Dictionary:
                        return new FakeDataDictionaryGeneratorService();
                    default:
                        throw new ArgumentException("Invalid Data Generator Type");
                }
            });
            builder.Register<ISerializerService>((c, p) =>
            {
                var type = p.TypedAs<SerializationType>();
                switch (type)
                {
                    case SerializationType.Json:
                        return new JsonSerializerService();
                    case SerializationType.proto:
                        return new ProtoSerializtionService();
                    default:
                        throw new ArgumentException("Invalid Serializer type");
                }
            })
                .As<ISerializerService>();
            builder.Register<IScenarioBuilder>((c, p) =>
            {
                var type = p.TypedAs<ScenarioEnum>();
                switch (type)
                {
                    case ScenarioEnum.ListWithJsonSerializer:
                        return new ListWithJsonSerializerScenarioBuilder();
                    default:
                        throw new ArgumentException("Invalid Serializer type");
                }
            })
            .As<IScenarioBuilder>();
            return builder.Build();
        }
    }
}
