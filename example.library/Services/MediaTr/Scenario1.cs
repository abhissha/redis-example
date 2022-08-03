using example.library.Services.DataGenerator;
using example.library.Services.Serializer;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example.library.Services.MediaTr
{
    public class Scenario1Result
    {
    }

    public class Scenario1Command: IRequest<Scenario1Result> { }

    public class Scenario1CommandHandler : IRequestHandler<Scenario1Command, Scenario1Result>
    {
        ILogger logger;
        ISerilizerFactory factory;
        IDataGeneratorFactory dataGeneratorFactory;
        ISerilizerFactory serilizerFactory;
        ITimerService timerService;
        IScenarioBuilderFactory scenarioFactory;
        IScenarioConfigFactory scenarioConfigFactory;
        public Scenario1CommandHandler(
                            ILogger logger,
                            ISerilizerFactory factory,
                            IDataGeneratorFactory dataGeneratorFactory,
                            ISerilizerFactory serilizerFactory,
                            ITimerService timerService,
                            IScenarioBuilderFactory scenarioFactory,
                            IScenarioConfigFactory scenarioConfigFactory)
        {
            this.logger = logger;
            this.factory = factory;
            this.dataGeneratorFactory = dataGeneratorFactory;
            this.serilizerFactory = serilizerFactory;
            this.timerService = timerService;
            this.scenarioFactory = scenarioFactory;
            this.scenarioConfigFactory = scenarioConfigFactory;
        }
        public Task<Scenario1Result> Handle(Scenario1Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
