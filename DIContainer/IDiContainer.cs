namespace example.DIContainer
{
    public interface IDiContainer
    {
        void Register();
        T Get<T>();

        T Get<T>(object key);
    }
}
