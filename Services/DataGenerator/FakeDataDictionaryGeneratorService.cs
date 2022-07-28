using Bogus;
using System;
using System.Collections.Generic;

namespace example.Services.DataGenerator
{
    public class FakeDataDictionaryGeneratorService : IDataGeneratorService
    {
        public U Generate<T, U>(int numberOfDataToGenerate) where T : class
        {
            var data = new Dictionary<string, Dictionary<string, List<T>>>();
            for (int i = 1; i <= numberOfDataToGenerate; i++)
            {
                data.Add(Guid.NewGuid().ToString(), new Dictionary<string, List<T>>()
                {
                    { i.ToString(), new Faker<T>().Generate(numberOfDataToGenerate) }
                });
            }
            return (U)Convert.ChangeType(new Faker<T>().Generate(numberOfDataToGenerate), typeof(U));
        }
    }

}
