using System;
using System.Text.Json;

namespace example.library.Services.Serializer
{
    public class JsonSerializerService : ISerializerService
    {
        public U Deserialize<T, U>(T str)
        {
            return (U)Convert.ChangeType(JsonSerializer.Deserialize<T>(str.ToString()), typeof(U));
        }

        public U Serialize<T, U>(T obj)
        {
            return (U)Convert.ChangeType(JsonSerializer.Serialize(obj), typeof(U));
        }
    }
}
