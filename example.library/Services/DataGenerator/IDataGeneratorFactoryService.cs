namespace example.library.Services.DataGenerator
{
    public interface IDataGeneratorFactoryService
    {
        IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType);
    }
}
