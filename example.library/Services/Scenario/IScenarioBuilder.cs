using example.library.Services;
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
        void Run();
    }
}
