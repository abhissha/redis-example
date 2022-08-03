using Bogus;
using example.library.Model;
using System;
using System.Collections.Generic;

namespace example.library.Services.DataGenerator
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
                    { i.ToString(), typeof(T)==typeof(Customer) ? ((List<T>)Convert.ChangeType(new CustomerFaker().Generate(i), typeof(List<T>))) : (new Faker<T>().Generate(numberOfDataToGenerate)) }
                });
            }
            return (U)Convert.ChangeType(data, typeof(U));
        }
    }
}
