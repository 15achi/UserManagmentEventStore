using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User;
using UserManagment.Domain.User.Repositories;

namespace UserManagment.Infrastructure.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly IEventStore _eventStore;
        public UserRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public User GetUser(string id)
        {
            var userId = new UserId(id);
            var userEvents = _eventStore.Load(userId);

            return userEvents.Count > 0 ? new User(userEvents) : null;
        }

        public UserId SaveUser(User user)
        {
            _eventStore.Save(user.Id, user.Version, user.DomainEvents);
            return user.Id;
        }
    }
}
