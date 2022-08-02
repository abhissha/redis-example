using System;

namespace example
{
    public class ScenarioBuilderFactory : IScenarioBuilderFactory
    {
        Func<ScenarioEnum, IScenarioBuilder> scenarioFactory;

        public ScenarioBuilderFactory(Func<ScenarioEnum, IScenarioBuilder> scenarioFactory)
        {
            this.scenarioFactory = scenarioFactory;
        }

        public IScenarioBuilder Get(ScenarioEnum scenario)
        {
            return scenarioFactory(scenario);
        }
    }
}
