using example.DIContainer;

namespace example.Services.DataGenerator
{
    public class DataGeneratorFactoryService : IDataGeneratorFactoryService
    {
        public IDiContainer Container { get; }

        public DataGeneratorFactoryService(IDiContainer container)
        {
            Container = container;
        }

        public IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType)
        {
            return Container.Get<IDataGeneratorService>(dataGeneratorType);
        }
    }
}
