namespace example.library.Services.Serializer
{
    public interface ISerilizerFactory
    {
        ISerializerService Get(SerializationType serType);
    }
}
