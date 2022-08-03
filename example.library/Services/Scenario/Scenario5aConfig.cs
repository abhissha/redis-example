using example.library.Services.Scenario;

namespace example
{
    public class Scenario5aConfig : ScenarioConfigBase
    {
        public Scenario5aConfig()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario5a_{0}";
        }
    }
}
