namespace example
{
    public interface IScenarioConfigFactory
    {
        IScenarioConfig Get(ScenarioEnum scenario);
    }
}
