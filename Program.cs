using Bogus;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //setting up connection to the redis server  
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379");
            //getting database instances of the redis  
            IDatabase database = conn.GetDatabase();
            for(int i = 10000; i <= 100000; i++)
            {
                //Timer.Start();
                var values = CustomerGenerator.Create(i);
                //Timer.Stop();
                Console.WriteLine($"Size: {i.ToString()}");
                Timer.Start();
                string serializedValue = JsonSerializer.Serialize<List<Customer>>(values);
                database.StringSet(i.ToString(), serializedValue);
                string employees = database.StringGet(i.ToString());
                var deserializedValue = JsonSerializer.Deserialize<List<Customer>>(employees);
                Timer.Stop();
            }
            //set value in redis server  
            //database.StringSet("redisKey", "redisvalue");
            //get value from redis server  
            //var value = database.StringGet("redisKey");
            //Console.WriteLine("Value cached in redis server is: " + value);
            Console.ReadLine();
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PinCode { get; set; }
    }
    public static class Timer
    {
        public static DateTime StartTime { get; set; }
        public static long StartMemory { get; set; }
        public static DateTime StopTime { get; set; }
        public static long EndMemory { get; set; }
        public static void Start()
        {
            StartTime = DateTime.Now;
            StartMemory=GC.GetTotalMemory(true);
        }

        public static void Stop()
        {
            StopTime = DateTime.Now;
            EndMemory = GC.GetTotalMemory(true);
            TimeSpan diff = StopTime - StartTime;
            Console.WriteLine($"{diff.TotalMilliseconds} ms: {diff.TotalSeconds} s: {diff.Seconds} m: {diff.Minutes}");
            //Console.WriteLine($"{diff.TotalMilliseconds} ms: {diff.TotalSeconds} s: {diff.Seconds} m: {diff.Minutes}");
        }

        public static void Print()
        {
            TimeSpan diff = StopTime - StartTime;
            Console.WriteLine($"{diff.TotalMilliseconds} ms: {diff.TotalSeconds} s: {diff.Seconds} m: {diff.Minutes}");
        }
    }

    public class CustomerGenerator
    {
        public static List<Customer> Create(int number)
        {
            var abc = new Faker<Customer>();
            return abc.Generate(number);
        }
    }

    public class EmployeeGenerator
    {
        public static List<Employee> Create(int number)
        {
            var returnList = new List<Employee>();
            for(int i = 0; i < number; i++)
            {
                returnList.Add(
                    new Employee() { 
                        Age = i + 1, 
                        Name = $"{i.ToString()} - Name" });
            }
            return returnList;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
