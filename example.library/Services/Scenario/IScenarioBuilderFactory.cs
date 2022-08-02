namespace example
{
    public interface IScenarioBuilderFactory
    {
        IScenarioBuilder Get(ScenarioEnum scenario);
    }
}
