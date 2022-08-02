using example.library.Services;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;

namespace example
{
    public abstract class ScenarioBuilder
    {
        protected IDataGeneratorFactory dataGeneratorFactoryService;
        protected ILogger logger;
        protected ISerilizerFactory serilizerFactory;
        protected ITimerService timerService;

        public IScenarioBuilder AddDataBuilder(IDataGeneratorFactory dataGeneratorFactoryService)
        {
            this.dataGeneratorFactoryService = dataGeneratorFactoryService;
            return (IScenarioBuilder)this;
        }

        public IScenarioBuilder AddLogger(ILogger logger)
        {
            this.logger = logger;
            return (IScenarioBuilder)this;
        }

        public IScenarioBuilder AddSerializer(ISerilizerFactory serilizerFactory)
        {
            this.serilizerFactory = serilizerFactory;
            return (IScenarioBuilder)this;
        }

        public IScenarioBuilder AddTimer(ITimerService timerService)
        {
            this.timerService = timerService;
            return (IScenarioBuilder)this;
        }
    }
}
