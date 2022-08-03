using System;
using System.Collections.Generic;
using System.Text;

namespace example.library.Services.Scenario
{
    public abstract class ScenarioConfigBase: IScenarioConfig
    {
        protected int _batchSize;
        public int BatchSize
        {
            get => _batchSize;
            set => _batchSize = value;
        }

        protected int _totalNumberOfElements;
        public int TotalNumberOfElements
        {
            get => _totalNumberOfElements; set => _totalNumberOfElements = value;
        }

        protected string _keyNamePattern;
        public string KeyNamePattern
        {
            get => _keyNamePattern;
            set => _keyNamePattern = value;
        }

        public int GetNumberOfBatch()
        {
            return TotalNumberOfElements / BatchSize;
        }
    }
}
