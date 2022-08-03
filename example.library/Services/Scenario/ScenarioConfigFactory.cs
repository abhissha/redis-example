using System;

namespace example
{
    public class ScenarioConfigFactory : IScenarioConfigFactory
    {
        private Func<ScenarioEnum, IScenarioConfig> factory;

        public ScenarioConfigFactory(Func<ScenarioEnum, IScenarioConfig> factory)
        {
            this.factory = factory;
        }
        public IScenarioConfig Get(ScenarioEnum scenario)
        {
            return this.factory(scenario);
        }
    }
}
