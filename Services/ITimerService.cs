namespace example.Services
{
    public interface ITimerService
    {
        void Start();
        void Stop();
        void Reset();
        bool IsRunning();
    }
}
