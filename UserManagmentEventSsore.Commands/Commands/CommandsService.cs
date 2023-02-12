using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User.Repositories;
using UserManagment.Domain.User;

namespace UserManagmentEventSsore.Commands.Commands
{
    public class CommandsService:ICommandsService
    {
        private readonly IUserRepository _userRepository;
        public CommandsService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserId CreateUser(string firstName, string lastName)
        {
            var user = User.CreateNewUser(firstName, lastName);
            var uid = _userRepository.SaveUser(user);
            return uid;
        }

        public void UpdateUserAddress(UserId userId, string city, string country, string street, string zipcode)
        {
            var user = _userRepository.GetUser(userId.ToString());

            if (user == null) return;

            user.ChangeUserAddress(street, country, zipcode, city);
            _userRepository.SaveUser(user);
        }
    }
}
