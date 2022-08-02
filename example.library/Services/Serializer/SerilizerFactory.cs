using System;

namespace example.library.Services.Serializer
{
    public class SerilizerFactory : ISerilizerFactory
    {
        private Func<SerializationType, ISerializerService> _serializer;

        public SerilizerFactory(Func<SerializationType, ISerializerService> serializer)
        {
            _serializer = serializer;
        }

        public ISerializerService Get(SerializationType serType)
        {
            return _serializer(serType);
        }
    }
}
