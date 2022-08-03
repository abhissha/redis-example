using example.library.Services.Serializer;
using StackExchange.Redis;

namespace example.library.Services.cache
{
    public class CacheService: ICacheService
    {
        private ITimerService timerService;
        private ISerilizerFactory serilizerFactory;
        IDatabase database;
        public CacheService(ITimerService timerService, ISerilizerFactory serilizerFactory)
        {
            this.timerService = timerService;
            this.serilizerFactory = serilizerFactory;
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost:6379");
            //getting database instances of the redis  
            database = conn.GetDatabase();
        }

        public U Get<T, U>(T key)
        {
            string serializedCustomers = database.StringGet(key.ToString());
            return this.serilizerFactory.Get(SerializationType.Json).Deserialize<string, U>(serializedCustomers);
        }

        public void Set<T, U>(T key, U value)
        {
            timerService.Start();
            var serializedData = this.serilizerFactory.Get(SerializationType.Json).Serialize<U, string>(value);
            timerService.Stop("Serializing");
            timerService.Start();
            database.StringSet(key.ToString(), serializedData);
            timerService.Stop("Save in redis");
        }
    }
}
