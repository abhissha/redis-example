using example.library.Services.MediaTr;
using MediatR;
using Serilog;

namespace example
{
    public class MediaTrApplication
    {
        ILogger logger;
        IMediator mediator;
        
        public MediaTrApplication(IMediator mediator, ILogger logger)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public void Run()
        {
            var result = this.mediator.Send(new PingCommand()).GetAwaiter().GetResult();
            //var resultTask = Task.Run(() => this.mediator.Send(new PingCommand()));
            //var abc = resultTask.Result;
            this.logger.Write(Serilog.Events.LogEventLevel.Information, "List With Json Serializer Scenario Ended");

        }
    }
}
