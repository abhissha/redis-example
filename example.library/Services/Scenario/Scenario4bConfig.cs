using example.library.Services.Scenario;

namespace example
{
    public class Scenario4bConfig : ScenarioConfigBase
    {
        public Scenario4bConfig()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario2_{0}";
        }
    }
}
