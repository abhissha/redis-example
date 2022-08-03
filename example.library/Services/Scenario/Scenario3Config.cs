using example.library.Services.Scenario;

namespace example
{
    public class Scenario3Config : ScenarioConfigBase
    {
        public Scenario3Config()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario3_{0}";
        }
    }
}
