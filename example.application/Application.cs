using example.library.Services;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;

namespace example
{
    public class Application
    {
        ILogger logger;
        ISerilizerFactory factory;
        IDataGeneratorFactory dataGeneratorFactory;
        ISerilizerFactory serilizerFactory;
        ITimerService timerService;
        IScenarioBuilderFactory scenarioFactory;
        public Application( ILogger logger, 
                            ISerilizerFactory factory,
                            IDataGeneratorFactory dataGeneratorFactory,
                            ISerilizerFactory serilizerFactory,
                            ITimerService timerService,
                            IScenarioBuilderFactory scenarioFactory)
        {
            this.logger = logger;
            this.factory = factory;
            this.dataGeneratorFactory = dataGeneratorFactory;
            this.serilizerFactory = serilizerFactory;
            this.timerService = timerService;
            this.scenarioFactory = scenarioFactory;
        }

        public void Run()
        {
            this.logger.Write(Serilog.Events.LogEventLevel.Information, "List With Json Serializer Scenario Started");
            var listWithJsonSerializerScenario = scenarioFactory.Get(ScenarioEnum.ListWithJsonSerializer);
            listWithJsonSerializerScenario
                .AddDataBuilder(dataGeneratorFactory)
                .AddSerializer(serilizerFactory)
                .AddTimer(timerService)
                .AddLogger(logger)
                .Run();
            this.logger.Write(Serilog.Events.LogEventLevel.Information, "List With Json Serializer Scenario Ended");

        }
    }
}
