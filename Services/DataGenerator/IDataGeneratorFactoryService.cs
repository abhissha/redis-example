namespace example.Services.DataGenerator
{
    public interface IDataGeneratorFactoryService
    {
        IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType);
    }
}
