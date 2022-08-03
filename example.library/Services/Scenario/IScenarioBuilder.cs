using example.library.Services;
using example.library.Services.cache;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;

namespace example
{
    public interface IScenarioBuilder
    {
        IScenarioBuilder AddLogger(ILogger logger);
        IScenarioBuilder AddDataBuilder(IDataGeneratorFactory dataGeneratorFactoryService);
        IScenarioBuilder AddSerializer(ISerilizerFactory serilizerFactory);
        IScenarioBuilder AddTimer(ITimerService timerService);
        IScenarioBuilder AddConfig(IScenarioConfig config);
        IScenarioBuilder AddCache(ICacheService cacheService);
        void Run();
        void GenerateData();
    }
}
