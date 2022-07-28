using ProtoBuf;

namespace example.Model
{
    [ProtoContract]
    public class Customer1
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string FirstName { get; set; }
        [ProtoMember(3)]
        public string LastName { get; set; }
        [ProtoMember(4)]
        public string Email { get; set; }
        [ProtoMember(5)]
        public string Bio { get; set; }
        [ProtoMember(6)]
        public Address1 Address { get; set; }
    }
}
