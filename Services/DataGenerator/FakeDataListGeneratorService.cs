using Bogus;
using System;

namespace example.Services.DataGenerator
{
    public class FakeDataListGeneratorService : IDataGeneratorService
    {
        public U Generate<T, U>(int numberOfDataToGenerate) where T : class
        {
            return (U)Convert.ChangeType(new Faker<T>().Generate(numberOfDataToGenerate), typeof(U));
        }
    }

}
