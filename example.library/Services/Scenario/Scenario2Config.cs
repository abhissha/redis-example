using example.library.Services.Scenario;

namespace example
{
    public class Scenario2Config : ScenarioConfigBase
    {
        public Scenario2Config()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario2_{0}";
        }
    }
}
