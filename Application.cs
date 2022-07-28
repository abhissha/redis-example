using ProtoBuf;
using Serilog;
using System;

namespace example
{
    public class Application
    {
        ILogger logger;
        public Application(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            this.logger.Write(Serilog.Events.LogEventLevel.Information, "Application Started");
        }
    }
}
