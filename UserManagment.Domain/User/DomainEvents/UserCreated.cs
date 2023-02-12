using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.User.DomainEvents
{
    public class UserCreated:DomainEvent
    {
        public string UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public UserCreated(
            string userId,
            string firstName,
            string lastName) : base(userId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
