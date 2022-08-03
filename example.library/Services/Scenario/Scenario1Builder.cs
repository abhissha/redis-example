using example.library.Model;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using StackExchange.Redis;
using System.Collections.Generic;

namespace example
{
    public class Scenario1Builder : ScenarioBuilder, IScenarioBuilder
    {
        public void Run()
        {
            
            var fakeDataFactory = this.dataGeneratorFactory.Get(DataGeneratorTypeEnum.List);
            
            var serializer = this.serilizerFactory.Get(SerializationType.Json);            
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379");
            //getting database instances of the redis  
            IDatabase database = conn.GetDatabase();

            int numberToStartFrom = 1;
            int numberOfData = 100;
            for (int i = numberToStartFrom; i <= numberOfData; i++)
            {

                var fakeData = fakeDataFactory.Generate<Customer, List<Customer>>(100);
                var serializedValue = serializer.Serialize<List<Customer>, string>(fakeData);
                database.StringSet(i.ToString(), serializedValue.ToString());
                this.timerService.Start();
                string serializedCustomers = database.StringGet(i.ToString());
                var deserializedValue = serializer.Deserialize<string,List<Customer>>(serializedCustomers);
                this.timerService.Stop("Deserilization Time:");
            }
        }
    }
}
