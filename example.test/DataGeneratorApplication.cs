using example.library.Services;
using example.library.Services.cache;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace example.test
{
    public class DataGeneratorApplication
    {
        ILogger logger;
        ISerilizerFactory factory;
        IDataGeneratorFactory dataGeneratorFactory;
        ISerilizerFactory serilizerFactory;
        ITimerService timerService;
        IScenarioBuilderFactory scenarioFactory;
        IScenarioConfigFactory scenarioConfigFactory;
        ICacheService cacheService;
        public DataGeneratorApplication(
                            ILogger logger,
                            ISerilizerFactory factory,
                            IDataGeneratorFactory dataGeneratorFactory,
                            ISerilizerFactory serilizerFactory,
                            ITimerService timerService,
                            IScenarioBuilderFactory scenarioFactory,
                            IScenarioConfigFactory scenarioConfigFactory,
                            ICacheService cacheService)
        {
            this.logger = logger;
            this.factory = factory;
            this.dataGeneratorFactory = dataGeneratorFactory;
            this.serilizerFactory = serilizerFactory;
            this.timerService = timerService;
            this.scenarioFactory = scenarioFactory;
            this.scenarioConfigFactory = scenarioConfigFactory;
            this.cacheService = cacheService;
        }

        public IScenarioBuilder Get(ScenarioEnum scenario)
        {
            return scenarioFactory
                .Get(scenario)
                .AddDataBuilder(dataGeneratorFactory)
                .AddSerializer(serilizerFactory)
                .AddTimer(timerService)
                .AddLogger(logger)
                .AddConfig(scenarioConfigFactory.Get(scenario))
                .AddCache(cacheService);
        }
    }
}
