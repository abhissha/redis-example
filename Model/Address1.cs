using ProtoBuf;

namespace example.Model
{
    [ProtoContract]
    public class Address1
    {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
        [ProtoMember(3)]
        public string PinCode { get; set; }
    }
}
