namespace example.library.Services
{
    public interface ITimerService
    {
        void Start();
        void Stop(string messageTemplate);
        void Reset();
        bool IsRunning();
    }
}
