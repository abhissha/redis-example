namespace example.library.Services.Serializer
{
    public interface ISerializerService
    {
        U Serialize<T, U>(T obj);

        U Deserialize<T, U>(T str);
    }
}
