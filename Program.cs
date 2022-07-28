using Autofac;
using Bogus;
using example.DIContainer;
using example.Model;
using example.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace example
{
    internal class Program
    {
        public static IDiContainer container = new DiContaner();
        static void Main(string[] args)
        {
            container.Register();
            container.Get<Application>().Run();
        }

        static void Test()
        {
            //setting up connection to the redis server  
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379");
            //getting database instances of the redis  
            IDatabase database = conn.GetDatabase();
            var factory = new SerilizerFactory();
            var jsonSerializer = factory.Get(SerializationType.Json);
            var protoSerializer = factory.Get(SerializationType.proto);
            for (int i = 5; i <= 50; i++)
            {
                SerializeDeserialize<Customer, string>(i, database, jsonSerializer);
                SerializeDeserialize<Customer1, string>(i, database, protoSerializer);

            }
            Console.ReadLine();
        }

        static void SerializeDeserialize<T,U>(int i,IDatabase database, ISerializer serializer) where T: class
        {
            //Timer.Start();
            List<T> values = DataGenerator.Create<T>(i);
            //Timer.Stop();
            Console.WriteLine($"Size: {i.ToString()}");
            TimerService.Start();
            var serializedValue = serializer.Serialize<List<T>,U>(values);
            database.StringSet(i.ToString(), serializedValue.ToString());
            string employees = database.StringGet(i.ToString());
            var deserializedValue = serializer.Deserialize<List<T>>(employees);
            TimerService.Stop();
        }
    }

    public interface ISerializer
    {
        U Serialize<T, U>(T obj);

        T Deserialize<T>(string str);
    }

    public class JsonSerializerService : ISerializer
    {
        public T Deserialize<T>(string str)
        {
            return JsonSerializer.Deserialize<T>(str);
        }

        public U Serialize<T, U>(T obj)
        {            
            return (U)Convert.ChangeType(JsonSerializer.Serialize(obj), typeof(U));
        }
    }

    public class ProtoSerializtionService : ISerializer
    {
        public T Deserialize<T>(string str)
        {
            return JsonSerializer.Deserialize<T>(str);
        }

        public U Serialize<T, U>(T obj)
        {
            return (U)Convert.ChangeType(JsonSerializer.Serialize(obj), typeof(U));
        }
    }


    public class SerilizerFactory
    {
        public ISerializer Get(SerializationType serType)
        {
            switch(serType){
                case SerializationType.Json:
                    return new JsonSerializerService();
                    break;
                case SerializationType.proto:
                    return new ProtoSerializtionService();
                    break;
                default:
                    throw new ArgumentException("not ");
                    break;
            }
        }
    }
    public enum SerializationType
    {
        Json,
        proto
    }

    public class DataGenerator
    {
        public static List<T> Create<T>(int number) where T: class
        {
            var abc = new Faker<T>();
            return abc.Generate(number);
        }
    }
}
