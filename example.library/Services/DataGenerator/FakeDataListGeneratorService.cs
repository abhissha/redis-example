using Bogus;
using example.library.Model;
using System;
using System.Collections.Generic;

namespace example.library.Services.DataGenerator
{
    public class FakeDataListGeneratorService : IDataGeneratorService
    {
        public U Generate<T, U>(int numberOfDataToGenerate) where T : class
        {
            return typeof(T) == typeof(Customer) ? 
                (U)Convert.ChangeType(new CustomerFaker().Generate(numberOfDataToGenerate), typeof(List<T>)) : 
                (U)Convert.ChangeType(new Faker<T>().Generate(numberOfDataToGenerate), typeof(U));
        }
    }

}
