using Bogus;
using example.library.Model;

namespace example.library.Services.DataGenerator
{
    public class CustomerFaker: Faker<Customer>
    {
        public CustomerFaker()
        {
            var addresses = new Faker<Address>()
                .RuleFor(o => o.Line1, f => f.Address.StreetAddress())
                .RuleFor(o => o.Line2, f => f.Address.StreetAddress())
                .RuleFor(o => o.PinCode, f => f.Address.ZipCode());

            RuleFor(o => o.Id, f => f.Random.Int());
            RuleFor(o => o.FirstName, f => f.Name.FirstName());
            RuleFor(o => o.LastName, f => f.Name.LastName());
            RuleFor(o => o.Email, f => f.Internet.Email());
            RuleFor(o => o.Bio, f => f.Person.Website);
            RuleFor(o => o.Address, f => addresses.Generate());
        }
    }
}
