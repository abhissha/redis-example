using System;

namespace example.library.Services.DataGenerator
{
    public class DataGeneratorFactory : IDataGeneratorFactory
    {
        private Func<DataGeneratorTypeEnum, IDataGeneratorService> factory;

        public DataGeneratorFactory(Func<DataGeneratorTypeEnum, IDataGeneratorService> factory)
        {
            this.factory = factory;
        }

        public IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType)
        {
            return factory(dataGeneratorType);
        }
    }
}
