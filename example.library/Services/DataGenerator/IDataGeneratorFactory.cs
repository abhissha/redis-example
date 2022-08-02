namespace example.library.Services.DataGenerator
{
    public interface IDataGeneratorFactory
    {
        IDataGeneratorService Get(DataGeneratorTypeEnum dataGeneratorType);
    }
}
