namespace example.Services.DataGenerator
{
    public interface IDataGeneratorService
    {
        U Generate<T, U>(int numberOfDataToGenerate) where T : class;
    }

}
