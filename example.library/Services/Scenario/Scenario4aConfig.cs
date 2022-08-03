using example.library.Services.Scenario;

namespace example
{
    public class Scenario4aConfig : ScenarioConfigBase
    {
        public Scenario4aConfig()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario4_{0}";
        }
    }
}
