using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User.DomainEvents;

namespace UserManagment.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        public override UserId Id { get; protected set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address UserAddress { get; private set; }

        public User(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private User()
        {

        }

        public static User CreateNewUser(
            string firstName,
            string lastName)
        {

            var user = new User();
            user.Apply(new UserCreated(new UserId().ToString(),
                firstName, lastName));

            return user;
        }

        public void ChangeUserAddress(string street, string country, string zipCode, string city)
        {
            Apply(new AddressChanged(city, country, zipCode, street, Id.ToString()));
        }

        public void On(UserCreated @event)
        {
            Id = new UserId(@event.UserId);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void On(AddressChanged @event)
        {
            UserAddress = new Address()
            {
                City = @event.City,
                Country = @event.Country,
                Street = @event.Street,
                ZipCode = @event.ZipCode
            };
        }
    }
}

