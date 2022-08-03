using example.library.Model;
using example.library.Services;
using example.library.Services.cache;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;
using System.Collections.Generic;

namespace example
{
    public abstract class ScenarioBuilder
    {
        protected IDataGeneratorFactory dataGeneratorFactory;
        protected ILogger logger;
        protected ISerilizerFactory serilizerFactory;
        protected ITimerService timerService;
        protected IScenarioConfig scenarioConfig;
        protected ICacheService cacheService;

        public IScenarioBuilder AddDataBuilder(IDataGeneratorFactory dataGeneratorFactory)
        {
            this.dataGeneratorFactory = dataGeneratorFactory;
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

        public IScenarioBuilder AddConfig(IScenarioConfig scenarioConfig)
        {
            this.scenarioConfig = scenarioConfig;
            return (IScenarioBuilder)this;
        }

        public IScenarioBuilder AddCache(ICacheService cacheService)
        {
            this.cacheService = cacheService;
            return (IScenarioBuilder)this;
        }

        public void GenerateData()
        {
            int numberToStartFrom = 1;
            for (int i = numberToStartFrom; i <= this.scenarioConfig.GetNumberOfBatch(); i++)
            {

                var fakeData = dataGeneratorFactory.Get(DataGeneratorTypeEnum.List).Generate<Customer, List<Customer>>(this.scenarioConfig.BatchSize);
                this.cacheService.Set(string.Format(this.scenarioConfig.KeyNamePattern, i.ToString()), fakeData);
            }
        }
    }
}
