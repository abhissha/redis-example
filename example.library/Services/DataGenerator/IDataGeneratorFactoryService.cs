using System.Collections.Generic;

namespace example.library.Services.DataGenerator
{
    public interface IDataGeneratorFactoryService
    {
        IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType);        
    }
}
