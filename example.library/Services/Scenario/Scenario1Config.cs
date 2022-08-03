using example.library.Services.Scenario;

namespace example
{
    public class Scenario1Config : ScenarioConfigBase
    {
        public Scenario1Config()
        {
            this._batchSize = 1000000;
            this._totalNumberOfElements = 1000000;
            this._keyNamePattern = $"Scenario1_{0}";
        }
        
    }
}
