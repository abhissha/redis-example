using example.library.Services.Scenario;

namespace example
{
    public class Scenario5bConfig : ScenarioConfigBase
    {
        public Scenario5bConfig()
        {
            this._batchSize = 100000;
            this._totalNumberOfElements = 100000;
            this._keyNamePattern = $"Scenario5b_{0}";
        }
    }
}
