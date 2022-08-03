using example.library.Services;
using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using Serilog;

namespace example
{
    public interface IScenarioConfig
    {
        int BatchSize { get; set; }
        int TotalNumberOfElements { get; set; }        
        string KeyNamePattern { get; set; }
        int GetNumberOfBatch();
    }
}
