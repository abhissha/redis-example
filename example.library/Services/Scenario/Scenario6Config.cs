using example.library.Services.Scenario;

namespace example
{
    public class Scenario6Config : ScenarioConfigBase
    {
        public Scenario6Config()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario6_{0}";
        }
    }
}
