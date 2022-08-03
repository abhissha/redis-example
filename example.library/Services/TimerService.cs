using Serilog;
using System.Diagnostics;

namespace example.library.Services
{
    public class TimerService : ITimerService
    {
        private ILogger logger;
        private Stopwatch stopWatch;
        public TimerService(ILogger logger)
        {
            this.logger = logger;
        }

        public bool IsRunning()
        {
            return stopWatch != null;
        }

        public void Reset()
        {
            stopWatch = null;
        }

        public void Start()
        {
            stopWatch = Stopwatch.StartNew();
        }

        public void Stop(string messageTemplate)
        {
            stopWatch.Stop();
            logger.Information($"{messageTemplate}. Total Execution Time: {stopWatch.ElapsedMilliseconds} ms");
        }
    }    
}
